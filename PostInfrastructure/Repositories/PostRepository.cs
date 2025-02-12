using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PostCore.Entities;
using PostCore.InterfaceRepositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostInfrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly PostDbContext _postDbContext;

        public PostRepository(PostDbContext postDbContext)
        {
            _postDbContext = postDbContext;
        }

        public async Task<List<Posts>> GetPostAndMedia()
        {
            List<Posts> result = await _postDbContext.Posts
                .Include(p => p.Medias)
                .ToListAsync();
            return result;
        }

        public async Task<List<Posts>> GetByAccountName(string accountName)
        {
            List<Posts> result = await _postDbContext.Posts
                .Where(p => p.AccountName.Equals(accountName))
                .ToListAsync();
            return result;
        }

        public async Task<List<Posts>> GetListLikeByAccountName(string accountName)
        {
            List<Posts> result = await _postDbContext.Posts
                .Where(p => p.AccountName.Contains(accountName))
                .ToListAsync();
            return result;
        }
    }
}