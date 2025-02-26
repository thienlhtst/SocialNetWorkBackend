using MassTransit.Initializers;
using PostApplication.CommunicateServices;
using PostApplication.Interfaces;
using PostApplication.ViewModel.CommentViewModel;
using PostCore.Entities;
using PostCore.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MassTransit.Util.ChartTable;

namespace PostApplication.Services
{
    public class CommentServices : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IReactionRepository _reactionRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IPostUserServices _postUserServices;
        private readonly IGenericRepository<Comment> _genericRepository;
        private readonly IStorageService _storage;

        public CommentServices(ICommentRepository commentRepository, IReactionRepository reactionRepository, IMediaRepository mediaRepository, IPostUserServices postUserServices, IGenericRepository<Comment> genericRepository, IStorageService storage)
        {
            _commentRepository=commentRepository;
            _reactionRepository=reactionRepository;
            _mediaRepository=mediaRepository;
            _postUserServices=postUserServices;
            _genericRepository=genericRepository;
            _storage=storage;
        }

        public async Task<int> CreateComment(RequestCreateCommentVM request)
        {
            var entity = new Comment
            {
                AccountName = request.AccountName,
                Id= request.Id,
                ParentId= request.ParentId,
                Content = request.Content,
            };
            var result = await _genericRepository.Create(entity);
            var resultmedia = 0;
            if (result!=null && request.Medias.Any())
            {
                var medias = request.Medias.Select(async x =>
                {
                    string fileName = x.file.FileName;
                    string fileExtension = Path.GetExtension(fileName);
                    await _storage.SaveFileAsync(x.file.OpenReadStream(), x.Id+fileExtension, 1);
                    return new Media
                    {
                        Id= x.Id,
                        ParentId= request.Id,
                        Width= x.Width,
                        Height= x.Height,
                        MediaName= x.MediaName,
                        Url= x.Id+fileExtension,
                        MediaType= x.MediaType,
                    };
                }
                );

                resultmedia = await _mediaRepository.CreateMedia((await Task.WhenAll(medias)).ToList());
            }
            if (!request.Medias.Any() && result!=null) return 2;
            if (resultmedia==1 &&result!=null)
                return 1;
            return 0;
        }

        public async Task<List<CommentViewModel>> GetAllCommentbyParentId(string parentid, string accountname)
        {
            var listcomment = await _commentRepository.GetListCommentbyParentId(parentid);
            var tasklistcomment = listcomment.Select(async x =>
            {
                var reaction = new LikeCommentViewModel
                {
                    AccountName = accountname,
                    IsLiked = await _reactionRepository.FindUserReaction(x.Id, accountname),
                    Count = await _reactionRepository.CountReaction(x.Id)
                };
                var countComment = await _commentRepository.CounComment(x.Id); // Gọi trước để tránh gọi lại
                var media = await _mediaRepository.GetAllbyParentId(x.Id);
                var userComment = await _postUserServices.GetInformationbyAccountname(x.AccountName);
                return new CommentViewModel
                {
                    Id = x.Id,
                    User=userComment,
                    Content = x.Content,
                    CountRetweet = 0,
                    CountSend = 0,
                    CountComment = countComment,
                    Like = reaction,
                    Media = media
                };
            });

            return (await Task.WhenAll(tasklistcomment)).ToList();
        }
    }
}