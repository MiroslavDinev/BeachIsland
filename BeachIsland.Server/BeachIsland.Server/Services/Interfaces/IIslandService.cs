namespace BeachIsland.Server.Services.Interfaces
{
    using BeachIsland.Server.Models.Islands;
    using BeachIsland.Server.Models.Islands.Admin;

    public interface IIslandService
    {
        Task<int> AddAsync(IslandAddDto addIslandDto, int partnerId);
        IslandAdminListDto[] AllAdminIslands();
        IslandListItemDto[] AllIslands();
        Task<bool> Delete(int id, int partnerId);
        IslandDetailsDto Details(int id, bool isAdmin);
        RegionsDto[] IslandRegions();
        PopulationSizesDto[] IslandSizes();
        Task<bool> Update(IslandEditDto islandEditDto, int partnerId, bool isAdmin);
    }
}
