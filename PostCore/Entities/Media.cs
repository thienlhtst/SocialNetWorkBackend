using PostCore.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PostCore.Entities
{
    public class Media
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string ParentId { get; set; }
        public string MediaName { get; set; } = string.Empty;
        public MediaType MediaType { get; set; }
        public string Url { get; set; } = string.Empty;
        public double? Width { get; set; }
        public double? Height { get; set; }
    }
}