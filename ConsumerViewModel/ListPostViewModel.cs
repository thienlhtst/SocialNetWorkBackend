using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerViewModel
{
    public class MediaEvent
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string ParentId { get; set; }
        public string MediaName { get; set; } = string.Empty;
        public bool MediaType { get; set; }
        public string Url { get; set; } = string.Empty;
        public double? Width { get; set; }
        public double? Height { get; set; }
    }

    public class UserPostsEvent
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public int Followers { get; set; }
        public string Avatar { get; set; }
    }

    public class LikeViewModelEvent
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public bool IsLiked { get; set; }

        public int Count { get; set; }
    }

    public class PostViewModelEvent
    {
        public string Id { get; set; }
        public UserPostsEvent? User { get; set; }
        public string Content { get; set; }
        public string TimePost { get; set; }
        public List<MediaEvent>? Media { get; set; }
        public LikeViewModelEvent Like { get; set; }
        public int CountComment { get; set; }
        public int CountRetweet { get; set; }
        public int CountSend { get; set; }
    }
}