namespace BeachIsland.Server.Models.Contact
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.ContactMessage;
    using static Data.DataConstants.ContactSubject;
    using static Data.DataConstants.User;

    public class ContactFormDto
    {
        [Required]
        [StringLength(NicknameMaxLength, MinimumLength = NicknameMinLength, ErrorMessage = "The name length should be between {2} and {1} symbols")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(SubjectMaxLength, MinimumLength = SubjectMinLength, ErrorMessage = "The subject length should be between {2} and {1} symbols")]
        public string Subject { get; set; }

        [Required]
        [StringLength(MessageMaxLength, MinimumLength = MessageMinLength, ErrorMessage = "The subject length should be between {2} and {1} symbols")]
        public string Content { get; set; }
    }
}
