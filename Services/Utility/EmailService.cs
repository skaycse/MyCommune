using System.Net;
using System.Net.Mail;

namespace MyCommune.Services.Utility
{

    public interface IEmailService
    {
        Task<bool> SendEmail(string subject, string body, string cc);
    }
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<bool> SendEmail(string subject, string body, string cc)
        {
            bool isEmailSend = default;
            try
            {
                SmtpClient smtpClient = new(_configuration["Smtp:Host"])
                {
                    Port = int.Parse(_configuration["Smtp:Port"]),
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_configuration["Smtp:Username"], _configuration["Smtp:Password"]),
                    EnableSsl = true
                };

                MailMessage mailMessage = new()
                {
                    From = new MailAddress(cc),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(cc);

                Task task = smtpClient.SendMailAsync(mailMessage);
                await task;
                isEmailSend = true;
            }
            catch (Exception ex)
            {
                isEmailSend = false;
            }
            return isEmailSend;
        }
    }
}
