﻿using Microsoft.EntityFrameworkCore;
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

        public MediaRepository(PostDbContext postDbContext)
        {
            _postDbContext = postDbContext;
        }

        public async Task<List<Media>> GetAllbyParentId(string parentId)
        {
            var result = await _postDbContext.Medias.Where(m => m.ParentId == parentId).ToListAsync();
            return result;
        }
    }
}