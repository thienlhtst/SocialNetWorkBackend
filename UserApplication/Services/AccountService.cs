using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApplication.Interfaces;
using UserApplication.ViewModel.AccountViewModel;
using UserCore.Entities;
using UserCore.InterfaceRepositories;

namespace UserApplication.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserRepository _userRepository;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager, IUserRepository userRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userRepository=userRepository;
        }

        public async Task<User> FindAccount(string requeststring)
        {
            var reponse = await _userRepository.GetbyUniqueString(requeststring);
            if (reponse == null) { return null; }
            return reponse;
        }

        public async Task<SignInResult> LoginAsync(LoginVM request)
        {
            return await _signInManager.PasswordSignInAsync(request.account, request.Password, isPersistent: false, lockoutOnFailure: false);
        }

        public async Task<IdentityResult> RegisterUser(RegisterVM request)
        {
            var user = new User
            {
                UserName = request.UserName,
                Email = request.Email,
                FullName = request.FullName,
                AcountName =request.AccountName
            };

            return await _userManager.CreateAsync(user, request.Password);
        }
    }
}