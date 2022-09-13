namespace BeachIsland.Server.Models.Islands
{
    public class IslandListItemDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public double SizeInSquareKm { get; set; }

        public decimal? Price { get; set; }

        public string ImageUrl { get; set; }
        public string FileType { get; set; }

        public bool IsPublic { get; set; }
    }
}
