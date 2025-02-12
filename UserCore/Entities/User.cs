using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCore.Entities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public string Title { get; set; } = string.Empty;
        public string Links { get; set; } = string.Empty;
        public bool Active { get; set; } = true;
        public bool AccountPrivated { get; set; } = false;
        public bool AccountConfirmed { get; set; } = false;
        public string UrlAvatar { get; set; } = string.Empty;
        public ICollection<Follow> Followers { get; set; } // Những người theo dõi
        public ICollection<Follow> Followees { get; set; } // Những người được theo dõi
    }
}