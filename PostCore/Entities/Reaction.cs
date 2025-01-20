using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostCore.Entities
{
    public class Reaction
    {
        public string UserId { get; set; } = string.Empty;
        public string PostIdOrCommentId { get; set; } = string.Empty;
    }
}
