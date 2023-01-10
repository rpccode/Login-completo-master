using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace DataAccesss.MailService
{
   public abstract class MasterMailService
    {
        private SmtpClient SmtpClient;
        protected string senderMail { get; set; }
        protected string Password { get; set; }
        protected string host { get; set; }
        protected int port { get; set; }
        protected bool ssl { get; set; }
        
        
        
        protected void initilizeSmtpClient()
        {
            SmtpClient = new SmtpClient();
            SmtpClient.Credentials = new NetworkCredential(senderMail,Password);
            SmtpClient.Host = host;
            SmtpClient.Port = port;
            SmtpClient.EnableSsl = ssl;
        }
        public void sendMail(string subject, string body, List<string> recipientMail)
        {
            var mailMassage = new MailMessage();

            try
            {
                mailMassage.From = new MailAddress(senderMail);
                foreach (string mail in recipientMail) {
                    mailMassage.To.Add(mail);
                }
                mailMassage.Subject = subject;
                mailMassage.Body = body;
                mailMassage.Priority = MailPriority.Normal;
                SmtpClient.Send(mailMassage);
            }
            catch(Exception ex){}
            finally {

                mailMassage.Dispose();
                SmtpClient.Dispose();
            
            }

        }
     }
}
