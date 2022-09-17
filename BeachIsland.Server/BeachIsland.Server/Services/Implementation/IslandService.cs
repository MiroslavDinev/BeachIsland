namespace BeachIsland.Server.Services.Implementation
{
    using System.Threading.Tasks;
    using BeachIsland.Server.Data;
    using BeachIsland.Server.Data.Models.Islands;
    using BeachIsland.Server.Enums;
    using BeachIsland.Server.Models.Islands;
    using BeachIsland.Server.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class IslandService : IIslandService
    {
        private readonly BeachIslandDbContext data;
        private readonly IImageService imageService;

        public IslandService(BeachIslandDbContext data, IImageService imageService)
        {
            this.data = data;
            this.imageService = imageService;
        }
        public async Task<int> AddAsync(IslandAddDto addIslandDto, int partnerId)
        {
            var island = new Island(addIslandDto.Name, addIslandDto.Location, addIslandDto.Description, addIslandDto.Size, addIslandDto.Price, addIslandDto.FileType, addIslandDto.PopulationSizeId, addIslandDto.IslandRegionId, partnerId);

            await this.data.Islands.AddAsync(island);

            await this.data.SaveChangesAsync();

            return island.Id;
        }

        public IslandListItemDto[] AllIslands()
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
                    Size = x.SizeInSquareKm,
                    FileType = x.FileType
                })
                .ToList();

            foreach (var island in islands)
            {
                var bytes = this.imageService.GetImage(island.Id, island.FileType, ImageCategory.Islands);

                var imageBase64String = Convert.ToBase64String(bytes);

                island.ImageUrl = imageBase64String;
            }

            return islands.ToArray();
        }

        public IslandDetailsDto Details(int id)
        {
            var island = this.data.Islands
                .Where(x => x.Id == id && x.IsDeleted == false)
                .Select(x => new IslandDetailsDto
                {
                    Id = x.Id,
                    Description = x.Description,
                    IslandRegionId = x.IslandRegionId,
                    IslandRegionName = x.IslandRegion.Name,
                    PopulationSizeId = x.PopulationSizeId,
                    PopulationSizeName = x.PopulationSize.Name,
                    Location = x.Location,
                    Name = x.Name,
                    Price = x.Price,
                    Size = x.SizeInSquareKm,
                    FileType = x.FileType
                })
                .FirstOrDefault();

            if(island != null)
            {
                var bytes = this.imageService.GetImage(id, island.FileType, ImageCategory.Islands);

                var imageBase64String = Convert.ToBase64String(bytes);

                island.ImageUrl = imageBase64String;

                return island;
            }

            return null;
        }

        public async Task<bool> Update(IslandEditDto islandEditDto, int partnerId)
        {
            var island = await this.data.Islands
                .Where(x => x.Id == islandEditDto.Id && x.PartnerId == partnerId)
                .FirstOrDefaultAsync();

            if(island == null)
            {
                return false;
            }

            island.Name = islandEditDto.Name;
            island.Location = islandEditDto.Location;
            island.Description = islandEditDto.Description;
            island.Price = islandEditDto.Price;
            island.SizeInSquareKm = islandEditDto.Size;
            island.FileType = islandEditDto.FileType;
            island.IslandRegionId = islandEditDto.IslandRegionId;
            island.PopulationSizeId = islandEditDto.PopulationSizeId;

            await this.data.SaveChangesAsync();

            return true;
        }

        public PopulationSizesDto[] IslandSizes()
        {
            var sizes = this.data.PopulationSizes
                .Select(x => new PopulationSizesDto
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToArray();

            return sizes;
        }

        public RegionsDto[] IslandRegions()
        {
            var regions = this.data.IslandRegions
                .Select(x => new RegionsDto
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToArray();

            return regions;
        }

        public async Task<bool> Delete(int id, int partnerId)
        {
            var island = await this.data.Islands
                .Where(x => x.Id == id && x.PartnerId == partnerId && x.IsDeleted == false)
                .FirstOrDefaultAsync();

            if(island == null)
            {
                return false;
            }

            island.IsDeleted = true;
            await this.data.SaveChangesAsync();

            return true;
        }
    }
}
