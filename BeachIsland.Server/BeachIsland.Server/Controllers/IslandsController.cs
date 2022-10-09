namespace BeachIsland.Server.Controllers
{
    using BeachIsland.Server.Extensions;
    using BeachIsland.Server.Infrastructure;
    using BeachIsland.Server.Models.Islands;
    using BeachIsland.Server.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using BeachIsland.Server.Enums;
    using BeachIsland.Server.Infrastructure.Exceptions;

    public class IslandsController : ApiController
    {
        private readonly IIslandService islandService;
        private readonly IPartnerService partnerService;
        private readonly IImageService imageService;
        private readonly IAdminService adminService;

        public IslandsController(IIslandService islandService, IPartnerService partnerService, IImageService imageService, IAdminService adminService)
        {
            this.islandService = islandService;
            this.partnerService = partnerService;
            this.imageService = imageService;
            this.adminService = adminService;
        }

        [Authorize]
        [HttpPost(nameof(AddIsland))]
        public async Task<ActionResult> AddIsland([FromForm] IFormFile file, [FromForm] string details)
        {
            var partnerId = this.partnerService.PartnerId(this.User.GetId());

            if(partnerId == 0)
            {
                return Unauthorized();
            }

            if(file == null)
            {
                return BadRequest("Cannot create island without valid file");
            }

            bool isValidImage = ImageExtensionHelper.IsValidImageFile(file);
            bool isValidSize = ImageExtensionHelper.ValidateImageSize(file);

            if (!isValidImage)
            {
                //throw new ImageNotSupportedFormatException();
                var ex = new ImageNotSupportedFormatException();
                return BadRequest(ex.Message);
            }

            if (!isValidSize)
            {
                //throw new ImageSizeExceedException();
                var ex = new ImageSizeExceedException();
                return BadRequest(ex.Message);
            }

            var island = JsonConvert.DeserializeObject<IslandAddDto>(details);

            var fileBytes = file.GetByteFromFileStream();

            var fileType = GetFileTypeExtension.GetFileType(file);

            island.FileType = fileType;

            var islandId = await this.islandService.AddAsync(island, partnerId);

            this.imageService.AddImage(fileBytes, fileType, islandId, ImageCategory.Islands);

            return Ok();
        }

        [HttpGet("All/{searchValue?}")]
        public IslandListItemDto[] All(string? searchValue)
        {
            return this.islandService.AllIslands(searchValue);
        }

        [HttpGet("Details/{id}")]
        public ActionResult<IslandDetailsDto> Details(int id)
        {
            var island = this.islandService.Details(id);

            if(island == null)
            {
                return NotFound("No such island exists");
            }

            return island;
        }

        [Authorize]
        [HttpPut(nameof(Update))]
        public async Task<ActionResult> Update([FromForm] IFormFile? file, [FromForm] string details)
        {
            var partnerId = this.partnerService.PartnerId(this.User.GetId());
            bool isAdmin = this.adminService.isAdmin(this.User.GetId());

            if (partnerId == 0 && !isAdmin)
            {
                return Unauthorized("Unsufficient user privileges!");
            }

            var island = JsonConvert.DeserializeObject<IslandEditDto>(details);

            if(file != null)
            {
                bool isValidImage = ImageExtensionHelper.IsValidImageFile(file);
                bool isValidSize = ImageExtensionHelper.ValidateImageSize(file);

                if (!isValidImage)
                {
                    //throw new ImageNotSupportedFormatException();
                    var ex = new ImageNotSupportedFormatException();
                    return BadRequest(ex.Message);
                }

                if (!isValidSize)
                {
                    //throw new ImageSizeExceedException();
                    var ex = new ImageSizeExceedException();
                    return BadRequest(ex.Message);
                }

                var fileBytes = file.GetByteFromFileStream();

                var fileType = GetFileTypeExtension.GetFileType(file);

                island.FileType = fileType;

                this.imageService.DeleteImages(island.Id, ImageCategory.Islands);

                this.imageService.AddImage(fileBytes, fileType, island.Id, ImageCategory.Islands);
            }

            var updated = await this.islandService.Update(island, partnerId, isAdmin);

            if (!updated)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet(nameof(IslandSizes))]
        public PopulationSizesDto[] IslandSizes()
        {
            return this.islandService.IslandSizes();
        }

        [HttpGet(nameof(IslandRegions))]
        public RegionsDto[] IslandRegions()
        {
            return this.islandService.IslandRegions();
        }

        [Authorize]
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var partnerId = this.partnerService.PartnerId(this.User.GetId());
            bool isAdmin = this.adminService.isAdmin(this.User.GetId());

            if (partnerId == 0 && !isAdmin)
            {
                return Unauthorized();
            }

            var deleted = await this.islandService.Delete(id, partnerId, isAdmin);

            if (!deleted)
            {
                return BadRequest();
            }

            return Ok();
        }

        [Authorize]
        [HttpGet(nameof(GetPartnerIslands))]
        public ActionResult<PartnerOwnIslandsDto[]> GetPartnerIslands()
        {
            var partnerId = this.partnerService.PartnerId(this.User.GetId());

            if (partnerId == 0)
            {
                return Unauthorized();
            }

            var partnerIslands = this.islandService.GetPartnerIslands(partnerId);

            if (partnerIslands.Any())
            {
                return partnerIslands;
            }

            return NoContent();
        }
    }
}
