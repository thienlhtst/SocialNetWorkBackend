using ConsumerViewModel;
using ConsumerViewModel.UserToComment;
using MassTransit;
using UserApplication.Interfaces;

namespace UserPresentation.Consumer
{
    public class RequestInfoUserfromComment : IConsumer<AccountNameCommentEvent>
    {
        private readonly IUserService _userService;

        public RequestInfoUserfromComment(IUserService userService)
        {
            _userService=userService;
        }

        public async Task Consume(ConsumeContext<AccountNameCommentEvent> context)
        {
            var result = await _userService.getUsercommentbyAccountName(context.Message.AccountName);
            await context.RespondAsync<UserCommentEvent>(result);
        }
    }
}