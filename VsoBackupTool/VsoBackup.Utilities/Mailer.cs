using System.Collections.Generic;
using System.Configuration;
using System.Net.Mail;

namespace VsoBackup.Utilities
{
    public class Mailer
    {
        public static void SendMail(List<string> errorMessages)
        {
            var client = new SmtpClient();
            var msg = new MailMessage();
            msg.From = new MailAddress("vsobackup@orbitone.com");
            msg.To.Add(ConfigurationManager.AppSettings["errorMailTo"]);
            msg.Subject = "Errors encountered during repository backup";
            msg.Body = string.Join("\n", errorMessages);
            client.Send(msg);
        }
    }
}
