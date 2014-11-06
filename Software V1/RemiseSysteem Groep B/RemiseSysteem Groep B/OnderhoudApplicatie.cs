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
    public partial class OnderhoudApplicatie : Form
    {
        List<Onderhoud> onderhoudsBeurten = new List<Onderhoud>();
        Onderhoud onderhoud;
        List<Medewerker> medewerkers;
        Medewerker medewerker;
        Medewerker medewerkerOnderhoud;
        int medewerkerID;

        DatabaseManager databaseManager;


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

        public void LaadMedewerkers()
        {
            medewerkers = Remise.Instance.Database.OnderhoudsMedewerkersOpvragen();

            foreach (Medewerker medewerker in medewerkers)
            {
                lbxMedewerkers.Items.Add(Convert.ToString(medewerker.Naam));
            }
        }

        public void LaadOnderhoud()
        {
            onderhoudsBeurten = Remise.Instance.Database.OnderhoudOpvragen();

            foreach(Onderhoud onderhoud in onderhoudsBeurten)
            {
                lbxOnderhoudsBeurten.Items.Add(Convert.ToString(onderhoud.ID));
            }
        }

        private void lbxOnderhoudsBeurten_SelectedIndexChanged(object sender, EventArgs e)
        {
            onderhoud = onderhoudsBeurten[lbxOnderhoudsBeurten.SelectedIndex];
            UpdateOnderhoudInfo(onderhoud);
        }

        void UpdateOnderhoudInfo(Onderhoud onderhoud)
        {
            tbxDatum.Text = Convert.ToString(onderhoud.TijdsIndicatie);

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
        }

        private void btnVerwijderMedewerker_Click(object sender, EventArgs e)
        {
            if(!this.databaseManager.VerwijderMedewerkerVanOnderhoud(onderhoud))
            {
                MessageBox.Show("Medewerker verwijderen mislukt.");
            }
            UpdateOnderhoudInfo(onderhoud);
        }

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
    }
}
