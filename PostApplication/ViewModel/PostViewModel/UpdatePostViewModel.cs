﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostApplication.ViewModel.PostViewModel
{
    public class UpdatePostViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}
