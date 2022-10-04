using BeachIsland.Server.Data;

namespace BeachIsland.Server.Models.Islands
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Island;

    public class IslandEditDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "The island name should be between {2} and {1} characters")]
        public string Name { get; set; }

        [Required]
        [StringLength(LocationMaxLength, MinimumLength = LocationMinLength, ErrorMessage = "The location should be between {2} and {1} characters")]
        public string Location { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = "The location should be between {2} and {1} characters")]
        public string Description { get; set; }

        [Required]
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "The area should be bigger than 0 km")]
        public double Size { get; set; }
        public decimal? Price { get; set; }

        [Required]
        public string FileType { get; set; }

        [Required]
        public int PopulationSizeId { get; set; }

        [Required]
        public int IslandRegionId { get; set; }
    }
}
