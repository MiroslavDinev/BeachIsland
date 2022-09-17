namespace BeachIsland.Server.Services.Interfaces
{
    using BeachIsland.Server.Models.Islands;

    public interface IIslandService
    {
        Task<int> AddAsync(IslandAddDto addIslandDto, int partnerId);
        IslandListItemDto[] AllIslands();
        Task<bool> Delete(int id, int partnerId);
        IslandDetailsDto Details(int id);
        RegionsDto[] IslandRegions();
        PopulationSizesDto[] IslandSizes();
        Task<bool> Update(IslandEditDto islandEditDto, int partnerId);
    }
}
