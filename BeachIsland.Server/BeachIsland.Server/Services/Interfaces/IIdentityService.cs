namespace BeachIsland.Server.Services.Interfaces
{
    public interface IIdentityService
    {
        string GenerateJwtToken(string userId, string username, string secret);
    }
}
