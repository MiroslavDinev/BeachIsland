namespace BeachIsland.Server.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using BeachIsland.Server.Data.Models.Islands;

    using static DataConstants.Partner;

    public class Partner
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }
        public IEnumerable<Island> Islands { get; set; }

        public Partner(string name, string phoneNumber, string userId)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            UserId = userId;
        }
    }
}
