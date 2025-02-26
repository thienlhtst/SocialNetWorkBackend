using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostCore.Entities
{
    public class TopicPost
    {
        public string PostId { get; set; } = string.Empty;
        public string TopicId { get; set; } = string.Empty;
        public Posts Posts { get; set; }
        public Topic Topic { get; set; }
    }
}