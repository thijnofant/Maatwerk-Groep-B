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
        List<Classes.Spoor> Sporen = DatabaseManager.Instance.SporenlijstOpvragen();

        protected void Page_Load(object sender, EventArgs e)
        {
            updateData();
        }

        private void updateData() {
            Sporen = DatabaseManager.Instance.SporenlijstOpvragen();
            foreach (Classes.Spoor s in Sporen) {
                foreach (Classes.Sector sec in s.Sectoren) {
                    if (DatabaseManager.Instance.StaatTramOpSector(sec.Id) == 0)
                        continue;
                    else
                        sec.Tram = new Classes.Tram(DatabaseManager.Instance.StaatTramOpSector(sec.Id), null);
                }
            }
            lvSporen.DataSource = Sporen;
            lvSporen.DataBind();
        }
    }
}