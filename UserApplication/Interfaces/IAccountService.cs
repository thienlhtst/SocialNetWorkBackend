using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApplication.ViewModel.AccountViewModel;
using UserCore.Entities;

namespace UserApplication.Interfaces
{
    public interface IAccountService
    {
        public Task<IdentityResult> RegisterUser(RegisterVM request);

        public Task<SignInResult> LoginAsync(LoginVM request);

        public Task<User> FindAccount(string requeststring);
    }
}