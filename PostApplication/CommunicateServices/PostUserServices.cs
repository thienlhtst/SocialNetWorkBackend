using ConsumerViewModel;
using ConsumerViewModel.UserToComment;
using ConsumerViewModel.UserToPost;
using MassTransit;
using PostApplication.ViewModel.CommentViewModel;
using PostApplication.ViewModel.PostViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostApplication.CommunicateServices
{
    public class PostUserServices : IPostUserServices
    {
        private readonly IRequestClient<AccountNameCommentEvent> _requestClient;
        private readonly IRequestClient<AccountNamePostEvent> _requestpostClient;

        public PostUserServices(IRequestClient<AccountNameCommentEvent> requestClient, IRequestClient<AccountNamePostEvent> requestClient1)
        {
            _requestClient=requestClient;
            _requestpostClient = requestClient1;
        }

        public async Task<UserComment> GetInformationbyAccountname(string AccoutName)
        {
            var result = new UserComment();
            try
            {
                var UserExists = await _requestClient.GetResponse<UserCommentEvent>(new AccountNameCommentEvent { AccountName=AccoutName });
                result= new UserComment
                {
                    Id = UserExists.Message.Id,
                    Avatar = UserExists.Message.Avatar,
                    FullName= UserExists.Message.FullName,
                    AccountName = UserExists.Message.AccountName,
                    Followers= UserExists.Message.Followers,
                    Title = UserExists.Message.Title,
                };
            }
            catch (RequestTimeoutException ex)
            {
                Console.WriteLine($"Service user không phản hồi: {ex.Message}");
            }

            return result;
        }

        public async Task<UserPosts> GetInformationbyAccountnameForPost(string AccoutName)
        {
            var result = new UserPosts();
            try
            {
                var UserExists = await _requestpostClient.GetResponse<UserPostEventVM>(new AccountNamePostEvent { AccountName=AccoutName });
                result= new UserPosts
                {
                    Id = UserExists.Message.Id,
                    Avatar = UserExists.Message.Avatar,
                    FullName= UserExists.Message.FullName,
                    AccountName = UserExists.Message.AccountName,
                    Followers= UserExists.Message.Followers,
                    Title = UserExists.Message.Title,
                };
            }
            catch (RequestTimeoutException ex)
            {
                Console.WriteLine($"Service user không phản hồi: {ex.Message}");
                result=  new UserPosts
                {
                    Id ="khong co",
                    Avatar = "khong co",
                    FullName= "khong co",
                    AccountName = "khong co",
                    Followers= 0,
                    Title = "khong co",
                };
            }

            return result;
        }
    }
}