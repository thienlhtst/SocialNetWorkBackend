using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostCore.Entities
{
    public class Topic
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int CountTopic { get; set; } = 0;
        public List<TopicUser> TopicUsers { get; set; } = new List<TopicUser>();
        public List<TopicPost> TopicPosts { get; set; } = new List<TopicPost>();
    }
}