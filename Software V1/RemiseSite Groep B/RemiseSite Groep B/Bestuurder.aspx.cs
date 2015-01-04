using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemiseSite_Groep_B
{
    public partial class Bestuurder : System.Web.UI.Page
    {
        //DatabaseManager db = DatabaseManager.Instance;
        //Remise remise = Remise.Instance;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOne_Click(object sender, EventArgs e)
        {
            tbInput.Text = tbInput.Text += "1";//voert cijfer 1 in in invoerveld
        }

        protected void btnTwo_Click(object sender, EventArgs e)
        {
            tbInput.Text = tbInput.Text += "2";//voert cijfer 2 in in invoerveld
        }

        protected void btnThree_Click(object sender, EventArgs e)
        {
            tbInput.Text = tbInput.Text += "3";//voert cijfer 3 in in invoerveld
        }

        protected void btnFour_Click(object sender, EventArgs e)
        {
            tbInput.Text = tbInput.Text += "4";//voert cijfer 4 in in invoerveld
        }

        protected void btnFive_Click(object sender, EventArgs e)
        {
            tbInput.Text = tbInput.Text += "5";//voert cijfer 5 in in invoerveld
        }

        protected void btnSix_Click(object sender, EventArgs e)
        {
            tbInput.Text = tbInput.Text += "6";//voert cijfer 6 in in invoerveld
        }

        protected void btnSeven_Click(object sender, EventArgs e)
        {
            tbInput.Text = tbInput.Text += "7";//voert cijfer 7 in in invoerveld
        }

        protected void btnEight_Click(object sender, EventArgs e)
        {
            tbInput.Text = tbInput.Text += "8";//voert cijfer 8 in in invoerveld
        }

        protected void btnNine_Click(object sender, EventArgs e)
        {
            tbInput.Text = tbInput.Text += "9";//voert cijfer 9 in in invoerveld
        }

        protected void btnZero_Click(object sender, EventArgs e)
        {
            tbInput.Text = tbInput.Text += "0";//voert cijfer 0 in in invoerveld
        }

        protected void btnBackspace_Click(object sender, EventArgs e)
        {
            if (tbInput.Text.Length > 0)
            {
                tbInput.Text = tbInput.Text.Remove(tbInput.Text.Length - 1);// verwijderd laatst ingevoerde cijfer uit het invoerveld
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            bool onderhoud = false;
            bool schoonmaak = false;
            int tramnr = Convert.ToInt32(tbInput.Text);

            if (cbMaintenance.Checked)//wanneer er voor onderhoud is gekozen
            {
                onderhoud = true;
            }
            if (cbCleaning.Checked)//wanneer er voor schoonhoud is gekozen
            {
                schoonmaak = true;
            }

            if (db.ZoekTram(tramnr) != null)//kijkt of de tram bestaat, anders foutmelding
            {
                if (remise.PlaatsAutomatischToewijzen(tramnr, onderhoud, schoonmaak))//roept het algoritme aan
                {
                    if (db.GetToegewezenSpoor(db.ZoekTram(tramnr).Id) != 0)//kijkt of er een toegeweze spoor is
                    {
                        lblGoToTrack.Text = Convert.ToString(db.GetToegewezenSpoor(db.ZoekTram(tramnr).Id));//geeft het toegewezen spoor weer
                    }
                    else//wanneer er geen toegeweze spoor is komt de volgende error
                    {
                        lblMessage.Text = "Het systeem heeft geen spoor kunnen toekennen";
                    }
                }
            }
            else//error wanneer ongeldig tramnr wordt ingevoerd
            {
                lblMessage.Text = "invoer is geen geldige tram";
            }

        }
        }
    }
}