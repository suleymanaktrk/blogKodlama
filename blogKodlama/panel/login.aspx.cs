using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace blogKodlama.panel
{
    public partial class login : cBase
    {
        cMember cm = new cMember();
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            string uIp = GetUserIP();
            var result = db.tbl_Logintalep.Where(x => x.istek_ip ==uIp).OrderByDescending(x => x.id).Take(3).ToList(); //kategori adına göre sondan sıralayıp getirir.
            DateTime ilkT = (DateTime)result[2].istekk_date;
            DateTime ikinciT = DateTime.Now;

            int logMinute = int.Parse((ikinciT - ilkT).Minutes.ToString());

            if (logMinute > 0)
            {
                tbl_Logintalep talep = new tbl_Logintalep();
                talep.istek_ip = GetUserIP();
                talep.istekk_date = DateTime.Now;
                talep.is_login = 0;
                db.tbl_Logintalep.Add(talep);
                db.SaveChanges();
                int idK = talep.id;

                if (txtEmail.Text != "" && txtSifre.Text != "")
                {
                    if (cm.adminLogin(txtEmail.Text, txtSifre.Text))
                    {
                        var kateg = db.tbl_Logintalep.Find(idK); //sadece primery key e göre arama yapar. sonuçta tek değer döndürür.
                        kateg.is_login = 1;
                        db.SaveChanges();

                        string cookie_content = cEncrytion.EncryptString(txtEmail.Text + "-ls-" + txtSifre.Text);//string şifreleme.
                        Response.Cookies["ST"].Value = cookie_content;
                        Response.Cookies["ST"].Expires = DateTime.Now.AddDays(7);
                        Response.Redirect("index.aspx");
                    }
                    else
                    {


                        ltrModal.Text = @"<div class='alert alert-danger'><strong> Tehlike!</strong> Olumsuz davranış algılandı.</ div > ";
                    }
                }
            }
            else
            {
                ltrModal.Text = @"<div class='alert alert-danger'><strong> Haddinden fazla istek. Lütfen bir dk bekle canım. "+logMinute.ToString()+@" </ div > ";
            }

        }
    }
}