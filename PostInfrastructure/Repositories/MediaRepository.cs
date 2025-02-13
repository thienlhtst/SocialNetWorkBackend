using Microsoft.EntityFrameworkCore;
using PostCore.Entities;
using PostCore.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PostInfrastructure.Repositories
{
    public class MediaRepository : IMediaRepository
    {
        private readonly PostDbContext _postDbContext;

        public MediaRepository(PostDbContext postDbContext)
        {
            _postDbContext = postDbContext;
        }

        public async Task<List<Media>> GetAllbyParentId(string parentId)
        {
            var data = _postDbContext.Medias.Where(m => m.ParentId.Equals(parentId));

            if (!data.Any()) return new List<Media>();
            return await data.ToListAsync();
        }
    }
}