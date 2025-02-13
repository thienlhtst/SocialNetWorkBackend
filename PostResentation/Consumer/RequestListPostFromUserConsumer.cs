using ConsumerViewModel;
using MassTransit;
using PostApplication.Interfaces;
using PostApplication.ViewModel.PostViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostResentation.Consumer
{
    public class RequestListPostFromUserConsumer : IConsumer<AccountNameEvent>
    {
        private readonly IPostService _postService;

        public RequestListPostFromUserConsumer(IPostService postService)
        {
            _postService=postService;
        }

        public async Task Consume(ConsumeContext<AccountNameEvent> context)
        {
            var result = await _postService.GetListByAccountName(context.Message.AccountName);
            await context.RespondAsync<PostViewModelEvent>(result);
        }
    }
}