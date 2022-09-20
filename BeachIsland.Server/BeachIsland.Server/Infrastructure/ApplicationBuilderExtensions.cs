namespace BeachIsland.Server.Infrastructure
{
    using BeachIsland.Server.Data;
    using BeachIsland.Server.Data.Models;
    using BeachIsland.Server.Data.Models.Islands;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using static WebConstants;

    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetService<BeachIslandDbContext>();

            dbContext.Database.Migrate();

            SeedPopulationSize(dbContext);
            SeedRegions(dbContext);
            SeedAdministrator(services.ServiceProvider);
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

        private static void SeedAdministrator(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(AdministratorRoleName))
                {
                    return;
                }

                var role = new IdentityRole { Name = AdministratorRoleName };
                await roleManager.CreateAsync(role);

                const string adminEmail = "admin.dreamisland@dir.bg";
                const string adminPassword = "admin123!321!";

                var user = new User
                {
                    Email = adminEmail,
                    UserName = adminEmail,
                    Nickname = "Admin"
                };

                await userManager.CreateAsync(user, adminPassword);
                await userManager.AddToRoleAsync(user, role.Name);

            })
                .GetAwaiter()
                .GetResult();
        }
    }
}
