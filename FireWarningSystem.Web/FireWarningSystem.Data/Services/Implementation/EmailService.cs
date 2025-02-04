using Microsoft.Extensions.Configuration;
using System.Net.Mail;

namespace FireWarningSystem.Data.Services.Implementation
{
    public class EmailService : IEmailService
    {
        private IConfiguration _configuration;

        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _toAddress;
        private readonly bool _enableSsl = false;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;

            _smtpServer = _configuration["SmtpServer"] ?? throw new InvalidCastException("Smtp Server address missing.");
            _smtpPort = int.Parse(_configuration["SmtpServerPort"] ?? throw new InvalidCastException("Smtp Server port missing."));
            _toAddress = _configuration["ToEmailAddress"] ?? throw new InvalidCastException("To email address missing.");
            bool.TryParse(_configuration["EnableEmailSsl"] ?? throw new InvalidCastException("Enable Email Ssl value missing."),out var value);
            _enableSsl = value;
        }

        public async Task SendFormEmailAsync(string fromEmail, string subject, string body)
        {
            var smtpClient = new SmtpClient(_smtpServer)
            {
                Port = _smtpPort,
                EnableSsl = _enableSsl
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(fromEmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            mailMessage.To.Add(_toAddress);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
