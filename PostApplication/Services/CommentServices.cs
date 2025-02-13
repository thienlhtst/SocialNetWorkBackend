using PostApplication.Interfaces;
using PostApplication.ViewModel.CommentViewModel;
using PostCore.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostApplication.Services
{
    public class CommentServices : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IReactionRepository _reactionRepository;
        private readonly IMediaRepository _mediaRepository;

        public CommentServices(ICommentRepository commentRepository, IReactionRepository reactionRepository, IMediaRepository mediaRepository)
        {
            _commentRepository=commentRepository;
            _reactionRepository=reactionRepository;
            _mediaRepository=mediaRepository;
        }

        public async Task<CommentViewModel> GetAllCommentbyParentId(string parentid, string accountname)
        {
            return null;
        }
    }
}