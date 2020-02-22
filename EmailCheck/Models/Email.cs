using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace EmailCheck.Models
{
    public class Email
    {
        public int Id { get; set; }
        public string To { get; set; }
        public string Bcc { get; set; }
        public string CC { get; set; }
        public string Subject { get; set; }
        public string body { get; set; }

        public void sendMail()
        {
            MailMessage mail = new MailMessage(ConfigurationManager.AppSettings["Email"].ToString(), To);
            mail.Subject = Subject;
            mail.Body = body;
            mail.IsBodyHtml = false;

            if (CC != null)
            {
                string[] ccId = CC.Split(',');
                foreach (var ccEmail in ccId)
                {
                    mail.CC.Add(new MailAddress(ccEmail));
                }
            }

            if (Bcc != null)
            {
                string[] bccEmail = Bcc.Split(',');
                foreach (var item in bccEmail)
                {
                    mail.Bcc.Add(new MailAddress(item));
                }
            }

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);            
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            NetworkCredential credential = new NetworkCredential(ConfigurationManager.AppSettings["Email"].ToString(), ConfigurationManager.AppSettings["Password"].ToString());
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = credential;
            smtp.Send(mail);
        }
    }
}