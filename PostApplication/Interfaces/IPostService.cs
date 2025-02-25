using PostApplication.ViewModel.PostViewModel;
using PostCore.Entities;
using PostCore.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostApplication.Interfaces
{
    public interface IPostService
    {
        Task<int> Create(CreatePostViewModel request);

        Task<Posts> Update(UpdatePostViewModel request);

        Task<List<PostViewModel>> GetListByAccountName(string accountName);

        Task<List<Posts>> GetListPostRelatedToAll();

        Task<List<PostViewModel>> GetListForHomePage(string accountName, int numberPost);
    }
}