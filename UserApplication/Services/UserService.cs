using Azure.Core;
using ConsumerViewModel;
using ConsumerViewModel.UserToComment;
using MassTransit;
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
        private readonly IRequestClient<AccountNameEvent> _requestClient;
        private readonly IStorageService _storageService;

        public UserService(IBaseRepository<User> baseRepository, IUserRepository userRepository, IStorageService storageService, IRequestClient<AccountNameEvent> requestClient)
        {
            _baseRepository=baseRepository;
            _userRepository=userRepository;
            _storageService=storageService;
            _requestClient=requestClient;
        }

        public async Task<UserCommentEvent> getUsercommentbyAccountName(string accountName)
        {
            var result = await _userRepository.GetbyAccountName(accountName);

            if (result == null) { return new UserCommentEvent(); }
            var response = new UserCommentEvent
            {
                Id =result.Id,
                FullName = result.FullName,
                AccountName = result.AccountName,
                Title = result.Title,
                Avatar = _storageService.GetFileUrl(result.UrlAvatar),
                Followers = await _userRepository.CountFolloweeorFollower(accountName, true),
            };
            return response;
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
            ResponseListPostViewModel? postViewModelEvent = null;

            try
            {
                var result1 = await _requestClient.GetResponse<ResponseListPostViewModel>(
                    new AccountNameEvent { AccountName = requestName });

                postViewModelEvent = new ResponseListPostViewModel
                {
                    resultofrespone= result1.Message.resultofrespone
                };
            }
            catch (RequestTimeoutException ex)
            {
                Console.WriteLine($"Service 2 không phản hồi: {ex.Message}");
                postViewModelEvent = new ResponseListPostViewModel
                {
                    resultofrespone= new List<PostViewModelEvent>() // Trả về danh sách rỗng thay vì lỗi
                };
            }
            return new ResponseInformationUserVM
            {
                InfoUser =response
            ,
                Type="public",
                PostViewModelEvent= postViewModelEvent.resultofrespone,
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
                entity.AccountName = request.AcountName;
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
            return response.AccountName ??"";
        }
    }
}