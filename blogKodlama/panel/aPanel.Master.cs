using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace blogKodlama.panel
{
    public partial class aPanel : System.Web.UI.MasterPage
    {
        cMember cm =new cMember();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!cm.adminIsLogged())//Kullanıcı giriş yapamamışsa.
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Abandon();
                Response.Cookies["ST"].Expires = DateTime.Now.AddDays(-1);
            }
            catch { }
            finally
            {
                Response.Redirect("login.aspx");
            }
        }
    }
}