using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeyirAkademi_v1._1.Models
{
    public class UserDetail : IdentityUser
    {
        public string UserAd { get; set; }
        public string UserSoyad { get; set; }
    }
}
