using Microsoft.AspNetCore.Identity;
using MyHome.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Services.Abstraction.UserAggregate
{
    public interface IRoleService
    {
        Task<IdentityResult> CreateRole(RoleTypeDto input);
    }
}
