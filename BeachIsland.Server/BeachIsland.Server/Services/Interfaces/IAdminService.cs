namespace BeachIsland.Server.Services.Interfaces
{
    using System.Threading.Tasks;

    public interface IAdminService
    {
        Task<bool> ChangeStatus(int islandId);
        bool isAdmin(string userId);
    }
}