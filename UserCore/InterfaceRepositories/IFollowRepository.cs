using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCore.Entities;

namespace UserCore.InterfaceRepositories
{
    public interface IFollowRepository
    {
        Task<Follow> GetbyID(string idfollower, string idfollowee);

        public Task<int> RequestFollowTo(string idfollower, string idfollowee);

        public Task<int?> RemoveFollowAccount(string UserIdFollower, string UserIdFollowee);

        public int CheckFollowFromUser(string requestId, string recipientId);
    }
}