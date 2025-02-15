using ConsumerViewModel;
using ConsumerViewModel.UserToComment;
using MassTransit;
using PostApplication.ViewModel.CommentViewModel;
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

        public PostUserServices(IRequestClient<AccountNameCommentEvent> requestClient)
        {
            _requestClient=requestClient;
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
    }
}