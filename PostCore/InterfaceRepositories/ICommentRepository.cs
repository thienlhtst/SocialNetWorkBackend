using PostCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostCore.InterfaceRepositories
{
    public interface ICommentRepository
    {
        public Task<int> CounComment(string id);

        public Task<List<Comment>> GetListCommentbyParentId(string parentId);
    }
}