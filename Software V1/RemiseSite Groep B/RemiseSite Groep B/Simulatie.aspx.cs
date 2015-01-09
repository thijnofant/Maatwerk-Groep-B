using RemiseSite_Groep_B.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemiseSite_Groep_B
{
    public partial class Simulatie : System.Web.UI.Page
    {
        private Remise remise = Remise.Instance;
        private int tramcount = 0;
        List<String> simList = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            sim();
            for (int i = 0; i < simList.Count(); i++)
            {
                lbSumilatie.Items.Add(simList[i]);
            }
        }

        private void sim()
        {
            for (int i = 0; i < 15; i++)
            {
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
                                    simList.Add("Tram " + gekozenTram.Nummer + " ingereden met defect");
                                    //defect
                                    break;
                                case 2:
                                    isGelukt = this.remise.PlaatsAutomatischToewijzen(gekozenTram.Nummer, false, false);
                                    simList.Add("Tram " + gekozenTram.Nummer + " ingereden die vuil is");
                                    //doorrijden
                                    break;
                                case 3:
                                    isGelukt = this.remise.PlaatsAutomatischToewijzen(gekozenTram.Nummer, false, true);
                                    simList.Add("Tram " + gekozenTram.Nummer + " ingereden");
                                    //vuil
                                    break;
                                case 4:
                                    isGelukt = this.remise.PlaatsAutomatischToewijzen(gekozenTram.Nummer, false, false);
                                    simList.Add("Tram " + gekozenTram.Nummer + " ingereden");
                                    //doorrijden
                                    break;
                                case 5:
                                    isGelukt = this.remise.PlaatsAutomatischToewijzen(gekozenTram.Nummer, false, false);
                                    simList.Add("Tram " + gekozenTram.Nummer + " ingereden");
                                    //doorrijden
                                    break;
                                case 6:
                                    isGelukt = this.remise.PlaatsAutomatischToewijzen(gekozenTram.Nummer, false, false);
                                    simList.Add("Tram " + gekozenTram.Nummer + " ingereden");
                                    //doorrijden
                                    break;
                                case 7:
                                    isGelukt = this.remise.PlaatsAutomatischToewijzen(gekozenTram.Nummer, false, false);
                                    simList.Add("Tram " + gekozenTram.Nummer + " ingereden");
                                    //doorrijden
                                    break;
                                case 8:
                                    isGelukt = this.remise.PlaatsAutomatischToewijzen(gekozenTram.Nummer, false, false);
                                    simList.Add("Tram " + gekozenTram.Nummer + " ingereden");
                                    //doorrijden
                                    break;
                                case 9:
                                    isGelukt = this.remise.PlaatsAutomatischToewijzen(gekozenTram.Nummer, false, false);
                                    simList.Add("Tram " + gekozenTram.Nummer + " ingereden");
                                    //doorrijden
                                    break;
                                case 10:
                                    isGelukt = this.remise.PlaatsAutomatischToewijzen(gekozenTram.Nummer, false, false);
                                    simList.Add("Tram " + gekozenTram.Nummer + " ingereden");
                                    //doorrijden
                                    break;
                                default:
                                    isGelukt = this.remise.PlaatsAutomatischToewijzen(gekozenTram.Nummer, true, true);
                                    simList.Add("Tram " + gekozenTram.Nummer + " ingereden");
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
                            simList.Add("Tram " + gekozenTram.Nummer + " uitgereden");
                        }
                    //uitrijden

                }
            }
        }

        protected void btnSim_Click(object sender, EventArgs e)
        {
            sim();
        }
    }
}