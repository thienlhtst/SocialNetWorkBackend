using PostApplication.ViewModel.CommentViewModel;
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
    }
}