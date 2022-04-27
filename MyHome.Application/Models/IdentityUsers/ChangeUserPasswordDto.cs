using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Models.IdentityUsers
{
    public class ChangeUserPasswordDto
    {
        public string? Email { get; set; }
        public string? NewPassword { get; set; }
    }
}
