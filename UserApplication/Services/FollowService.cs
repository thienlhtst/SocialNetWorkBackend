using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApplication.Interfaces;
using UserApplication.ViewModel.FollowViewModel;
using UserCore.Entities;
using UserCore.InterfaceRepositories;

namespace UserApplication.Services
{
    public class FollowService : IFollowService
    {
        private readonly IFollowRepository _followRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBaseRepository<Follow> _followBase;

        public FollowService(IFollowRepository followRepository, IBaseRepository<Follow> baseRepository, IUserRepository userRepository)
        {
            _followRepository=followRepository;
            _followBase=baseRepository;
            _userRepository=userRepository;
        }

        //test
        public async Task<List<Follow>> Getall()
        {
            return await _followBase.GetAll();
        }

        //test

        public async Task<int> RequestFollowTo(RequestFollowVM request)
        {
            var idfollowee = await _userRepository.GetbyAccountName(request.Followee);
            var result = await _followRepository.RequestFollowTo(request.Follower, idfollowee.Id);
            return result;
        }

        public async Task<int> ResponseFollowPrivateUser(RequestFollowVM request)
        {
            var idfollower = await _userRepository.GetbyAccountName(request.Follower);

            var entity = await _followRepository.GetbyID(idfollower.Id, request.Followee);
            entity.IsFollowing =true;
            var result = await _followBase.Update(entity);
            if (result != null) { return 1; }
            return 0;
        }

        public async Task<int> RemoveFollowUser(RequestFollowVM request)
        {
            var idfollower = await _userRepository.GetbyAccountName(request.Follower);
            var result = await _followRepository.RemoveFollowAccount(idfollower.Id, request.Followee);
            if (result == 1) { return 1; }
            return 0;
        }

        public async Task<int> RemoveFolloweeUser(RequestFollowVM request)
        {
            var idfollower = await _userRepository.GetbyAccountName(request.Followee);
            var result = await _followRepository.RemoveFollowAccount(request.Follower, idfollower.Id);
            if (result == 1) { return 1; }
            return 0;
        }

        public Task<int> CheckFollowFromUser(string requestId, string recipientId)
        {
            throw new NotImplementedException();
        }
    }
}