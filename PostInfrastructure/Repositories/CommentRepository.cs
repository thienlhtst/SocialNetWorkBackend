using Microsoft.EntityFrameworkCore;
using PostCore.Entities;
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
        private readonly IDbContextFactory<PostDbContext> _contextFactory;

        public CommentRepository(PostDbContext postDbContext, IDbContextFactory<PostDbContext> contextFactory)
        {
            _postDbContext=postDbContext;
            _contextFactory=contextFactory;
        }

        public async Task<int> CounComment(string id)
        {
            using var context = _contextFactory.CreateDbContext();

            var count = await context.Comments
     .Where(x => x.ParentId == id)
     .CountAsync(); // Trả về số lượng trực tiếp từ SQL Server

            return count;
        }

        public async Task<List<Comment>> GetListCommentbyParentId(string parentId)
        {
            var result = await _postDbContext.Comments.Where(x => x.ParentId.Equals(parentId)).ToListAsync();
            return result??new List<Comment>();
        }
    }
}