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
        Task<Posts> Create(CreatePostViewModel request);
        Task<Posts> Update(UpdatePostViewModel request);
    }
}
