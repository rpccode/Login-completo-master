using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesss.MailService
{
    class SystemSupportMail : MasterMailService
    {
        public SystemSupportMail()
        {
            senderMail = "rapccode@gmail.com";
            Password = "72400241230";
            host = "smtp.gmail.com";
            port = 587;
            ssl = true;
            initilizeSmtpClient();
        }

    }
}
