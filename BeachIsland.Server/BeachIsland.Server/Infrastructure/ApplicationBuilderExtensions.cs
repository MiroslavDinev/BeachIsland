namespace BeachIsland.Server.Infrastructure
{
    using BeachIsland.Server.Data;
    using BeachIsland.Server.Data.Models.Islands;
    using Microsoft.EntityFrameworkCore;

    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetService<BeachIslandDbContext>();

            dbContext.Database.Migrate();

            SeedPopulationSize(dbContext);
            SeedRegions(dbContext);
        }

        private static void SeedRegions(BeachIslandDbContext dbContext)
        {
            if (dbContext.IslandRegions.Any())
            {
                return;
            }

            dbContext.IslandRegions.AddRange(new[]
            {
                new IslandRegion {Name = "Africa"},
                new IslandRegion {Name = "Asia"},
                new IslandRegion {Name = "Canada"},
                new IslandRegion {Name = "Carribean"},
                new IslandRegion {Name = "Central America"},
                new IslandRegion {Name = "Europe"},
                new IslandRegion {Name = "South America"},
                new IslandRegion {Name = "South Pacific"},
                new IslandRegion {Name = "United States"}
            });

            dbContext.SaveChanges();
        }

        private static void SeedPopulationSize(BeachIslandDbContext dbContext)
        {
            if (dbContext.PopulationSizes.Any())
            {
                return;
            }

            dbContext.PopulationSizes.AddRange(new[]
            {
                new PopulationSize {Name = "Uninhabited"},
                new PopulationSize {Name = "Up to 10 persons"},
                new PopulationSize {Name = "Between 10 persons and 100 persons"},
                new PopulationSize {Name = "Between 100 persons and 1000 persons"},
                new PopulationSize {Name = "Between 1000 persons and 10000 persons"},
                new PopulationSize {Name = "Between 10000 persons and 100000 persons"},
                new PopulationSize {Name = "Between 100000 persons and 1000000 persons"},
                new PopulationSize {Name = "Over 1000000"}
            });

            dbContext.SaveChanges();
        }
    }
}
