using RemiseSite_Groep_B.Classes;
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
        private List<Tram> trams;
        protected void Page_Load(object sender, EventArgs e)
        {
            Uitrijlijst = DatabaseManager.Instance.GetUitrijlijst();
            if (!IsPostBack)
            {
                for (int i = 0; i < Uitrijlijst.Count(); i++)
                {
                    lbHistory.Items.Add(Uitrijlijst[i]);
                }

                //Status Wijziggen
                ddStatus.Items.Add(TramStatus.Defect.ToString());
                ddStatus.Items.Add(TramStatus.Dienst.ToString());
                ddStatus.Items.Add(TramStatus.Remise.ToString());
                ddStatus.Items.Add(TramStatus.Schoonmaak.ToString());
            }

            //Status Wijziggen
            HaalTramsOp();
        }

        private void HaalTramsOp()
        {
            ddTrams.Items.Clear();
            this.trams = new List<Classes.Tram>();
            this.trams = DatabaseManager.Instance.AlleTrams();
            foreach (Tram tram in this.trams)
            {
                ddTrams.Items.Add(tram.ToString());
            }
        }

        protected void lbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddTrams.SelectedIndex >= 0)
            {
                string text = ddTrams.SelectedItem.ToString();
                foreach (Tram tram in this.trams)
                {
                    if (text == tram.ToString())
                    {
                        for (int i = 0; i < ddTrams.Items.Count - 1; i++)
                        {
                            if (ddTrams.Items[i].ToString() == tram.Status.ToString())
                            {
                                ddTrams.SelectedIndex = i;
                            }
                        }
                    }
                }
            }
        }

        protected void btnWijzig_Click(object sender, EventArgs e)
        {
            TramStatus status = (TramStatus)Enum.Parse(typeof(TramStatus), ddStatus.SelectedItem.ToString());
            if (ddTrams.SelectedIndex >= 0)
            {
                string text = ddTrams.SelectedItem.ToString();
                foreach (Tram tram in this.trams)
                {
                    if (text == tram.ToString())
                    {
                        DatabaseManager.Instance.TramstatusVeranderen(status, tram.Id);
                        HaalTramsOp();
                    }
                }
            }
        }
    }
}