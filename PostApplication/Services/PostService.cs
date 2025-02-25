using PostApplication.CommunicateServices;
using PostApplication.Interfaces;
using PostApplication.ViewModel.MediaViewModel;
using PostApplication.ViewModel.PostViewModel;
using PostCore.Entities;
using PostCore.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostApplication.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IReactionRepository _reactionRepository;
        private readonly IGenericRepository<Posts> _genericRepository;
        private readonly IPostUserServices _userPostServices;
        private readonly IStorageService _storage;

        public PostService(IPostRepository postRepository, ICommentRepository commentRepository, IMediaRepository mediaRepository, IReactionRepository reactionRepository, IGenericRepository<Posts> genericRepository, IPostUserServices userPostServices, IStorageService storage)
        {
            _postRepository=postRepository;
            _commentRepository=commentRepository;
            _mediaRepository=mediaRepository;
            _reactionRepository=reactionRepository;
            _genericRepository=genericRepository;
            _userPostServices=userPostServices;
            _storage=storage;
        }

        public async Task<int> Create(CreatePostViewModel request)
        {
            Posts newPost = new Posts()
            {
                Id=request.Id,
                Content = request.Content,
                AccountName = request.AccountName,
                Privacy = request.Privacy,
                TopicPosts = request.listTopic.Select(x => new TopicPost
                {
                    PostId=request.Id,
                    TopicId=x,
                }).ToList(),
            };
            Posts result = await _genericRepository.Create(newPost);
            var resultmedia = 0;
            if (result!=null && request.Medias.Any())
            {
                var medias = request.Medias.Select(async x =>
                {
                    string fileName = x.file.FileName;
                    string fileExtension = Path.GetExtension(fileName);
                    await _storage.SaveFileAsync(x.file.OpenReadStream(), x.Id+fileExtension, 0);
                    return new Media
                    {
                        Id= x.Id,
                        ParentId= request.Id,
                        Width= x.Width,
                        Height= x.Height,
                        MediaName= x.MediaName,
                        Url= x.Id+fileExtension,
                        MediaType= x.MediaType,
                    };
                }
                );

                resultmedia = await _mediaRepository.CreateMedia((await Task.WhenAll(medias)).ToList());
            }
            if (!request.Medias.Any() && result!=null) return 2;
            if (resultmedia==1 &&result!=null)
                return 1;
            return 0;
        }

        public async Task<List<PostViewModel>> GetListByAccountName(string accountName)
        {
            var result = await _postRepository.GetByAccountName(accountName);
            if (result == null) return new List<PostViewModel>(); // Trả về danh sách rỗng nếu không có bài viết

            var tasks = result.Select(async x =>
            {
                var like = new LikeViewModel
                {
                    AccountName = accountName,
                    IsLiked = await _reactionRepository.FindUserReaction(x.Id, accountName),
                    Count = await _reactionRepository.CountReaction(x.Id)
                };

                var countComment = await _commentRepository.CounComment(x.Id); // Gọi trước để tránh gọi lại
                var media = await _mediaRepository.GetAllbyParentId(x.Id);
                return new PostViewModel
                {
                    Id = x.Id,
                    Content = x.Content,
                    TimePost= x.CreatedAt,
                    CountRetweet = 0,
                    CountSend = 0,
                    CountComment = countComment,
                    Like = like,
                    Media = media
                };
            });

            return (await Task.WhenAll(tasks)).ToList();
        }

        public async Task<List<PostViewModel>> GetListForHomePage(string accountName, int numberPost)
        {
            var query = await _postRepository.GetPrioritizedPosts(accountName, numberPost);

            var result = query.Select(async x =>
            {
                var like = new LikeViewModel
                {
                    AccountName = accountName,
                    IsLiked = await _reactionRepository.FindUserReaction(x.Id, accountName),
                    Count = await _reactionRepository.CountReaction(x.Id)
                };
                var countComment = await _commentRepository.CounComment(x.Id); // Gọi trước để tránh gọi lại
                var media = await _mediaRepository.GetAllbyParentId(x.Id);
                var user = await _userPostServices.GetInformationbyAccountnameForPost(x.AccountName);
                return new PostViewModel()
                {
                    Id= x.Id,
                    Content= x.Content,
                    CountRetweet = 0,
                    CountSend = 0,
                    CountComment = countComment,
                    TimePost=x.CreatedAt,
                    Like=like,
                    Media=media,
                    User=user,
                };
            });
            return (await Task.WhenAll(result)).ToList(); ;
        }

        public async Task<List<Posts>> GetListPostRelatedToAll()
        {
            return await _postRepository.GetPostAndMedia();
        }

        public async Task<Posts> Update(UpdatePostViewModel request)
        {
            Posts check = await _genericRepository.GetById(request.Id);
            if (check == null)
            {
                return null;
            }
            check.Content = request.Content;
            check.AccountName = request.AccountName;
            check.UpdatedAt = DateTime.UtcNow;
            check.Privacy = request.Privacy;
            Posts result = await _genericRepository.Update(check);
            return result;
        }
    }
}