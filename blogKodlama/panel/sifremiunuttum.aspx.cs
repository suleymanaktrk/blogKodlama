using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace blogKodlama.panel
{
    public partial class sifremiunuttum : cBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnGonder_Click(object sender, EventArgs e)
        {
            string[] mesaj= {"",""};
            if (IsEmail(txtEMail.Text))
            {
                string email = txtEMail.Text;
                var kayit = db.tbl_Users.Where(x => x.email == email&&x.is_active==1).FirstOrDefault();

                if (kayit != null)
                {
                    string dogrulamaKodu = CreateRandomValue(5,true,true,true,false);
                    if (cMail.SendEmail("Doğrulama Kodu: <a href=\"http://localhost:50640/panel/SifreYenile.aspx?code="+ dogrulamaKodu+"\">Doğrula</a>", txtEMail.Text))
                    {

                        tbl_DKod kodlu = new tbl_DKod();
                        kodlu.kisi_id = kayit.id;
                        kodlu.d_kod = dogrulamaKodu;
                        kodlu.code_date = DateTime.Now;
                        kodlu.is_active = true;
                        db.tbl_DKod.Add(kodlu);
                        db.SaveChanges();

                        mesaj[0] = "Duğrulama kodunuz gönderilmiştir. Mail hesabına giderek işlemleri yapabilirsiniz.";
                        mesaj[1] = "success";
                    }
                    else
                    {
                        mesaj[0] = "Mail gönderilemedi.";
                        mesaj[1] = "danger";
                    }

                }
                else
                {
                    mesaj[0] = "Kullanıcı email hesabı mevcut değil.";
                    mesaj[1] = "danger";
                }

            }
            else
            {
                mesaj[0] = "Email deseni yanlış girildi.";
                mesaj[1] = "danger";
            }

            ltrModal.Text = @"<div class='alert alert-"+mesaj[1]+"'><strong> Mesaj!</strong>"+mesaj[0]+"</ div > ";
        }
    }
}