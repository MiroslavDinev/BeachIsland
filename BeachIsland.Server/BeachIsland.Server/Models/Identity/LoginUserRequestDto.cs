namespace BeachIsland.Server.Models.Identity
{
    using System.ComponentModel.DataAnnotations;

    public class LoginUserRequestDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
