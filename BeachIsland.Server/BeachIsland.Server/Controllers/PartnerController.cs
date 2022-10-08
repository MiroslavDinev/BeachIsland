namespace BeachIsland.Server.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using BeachIsland.Server.Infrastructure;
    using BeachIsland.Server.Models.Partner;
    using BeachIsland.Server.Services.Interfaces;

    public class PartnerController : ApiController
    {
        private readonly IPartnerService partnerService;

        public PartnerController(IPartnerService partnerService)
        {
            this.partnerService = partnerService;
        }

        [Authorize]
        [HttpPost(nameof(BecomePartner))]
        public async Task<ActionResult> BecomePartner(RegisterPartnerRequestDto partnerRequestDto)
        {
            var userId = this.User.GetId();

            var userIsPartner = this.partnerService
                .isPartner(userId);

            if (userIsPartner)
            {
                var exception = new Exception("You are already a partner!");
                return BadRequest(exception.Message);
            }

            await this.partnerService.BecomePartner(partnerRequestDto, userId);

            return Ok();
        }
    }
}
