using Microsoft.AspNetCore.Identity;
using MyHome.Application.Models;
using MyHome.Application.Services.Abstraction.UserAggregate;
using MyHome.Domain.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Services.Implementatioon.UserAggregate
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleService(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> CreateRole(RoleTypeDto input)
        {
            var role = await _roleManager.FindByNameAsync(input.RoleType.ToString());
            if (role == null)
                return await _roleManager.CreateAsync(new AppRole() { Name = input.RoleType.ToString() });
            else
                return IdentityResult.Failed(new IdentityError() { Description = "Role already exsists!" });
        }

    }
}
