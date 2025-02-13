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
            List<PostViewModelEvent> rs = result.Select(post => new PostViewModelEvent
            {
                Id = post.Id,
                User = post.User != null ? new UserPostsEvent
                {
                    Id = post.User.Id,
                    AccountName = post.User.AccountName,
                    FullName = post.User.FullName,
                    Title = post.User.Title,
                    Followers = post.User.Followers,
                    Avatar = post.User.Avatar
                } : null,
                Content = post.Content,
                TimePost = post.TimePost,
                Media = post.Media?.Select(media => new MediaEvent
                {
                    ParentId = post.Id,
                    MediaName = media.MediaName,
                    MediaType = Convert.ToInt32(media.MediaType),
                    Url = media.Url,
                    Width = media.Width,
                    Height = media.Height
                }).ToList(),
                Like = new LikeViewModelEvent
                {
                    Id = post.Like.Id,
                    AccountName = post.Like.AccountName,
                    IsLiked = post.Like.IsLiked,
                    Count = post.Like.Count
                },
                CountComment = post.CountComment,
                CountRetweet = post.CountRetweet,
                CountSend = post.CountSend
            }).ToList();
            Console.WriteLine(rs[0].Id);
            var finalresult = new ResponseListPostViewModel
            {
                resultofrespone= rs
            };
            await context.RespondAsync<ResponseListPostViewModel>(finalresult);
        }
    }
}