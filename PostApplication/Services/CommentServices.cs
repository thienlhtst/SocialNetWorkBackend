using MassTransit.Initializers;
using PostApplication.CommunicateServices;
using PostApplication.Interfaces;
using PostApplication.ViewModel.CommentViewModel;
using PostCore.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MassTransit.Util.ChartTable;

namespace PostApplication.Services
{
    public class CommentServices : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IReactionRepository _reactionRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IPostUserServices _postUserServices;

        public CommentServices(ICommentRepository commentRepository,
            IReactionRepository reactionRepository,
            IMediaRepository mediaRepository,
            IPostUserServices postUserServices)
        {
            _postUserServices = postUserServices;
            _commentRepository=commentRepository;
            _reactionRepository=reactionRepository;
            _mediaRepository=mediaRepository;
        }

        public async Task<List<CommentViewModel>> GetAllCommentbyParentId(string parentid, string accountname)
        {
            var listcomment = await _commentRepository.GetListCommentbyParentId(parentid);
            var tasklistcomment = listcomment.Select(async x =>
            {
                var reaction = new LikeCommentViewModel
                {
                    AccountName = accountname,
                    IsLiked = await _reactionRepository.FindUserReaction(x.Id, accountname),
                    Count = await _reactionRepository.CountReaction(x.Id)
                };
                var countComment = await _commentRepository.CounComment(x.Id); // Gọi trước để tránh gọi lại
                var media = await _mediaRepository.GetAllbyParentId(x.Id);
                var userComment = await _postUserServices.GetInformationbyAccountname(x.AccountName);
                return new CommentViewModel
                {
                    Id = x.Id,
                    User=userComment,
                    Content = x.Content,
                    CountRetweet = 0,
                    CountSend = 0,
                    CountComment = countComment,
                    Like = reaction,
                    Media = media
                };
            });

            return (await Task.WhenAll(tasklistcomment)).ToList();
        }
    }
}