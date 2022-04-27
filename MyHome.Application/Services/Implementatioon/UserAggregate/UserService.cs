using Microsoft.AspNetCore.Identity;
using MyHome.Application.Constants;
using MyHome.Application.Models;
using MyHome.Application.Models.IdentityUsers;
using MyHome.Application.Services.Abstraction;
using MyHome.Domain.Entities.UserAggregate;
using MyHome.Infrastructure.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Application.Services.Implementatioon
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<AppUser> _userManager;


        public UserService(UserManager<AppUser> userManager, IUserRepository userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }


        //Create Admin User
        public async Task CreateAdminUser(CreateUserDto input)
        {
            var adminEmailExsits = await _userManager.FindByEmailAsync(input.Email);
            var adminNameExsits = await _userManager.FindByNameAsync(input.UserName);
            if(adminEmailExsits == null && adminNameExsits == null)
            {
                var currentUser = new AppUser()
                {
                    UserName = input.UserName,
                    Email = input.Email,
                    PhoneNumber = input.Phone
                };
                var createdUser = await _userManager.CreateAsync(currentUser, input.Password);
                if (createdUser.Succeeded)
                    await _userManager.AddToRoleAsync(currentUser, RoleType.Admin.ToString());
            }
            else if(adminEmailExsits == null && adminNameExsits != null)
            {
                IdentityResult.Failed(new IdentityError() { Description = "Admin with this name already exists!" });
            }
            else if (adminEmailExsits != null && adminNameExsits == null)
            {
                IdentityResult.Failed(new IdentityError() { Description = "Email is already in Use!" });
            }
            else
            {
                IdentityResult.Failed();
            }
        }

        //Create SuperVisor
        public async Task CreateSuperVisor(CreateUserDto input)
        {
            var superVisorEmailExsits = _userManager.FindByEmailAsync(input.Email);
            var superVisorNameExsits = _userManager.FindByNameAsync(input.UserName);
            if(superVisorEmailExsits == null && superVisorNameExsits == null)
            {
                var newUser = new AppUser()
                {
                    UserName = input.UserName,
                    Email = input.Email,
                    PhoneNumber = input.Phone
                };
                var currentUser = await _userManager.CreateAsync(newUser, input.Password);
                if (currentUser.Succeeded)
                    await _userManager.AddToRoleAsync(newUser, RoleType.Supervisor.ToString());
            }
            else if (superVisorEmailExsits == null && superVisorNameExsits != null)
            {
                IdentityResult.Failed(new IdentityError() { Description = "SuperVisor with this name already exists!" });
            }
            else if (superVisorEmailExsits != null && superVisorNameExsits == null)
            {
                IdentityResult.Failed(new IdentityError() { Description = "Email is already in Use!" });
            }
            else
            {
                IdentityResult.Failed();
            }
        }

        //Create User
        public async Task CreateUser(CreateUserDto input)
        {
            var userEmailExits = await _userManager.FindByEmailAsync(input.Email);
            var userNameExists = await _userManager.FindByNameAsync(input.UserName);

            if(userEmailExits == null && userNameExists == null)
            {
                var newUser = new AppUser()
                {
                    Email = input.Email,
                    UserName = input.UserName,
                    PhoneNumber = input.Phone

                };
                var currentUser = await _userManager.CreateAsync(newUser, input.Password);
                if (currentUser.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, RoleType.User.ToString());
                }
            }
            else if (userEmailExits == null && userNameExists != null)
            {
                IdentityResult.Failed(new IdentityError() { Description = "UserName isn't free" });
            }
            else if (userEmailExits != null && userNameExists == null)
            {
                IdentityResult.Failed(new IdentityError() { Description = "Email is already in Use!" });
            }
            else
            {
                IdentityResult.Failed();
            }

        }

        //Delete Users
        public async Task DeleteUser(DeleteUserDto input)
        {
            var userExist = await _userManager.FindByEmailAsync(input.Email);
            if(userExist != null)
            {
                await _userManager.DeleteAsync(userExist);
            }
            else
            {
                IdentityResult.Failed(new IdentityError() { Description = "User with this email doesn't exists!"});
            }
        }

        //Update User Name
        public async Task ChangeUserName(UpdateUserNameDto input)
        {
            var userExists = await _userManager.FindByEmailAsync(input.Email);
            if(userExists != null)
            {
                if(input.NewUserName != null)
                {
                    var userNameExists = await _userManager.FindByNameAsync(input.NewUserName);
                    if (userNameExists == null)
                    {
                        userExists.UserName = input.NewUserName;
                        _userRepository.Update(userExists);
                        await _userRepository.SaveChangesAsync();

                    }
                    else
                    {
                        IdentityResult.Failed(new IdentityError() { Description = "User Name already in use!" });
                    }
                }
                else
                {
                    IdentityResult.Failed(new IdentityError() { Description = "User Name can't be empty!" });
                }
            }
            else
            {
                IdentityResult.Failed(new IdentityError() { Description = "User with this email doesn't exists!" });
            }
        }

        //Update User Email
        public async Task<bool> ChangeUserEmail(UpdateUserEmailDto input)
        {
            var user = _userRepository.GetQuery(i => i.Id == input.Id).SingleOrDefault();
            _userRepository.Update(user);
            user.Email = input.NewEmail;
            return await _userRepository.SaveChangesAsync();
        }

    }
}
