namespace BeachIsland.Server.Data.Models
{
    public abstract class BaseDataModel
    {
        public int Id { get; set; }
        public bool IsPublic { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsBooked { get; set; }
    }
}
