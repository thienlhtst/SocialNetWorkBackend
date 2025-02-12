using PostCore.Entities;
using PostCore.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostApplication.ViewModel.MediaViewModel
{
    public class CreateMediaViewModel
    {
        public string MediaName { get; set; } = string.Empty;
        public MediaType MediaType { get; set; }
        public string Url { get; set; } = string.Empty;
        public double Width { get; set; }
        public double Height { get; set; }
    }
}
