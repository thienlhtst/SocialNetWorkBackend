using PostApplication.Interfaces;
using PostApplication.ViewModel.TopicViewModel;
using PostCore.Entities;
using PostCore.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostApplication.Services
{
    public class TopicServices : ITopicServices
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IGenericRepository<Topic> _topicGenericRepository;
        private readonly IGenericRepository<TopicUser> _UsertopicGenericRepository;
        private readonly IGenericRepository<TopicPost> _TopicPostGenericRepository;

        public TopicServices(ITopicRepository topicRepository, IGenericRepository<Topic> topicGenericRepository, IGenericRepository<TopicUser> usertopicGenericRepository, IGenericRepository<TopicPost> topicPostGenericRepository)
        {
            _topicRepository=topicRepository;
            _topicGenericRepository=topicGenericRepository;
            _UsertopicGenericRepository=usertopicGenericRepository;
            _TopicPostGenericRepository=topicPostGenericRepository;
        }

        public async Task<int> CreateTopic(List<RequestCreateTopicVM> request)
        {
            var topic = request.Select(x =>
            new Topic
            {
                Id= Guid.NewGuid().ToString(),
                Name= x.Name,
                CountTopic=0
            }

            ).ToList();
            var result = await _topicGenericRepository.CreateRange(topic);
            return result;
        }

        public async Task<int> CreateTopicUser(List<RequestCreateTopicUserVM> request)
        {
            var listTopicUser = request.Select(
                x => new TopicUser
                {
                    TopicId= x.TopicId,
                    AccountName= x.AccountName,
                }
                ).ToList();
            return await _UsertopicGenericRepository.CreateRange(listTopicUser);
        }

        public async Task<int> DeleteTopicUser(List<RequestDeteleTopicUserVM> request)
        {
            var listTopicUser = request.Select(
               x => new TopicUser
               {
                   TopicId= x.TopicId,
                   AccountName= x.AccountName,
               }
               ).ToList();
            return await _UsertopicGenericRepository.DeleteRange(listTopicUser);
        }

        public async Task<int> DeteleTopic(string Id)
        {
            var find = await _topicGenericRepository.GetById(Id);
            return await _topicGenericRepository.Delete(find);
        }

        public async Task<List<TopicPost>> GetAllPost()
        {
            var query = await _TopicPostGenericRepository.GetAll();
            return query;
        }

        public async Task<List<RequestTopicVM>> GetAllTopic()
        {
            var query = await _topicGenericRepository.GetAll();
            var result = query.Select(x => new RequestTopicVM
            {
                Id = x.Id,
                Name= x.Name,
                CountTopic=x.CountTopic,
            }).ToList();
            return result;
        }

        public async Task<List<RequestTopicUserVM>> GetAllTopicbyUser(string AccountName)
        {
            var query = await _topicRepository.GetAllbyUser(AccountName);
            var result = query.Select(x => new RequestTopicUserVM
            {
                TopicId = x.TopicId,
                TopicName= x.Topic.Name,
            }).ToList();
            return result;
        }
    }
}