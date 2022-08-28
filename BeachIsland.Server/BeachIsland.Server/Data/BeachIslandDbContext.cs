namespace BeachIsland.Server.Data
{
    using BeachIsland.Server.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class BeachIslandDbContext : IdentityDbContext<User>
    {
        public BeachIslandDbContext(DbContextOptions<BeachIslandDbContext> options)
            : base(options)
        {
        }
    }
}