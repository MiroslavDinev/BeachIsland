namespace BeachIsland.Server.Models.Identity
{
    public class ProfileResponseDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string? Nickname { get; set; }
        public string? OccupationalField { get; set; }
    }
}
