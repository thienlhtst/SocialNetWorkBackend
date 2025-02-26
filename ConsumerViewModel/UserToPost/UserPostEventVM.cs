using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerViewModel.UserToPost
{
    public class UserPostEventVM
    {
        public string Id { get; set; }
        public string AccountName { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public int Followers { get; set; }
        public string Avatar { get; set; }
    }
}