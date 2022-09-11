namespace BeachIsland.Server.Data
{
    using System.Reflection;
    using BeachIsland.Server.Data.Models;
    using BeachIsland.Server.Data.Models.Islands;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class BeachIslandDbContext : IdentityDbContext<User>
    {
        public BeachIslandDbContext(DbContextOptions<BeachIslandDbContext> options)
            : base(options)
        {

        }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Island> Islands { get; set; }
        public DbSet<PopulationSize> PopulationSizes { get; set; }
        public DbSet<IslandRegion> IslandRegions { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}