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
        private readonly IGenericRepository<Posts> _genericRepository;

        public PostService(IPostRepository postRepository, IGenericRepository<Posts> genericRepository)
        {
            _postRepository = postRepository;
            _genericRepository = genericRepository;
        }

        public async Task<Posts> Create(CreatePostViewModel request)
        {
            Posts newPost = new Posts() {
                Content = request.Content,
                AccountName = request.AccountName,
                Privacy = request.Privacy,
                Medias = request.Medias?.Select(m => new Media
                {
                }).ToList() ?? new List<Media>()
            };
            Posts result = await _genericRepository.Create(newPost);
            return result;
        }

        public async Task<List<Posts>> GetListByAccountName(string accountName)
        {
            var result = await _postRepository.GetByAccountName(accountName);
            return result;
        }

        public async Task<List<Posts>> GetListPostRelatedToAll()
        {
            return await _postRepository.GetPostAndMedia();
        }

        public async Task<Posts> Update(UpdatePostViewModel request)
        {
            Posts check = await _genericRepository.GetById(request.Id);
            if (check == null) {
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
