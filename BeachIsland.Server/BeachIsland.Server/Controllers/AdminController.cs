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
        private readonly IAdminService adminService;

        public AdminController(IIslandService islandService, IAdminService adminService)
        {
            this.islandService = islandService;
            this.adminService = adminService;
        }

        [HttpGet(nameof(AllIslands))]
        public IslandAdminListDto[] AllIslands()
        {
            return this.islandService.AllAdminIslands();
        }

        [HttpPost("ChangeIslandStatus/{id}")]
        public async Task<ActionResult> ChangeIslandStatus(int id)
        {
            var changed = await this.adminService.ChangeIslandStatus(id);

            if (!changed)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
