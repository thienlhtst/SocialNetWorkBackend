using ConsumerViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCore.Entities;

namespace UserApplication.ViewModel.UserViewModel
{
    public class ResponseInformationUserVM
    {
        public string Type { get; set; }
        public User InfoUser { get; set; }
        public List<PostViewModelEvent> PostViewModelEvent { get; set; }
    }
}