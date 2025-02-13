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
            _mediaRepository = mediaRepository;
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
            if (result == null) return new List<PostViewModel>(); // Trả về danh sách rỗng nếu không có bài viết

            var tasks = result.Select(async x =>
            {
                var like = new LikeViewModel
                {
                    AccountName = accountName,
                    IsLiked = await _reactionRepository.FindUserReaction(x.Id, accountName),
                    Count = await _reactionRepository.CountReaction(x.Id)
                };
                // Không để danh sách null

                var countComment = await _commentRepository.CounComment(x.Id); // Gọi trước để tránh gọi lại
                var media = await _mediaRepository.GetAllbyParentId(x.Id);
                return new PostViewModel
                {
                    Id = x.Id,
                    Content = x.Content,
                    CountRetweet = 0,
                    CountSend = 0,
                    CountComment = countComment,
                    Like = like,
                    Media = media
                };
            });

            return (await Task.WhenAll(tasks)).ToList();
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