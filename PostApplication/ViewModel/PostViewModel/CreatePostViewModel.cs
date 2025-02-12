using PostApplication.ViewModel.MediaViewModel;
using PostCore.Entities;
using PostCore.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostApplication.ViewModel.PostViewModel
{
    public class CreatePostViewModel
    {
        public string Content { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
        public Privacy Privacy { get; set; } = Privacy.Public;
        public List<CreateMediaViewModel>? Medias { get; set; }
    }
}
