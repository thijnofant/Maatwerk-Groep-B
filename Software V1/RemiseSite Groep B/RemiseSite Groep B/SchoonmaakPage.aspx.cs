using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemiseSite_Groep_B
{
    public partial class SchoonmaakPage : System.Web.UI.Page
    {
        DatabaseManager dm;
        Classes.Medewerker mw;

        List<Classes.Medewerker> mwList;
        List<Classes.Schoonmaak> smList;

        List<Classes.Medewerker> mwsmList;

        protected void Page_Load(object sender, EventArgs e)
        {
            dm = DatabaseManager.Instance;

            //Checks if employee is logged in
            if (Session["LoggedInMedewerker"] == null)
            {
                //TODO: Modify!!!
                Response.Redirect("Account/Login.aspx");
            }
            else
            {
                mw = (Classes.Medewerker)Session["LoggedInMedewerker"];
            }

            //Checks for employee type
            if (mw.MedewerkerType == Classes.MedewerkerType.Beheerder)
            {
                pnlSchoonmaak.Visible = false;
                lblSchoonmaker.Visible = false;
                lbxBeheerderMedewerker.Visible = true;
                btnSchoonmaakMedewerkers.Visible = true;
                pnlBeheerder.Visible = true;

                FillBeheerderMedewerker();

                if (Session["SelectedMedewerker"] != null)
                {
                    FillSchoonmaakBeurten((int)Session["SelectedMedewerker"]);
                }
            }
            else if (mw.MedewerkerType == Classes.MedewerkerType.Schoonmaker)
            {
                pnlSchoonmaak.Visible = false;
                lblSchoonmaker.Visible = true;
                lbxBeheerderMedewerker.Visible = false;
                btnSchoonmaakMedewerkers.Visible = false;
                pnlBeheerder.Visible = false;

                FillSchoonmaakBeurten(mw.Id);
            }
            else
            {
                //TODO: Modify!!!
                Response.Redirect("Home.aspx");
            }

            if (Session["SelectedSchoonmaak"] != null)
            {
                pnlSchoonmaak.Visible = true;

                UpdateSchoonmaakPanel((Classes.Schoonmaak)Session["SelectedSchoonmaak"]);
            }

            if (Session["SelectedBeurt"] != null)
            {
                UpdateInfo((int)Session["SelectedBeurt"]);
            }
        }

        protected void UpdateInfo(int beurtId)
        {

        }

        protected void FillSchoonmaakBeurten(int mwId)
        {
            smList = dm.SchoonmaakOpvragen(mwId);

            foreach(Classes.Schoonmaak smTemp in smList)
            {
                lbxSchoonmaakBeurten.Items.Add("ID: " + smTemp.ID + " Tram: " + smTemp.Tram.Nummer);
            }
        }

        protected void FillBeheerderMedewerker()
        {
            mwList = dm.SchoonmaakMedewerkersOpvragen();

            foreach (Classes.Medewerker mwTemp in mwList)
            {
                lbxBeheerderMedewerker.Items.Add("ID: " + mwTemp.Id + " Naam: " + mwTemp.Naam);
            }
        }

        protected void UpdateSchoonmaakPanel(Classes.Schoonmaak sm)
        {
            lblSchoonmaakBeurtId.Text = Convert.ToString(sm.ID);
            lblSchoonmaakBeurtType.Text = Convert.ToString(sm.Soort);
            lblSchoonmaakTram.Text = Convert.ToString(sm.Tram.Nummer);
            lblSchoonmaakSpoor.Text = Convert.ToString(sm.Tram.StaatOpSector.SpoorID);
            lblSchoonmaakSector.Text = Convert.ToString(sm.Tram.StaatOpSector.Id);
            lblSchoonmaakBeginDatum.Text = Convert.ToString(sm.BeginDatum);

            FillSchoonmaakMedewerkers(sm.ID);
        }

        protected void FillSchoonmaakMedewerkers(int smId)
        {
            mwsmList = dm.MedewerkersSchoonmaakOpvragen(smId);

            foreach(Classes.Medewerker mwTemp in mwsmList)
            {
                lbxBeheerderMedewerkers.Items.Add("ID: " + mwTemp.Id + " Naam: " + mwTemp.Naam);
            }
        }

        protected void lbxBeheerderMedewerker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["SelectedMedewerker"] = mwList[lbxBeheerderMedewerker.SelectedIndex].Id;

            Response.Redirect("SchoonmaakPage.aspx");
        }
    }
}