

using Sagicor.Access.Application.Models.Identity;

namespace Sagicor.Access.Application.Contracts.Identity;

public interface IUserService
{
    Task<List<User>> GetUsers();
    Task<User> GetUser(string userId);
    public string UserId { get; }
}
