namespace BeachIsland.Server.Models.Identity
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public bool IsPartner { get; set; }
    }
}
