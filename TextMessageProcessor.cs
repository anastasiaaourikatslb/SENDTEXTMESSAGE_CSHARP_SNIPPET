using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Data;
using System.Data.OracleClient;
using System.IO;

namespace AlertsProcessor
{
.....

        static bool SendTextMessage(string cellphonenumber, string carriersmsgateway,string deliveryfrequency, string txtmsgBody, string userid)
        {
            if (cellphonenumber == null || carriersmsgateway == null || deliveryfrequency == null|| txtmsgBody == null)
                return false;

            string sendto = sendto = string.Format("{0}{1}", cellphonenumber, carriersmsgateway);


            SmtpClient osc = new SmtpClient();
            osc.Host = "mail.slb.com";
            osc.Port = 25;
            string strFrom = "salesgis@donotreply.com";
            MailAddressCollection mac = new MailAddressCollection();
            MailAddress macme = new MailAddress(sendto);
            mac.Add(macme);

            MailMessage amsg = new MailMessage(strFrom, mac.ToString());
            amsg.IsBodyHtml = true;
            amsg.Subject = string.Format("SalesGIS {0} Alert", deliveryfrequency);
            amsg.Body = txtmsgBody;

            try
            {
                osc.Send(amsg);
                Console.WriteLine(string.Format("{0}:Text Alert Sent To {1}", DateTime.Now, userid));

            }
            catch 
            {
                Console.WriteLine(string.Format("{0}: Text Alert Failed For {1}", DateTime.Now, userid));

            }

            return true;
        }

    }

}
