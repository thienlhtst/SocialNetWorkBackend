using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostCore.Entities
{
    public class Media
    {
        public string Id { get; set; } = string.Empty;
        public string PostId { get; set; } = string.Empty;
        public string MediaName { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public double Width { get; set; }
        public double Height { get; set; }
    }
}
