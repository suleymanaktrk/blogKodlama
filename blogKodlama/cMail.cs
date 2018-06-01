using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net.Mail;

namespace blogKodlama
{
    public class cMail
    {
     
        public static void Iletisim(string Name,string Telefon,string Mail,string Siparis)
        {
            try
            {
                string msg = "";
                msg += "Ad Soyad: " + Name + "\n" + "<br/><br/>Telefon: " + Telefon + "\n" + "<br/><br/>Mail: " + Mail + "\n" + "<br/><br/>Mesaj: "+Siparis;
              
              //  SendEmail(msg);
            }
            catch
            {
                //return false;
            }
        }


        public static bool SendEmail(string Mesaj,string aliciMail)
        {
            try
            {
                MailMessage mailMsg = new MailMessage();
                MailAddress kimden = new MailAddress("mail@suleymanakturk.com", "Şifre yenileme kodunuz.");
                MailAddress kime = new MailAddress(aliciMail);
                mailMsg.From = kimden;
                mailMsg.Subject = "Blog Site - Şifre Yenileme";
                mailMsg.Body = Mesaj;
                mailMsg.IsBodyHtml = true;
                mailMsg.To.Add(kime);

                SmtpClient smtpClient = new SmtpClient("mail.suleymanakturk.com", 587);
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("mail@suleymanakturk.com", "DZpq34G9");
                smtpClient.Credentials = credentials;

                smtpClient.Send(mailMsg);

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}