namespace BeachIsland.Server.Services.Interfaces
{
    using System.Threading.Tasks;
    using BeachIsland.Server.Models.Identity;

    public interface IIdentityService
    {
        string GenerateJwtToken(string userId, string username, string secret, bool isAdmin);
        ProfileResponseDto GetProfile(string userId);
        Task<bool> UpdateProfile(ProfileUpdateRequestDto profileUpdateRequestDto, string userId);
    }
}
