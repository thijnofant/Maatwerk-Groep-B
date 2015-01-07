using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemiseSite_Groep_B
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedInMedewerker"] == null)
            {
                Button1.Visible = false;
            }
            else
            {
                Button1.Visible = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["LoggedInMedewerker"] = null;
            Response.Redirect("/Login");
        }
    }
}