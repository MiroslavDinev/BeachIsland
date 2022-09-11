namespace BeachIsland.Server.Data.Models.Islands
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.EntityFrameworkCore.Metadata.Internal;

    using static DataConstants.Island;

    public class Island : BaseDataModel
    {
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(LocationMaxLength)]
        public string Location { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public double SizeInSquareKm { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }

        public string FileType { get; set; }

        public int PartnerId { get; set; }

        public Partner Partner { get; set; }

        public int PopulationSizeId { get; set; }
        public PopulationSize PopulationSize { get; set; }

        public int IslandRegionId { get; set; }

        public IslandRegion IslandRegion { get; set; }

        public Island(string name, string location, string description, double sizeInSquareKm, decimal? price, string fileType,  int populationSizeId, int islandRegionId, int partnerId)
        {
            Name = name;
            Location = location;
            Description = description;
            SizeInSquareKm = sizeInSquareKm;
            Price = price;
            FileType = fileType;
            PopulationSizeId = populationSizeId;
            IslandRegionId = islandRegionId;
            PartnerId = partnerId;
        }
    }
}
