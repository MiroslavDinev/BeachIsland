namespace BeachIsland.Server.Data
{
    using System.Reflection;
    using BeachIsland.Server.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class BeachIslandDbContext : IdentityDbContext<User>
    {
        public BeachIslandDbContext(DbContextOptions<BeachIslandDbContext> options)
            : base(options)
        {

        }
        public DbSet<Partner> Partners { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}