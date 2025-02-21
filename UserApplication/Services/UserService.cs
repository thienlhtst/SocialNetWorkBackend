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
using UserApplication.ViewModel.Enum;
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
        private readonly IFollowRepository _followRepository;

        public UserService(IBaseRepository<User> baseRepository, IUserRepository userRepository, IRequestClient<AccountNameEvent> requestClient, IStorageService storageService, IFollowRepository followRepository)
        {
            _baseRepository=baseRepository;
            _userRepository=userRepository;
            _requestClient=requestClient;
            _storageService=storageService;
            _followRepository=followRepository;
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

        public async Task<ResponseInformationUserVM?> GetInformationUser(string requestName, string currentID)
        {
            var response = await _userRepository.GetInfoUser(requestName);
            response.UrlAvatar = _storageService.GetFileUrl(response.UrlAvatar);
            var Isfollow = 0;//chua follow
            if (response.Followers.FirstOrDefault(x => x.UserIdFollower.Equals(currentID)) != null)
            {
                Isfollow=1; // da follow
            }
            if (response.Followees.FirstOrDefault(x => x.UserIdFollower.Equals(currentID)) != null)
            {
                Isfollow=2;// follow lai
            }
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
                IsFollow=Isfollow,
                Type="public",
                PostViewModelEvent= postViewModelEvent.resultofrespone,
            };
        }

        public async Task<List<User>> GetAll()
        {
            var response = await _baseRepository.GetAll();
            return response;
        }

        public async Task<List<UserFollowProfileVM>> GetFollowerOrFolloweeUser(string OwnnerId, string requestAccountname, string type, bool typePrivate)
        {
            var user = await _userRepository.GetbyAccountName(requestAccountname);
            var result = await _userRepository.GetFollowerOrFolloweeUser(user.Id, type, typePrivate);
            if (result == null) return new List<UserFollowProfileVM> { };
            var finalresult = result.Select(x =>
            {
                var check = _followRepository.CheckFollowFromUser(OwnnerId, x.Id);
                return new UserFollowProfileVM
                {
                    Id= x.Id,
                    AccountName= x.AccountName,
                    FullName= x.FullName,
                    Src=x.UrlAvatar,
                    IsFollow=check,
                };
            }).ToList();
            return finalresult;
        }

        public async Task<User?> UpdateInformationUser(string IdUser, RequestUpdateUserVM request)
        {
            var entity = await _baseRepository.GetbyId(IdUser);
            if (entity != null)
            {
                entity.FullName = request.FullName;
                entity.AccountName = request.AcountName;
                //  entity.Email = request.Email;
                entity.Title = request.Title;
                entity.Links = request.Links;
                // entity.AccountConfirmed = request.AccountConfirmed;
                entity.AccountPrivated = request.AccountPrivated;
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
                string fileName = request.file.FileName;
                string fileExtension = Path.GetExtension(fileName);
                entity.UrlAvatar = entity.AccountName+"_avatar"+fileExtension;
                await _storageService.SaveFileAsync(request.file.OpenReadStream(), entity.UrlAvatar);
                var reponse = await _baseRepository.Update(entity);
                return reponse;
            }
            return entity;
        }

        public async Task<List<UserSreachVM>?> GetListSreachUser(string OwnId, string request)
        {
            var response = await _userRepository.GetUserToSreach(request);
            if (response==null) return new List<UserSreachVM>();
            var result = response.Select(x =>
            {
                var isFollow = statusFollow.Follow;
                if (x.Followees.FirstOrDefault(x => x.UserIdFollower==OwnId)!=null)
                    isFollow = statusFollow.Followed;
                return new UserSreachVM
                {
                    AccountName = x.AccountName,
                    FullName=x.FullName,
                    Title= x.Title,
                    UrlAvatar = x.UrlAvatar,
                    Followers= x.Followees.Count(),
                    IsFollow=isFollow,
                };
            }).ToList();
            return result;
        }

        public async Task<string> GetstringAccountUser(string requestid)
        {
            var accountname = "";

            var response = await _baseRepository.GetbyId(requestid);
            if (response != null) { return response.AccountName; }
            return accountname;
        }
    }
}