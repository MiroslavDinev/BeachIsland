namespace BeachIsland.Server.Services.Interfaces
{
    using BeachIsland.Server.Models.Islands;
    using BeachIsland.Server.Models.Islands.Admin;

    public interface IIslandService
    {
        Task<int> AddAsync(IslandAddDto addIslandDto, int partnerId);
        IslandAdminListDto[] AllAdminIslands();
        IslandListItemDto[] AllIslands(string searchValue);
        Task<bool> Delete(int id, int partnerId, bool isAdmin);
        IslandDetailsDto Details(int id);
        PartnerOwnIslandsDto[] GetPartnerIslands(int partnerId);
        RegionsDto[] IslandRegions();
        PopulationSizesDto[] IslandSizes();
        Task<bool> Update(IslandEditDto islandEditDto, int partnerId, bool isAdmin);
    }
}
