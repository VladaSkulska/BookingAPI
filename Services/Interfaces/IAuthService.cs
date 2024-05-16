using BookingServiceAPI.Models.DTOs.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace BookingServiceAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task RegisterUserAsync(RegisterModel model);
        Task<JwtSecurityToken> LoginAsync(string username, string password);
    }
}