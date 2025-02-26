using PostApplication.ViewModel.TopicViewModel;
using PostCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostApplication.Interfaces
{
    public interface ITopicServices
    {
        Task<int> CreateTopic(List<RequestCreateTopicVM> request);

        Task<int> DeteleTopic(string Id);

        Task<int> CreateTopicUser(List<RequestCreateTopicUserVM> request);

        Task<int> DeleteTopicUser(List<RequestDeteleTopicUserVM> request);

        Task<List<RequestTopicVM>> GetAllTopic();

        Task<List<TopicPost>> GetAllPost();

        Task<List<RequestTopicUserVM>> GetAllTopicbyUser(string AccountName);
    }
}