using Microsoft.EntityFrameworkCore;
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

        public ReactionRepository(PostDbContext postDbContext)
        {
            _postDbContext = postDbContext;
        }

        public async Task<int> CountReaction(string id)
        {
            var count = await _postDbContext.Reactions.Where(x => x.PostIdOrCommentId.Equals(id)).CountAsync();

            return count;
        }

        public async Task<bool> FindUserReaction(string id, string AccountName)
        {
            var count = await _postDbContext.Reactions.FirstOrDefaultAsync(x => x.PostIdOrCommentId.Equals(id) && x.AccountName.Equals(AccountName));
            if (count == null) return false;
            return true;
        }
    }
}