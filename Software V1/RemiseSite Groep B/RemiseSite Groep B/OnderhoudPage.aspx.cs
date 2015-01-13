using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemiseSite_Groep_B
{
    public partial class OnderhoudPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected DataTable BeurtenOphalen()
        {
            DataTable Onderhoudsbeurten = new DataTable();
            return Onderhoudsbeurten;
        }

        protected void lijstBeurten_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}