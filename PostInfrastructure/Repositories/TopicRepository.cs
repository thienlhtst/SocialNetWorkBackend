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
    public class TopicRepository : ITopicRepository
    {
        private readonly PostDbContext _postDbContext;

        public TopicRepository(PostDbContext postDbContext)
        {
            _postDbContext = postDbContext;
        }

        public async Task<List<TopicUser>> GetAllbyUser(string AccountName)
        {
            var query = _postDbContext.TopicUsers.Include(x => x.TopicId).Where(x => x.AccountName.Equals(AccountName));
            return await query.ToListAsync();
        }
    }
}