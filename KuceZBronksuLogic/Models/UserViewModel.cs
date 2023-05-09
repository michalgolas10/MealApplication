using KuceZBronksuDAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuceZBronksuBLL.Models
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; } 
        public List<string> Roles { get; set; }
        public bool EmailConfirmed { get; set; }
    }
}
