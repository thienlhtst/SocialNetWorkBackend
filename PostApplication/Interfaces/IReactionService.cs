using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostApplication.Interfaces
{
    public interface IReactionService
    {
        public Task<int> RemoveReaction(string AccountName, string postorCommentId);

        public Task<int> CreateReaction(string AccountName, string postorCommentId);
    }
}