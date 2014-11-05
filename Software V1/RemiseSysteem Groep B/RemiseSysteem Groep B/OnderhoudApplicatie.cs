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
            tbxDatum.Text = Convert.ToString(onderhoud.BeginDatum);

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
            onderhoud.VerwijderMedewerker(medewerker);
        }

        //private void lbxOnderhoudsMedewerkers_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    medewerker = medewerkers[lbxOnderhoudsMedewerkers.SelectedIndex];
        //}

        private void btnTijdsIndicatieWijzigen_Click(object sender, EventArgs e)
        {
            if (onderhoud != null)
            {
                onderhoud.TijdsIndicatieWijzigen(dtpDatum.Value);
            }
            else
            {
                MessageBox.Show("Er is nog geen onderhoud geselecteerd.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(databaseManager.Test())
            {
                MessageBox.Show("Succes");
            }
            else
            {
                MessageBox.Show("Fail");
            }

        }

        private void btnVoegMedewerkerToe_Click(object sender, EventArgs e)
        {
            if(lbxMedewerkers.SelectedIndex != -1 && lbxOnderhoudsBeurten.SelectedIndex != -1)
            {
                if (!this.databaseManager.VoegMedewerkerToeAanOnderhoud(medewerkers[lbxMedewerkers.SelectedIndex], onderhoud))
                {
                    MessageBox.Show("Toevoegen mislukt.");
                }
            }
            else
            {
                MessageBox.Show("Geen medewerker of onderhoudsbeurt geselecteerd.");
            }
        }
    }
}
