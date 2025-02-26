using PostCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostCore.InterfaceRepositories
{
    public interface ITopicRepository
    {
        Task<List<TopicUser>> GetAllbyUser(string AccountName);

        Task<int> ChangeCountTopic(List<TopicPost> request);
    }
}