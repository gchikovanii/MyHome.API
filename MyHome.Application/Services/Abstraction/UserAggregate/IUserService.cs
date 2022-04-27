using MyHome.Application.Models;
using MyHome.Application.Models.IdentityUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Services.Abstraction
{
    public interface IUserService
    {
        Task CreateAdminUser(CreateUserDto input);
        Task CreateSuperVisor(CreateUserDto input);
        Task CreateUser(CreateUserDto input);
        Task DeleteUser(DeleteUserDto input);
        Task ChangeUserName(UpdateUserNameDto input);
        Task<bool> ChangeUserEmail(UpdateUserEmailDto input);
    }
}
