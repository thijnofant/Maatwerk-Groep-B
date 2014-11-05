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
        List<Medewerker> medewerkersOnderhoud;
        Medewerker medewerkerOnderhoud;

        DatabaseManager databaseManager;


        public OnderhoudApplicatie()
        {
            InitializeComponent();

            databaseManager = DatabaseManager.Instance;

            medewerkersOnderhoud = new List<Medewerker>();

            LaadMedewerkers();
            LaadOnderhoud();
        }

        public void LaadMedewerkers()
        {
            List<Medewerker> medewerkers = Remise.Instance.Database.OnderhoudsMedewerkersOpvragen();

            foreach(Medewerker medewerker in medewerkers)
            {
                lbxMedewerkers.Items.Add(medewerker);
            }
        }

        public void LaadOnderhoud()
        {
            onderhoudsBeurten = Remise.Instance.Database.OnderhoudsBeurtenOpvragen();

            foreach(Onderhoud onderhoud in onderhoudsBeurten)
            {
                lbxOnderhoudsBeurten.Items.Add(onderhoud);
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

            this.medewerkersOnderhoud = Remise.Instance.Database.MedewerkersOpvragen(onderhoud);

            foreach (Medewerker medewerker in this.medewerkersOnderhoud)
            {
                lbxOnderhoudsMedewerkers.Items.Add(medewerker);
            }
        }

        private void btnVerwijderMedewerker_Click(object sender, EventArgs e)
        {
            onderhoud.VerwijderMedewerker(medewerkerOnderhoud);
        }

        private void lbxOnderhoudsMedewerkers_SelectedIndexChanged(object sender, EventArgs e)
        {
            medewerkerOnderhoud = medewerkersOnderhoud[lbxOnderhoudsMedewerkers.SelectedIndex];
        }

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
    }
}
