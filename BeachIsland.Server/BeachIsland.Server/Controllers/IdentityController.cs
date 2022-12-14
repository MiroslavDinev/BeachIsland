namespace BeachIsland.Server.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Options;
    using Microsoft.AspNetCore.Authorization;

    using BeachIsland.Server.Data.Models;
    using BeachIsland.Server.Models.Identity;
    using BeachIsland.Server.Services.Interfaces;
    using BeachIsland.Server.Infrastructure;

    using static WebConstants;

    public class IdentityController : ApiController
    {
        private readonly UserManager<User> userManager;
        private readonly IIdentityService identityService;
        private readonly IPartnerService partnerService;
        private readonly AppSettings appSettings;

        public IdentityController(UserManager<User> userManager, IOptions<AppSettings> appSettings, IIdentityService identityService, IPartnerService partnerService)
        {
            this.userManager = userManager;
            this.identityService = identityService;
            this.partnerService = partnerService;
            this.appSettings = appSettings.Value;
        }

        [HttpPost(nameof(Register))]
        public async Task<ActionResult> Register(RegisterUserRequestDto model)
        {
            var user = new User
            {
                Email = model.Email,
                UserName = model.Username
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors?.FirstOrDefault().Description);
        }

        [HttpPost(nameof(Login))]
        public async Task<ActionResult<LoginResponseDto>> Login(LoginUserRequestDto model)
        {
            var user = await this.userManager.FindByNameAsync(model.Username);

            if(user == null)
            {
                return Unauthorized("Invalid credentials!");
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, model.Password);

            if (!passwordValid)
            {
                return Unauthorized("Invalid credentials!");
            }

            var userRoles =await this.userManager.GetRolesAsync(user);

            var isAdmin = userRoles.Any(x => x == AdministratorRoleName);

            var encryptedToken = this.identityService.GenerateJwtToken(user.Id, user.UserName, this.appSettings.Secret, isAdmin);

            return new LoginResponseDto
            {
                Token = encryptedToken,
                Username = user.UserName,
                IsPartner = this.partnerService.isPartner(user.Id),
                IsAdmin = isAdmin,
            };
        }

        [Authorize]
        [HttpGet(nameof(GetProfile))]
        public ProfileResponseDto GetProfile()
        {
            var userId = this.User.GetId();

            var profileInfo = this.identityService.GetProfile(userId);

            return profileInfo;
        }

        [Authorize]
        [HttpPost(nameof(UpdateProfile))]
        public async Task<ActionResult> UpdateProfile(ProfileUpdateRequestDto profileUpdateRequestDto)
        {
            var userId = this.User.GetId();

            var successfullyUpdatedProfile = await this.identityService.UpdateProfile(profileUpdateRequestDto, userId);

            if (!successfullyUpdatedProfile)
            {
                return BadRequest("Something went wrong. Please try again later.");
            }

            return Ok();
        }
    }
}
