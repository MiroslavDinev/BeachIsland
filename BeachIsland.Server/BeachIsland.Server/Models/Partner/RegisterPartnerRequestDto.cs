namespace BeachIsland.Server.Models.Partner
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Partner;

    public class RegisterPartnerRequestDto
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "The name length should be between {2} and {1} symbols")]
        public string Name { get; set; }

        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength, ErrorMessage = "The phone number length should be between {2} and {1} symbols")]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
