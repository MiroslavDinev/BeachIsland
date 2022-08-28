namespace BeachIsland.Server.Infrastructure
{
    using BeachIsland.Server.Data;
    using Microsoft.EntityFrameworkCore;

    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetService<BeachIslandDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
