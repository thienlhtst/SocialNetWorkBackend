using Microsoft.EntityFrameworkCore;
using PostCore.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostInfrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly PostDbContext _postDbContext;

        public CommentRepository(PostDbContext postDbContext)
        {
            _postDbContext = postDbContext;
        }

        public async Task<int> CounComment(string id)
        {
            var count = await _postDbContext.Comments.Where(x => x.ParentId.Equals(id)).CountAsync();
            return count;
        }
    }
}