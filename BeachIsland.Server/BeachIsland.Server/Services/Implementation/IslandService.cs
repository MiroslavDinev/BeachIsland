namespace BeachIsland.Server.Services.Implementation
{
    using System.Threading.Tasks;
    using BeachIsland.Server.Data;
    using BeachIsland.Server.Data.Models.Islands;
    using BeachIsland.Server.Models.Islands;
    using BeachIsland.Server.Services.Interfaces;

    public class IslandService : IIslandService
    {
        private readonly BeachIslandDbContext data;

        public IslandService(BeachIslandDbContext data)
        {
            this.data = data;
        }
        public async Task<int> AddAsync(AddIslandDto addIslandDto, int partnerId)
        {
            var island = new Island(addIslandDto.Name, addIslandDto.Location, addIslandDto.Description, addIslandDto.SizeInSquareKm, addIslandDto.Price, addIslandDto.FileType, addIslandDto.PopulationSizeId, addIslandDto.IslandRegionId, partnerId);

            await this.data.Islands.AddAsync(island);

            await this.data.SaveChangesAsync();

            return island.Id;
        }
    }
}
