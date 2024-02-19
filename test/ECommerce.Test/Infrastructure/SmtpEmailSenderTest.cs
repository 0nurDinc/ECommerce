using ECommerce.Infrastructure.Email;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Test.Infrastructure
{
    [TestClass]
    public class SmtpEmailSenderTest
    {
        [TestMethod]
        public async Task SendEmailAsync_Successful()
        {
            // Arrange
            var emailSettings = new EmailSettings
            {
                SmtpServer = "smtp.example.com",
                Port = 587,
                UserName = "your_username",
                Password = "your_password"
            };

            var options = Options.Create(emailSettings);

            var smtpEmailSender = new SmtpEmailSender(options);

            // Act
            var to = "recipient@example.com";
            var subject = "Test Subject";
            var body = "Test Body";

            // Assert
            await Assert.ThrowsExceptionAsync<SmtpException>(() => smtpEmailSender.SendEmailAsync(to, subject, body));
        }
    }
}
