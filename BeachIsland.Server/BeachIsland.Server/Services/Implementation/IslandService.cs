namespace BeachIsland.Server.Services.Implementation
{
    using System.Threading.Tasks;
    using BeachIsland.Server.Data;
    using BeachIsland.Server.Data.Models.Islands;
    using BeachIsland.Server.Enums;
    using BeachIsland.Server.Models.Islands;
    using BeachIsland.Server.Services.Interfaces;

    public class IslandService : IIslandService
    {
        private readonly BeachIslandDbContext data;
        private readonly IImageService imageService;

        public IslandService(BeachIslandDbContext data, IImageService imageService)
        {
            this.data = data;
            this.imageService = imageService;
        }
        public async Task<int> AddAsync(AddIslandDto addIslandDto, int partnerId)
        {
            var island = new Island(addIslandDto.Name, addIslandDto.Location, addIslandDto.Description, addIslandDto.Size, addIslandDto.Price, addIslandDto.FileType, addIslandDto.PopulationSizeId, addIslandDto.IslandRegionId, partnerId);

            await this.data.Islands.AddAsync(island);

            await this.data.SaveChangesAsync();

            return island.Id;
        }

        public List<IslandListItemDto> AllIslands()
        {
            var islands = this.data.Islands
                .Where(x =>x.IsDeleted == false)
                .Select(x => new IslandListItemDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Location = x.Location,
                    IsPublic = x.IsPublic,
                    Price = x.Price,
                    SizeInSquareKm = x.SizeInSquareKm,
                    FileType = x.FileType
                })
                .ToList();

            foreach (var island in islands)
            {
                var bytes = this.imageService.GetImage(island.Id, island.FileType, ImageCategory.Islands);

                var imageBase64String = Convert.ToBase64String(bytes);

                island.ImageUrl = imageBase64String;
            }

            return islands;
        }
    }
}
