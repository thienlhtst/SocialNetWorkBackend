﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApplication.ViewModel.UserViewModel;
using UserCore.Entities;

namespace UserApplication.Interfaces
{
    public interface IUserService
    {
        Task<int> ChangePrivatedAccount(PrivateAccountVM request);

        public Task<ResponseInformationUserVM?> GetInformationUser(string requestName);

        public Task<string> GetstringAccountUser(string requestid);

        public Task<List<User>?> GetListSreachUser(string request);

        public Task<User?> UpdateInformationUser(string IdUser, RequestUpdateUserVM request);

        public Task<List<User>> GetFollowerOrFolloweeUser(string requestId, string type, bool typePrivate);
    }
}