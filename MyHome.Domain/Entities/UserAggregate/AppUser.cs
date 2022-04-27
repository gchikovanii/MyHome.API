using Microsoft.AspNetCore.Identity;
using MyHome.Domain.Entities.AdvertisementAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Domain.Entities.UserAggregate
{
    public class AppUser : IdentityUser<int>
    {
        public ICollection<AppUserRole>? AppUserRoles { get; set; }
        public ICollection<Advertisement>? Advertisements { get; set; }
    }
}
