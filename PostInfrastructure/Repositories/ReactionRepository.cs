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
    public class ReactionRepository : IReactionRepository
    {
        private readonly PostDbContext _postDbContext;
        private readonly IDbContextFactory<PostDbContext> _contextFactory;

        public ReactionRepository(PostDbContext postDbContext, IDbContextFactory<PostDbContext> contextFactory)
        {
            _postDbContext=postDbContext;
            _contextFactory=contextFactory;
        }

        public async Task<int> CountReaction(string id)
        {
            using var context = _contextFactory.CreateDbContext();
            var count = await context.Reactions.Where(x => x.PostIdOrCommentId.Equals(id)).CountAsync();

            return count;
        }

        public async Task<int> RemoveReaction(string AccountName, string postorCommentId)
        {
            var result = await _postDbContext.Reactions.Where(x => x.AccountName == AccountName && x.PostIdOrCommentId == postorCommentId)
    .ExecuteDeleteAsync();
            return result;
        }

        public async Task<int> CreateReaction(string AccountName, string postorCommentId)
        {
            var entity = new Reaction
            {
                AccountName= AccountName,
                PostIdOrCommentId= postorCommentId,
            };
            var result = _postDbContext.Reactions.Add(entity);
            return await _postDbContext.SaveChangesAsync(); ;
        }

        public async Task<bool> FindUserReaction(string id, string AccountName)
        {
            using var context = _contextFactory.CreateDbContext();
            var count = await context.Reactions.FirstOrDefaultAsync(x => x.PostIdOrCommentId.Equals(id) && x.AccountName.Equals(AccountName));
            if (count == null) return false;
            return true;
        }
    }
}