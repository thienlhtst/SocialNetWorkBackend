using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCore.Entities;
using UserCore.InterfaceRepositories;

namespace UserInfrastructure.Repositories
{
    public class FollowRepository : IFollowRepository
    {
        private readonly UserDbContext _userDbContext;
        private readonly IBaseRepository<Follow> _followbase;

        public FollowRepository(UserDbContext userDbContext, IBaseRepository<Follow> baseRepository)
        {
            _userDbContext=userDbContext;
            _followbase=baseRepository;
        }

        public async Task<Follow> GetbyID(string idfollower, string idfollowee)
        {
            var result = await _userDbContext.Follows.FirstOrDefaultAsync(x => x.UserIdFollower.Equals(idfollower) && x.UserIdFollowee.Equals(idfollowee));
            return result;
        }

        public async Task<int> RequestFollowTo(string idfollower, string idfollowee)
        {
            var reponse = await _userDbContext.Users.FirstOrDefaultAsync(x => x.Id.Equals(idfollowee));
            Follow entity = new Follow
            {
                UserIdFollowee = idfollowee,
                UserIdFollower = idfollower,
                CreateAat = DateTime.Now,
            };
            if (!reponse.AccountPrivated)
            {
                entity.IsFollowing = true;
            }
            else
            {
                entity.IsFollowing = false;
            }

            var result = await _followbase.Create(entity);
            if (result != null) { return 1; }
            return 0;
        }

        public async Task<int?> AcceptFollowPivateAccount(string UserIdFollower, string UserIdFollowee)
        {
            var reponse = _userDbContext.Follows.FirstOrDefault(x => x.UserIdFollower.Equals(UserIdFollower)&& x.UserIdFollowee.Equals(UserIdFollowee));
            reponse.IsFollowing=true;
            var result = await _followbase.Update(reponse);
            if (result != null) { return 1; }
            return 0;
        }

        public async Task<int?> RemoveFollowAccount(string UserIdFollower, string UserIdFollowee)
        {
            var reponse = _userDbContext.Follows.FirstOrDefault(x => x.UserIdFollower.Equals(UserIdFollower)&& x.UserIdFollowee.Equals(UserIdFollowee));
            var result = await _followbase.Delete(reponse);
            return result;
        }

        public int CheckFollowFromUser(string requestId, string recipientId)
        {
            var result = _userDbContext.Follows.FirstOrDefault(x => x.UserIdFollower.Equals(requestId)&& x.UserIdFollowee.Equals(recipientId));
            if (result!= null) return 1;//da follow
            var result1 = _userDbContext.Follows.FirstOrDefault(x => x.UserIdFollower.Equals(recipientId)&& x.UserIdFollowee.Equals(requestId));
            if (result1== null) return 2;// nguoi nhan yeu cau da follow

            return 0;//
        }
    }
}