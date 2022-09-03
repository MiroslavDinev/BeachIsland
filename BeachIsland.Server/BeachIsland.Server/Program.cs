using Microsoft.EntityFrameworkCore;

using BeachIsland.Server.Data;
using BeachIsland.Server.Infrastructure;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var appSettings = builder.Services.GetAppSettings(builder.Configuration);

builder.Services.AddDbContext<BeachIslandDbContext>(options =>
    options.UseSqlServer(connectionString))
    .AddIdentity()
    .AddJwtAuthentication(appSettings)
    .AddApplicationServices();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseCors(myAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.ApplyMigrations();

app.Run();
