using PostCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostApplication.ViewModel.CommentViewModel
{
    public class UserComment
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public int Followers { get; set; }
        public string Avatar { get; set; }
    }

    public class LikeCommentViewModel
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public bool IsLiked { get; set; }

        public int Count { get; set; }
    }

    public class CommentViewModel
    {
        public string Id { get; set; }
        public UserComment? User { get; set; }
        public string Content { get; set; }
        public string TimePost { get; set; }
        public List<Media>? Media { get; set; }
        public LikeCommentViewModel Like { get; set; }
        public int CountComment { get; set; }
        public int CountRetweet { get; set; }
        public int CountSend { get; set; }
    }
}