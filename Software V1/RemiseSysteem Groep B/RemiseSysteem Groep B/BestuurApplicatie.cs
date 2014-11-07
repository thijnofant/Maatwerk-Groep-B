using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemiseSysteem_Groep_B
{
    /// <summary>
    /// Het form voor het bestuursysteem waarmee inkomende treinen worden geregistreerd en 
    /// waar sporen automatisch worden toegekend. 
    /// ook is het mogelijk om een schoonmaak of reparatie aanvraag te doen.
    /// </summary>
    public partial class BestuurApplicatie : Form
    {
        DatabaseManager db = DatabaseManager.Instance;
        Remise remise = Remise.Instance;


        public BestuurApplicatie()
        {
            InitializeComponent();     
        }


        private void btnOne_Click(object sender, EventArgs e)
        {
            tbxInput.Text = tbxInput.Text += "1";//voert cijfer 1 in in invoerveld
        }


        private void btnTwo_Click(object sender, EventArgs e)
        {
            tbxInput.Text = tbxInput.Text += "2";//voert cijfer 2 in in invoerveld
        }


        private void btnThree_Click(object sender, EventArgs e)
        {
            tbxInput.Text = tbxInput.Text += "3";//voert cijfer 3 in in invoerveld
        }


        private void btnFour_Click(object sender, EventArgs e)
        {
            tbxInput.Text = tbxInput.Text += "4";//voert cijfer 4 in in invoerveld
        }


        private void btnFive_Click(object sender, EventArgs e)
        {
            tbxInput.Text = tbxInput.Text += "5";//voert cijfer 5 in in invoerveld
        }


        private void btnSix_Click(object sender, EventArgs e)
        {
            tbxInput.Text = tbxInput.Text += "6";//voert cijfer 6 in in invoerveld
        }


        private void btnSeven_Click(object sender, EventArgs e)
        {
            tbxInput.Text = tbxInput.Text += "7";//voert cijfer 7 in in invoerveld
        }


        private void btnEight_Click(object sender, EventArgs e)
        {
            tbxInput.Text = tbxInput.Text += "8";//voert cijfer 8 in in invoerveld
        }


        private void btnNine_Click(object sender, EventArgs e)
        {
            tbxInput.Text = tbxInput.Text += "9";//voert cijfer 9 in in invoerveld
        }


        private void btnZero_Click(object sender, EventArgs e)
        {
            tbxInput.Text = tbxInput.Text += "0"; //voert cijfer 0 in in invoerveld
        }


        private void btnCorrect_Click(object sender, EventArgs e)
        {
            if (tbxInput.Text.Length > 0)
            {
                tbxInput.Text = tbxInput.Text.Remove(tbxInput.Text.Length - 1);// verwijderd laatst ingevoerde cijfer uit het invoerveld
            }
        }


        private void rbnYes_CheckedChanged(object sender, EventArgs e)
        {
            btnConfirm.Visible = true; //laat bevestig knop pas zien wanneer er een onderhoud keuze is gemaakt
        }


        private void rbnNo_CheckedChanged(object sender, EventArgs e)
        {
            btnConfirm.Visible = true; //laat bevestig knop pas zien wanneer er een onderhoud keuze is gemaakt
            
        }

        /// <summary>
        /// Deze Methode wordt aangeroepen als op de confirm-button wordt geklikt. Deze roept Remise.AutomatischInvoeren aan om de invoer af te handelen.
        /// </summary>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            bool onderhoud = false;
            bool schoonmaak = false;
            int tramnr = Convert.ToInt32(tbxInput.Text);

            if(rbJa.Checked)//wanneer er voor onderhoud is gekozen
            {
               onderhoud = true;
            }
            if (chbschoonmaak.Checked)//wanneer er voor schoonhoud is gekozen
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


        private void rbJa_CheckedChanged(object sender, EventArgs e)
        {
            btnConfirm.Visible = true; //laat bevestig knop pas zien wanneer er een onderhoud keuze is gemaakt
        }


        private void rbNee_CheckedChanged(object sender, EventArgs e)
        {
            btnConfirm.Visible = true; //laat bevestig knop pas zien wanneer er een onderhoud keuze is gemaakt
        }
    }
}
