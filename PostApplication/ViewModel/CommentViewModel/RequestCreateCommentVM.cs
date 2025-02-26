using PostApplication.ViewModel.MediaViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostApplication.ViewModel.CommentViewModel
{
    public class RequestCreateCommentVM
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string ParentId { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public List<CreateMediaViewModel> Medias { get; set; } = new List<CreateMediaViewModel>();
    }
}