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
        /// <param name="bcc">People to inform about the email.</param>
        /// <param name="subject">Subject of email.</param>
        /// <param name="body">Content of the email.</param>
        public static void SendEmail(List<string> to, List<string> bcc , string subject, string body)
        {
            MailAddress fromMailAddress = new MailAddress(GlobalConfig.AppKey("senderEmail"), GlobalConfig.AppKey("senderDisplayName"));

            MailMessage mailMessage = new MailMessage();

            foreach (string email in to)
            {
                mailMessage.To.Add(email); 
            }

            foreach (string email in bcc)
            {
                mailMessage.Bcc.Add(email);
            }

            mailMessage.From = fromMailAddress;
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Send(mailMessage);
        }

        /// <summary>
        /// Sends an email.
        /// </summary>
        /// <param name="to">A list of people to send to.</param>
        /// <param name="subject">Subject of email.</param>
        /// <param name="body">Content of the email.</param>
        public static void SendEmail(string to, string subject, string body)
        {
            Email.SendEmail(new List<string> { to }, new List<string> { }, subject, body);
        }
    }
}
