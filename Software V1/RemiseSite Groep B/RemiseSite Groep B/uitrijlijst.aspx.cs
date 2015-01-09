using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemiseSite_Groep_B
{
    public partial class uitrijlijst : System.Web.UI.Page
    {
        private List<string> Uitrijlijst;
        protected void Page_Load(object sender, EventArgs e)
        {
            Uitrijlijst = DatabaseManager.Instance.GetUitrijlijst();

            for (int i = 0; i < Uitrijlijst.Count(); i++)
			{
                lbHistory.Items.Add(Uitrijlijst[i]);
			}
        }
    }
}