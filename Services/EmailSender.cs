using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;
using System.Net;
using System.Net.Http;

namespace Jopp_lunch.Services
{

    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SmtpClient("smtp.forpsi.com")
            {
                EnableSsl = false,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Port = 587,
                Credentials = new NetworkCredential("info@jopp-obedy.cz", "vvCsDmdT7#m")
            };

            return client.SendMailAsync(
                new MailMessage(from: "info@jopp-obedy.cz",
                                to: email,
                                subject,
                                message
                                ));
        }
    }
}


