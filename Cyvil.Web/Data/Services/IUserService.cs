using System.Security.Claims;
using Cyvil.Web.Models;

namespace Cyvil.Web.Data.Services
{
    public interface IUserService
    {
        UserModel GetUserModel(string userId);
        Task CreateSuperUserAsync();
        string GetCurrentUserId(ClaimsPrincipal User);
    }
}