namespace BeachIsland.Server.Controllers
{
    using BeachIsland.Server.Models.Islands;
    using BeachIsland.Server.Models.Islands.Admin;
    using BeachIsland.Server.Services.Interfaces;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static WebConstants;

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = AdministratorRoleName)]
    public class AdminController : ApiController
    {
        private readonly IIslandService islandService;

        public AdminController(IIslandService islandService)
        {
            this.islandService = islandService;
        }

        [HttpGet(nameof(AllIslands))]
        public IslandAdminListDto[] AllIslands()
        {
            return this.islandService.AllAdminIslands();
        }
    }
}
