using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApplication.ViewModel.UserViewModel
{
    public class RequestUpdateAvatarUserVM
    {
        public IFormFile file { get; set; }
    }
}