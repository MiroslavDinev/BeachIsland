namespace BeachIsland.Server.Models.Islands
{
    public class IslandDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public double Size { get; set; }
        public decimal? Price { get; set; }
        public string ImageUrl { get; set; }
        public string FileType { get; set; }
        public int IslandRegionId { get; set; }
        public string IslandRegionName { get; set; }
        public int PopulationSizeId { get; set; }
        public string PopulationSizeName { get; set; }
        public bool IsPublic { get; set; }
    }
}
