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
    public partial class OpstartForm : Form
    {
        private Remise remise;
        BeheerApplicatie beheerdersApp;
        BestuurApplicatie bestuurdersApp;
        OnderhoudApplicatie onderhoudsApp;
        SchoonmaakApplicatie schoonmaakApp;

        public OpstartForm() {
            InitializeComponent();
            beheerdersApp = new BeheerApplicatie();
            bestuurdersApp = new BestuurApplicatie();
            onderhoudsApp = new OnderhoudApplicatie();
            schoonmaakApp = new SchoonmaakApplicatie();
            this.remise = Remise.Instance;
            //Simulatie();
        }

        private void btnBeheerdersApp_Click(object sender, EventArgs e) 
        {
            beheerdersApp.Show();
        }

        private void btnBestuurdersApp_Click(object sender, EventArgs e) 
        {
            bestuurdersApp.Show();
        }

        private void btnOnderhoudsApp_Click(object sender, EventArgs e) 
        {
            onderhoudsApp.Show();
        }

        private void btnSchoonmaakApp_Click(object sender, EventArgs e) 
        {
            schoonmaakApp.Show();
        }

        private void Simulatie()
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            List<Tram> trams = new List<Tram>();
            bool isGelukt;
            Random willekeurigGetalGenerator = new Random();
            int inOfUitNummer = willekeurigGetalGenerator.Next(0, 2);
            int willekeurigGetal = willekeurigGetalGenerator.Next(10);
            if (inOfUitNummer > 1)
            {
                trams = this.remise.Database.AlleTramsMetStatus(TramStatus.Dienst);
                Tram gekozenTram = trams[willekeurigGetalGenerator.Next(trams.Count - 1)];
                //inrijden
                switch (willekeurigGetal)
                {
                    case 1:
                        isGelukt = this.remise.PlaatsAutomatischToewijzen(gekozenTram.Nummer, true, false);
                        //defect
                        break;
                    case 2:
                        isGelukt = this.remise.PlaatsAutomatischToewijzen(gekozenTram.Nummer, false, false);
                        //doorrijden
                        break;
                    case 3:
                        isGelukt = this.remise.PlaatsAutomatischToewijzen(gekozenTram.Nummer, false, true);
                        //vuil
                        break;
                    case 4:
                        isGelukt = this.remise.PlaatsAutomatischToewijzen(gekozenTram.Nummer, false, false);
                        //doorrijden
                        break;
                    case 5:
                        isGelukt = this.remise.PlaatsAutomatischToewijzen(gekozenTram.Nummer, false, false);
                        //doorrijden
                        break;
                    case 6:
                        isGelukt = this.remise.PlaatsAutomatischToewijzen(gekozenTram.Nummer, false, false);
                        //doorrijden
                        break;
                    case 7:
                        isGelukt = this.remise.PlaatsAutomatischToewijzen(gekozenTram.Nummer, false, false);
                        //doorrijden
                        break;
                    case 8:
                        isGelukt = this.remise.PlaatsAutomatischToewijzen(gekozenTram.Nummer, false, false);
                        //doorrijden
                        break;
                    case 9:
                        isGelukt = this.remise.PlaatsAutomatischToewijzen(gekozenTram.Nummer, false, false);
                        //doorrijden
                        break;
                    case 10:
                        isGelukt = this.remise.PlaatsAutomatischToewijzen(gekozenTram.Nummer, false, false);
                        //doorrijden
                        break;
                    default:
                        isGelukt = this.remise.PlaatsAutomatischToewijzen(gekozenTram.Nummer, false, false);
                        //doorrijden
                        break;
                }

            }
            else
            {
                trams = this.remise.Database.AlleTramsMetStatus(TramStatus.Remise);
                Tram gekozenTram = trams[willekeurigGetalGenerator.Next(trams.Count - 1)];
                
                //uitrijden

            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            timer1.Interval = 5000;
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }
    }
}
