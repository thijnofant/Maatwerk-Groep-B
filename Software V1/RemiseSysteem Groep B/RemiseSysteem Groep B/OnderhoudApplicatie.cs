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
    /// 
    /// </summary>
    public partial class OnderhoudApplicatie : Form
    {
        List<Onderhoud> onderhoudsBeurten = new List<Onderhoud>();
        Onderhoud onderhoud;
        List<Medewerker> medewerkers;
        Medewerker medewerker;
        Medewerker medewerkerOnderhoud;
        int medewerkerID;

        DatabaseManager databaseManager;

        /// <summary>
        /// 
        /// </summary>
        public OnderhoudApplicatie()
        {
            InitializeComponent();

            databaseManager = DatabaseManager.Instance;

            medewerkers = new List<Medewerker>();

            LaadMedewerkers();

            if(medewerkers.Count >= 1)
            {
                medewerker = medewerkers[0];
            }

            LaadOnderhoud();
        }

        /// <summary>
        /// 
        /// </summary>
        public void LaadMedewerkers()
        {
            medewerkers = Remise.Instance.Database.OnderhoudsMedewerkersOpvragen();

            foreach (Medewerker medewerker in medewerkers)
            {
                lbxMedewerkers.Items.Add(Convert.ToString(medewerker.Naam));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void LaadOnderhoud()
        {
            onderhoudsBeurten = Remise.Instance.Database.OnderhoudOpvragen();

            foreach(Onderhoud onderhoud in onderhoudsBeurten)
            {
                lbxOnderhoudsBeurten.Items.Add(Convert.ToString(onderhoud.ID));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbxOnderhoudsBeurten_SelectedIndexChanged(object sender, EventArgs e)
        {
            onderhoud = onderhoudsBeurten[lbxOnderhoudsBeurten.SelectedIndex];
            UpdateOnderhoudInfo(onderhoud);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="onderhoud"></param>
        void UpdateOnderhoudInfo(Onderhoud onderhoud)
        {
            tbxDatum.Text = Convert.ToString(onderhoud.TijdsIndicatie);
            if(tbxDatum.Text == "01/01/0001 00:00:00")
            {
                tbxDatum.Text = "";
            }

            medewerkerID = Remise.Instance.Database.MedewerkerOpvragen(onderhoud);

            if(medewerkerID != -1)
            {
                medewerkerOnderhoud = this.databaseManager.ZoekMedewerkerOpID(medewerkerID);

                tbxMedewerkerOnderhoud.Text = medewerkerOnderhoud.Naam;
            }
            else
            {
                tbxMedewerkerOnderhoud.Text = "Geen medewerker.";
            }

            if(this.databaseManager.IsKlaar(onderhoud))
            {
                chxKlaar.Checked = true;
            }
            else
            {
                chxKlaar.Checked = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVerwijderMedewerker_Click(object sender, EventArgs e)
        {
            if(!this.databaseManager.VerwijderMedewerkerVanOnderhoud(onderhoud))
            {
                MessageBox.Show("Medewerker verwijderen mislukt.");
            }
            UpdateOnderhoudInfo(onderhoud);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVoegMedewerkerToe_Click(object sender, EventArgs e)
        {
            if(lbxMedewerkers.SelectedIndex != -1 && lbxOnderhoudsBeurten.SelectedIndex != -1)
            {
                if (!this.databaseManager.VoegMedewerkerToeAanOnderhoud(medewerkers[lbxMedewerkers.SelectedIndex], onderhoud))
                {
                    MessageBox.Show("Toevoegen mislukt.");
                }
                UpdateOnderhoudInfo(onderhoud);
            }
            else
            {
                MessageBox.Show("Geen medewerker of onderhoudsbeurt geselecteerd.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTijdsIndicatieWijzigen_Click(object sender, EventArgs e)
        {
            string uur = Convert.ToString(nudUur.Value);
            string minuut = Convert.ToString(nudMinuut.Value);
            if(nudUur.Value < 10)
            {
                uur = "0" + Convert.ToString(nudUur.Value);
            }
            if(nudMinuut.Value < 10)
            {
                minuut = "0" + Convert.ToString(nudMinuut.Value);
            }
            DateTime datum = Convert.ToDateTime(dtpDatum.Value + " " + uur + ":" + minuut);
            if(!this.databaseManager.WijzigTijdsIndicatieOnderhoud(datum, onderhoud))
            {
                MessageBox.Show("Tijdsindicatie wijzigen mislukt.");
            }
            UpdateOnderhoudInfo(onderhoud);
        }

        private void chxKlaar_CheckedChanged(object sender, EventArgs e)
        {
            //if(chxKlaar.Checked == true)
            //{
            //    DateTime datum = dtpDatum.Value;
            //    datum.AddHours(Convert.ToDouble(nudUur.Value));
            //    datum.AddMinutes(Convert.ToDouble(nudMinuut.Value));

            //    this.databaseManager.WijzigKlaar(onderhoud, true);
            //    this.databaseManager.WijzigTijdsIndicatieOnderhoud(datum, onderhoud);
            //}
            //else
            //{
            //    this.databaseManager.WijzigKlaar(onderhoud, false);
            //}
        }

        private void chxKlaar_MouseClick(object sender, MouseEventArgs e)
        {
            if (chxKlaar.Checked == true)
            {
                DateTime datum = dtpDatum.Value;
                datum.AddHours(Convert.ToDouble(nudUur.Value));
                datum.AddMinutes(Convert.ToDouble(nudMinuut.Value));

                this.databaseManager.WijzigKlaar(onderhoud, true);
                this.databaseManager.WijzigTijdsIndicatieOnderhoud(datum, onderhoud);
            }
            else
            {
                this.databaseManager.WijzigKlaar(onderhoud, false);
            }
        }
    }
}
