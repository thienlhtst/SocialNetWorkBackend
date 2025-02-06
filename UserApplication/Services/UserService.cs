using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApplication.Interfaces;
using UserApplication.ViewModel.UserViewModel;
using UserCore.Entities;
using UserCore.InterfaceRepositories;

namespace UserApplication.Services
{
    public class UserService : IUserService, IBaseServices<User>
    {
        private readonly IBaseRepository<User> _baseRepository;
        private readonly IUserRepository _userRepository;
        private readonly IStorageService _storageService;

        public UserService(IBaseRepository<User> baseRepository, IUserRepository userRepository, IStorageService storageService)
        {
            _baseRepository=baseRepository;
            _userRepository=userRepository;
            _storageService=storageService;
        }

        public async Task<int> ChangePrivatedAccount(PrivateAccountVM request)
        {
            var response = await _baseRepository.GetbyId(request.Id);
            if (response != null)
            {
                response.AccountPrivated  =request.IsPrivate;
                var result = await _baseRepository.Update(response);
                if (result != null) return 1;
                return 0;
            }
            return 0;
        }

        public async Task<ResponseInformationUserVM?> GetInformationUser(string requestName)
        {
            var response = await _userRepository.GetInfoUser(requestName);
            response.UrlAvatar = _storageService.GetFileUrl(response.UrlAvatar);
            return new ResponseInformationUserVM
            {
                InfoUser =response
            ,
                Type="public"
            };
        }

        public async Task<List<User>> GetAll()
        {
            var response = await _baseRepository.GetAll();
            return response;
        }

        public async Task<List<User>> GetFollowerOrFolloweeUser(string requestId, string type, bool typePrivate)
        {
            var result = await _userRepository.GetFollowerOrFolloweeUser(requestId, type, typePrivate);
            return result;
        }

        public async Task<User?> UpdateInformationUser(string IdUser, RequestUpdateUserVM request)
        {
            var entity = await _baseRepository.GetbyId(IdUser);
            if (entity != null)
            {
                entity.FullName = request.FullName;
                entity.AcountName = request.AcountName;
                entity.Email = request.Email;
                entity.Title = request.Title;
                entity.Links = request.Links;
                entity.AccountConfirmed = request.AccountConfirmed;

                entity.Active = entity.Active;  // Giữ
                var reponse = await _baseRepository.Update(entity);
                return reponse;
            }
            return entity;
        }

        public async Task<User?> UpdateAvatarUser(string IdUser, RequestUpdateAvatarUserVM request)
        {
            var entity = await _baseRepository.GetbyId(IdUser);
            if (entity != null)
            {
                entity.UrlAvatar = entity+"_avatar";
                await _storageService.SaveFileAsync(request.file.OpenReadStream(), entity.UrlAvatar);
                var reponse = await _baseRepository.Update(entity);
                return reponse;
            }
            return entity;
        }

        public async Task<List<User>?> GetListSreachUser(string request)
        {
            var response = await _userRepository.GetUserToSreach(request);
            return response;
        }

        public async Task<string> GetstringAccountUser(string requestid)
        {
            var response = await _baseRepository.GetbyId(requestid);
            return response.AcountName ?? string.Empty;
        }
    }
}