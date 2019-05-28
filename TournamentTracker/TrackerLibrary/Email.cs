using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace TrackerLibrary
{
    public static class Email
    {
        /// <summary>
        /// Sends an email.
        /// </summary>
        /// <param name="to">A list of people to send to.</param>
        /// <param name="subject">Subject of email.</param>
        /// <param name="body">Content of the email.</param>
        public static void SendEmail(string to, string subject, string body)
        {
            MailAddress fromMailAddress = new MailAddress(GlobalConfig.AppKey("senderEmail"), GlobalConfig.AppKey("senderDisplayName"));

            MailMessage mailMessage = new MailMessage();

            mailMessage.To.Add(to);
            mailMessage.From = fromMailAddress;
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Send(mailMessage);
        }
    }
}
