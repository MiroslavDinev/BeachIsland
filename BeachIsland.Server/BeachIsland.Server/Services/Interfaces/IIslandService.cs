namespace BeachIsland.Server.Services.Interfaces
{
    using BeachIsland.Server.Models.Islands;

    public interface IIslandService
    {
        Task<int> AddAsync(AddIslandDto addIslandDto, int partnerId);
        List<IslandListItemDto> AllIslands();
    }
}
