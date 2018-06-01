using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace blogKodlama
{
    public partial class Default : cBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //yan menü
            var yanmenu = db.tbl_kategori.ToList();
            rptNav.DataSource = yanmenu;
            rptNav.DataBind();

            //profil resmi
            var resim = db.tbl_Resim.FirstOrDefault();
            imgProfil.ImageUrl = "img/" + resim.adi;

            //hakkımda alanı
            var hakkimda = db.tbl_hakkimda.FirstOrDefault();
            ltrAd.Text = hakkimda.ad;
            ltrSoyad.Text = hakkimda.soyad;
            ltrAdres.Text = hakkimda.adres;
            ltrTel.Text = hakkimda.tel;
            ltrAciklama.Text = hakkimda.aciklama;
            linkMail.NavigateUrl = "mailto:" + hakkimda.email;
            linkMail.Text = hakkimda.email;

            //Özgeçmiş
            var ozgecmis = db.tbl_Ozgecmis.ToList();
            rptOzgecmis.DataSource = ozgecmis;
            rptOzgecmis.DataBind();

            //Eğitim
            var egitim = db.tbl_Egitim.ToList();
            rptEgitim.DataSource = egitim;
            rptEgitim.DataBind();

            //BeceriKategori
            var beceriKtgr = db.tbl_Becerikategori.Select(x => new { x.id, x.baslik,x.type }).ToList();
            rptBeceriKategori.DataSource = beceriKtgr;
            rptBeceriKategori.DataBind();

            //İlgiler
            var ilgilerim = db.tbl_Ilgiler.Select(x=>new {x.icerik}).ToList();
            rptIlgilerim.DataSource = ilgilerim;
            rptIlgilerim.DataBind();

            //Ödüllerim
            var Oduller = db.tbl_Oduller.OrderByDescending(x => x.id).ToList();
            rptOduller.DataSource = Oduller;
            rptOduller.DataBind();

        }

        protected void rptBeceriKategori_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Panel pnl1 = (Panel)e.Item.FindControl("pnlType1");
            Panel pnl2 = (Panel)e.Item.FindControl("pnlType2");



            int id = (int)DataBinder.Eval(e.Item.DataItem, "id");
            var beceri = db.tbl_Beceri.Where(x => x.kid == id).Select(x => new { x.baslik, x.aciklama }).ToList();


            int tip = (int)DataBinder.Eval(e.Item.DataItem, "type");
            if (tip == 1)
            {
                pnl1.Enabled = true;
                pnl2.Enabled = false;
                Repeater rpt = (Repeater)e.Item.FindControl("rptBeceri1");
                rpt.DataSource = beceri;
                rpt.DataBind();

            }
            else
            {
                pnl1.Enabled = false;
                pnl2.Enabled = true;
                Repeater rpt = (Repeater)e.Item.FindControl("rptBeceri2");
                rpt.DataSource = beceri;
                rpt.DataBind();

            }
        }

        protected void rptBeceri_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
           
        }
    }
}