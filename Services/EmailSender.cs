using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;
using System.Net;
using System.Net.Http;
using System.Net.Mime;

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

        public Task SendEmail4AttachAsync(string email, string subject, string message, string attach1_path, string attach2_path, string attach3_path,string attach4_path)
        {
            var client = new SmtpClient("smtp.forpsi.com")
            {
                EnableSsl = false,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Port = 587,
                Credentials = new NetworkCredential("info@jopp-obedy.cz", "vvCsDmdT7#m")
            };
            ContentType ct = new ContentType(MediaTypeNames.Application.Pdf);
            Attachment attach1 = new Attachment(attach1_path, ct);
            attach1_path.Remove(0,21);
            attach1.Name = attach1_path;
            Attachment attach2 = new Attachment(attach2_path, ct);
            attach2_path.Remove(0, 21);
            attach2.Name = attach2_path;
            Attachment attach3 = new Attachment(attach3_path, ct);
            attach3_path.Remove(0, 21);
            attach3.Name = attach3_path;
            Attachment attach4 = new Attachment(attach4_path, ct);
            attach4_path.Remove(0, 21);
            attach4.Name = attach1_path;

            MailMessage msg = new MailMessage
                (from: "info@jopp-obedy.cz",
                to: email,
                subject: subject,
                 message
                );
            msg.Attachments.Add( attach1);
            msg.Attachments.Add( attach2 );
            msg.Attachments.Add( attach3 );
            msg.Attachments.Add( attach4 );
            return client.SendMailAsync(msg);
        }
    }
}


