namespace BeachIsland.Server.Services.Interfaces
{
    using System.Threading.Tasks;

    public interface IAdminService
    {
        Task<bool> ChangeIslandStatus(int islandId);
        bool isAdmin(string userId);
    }
}