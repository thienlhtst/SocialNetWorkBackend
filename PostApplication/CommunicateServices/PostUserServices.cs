using ConsumerViewModel;
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
        private readonly IRequestClient<AccountNameEvent> _requestClient;

        public PostUserServices(IRequestClient<AccountNameEvent> requestClient)
        {
            _requestClient=requestClient;
        }

        public async Task<UserComment> GetInformationbyAccountname(string AccoutName)
        {
            var UserExists = await _requestClient.GetResponse<UserComment>(AccoutName);
            return UserExists.Message;
        }
    }
}