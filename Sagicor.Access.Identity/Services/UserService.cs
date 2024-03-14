using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Sagicor.Access.Application.Contracts.Identity;
using Sagicor.Access.Application.Models.Identity;
using Sagicor.Access.Identity.Models;
using System.Security.Claims;

namespace Sagicor.Access.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserService(UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }




        public async Task<User> GetUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return new User
            {
                Email = user.Email,
                Id = user.Id,
                Firstname = user.FirstName,
                Lastname = user.LastName
            };
        }

        public async Task<List<User>> GetUsers()
        {
            var users = await _userManager.GetUsersInRoleAsync("Reader");
            return users.Select(q => new User
            {
                Id = q.Id,
                Email = q.Email,
                Firstname = q.FirstName,
                Lastname = q.LastName
            }).ToList();
        }


        public string UserId { get => _contextAccessor.HttpContext?.User?.FindFirstValue("uid"); }



    }
}
