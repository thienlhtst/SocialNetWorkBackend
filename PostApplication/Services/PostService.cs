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

        public PostService(IPostRepository postRepository, IMediaRepository mediaRepository, IGenericRepository<Posts> genericRepository, IReactionRepository reactionRepository, ICommentRepository commentRepository)
        {
            _postRepository = postRepository;
            _commentRepository = commentRepository;
            _genericRepository = genericRepository;
            _reactionRepository = reactionRepository;
            _commentRepository = commentRepository;
        }

        public async Task<Posts> Create(CreatePostViewModel request)
        {
            Posts newPost = new Posts()
            {
                Content = request.Content,
                AccountName = request.AccountName,
                Privacy = request.Privacy,
            };
            Posts result = await _genericRepository.Create(newPost);
            return result;
        }

        public async Task<List<PostViewModel>> GetListByAccountName(string accountName)
        {
            var result = await _postRepository.GetByAccountName(accountName);
            if (result !=null)
            {
                var mix = new List<PostViewModel>();
                result.ForEach(async x =>
                {
                    var Like = new LikeViewModel
                    {
                        AccountName=accountName,
                        IsLiked= await _reactionRepository.FindUserReaction(x.Id, accountName),
                        Count = await _reactionRepository.CountReaction(x.Id)
                    };
                    var media = await _mediaRepository.GetAllbyParentId(x.Id);
                    var item = new PostViewModel
                    {
                        Id= x.Id,
                        Content=x.Content,
                        CountRetweet= 0,
                        CountSend=0,
                        CountComment= await _commentRepository.CounComment(x.Id),
                        Like = Like,
                        Media= media,
                    };
                    mix.Add(item);
                });
                return mix;
            }
            return null;
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