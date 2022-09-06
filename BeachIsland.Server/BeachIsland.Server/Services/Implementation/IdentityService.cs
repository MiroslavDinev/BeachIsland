namespace BeachIsland.Server.Services.Implementation
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using BeachIsland.Server.Data;
    using BeachIsland.Server.Models.Identity;
    using BeachIsland.Server.Services.Interfaces;
    using Microsoft.IdentityModel.Tokens;

    public class IdentityService : IIdentityService
    {
        private readonly BeachIslandDbContext data;

        public IdentityService(BeachIslandDbContext data)
        {
            this.data = data;
        }
        public string GenerateJwtToken(string userId, string username, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return encryptedToken;
        }

        public ProfileResponseDto GetProfile(string userId)
        {
            var profileInfo = this.data.Users
                .Where(x => x.Id == userId)
                .Select(x => new ProfileResponseDto
                {
                    Username = x.UserName,
                    Email = x.Email,
                    Nickname = x.Nickname == null ? "" : x.Nickname,
                    OccupationalField = x.OccupationalField == null ? "" : x.OccupationalField
                })
                .FirstOrDefault();

            return profileInfo;
        }

        public async Task<bool> UpdateProfile(ProfileUpdateRequestDto profileUpdateRequestDto, string userId)
        {
            var user = this.data.Users
                .Where(x => x.Id == userId)
                .FirstOrDefault();

            if(user != null)
            {
                user.Nickname = string.IsNullOrEmpty(profileUpdateRequestDto.Nickname) ? user.Nickname : profileUpdateRequestDto.Nickname;
                user.OccupationalField = string.IsNullOrEmpty(profileUpdateRequestDto.OccupationalField) ? user.OccupationalField : profileUpdateRequestDto.OccupationalField;
                await this.data.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
