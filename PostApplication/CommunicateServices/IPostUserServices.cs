using ConsumerViewModel.UserToComment;
using PostApplication.ViewModel.CommentViewModel;
using PostApplication.ViewModel.PostViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostApplication.CommunicateServices
{
    public interface IPostUserServices
    {
        Task<UserComment> GetInformationbyAccountname(string AccoutName);

        Task<UserPosts> GetInformationbyAccountnameForPost(string AccoutName);
    }
}