using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Api
{
    public class MailService : IMailService
    {
        private readonly SendMail _mailConfig;
        public MailService(SendMail mailConfig)
        {
            _mailConfig = mailConfig;
        }

        public async Task SendEmailAsync(string Title, string Body)
        {
            MailMessage message = new MailMessage();
            var smtp = new SmtpClient("smtp.gmail.com", 587);
            message.From = new MailAddress("infoargeinvex@gmail.com");
            message.To.Add(new MailAddress("fatih.emecen98@gmail.com"));
            message.Subject = _mailConfig.Title;
            message.IsBodyHtml = true;
            message.Body = _mailConfig.Body;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("infoargeinvex@gmail.com", "tpomvynthxqdxmys");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(message);
        }
    }
}
