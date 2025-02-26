using ConsumerViewModel.UserToComment;
using ConsumerViewModel.UserToPost;
using MassTransit;
using UserApplication.Interfaces;

namespace UserPresentation.Consumer
{
    public class RequestInfoUserfromPost : IConsumer<AccountNamePostEvent>
    {
        private readonly IUserService _userService;

        public RequestInfoUserfromPost(IUserService userService)
        {
            _userService=userService;
        }

        public async Task Consume(ConsumeContext<AccountNamePostEvent> context)
        {
            var query = await _userService.getUsercommentbyAccountName(context.Message.AccountName);
            var result = new UserPostEventVM
            {
                Id=query.Id,
                Title=query.Title,
                AccountName=query.AccountName,
                Avatar=query.Avatar,
                Followers=query.Followers,
                FullName=query.FullName,
            };
            await context.RespondAsync<UserPostEventVM>(result);
        }
    }
}