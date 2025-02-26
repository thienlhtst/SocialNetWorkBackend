using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApplication.ViewModel.UserViewModel
{
    public class RequestUpdateUserVM
    {
        public string FullName { get; set; } = string.Empty;
        public string AcountName { get; set; } = string.Empty;

        // string Email { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;

        public string Links { get; set; } = string.Empty;
        public bool AccountPrivated { get; set; } = false;
    }
}