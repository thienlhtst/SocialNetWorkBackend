using Microsoft.EntityFrameworkCore;
using PostCore.Entities;
using PostCore.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostInfrastructure.Repositories
{
    public class MediaRepository : IMediaRepository
    {
        private readonly PostDbContext _postDbContext;
        private readonly IDbContextFactory<PostDbContext> _contextFactory;

        public MediaRepository(PostDbContext postDbContext, IDbContextFactory<PostDbContext> contextFactory)
        {
            _postDbContext=postDbContext;
            _contextFactory=contextFactory;
        }

        public async Task<int> CreateMedia(List<Media> medias)
        {
            _postDbContext.Medias.AddRange(medias);
            return await _postDbContext.SaveChangesAsync();
        }

        public async Task<List<Media>> GetAllbyParentId(string parentId)
        {
            using var context = _contextFactory.CreateDbContext();

            var data = context.Medias.Where(m => m.ParentId.Equals(parentId));

            if (!data.Any()) return new List<Media>();
            return await data.ToListAsync();
        }
    }
}