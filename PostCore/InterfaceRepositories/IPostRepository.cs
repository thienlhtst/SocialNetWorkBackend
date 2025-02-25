using PostCore.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostCore.InterfaceRepositories
{
    public interface IPostRepository
    {
        public Task<List<Posts>> GetByAccountName(string accountName);

        public Task<List<Posts>> GetListLikeByAccountName(string accountName);

        public Task<List<Posts>> GetPostAndMedia();

        public Task<List<Posts>> GetPrioritizedPosts(string accountName, int numberPosts);
    }
}