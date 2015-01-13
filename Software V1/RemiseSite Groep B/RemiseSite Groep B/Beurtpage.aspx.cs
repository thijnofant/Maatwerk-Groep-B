using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemiseSite_Groep_B
{
    public partial class BeurtPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lijstBeurten_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public DataTable BeurtenOphalen()
        {
            DataTable beurten = new DataTable();
            return beurten;
        }
    }
}