using PostApplication.Interfaces;
using PostCore.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostApplication.Services
{
    public class ReactionService : IReactionService
    {
        private readonly IReactionRepository _reactionRepository;

        public ReactionService(IReactionRepository reactionRepository)
        {
            _reactionRepository=reactionRepository;
        }

        public async Task<int> CreateReaction(string AccountName, string postorCommentId)
        {
            return await _reactionRepository.CreateReaction(AccountName, postorCommentId);
        }

        public async Task<int> RemoveReaction(string AccountName, string postorCommentId)
        {
            return await (_reactionRepository.RemoveReaction(AccountName, postorCommentId));
        }
    }
}