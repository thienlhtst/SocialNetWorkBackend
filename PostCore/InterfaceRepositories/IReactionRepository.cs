using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostCore.InterfaceRepositories
{
    public interface IReactionRepository
    {
        public Task<int> CountReaction(string id);

        public Task<bool> FindUserReaction(string id, string AccountName);
    }
}