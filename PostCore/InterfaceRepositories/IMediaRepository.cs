using PostCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostCore.InterfaceRepositories
{
    public interface IMediaRepository
    {
        public Task<List<Media>> GetAllbyParentId(string parentId);

        public Task<int> CreateMedia(List<Media> medias);
    }
}