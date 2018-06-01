using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace blogKodlama.panel
{
    public partial class Log : System.Web.UI.MasterPage
    {
        cMember cm = new cMember();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (cm.adminIsLogged())//login yapılmışsa ana sayfaya git.
                    Response.Redirect("index.aspx");
            }

        }
    }
}