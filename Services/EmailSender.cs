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

            // Původní cesty k souborům
            string originalAttach1Path = attach1_path;
            string originalAttach2Path = attach2_path;
            string originalAttach3Path = attach3_path;
            string originalAttach4Path = attach4_path;

            Attachment attach1 = new Attachment(originalAttach1Path, ct);
            attach1.Name = Path.GetFileName(originalAttach1Path);

            Attachment attach2 = new Attachment(originalAttach2Path, ct);
            attach2.Name = Path.GetFileName(originalAttach2Path);

            Attachment attach3 = new Attachment(originalAttach3Path, ct);
            attach3.Name = Path.GetFileName(originalAttach3Path);

            Attachment attach4 = new Attachment(originalAttach4Path, ct);
            attach4.Name = Path.GetFileName(originalAttach4Path);

            MailMessage msg = new MailMessage(
                from: "info@jopp-obedy.cz",
                to: email,
                subject: subject,
                body: message
            );
            msg.Attachments.Add(attach1);
            msg.Attachments.Add(attach2);
            msg.Attachments.Add(attach3);
            msg.Attachments.Add(attach4);

            return client.SendMailAsync(msg);
        }
    }
}


