namespace BeachIsland.Server.Infrastructure
{
    using System.Security.Claims;

    public static class IdentityExtensions
    {
        public static string GetId(this ClaimsPrincipal user)
        {
            var userId = user.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)
                ?.Value;

            return userId;
        }
    }
}
