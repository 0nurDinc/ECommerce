using ECommerce.Application.Interfaces.Service.Email;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Email
{
    public class SmtpEmailSender : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public SmtpEmailSender(IOptions<EmailSettings> settings)
        {
            _emailSettings = settings.Value;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            using (var client = new SmtpClient())
            {
                client.Host = _emailSettings.SmtpServer;
                client.Port = _emailSettings.Port;

                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(_emailSettings.UserName, _emailSettings.Password);

                client.EnableSsl = true;

                var message = new MailMessage()
                {
                    From = new MailAddress(_emailSettings.UserName),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                message.To.Add(to);

                await client.SendMailAsync(message);

            }
        }
    }
}
