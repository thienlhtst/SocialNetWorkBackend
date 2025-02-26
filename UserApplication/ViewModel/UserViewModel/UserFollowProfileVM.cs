using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApplication.ViewModel.UserViewModel
{
    public class UserFollowProfileVM
    {
        public string Src { get; set; }
        public string AccountName { get; set; }
        public string FullName { get; set; }
        public string Id { get; set; }
        public int IsFollow { get; set; }
    }
}