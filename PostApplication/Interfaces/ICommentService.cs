using PostApplication.ViewModel.CommentViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostApplication.Interfaces
{
    public interface ICommentService
    {
        public Task<List<CommentViewModel>> GetAllCommentbyParentId(string parentid, string accountname);

        public Task<int> CreateComment(RequestCreateCommentVM request);
    }
}