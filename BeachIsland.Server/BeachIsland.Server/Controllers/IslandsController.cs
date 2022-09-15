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

        public IslandsController(IIslandService islandService, IPartnerService partnerService, IImageService imageService)
        {
            this.islandService = islandService;
            this.partnerService = partnerService;
            this.imageService = imageService;
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

            bool isValidImage = ImageExtensionHelper.IsValidImageFile(file);
            bool isValidSize = ImageExtensionHelper.ValidateImageSize(file);

            if (!isValidImage)
            {
                throw new ImageNotSupportedFormatException();
            }

            if (!isValidSize)
            {
                throw new ImageSizeExceedException();
            }

            var island = JsonConvert.DeserializeObject<IslandAddDto>(details);

            var fileBytes = file.GetByteFromFileStream();

            var fileType = GetFileTypeExtension.GetFileType(file);

            island.FileType = fileType;

            var islandId = await this.islandService.AddAsync(island, partnerId);

            this.imageService.AddImage(fileBytes, fileType, islandId, ImageCategory.Islands);

            return Ok();
        }

        [Authorize]
        [HttpGet(nameof(All))]
        public IslandListItemDto[] All()
        {
            return this.islandService.AllIslands();
        }

        [Authorize]
        [HttpGet("Details/{id}")]
        public ActionResult<IslandDetailsDto> Details(int id)
        {
            var island = this.islandService.Details(id);

            if(island == null)
            {
                return NotFound();
            }

            return island;
        }

        [Authorize]
        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update([FromForm] IFormFile file, [FromForm] string details)
        {
            var partnerId = this.partnerService.PartnerId(this.User.GetId());

            if (partnerId == 0)
            {
                return Unauthorized();
            }

            bool isValidImage = ImageExtensionHelper.IsValidImageFile(file);
            bool isValidSize = ImageExtensionHelper.ValidateImageSize(file);

            if (!isValidImage)
            {
                throw new ImageNotSupportedFormatException();
            }

            if (!isValidSize)
            {
                throw new ImageSizeExceedException();
            }

            var island = JsonConvert.DeserializeObject<IslandEditDto>(details);

            var fileBytes = file.GetByteFromFileStream();

            var fileType = GetFileTypeExtension.GetFileType(file);

            island.FileType = fileType;

            var updated = await this.islandService.Update(island, partnerId);

            if (!updated)
            {
                return BadRequest();
            }

            this.imageService.DeleteImages(island.Id, ImageCategory.Islands);

            this.imageService.AddImage(fileBytes, fileType, island.Id, ImageCategory.Islands);

            return Ok();
        }
    }
}
