using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostCore.Entities
{
    public class UserPostViews
    {
        public string PostId { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
        public int Count { get; set; }
        public Posts Posts { get; set; } = new Posts();
    }
}