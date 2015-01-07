using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemiseSite_Groep_B
{
    public partial class administrator : System.Web.UI.Page
    {
        List<Classes.Spoor> Sporen;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                updateData();
            }
        }

        private void updateData() {
            List<Classes.Spoor> tempSporen = DatabaseManager.Instance.SporenlijstOpvragen();
            if (tempSporen != null) {
                Sporen = tempSporen;
            }
            foreach (Classes.Spoor s in Sporen) {
                foreach (Classes.Sector sec in s.Sectoren) {
                    int tramid = DatabaseManager.Instance.StaatTramOpSector(sec.Id, s.Id);
                    if (tramid == 0)
                        continue;
                    else
                        sec.Tram = new Classes.Tram(tramid, null);
                }
            }
            lvSporen.DataSource = Sporen;
            lvSporen.DataBind();
        }
    }
}