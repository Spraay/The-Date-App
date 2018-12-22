using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Service.Service
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SmtpClient SmtpClientBuilder()
        {
            return new SmtpClient
            {
                Host = _configuration.GetSection("EmailSenderConfiguration").GetSection("SmtpHost").Value,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(
                    _configuration.GetSection("EmailSenderConfiguration").GetSection("Sender").Value,
                    _configuration.GetSection("EmailSenderConfiguration").GetSection("Passwd").Value),
                EnableSsl = true,
                Port = 587
            };
        } 

        public async Task SendEmailAsync(string email, string subject, string body)
        {
            MailAddress from = new MailAddress(_configuration.GetSection("EmailSenderConfiguration").GetSection("Sender").Value);
            MailAddress to = new MailAddress(email);

            var message = new MailMessage(from.Address, to.Address, subject, body);
            await SmtpClientBuilder().SendMailAsync(message);
        }
    }

    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string confirmationLink)
        {
            return emailSender.SendEmailAsync(email, "Confirm your email",
                $"Please confirm your account by clicking this link: <a href='{HtmlEncoder.Default.Encode(confirmationLink)}'");
        }

        public static Task SendEmailPasswordResetAsync(this IEmailSender emailSender, string email, string resetLink)
        {
            return emailSender.SendEmailAsync(email, "Reset your password",
                $"You can reset account password by clicking this link: <a href='{HtmlEncoder.Default.Encode(resetLink)}'");
        }
    }
}
