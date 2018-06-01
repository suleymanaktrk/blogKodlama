using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace blogKodlama.panel
{
    public partial class SifreYenile : cBase
    {
        string dCode = "";
        int kisiId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                dCode = Request.QueryString["code"];
                if (dCode == null)
                {
                    Response.Redirect("sifremiunuttum.aspx");
                }
                else
                {
                    dCode = CleanHTML(dCode);
                    var codeKayit = db.tbl_DKod.Where(x => x.d_kod == dCode).FirstOrDefault();
                    if (codeKayit != null)
                    {
                        txtEmail.Text = codeKayit.tbl_Users.email;
                        txtDogrulamaKodu.Text = codeKayit.d_kod;

                        kisiId = codeKayit.kisi_id;
                    }
                    else
                    {
                        Response.Redirect("sifremiunuttum.aspx");
                    }
                }

            }

        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            string[] mesaj = { "", "" };
            string sifre = txtSifre.Text;
            string sifreTekrar = txtSifreTekrar.Text;
            if (sifre == sifreTekrar)
            {
                dCode = Request.QueryString["code"];
                if (!dCode.IsTextBoxEmptyOrNull())
                {
                    var kisi = db.tbl_DKod.Where(x => x.d_kod == dCode).FirstOrDefault().tbl_Users;
                    kisi.sifre = cExtensions.ToMD5(sifre);

                    if (db.SaveChanges() > 0)
                    {
                        mesaj[1] = "Şifreniz başarıyla güncellendi.";
                        mesaj[0] = "success";
                    }
                    else
                    {
                        mesaj[1] = "Veri Tabanına kayıtta bir hata oluştu.";
                        mesaj[0] = "danger";
                    }

                }
            }
            else
            {
                mesaj[1] = "Şifreler uyuşmuyor.";
                mesaj[0] = "danger";


            }
            ltrModal.Text = @"<div class='alert alert-" + mesaj[0] + "'><strong> Mesaj!</strong>" + mesaj[1] + "</ div > ";
        }
    }
}