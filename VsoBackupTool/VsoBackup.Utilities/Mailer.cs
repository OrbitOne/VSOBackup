using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace VsoBackup.Utilities
{
    public class Mailer
    {

        public static void SendMail(List<string> errorMessages)
        {
            SmtpClient client = new SmtpClient();
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("vsobackup@orbitone.com");
            msg.To.Add(ConfigurationManager.AppSettings["errorMailTo"]);
            msg.Subject = "Errors encountered during repository backup";
            errorMessages.ForEach(m => msg.Body += m);
            client.Send(msg);
        }

    }
}
