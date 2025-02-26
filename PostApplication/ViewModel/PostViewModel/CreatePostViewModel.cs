using PostApplication.ViewModel.MediaViewModel;
using PostApplication.ViewModel.TopicViewModel;
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
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Content { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
        public Privacy Privacy { get; set; } = Privacy.Public;
        public List<string> listTopic { get; set; }

        public List<CreateMediaViewModel> Medias { get; set; } = new List<CreateMediaViewModel>();
    }
}