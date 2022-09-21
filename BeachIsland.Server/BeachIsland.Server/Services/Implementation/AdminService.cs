namespace BeachIsland.Server.Services.Implementation
{
    using BeachIsland.Server.Data;
    using BeachIsland.Server.Services.Interfaces;
    using static WebConstants;

    public class AdminService : IAdminService
    {
        private readonly BeachIslandDbContext data;

        public AdminService(BeachIslandDbContext data)
        {
            this.data = data;
        }
        public bool isAdmin(string userId)
        {
            var userRolesIds = this.data.UserRoles
                .Where(x => x.UserId == userId)
                .Select(x => x.RoleId)
                .ToArray();

            var isAdmin = false;

            if (userRolesIds.Any())
            {
                isAdmin = this.data.Roles
                    .Any(x => x.Name == AdministratorRoleName && userRolesIds.Contains(x.Id));
            }

            return isAdmin;
        }

        public async Task<bool> ChangeStatus(int islandId)
        {
            var island = this.data.Islands.Find(islandId);

            if (island == null)
            {
                return false;
            }
            else if (island.IsDeleted)
            {
                return false;
            }

            island.IsPublic = !island.IsPublic;

            await this.data.SaveChangesAsync();

            return true;
        }
    }
}
