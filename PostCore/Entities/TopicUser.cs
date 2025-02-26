using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostCore.Entities
{
    public class TopicUser
    {
        public string AccountName { get; set; } = string.Empty;
        public string TopicId { get; set; } = string.Empty;
        public Topic Topic { get; set; }
    }
}