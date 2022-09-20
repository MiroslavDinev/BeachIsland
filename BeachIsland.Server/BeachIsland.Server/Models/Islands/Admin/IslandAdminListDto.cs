namespace BeachIsland.Server.Models.Islands.Admin
{
    public class IslandAdminListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PartnerName { get; set; }
        public string ImageUrl { get; set; }
        public string FileType { get; set; }
        public bool IsPublic { get; set; }
    }
}
