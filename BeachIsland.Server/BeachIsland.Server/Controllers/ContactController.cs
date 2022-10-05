namespace BeachIsland.Server.Controllers
{
    using System.Net.Mail;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using BeachIsland.Server.Models.Contact;
    using BeachIsland.Server.Infrastructure.Exceptions;

    public class ContactController : ApiController
    {
        private const string AdminEmailAddress = "admin.dreamisland@dir.bg";

        [Authorize]
        [HttpPost(nameof(Book))]
        public ActionResult Book(ContactFormDto contact)
        {
            MailAddress to = new MailAddress(AdminEmailAddress);
            MailAddress from = new MailAddress(contact.Email);

            MailMessage mailMessage = new MailMessage(from, to);

            mailMessage.Subject = contact.Subject;
            mailMessage.Body = contact.Content;

            SmtpClient client = new SmtpClient("mail.dir.bg", 587);

            try
            {
                client.Send(mailMessage);
            }
            catch (SmtpException ex)
            {
                throw new EmailNotSentException(ex.Message);
            }

            return Ok("Email sent successfully");
        }
    }
}
