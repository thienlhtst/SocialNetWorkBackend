using PostApplication.Interfaces;
using PostCore.Entities;
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
        private readonly IGenericRepository<Comment> _genericCommentRepository;
        private readonly IGenericRepository<Posts> _genericPostRepository;

        public ReactionService(IReactionRepository reactionRepository, IGenericRepository<Comment> genericCommentRepository, IGenericRepository<Posts> genericPostRepository)
        {
            _reactionRepository=reactionRepository;
            _genericCommentRepository=genericCommentRepository;
            _genericPostRepository=genericPostRepository;
        }

        public async Task<int> CreateReaction(string AccountName, string postorCommentId)
        {
            bool exists = await _genericPostRepository.ExistsEntity(postorCommentId)
               || await _genericCommentRepository.ExistsEntity(postorCommentId);
            if (!exists) return -1;

            return await _reactionRepository.CreateReaction(AccountName, postorCommentId);
        }

        public async Task<int> RemoveReaction(string AccountName, string postorCommentId)
        {
            bool exists = await _genericPostRepository.ExistsEntity(postorCommentId)
              || await _genericCommentRepository.ExistsEntity(postorCommentId);
            if (!exists) return -1;
            return await (_reactionRepository.RemoveReaction(AccountName, postorCommentId));
        }
    }
}