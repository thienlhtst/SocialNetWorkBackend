using PostApplication.Interfaces;
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
                Id = Guid.NewGuid().ToString(),
                Content = request.Content,
                UserId = request.UserId,
                CreatedAt = DateTime.UtcNow,
            };
            Posts result = await _genericRepository.Create(newPost);
            return result;
        }

        public async Task<Posts> Update(UpdatePostViewModel request)
        {
            Posts check = await _genericRepository.GetbyId(request.Id);
            if (check == null) {
                return null;
            }
            check.Content = request.Content;
            check.UserId = request.UserId;
            check.UpdatedAt = DateTime.UtcNow;
            Posts result = await _genericRepository.Update(check);
            return result;
        }
    }
}
