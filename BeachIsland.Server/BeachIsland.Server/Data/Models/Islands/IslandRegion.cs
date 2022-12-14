namespace BeachIsland.Server.Data.Models.Islands
{
    public class IslandRegion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Island> Islands { get; set; }
    }
}
