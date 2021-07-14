using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace UtiltyLayer
{
    public class SendEmail
    {
        public void Send(string toEmailAddress, string Subject, string EmailBody, string cc, AlternateView alternateView)
        {
            try
            {
                SmtpSection section = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");

                SmtpClient smtpClient = new SmtpClient(section.Network.Host, section.Network.Port);
                smtpClient.EnableSsl = section.Network.EnableSsl;
                smtpClient.Timeout = 100000;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(section.Network.UserName, section.Network.Password);
                MailMessage mailMessage = new MailMessage(section.From, toEmailAddress);
                mailMessage.Subject = Subject;
                mailMessage.Body = EmailBody;
                if (cc != null)
                {
                    MailAddress ccmail = new MailAddress(cc);
                    mailMessage.CC.Add(ccmail);

                }
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = UTF8Encoding.UTF8;
                if (alternateView != null)
                {
                    mailMessage.AlternateViews.Add(alternateView);
                }
                smtpClient.Send(mailMessage);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
