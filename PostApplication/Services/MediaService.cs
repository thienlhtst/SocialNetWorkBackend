using PostApplication.Interfaces;
using PostApplication.ViewModel.MediaViewModel;
using PostCore.Entities;
using PostCore.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostApplication.Services
{
    public class MediaService : IMediaService
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly IGenericRepository<Media> _genericRepositoryMedia;
        private readonly IGenericRepository<Posts> _genericRepositoryPosts;

        public MediaService(IMediaRepository mediaRepository, IGenericRepository<Media> genericRepositoryMedia, IGenericRepository<Posts> genericRepositoryPosts)
        {
            _mediaRepository = mediaRepository;
            _genericRepositoryMedia = genericRepositoryMedia;
            _genericRepositoryPosts = genericRepositoryPosts;
        }

    }
}
