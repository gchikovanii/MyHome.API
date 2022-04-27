using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHome.API.Constants;
using MyHome.Application.Models;
using MyHome.Application.Models.IdentityUsers;
using MyHome.Application.Services.Abstraction;
using MyHome.Application.Services.Abstraction.UserAggregate;

namespace MyHome.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        public UserController(IRoleService roleService, IUserService userService)
        {
            _roleService = roleService;
            _userService = userService;
        }

        [HttpPost(nameof(CreateUserRole))]
        [Authorize(Roles = UserType.Admin)]

        public async Task<IActionResult> CreateUserRole([FromForm]RoleTypeDto input)
        {
            var result = await _roleService.CreateRole(input);
            if (result.Succeeded)
                return Ok();
            else
                return BadRequest();
        }


        [HttpPost(nameof(CreateAdmin))]
        [Authorize(Roles = UserType.Admin)]

        public async Task<IActionResult> CreateAdmin(CreateUserDto input)
        {
            await _userService.CreateAdminUser(input);
            return Ok();
        }
        [HttpPost(nameof(CreateSuperVisor))]
        [Authorize(Roles = UserType.Admin)]

        public async Task<IActionResult> CreateSuperVisor(CreateUserDto input)
        {
            await _userService.CreateSuperVisor(input);
            return Ok();
        }
        [HttpPost(nameof(CreateUser))]
        [Authorize(Roles = UserType.AdminSuperVisor)]

        public async Task<IActionResult> CreateUser(CreateUserDto input)
        {
            await _userService.CreateUser(input);
            return Ok();
        }

        [HttpPut(nameof(ChangeUserName))]
        [Authorize(Roles = UserType.AdminSuperVisor)]

        public async Task<IActionResult> ChangeUserName(UpdateUserNameDto input)
        {
            await _userService.ChangeUserName(input);
            return Ok();
        }

        [HttpPut(nameof(ChangeUserEmail))]
        [Authorize(Roles = UserType.User)]

        public async Task<IActionResult> ChangeUserEmail(UpdateUserEmailDto input)
        {
            await _userService.ChangeUserEmail(input);
            return Ok();
        }
        [HttpDelete(nameof(DeleteUser))]
        [Authorize(Roles = UserType.AdminSuperVisor)]

        public async Task<IActionResult> DeleteUser(DeleteUserDto input)
        {
            await _userService.DeleteUser(input);
            return Ok();
        }



    }
}
