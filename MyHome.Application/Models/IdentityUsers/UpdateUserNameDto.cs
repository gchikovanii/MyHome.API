using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Models.IdentityUsers
{
    public class UpdateUserNameDto
    {
        public string? NewUserName { get; set; }
        public string? Email { get; set; }
    }
}
