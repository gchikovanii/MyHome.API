using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Models.IdentityUsers
{
    public class UpdateUserEmailDto
    {
        public int Id { get; set; }
        public string? NewEmail { get; set; }
    }
}
