﻿using System;
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
    public partial class simulatieapp : Form
    {
        private Remise remise;
        private int tramcount;
        /// <summary>
        /// 
        /// </summary>
        public simulatieapp()
        {
            InitializeComponent();
            this.remise = Remise.Instance;
            Simuleren();
            tramcount = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Simuleren()
        {
            timer1.Interval = 100; //5000;
            timer1.Tick += timer1_Tick;
            timer1.Start();
            //backgroundWorker1.RunWorkerAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(tramcount > 14)
            {
                timer1.Enabled = false;
            }
            tramcount++;
            List<Tram> trams = new List<Tram>();
            bool isGelukt;
            Random willekeurigGetalGenerator = new Random();
            int inOfUitNummer = willekeurigGetalGenerator.Next(0, 5);
            int willekeurigGetal = willekeurigGetalGenerator.Next(10);
            if (inOfUitNummer > 1)
            {
                trams = this.remise.Database.AlleTramsMetStatus(TramStatus.Dienst);
                if (trams != null)
                    if (trams.Count > 0)
                    {
                        Tram gekozenTram = trams[willekeurigGetalGenerator.Next(0, trams.Count - 1)];
                        //inrijden
                        switch (willekeurigGetal)
                        {
                            case 1:
                                isGelukt = this.remise.PlaatsAutomatischToewijzen(gekozenTram.Nummer, true, false);
                                lbxSimulatie.Items.Add("Tram ingereden met defect");
                                //defect
                                break;
                            case 2:
                                isGelukt = this.remise.PlaatsAutomatischToewijzen(gekozenTram.Nummer, false, false);
                                lbxSimulatie.Items.Add("Tram ingereden die vuil is");
                                //doorrijden
                                break;
                            case 3:
                                isGelukt = this.remise.PlaatsAutomatischToewijzen(gekozenTram.Nummer, false, true);
                                lbxSimulatie.Items.Add("Tram ingereden");
                                //vuil
                                break;
                            case 4:
                                isGelukt = this.remise.PlaatsAutomatischToewijzen(gekozenTram.Nummer, false, false);
                                lbxSimulatie.Items.Add("Tram ingereden");
                                //doorrijden
                                break;
                            case 5:
                                isGelukt = this.remise.PlaatsAutomatischToewijzen(gekozenTram.Nummer, false, false);
                                lbxSimulatie.Items.Add("Tram ingereden");
                                //doorrijden
                                break;
                            case 6:
                                isGelukt = this.remise.PlaatsAutomatischToewijzen(gekozenTram.Nummer, false, false);
                                lbxSimulatie.Items.Add("Tram ingereden");
                                //doorrijden
                                break;
                            case 7:
                                isGelukt = this.remise.PlaatsAutomatischToewijzen(gekozenTram.Nummer, false, false);
                                lbxSimulatie.Items.Add("Tram ingereden");
                                //doorrijden
                                break;
                            case 8:
                                isGelukt = this.remise.PlaatsAutomatischToewijzen(gekozenTram.Nummer, false, false);
                                lbxSimulatie.Items.Add("Tram ingereden");
                                //doorrijden
                                break;
                            case 9:
                                isGelukt = this.remise.PlaatsAutomatischToewijzen(gekozenTram.Nummer, false, false);
                                lbxSimulatie.Items.Add("Tram ingereden");
                                //doorrijden
                                break;
                            case 10:
                                isGelukt = this.remise.PlaatsAutomatischToewijzen(gekozenTram.Nummer, false, false);
                                lbxSimulatie.Items.Add("Tram ingereden");
                                //doorrijden
                                break;
                            default:
                                isGelukt = this.remise.PlaatsAutomatischToewijzen(gekozenTram.Nummer, true, true);
                                lbxSimulatie.Items.Add("Tram ingereden");
                                //doorrijden
                                break;
                        }
                    }
            }
            else
            {
                trams = this.remise.Database.AlleTramsMetStatus(TramStatus.Remise);
                if (trams != null)
                    if (trams.Count > 0)
                    {
                        Tram gekozenTram = trams[willekeurigGetalGenerator.Next(0, trams.Count - 1)];
                        this.remise.Database.TramRijdUitRemise(gekozenTram.Nummer);
                        this.remise.Database.TramstatusVeranderen(TramStatus.Dienst, gekozenTram.Id);
                        lbxSimulatie.Items.Add("Tram uitgereden");
                    }
                //uitrijden

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {

        }
    }
}
