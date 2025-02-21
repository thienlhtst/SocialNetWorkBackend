using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApplication.ViewModel.Enum;

namespace UserApplication.ViewModel.UserViewModel
{
    public class UserSreachVM
    {
        public string FullName { get; set; } = "";
        public string AccountName { get; set; } = "";
        public string Title { get; set; } = "";
        public string UrlAvatar { get; set; } = "";
        public int Followers { get; set; }
        public statusFollow IsFollow { get; set; }
    }
}