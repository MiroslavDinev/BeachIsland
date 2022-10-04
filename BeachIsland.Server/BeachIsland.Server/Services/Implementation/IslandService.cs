namespace BeachIsland.Server.Services.Implementation
{
    using System.Threading.Tasks;
    using BeachIsland.Server.Data;
    using BeachIsland.Server.Data.Models.Islands;
    using BeachIsland.Server.Enums;
    using BeachIsland.Server.Models.Islands;
    using BeachIsland.Server.Models.Islands.Admin;
    using BeachIsland.Server.Services.Interfaces;

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

        public IslandListItemDto[] AllIslands(string searchValue)
        {
            var islandsQuery = this.data.Islands
                .Where(x => x.IsDeleted == false && x.IsPublic == true)
                .Select(x => new IslandListItemDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Location = x.Location,
                    IsPublic = x.IsPublic,
                    Price = x.Price,
                    Size = x.SizeInSquareKm,
                    FileType = x.FileType
                });

            if (!string.IsNullOrEmpty(searchValue))
            {
                islandsQuery = islandsQuery
                    .Where(x=> x.Name.ToUpper().Contains(searchValue.ToUpper()) 
                    || x.Location.ToLower().Contains(searchValue.ToUpper()));
            }

            var result = islandsQuery.OrderByDescending(x => x.Id).ToArray();

            foreach (var island in result)
            {
                var bytes = this.imageService.GetImage(island.Id, island.FileType, ImageCategory.Islands);

                var imageBase64String = Convert.ToBase64String(bytes);

                island.ImageUrl = imageBase64String;
            }

            return result;
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
                    FileType = x.FileType,
                    IsPublic = x.IsPublic
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

        public async Task<bool> Update(IslandEditDto islandEditDto, int partnerId, bool isAdmin)
        {
            var island = await this.data.Islands
                .Where(x => x.Id == islandEditDto.Id && (x.PartnerId == partnerId || isAdmin))
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
            island.IslandRegionId = islandEditDto.IslandRegionId;
            island.PopulationSizeId = islandEditDto.PopulationSizeId;
            island.IsPublic = isAdmin;

            if(islandEditDto.FileType != null)
            {
                island.FileType = islandEditDto.FileType;
            }           

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

        public async Task<bool> Delete(int id, int partnerId, bool isAdmin)
        {
            var island = await this.data.Islands
                .Where(x => x.Id == id && x.IsDeleted == false && (x.PartnerId == partnerId || isAdmin))
                .FirstOrDefaultAsync();

            if(island == null)
            {
                return false;
            }

            island.IsDeleted = true;
            await this.data.SaveChangesAsync();

            return true;
        }

        public IslandAdminListDto[] AllAdminIslands()
        {
            var islands = this.data.Islands
                .Where(x => x.IsDeleted == false && x.IsPublic == false)
                .Select(x => new IslandAdminListDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsPublic = x.IsPublic,
                    FileType = x.FileType,
                    Description = x.Description,
                    PartnerName = x.Partner.Name
                })
                .OrderBy(x => x.Id)
                .ToList();

            foreach (var island in islands)
            {
                var bytes = this.imageService.GetImage(island.Id, island.FileType, ImageCategory.Islands);

                var imageBase64String = Convert.ToBase64String(bytes);

                island.ImageUrl = imageBase64String;
            }

            return islands.ToArray();
        }

        public PartnerOwnIslandsDto[] GetPartnerIslands(int partnerId)
        {
            var partnerIslands = this.data.Islands
                .Where(x => x.PartnerId == partnerId && x.IsDeleted == false)
                .Select(x => new PartnerOwnIslandsDto
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
                    FileType = x.FileType,
                    IsPublic = x.IsPublic,
                })
                .OrderByDescending(x => x.Id)
                .ToArray();

            if (partnerIslands.Any())
            {
                foreach (var island in partnerIslands)
                {
                    var bytes = this.imageService.GetImage(island.Id, island.FileType, ImageCategory.Islands);

                    var imageBase64String = Convert.ToBase64String(bytes);

                    island.ImageUrl = imageBase64String;
                }
            }

            return partnerIslands;
        }
    }
}
