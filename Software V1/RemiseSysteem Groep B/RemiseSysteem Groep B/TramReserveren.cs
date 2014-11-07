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
    /// Form die gebruikt wordt voor het Reserveren van een Tram op een Spoor, met eventuele Reparatie.
    /// </summary>
    public partial class TramReserveren : Form
    {
        DatabaseManager db = DatabaseManager.Instance;

        /// <summary>
        /// Dit is de constructor voor TramReserveren.
        /// </summary>
        public TramReserveren()
        {
            InitializeComponent();
            gbReparatie.Visible = false;//laat reparatie controlls pas zien wanneer er gekozen is voor een reparatie
        }

        /// <summary>
        /// Deze Methode wordt aangeroepen als de CheckBox wordt gecheckt of als ge-unchecked om de Reparatie Controlls weer te geven.
        /// </summary>
        private void chbReparatie_CheckedChanged(object sender, EventArgs e)
        {
            if(chbReparatie.Checked)
            {
                gbReparatie.Visible = true;//laat reparatie controlls pas zien wanneer er gekozen is voor een reparatie
            }
            else
            {
                gbReparatie.Visible = false;//anders niet
            }
        }

        /// <summary>
        /// De Confirm-Button om een Reservering door te voeren.
        /// </summary>
        private void btnBevestig_Click_1(object sender, EventArgs e)
        {
            Tram tram = db.ZoekTram(Convert.ToInt32(tbTramnummer.Text));//haalt tram op uit de database
            db.TramReserveren(tram.Id, Convert.ToInt32(tbSpoornummer.Text));//reserveerd de tram in de database
            BeurtType type = BeurtType.Klein;
            int aantalToegestaandeBeurten = 0;

            //het onderstaande wordt enkel uitgevoerd wanneer er ook is gekozen reparatie
            if (chbReparatie.Checked)
            {
                if(rbGroot.Checked)//voor grote reparatie
                {
                    type = BeurtType.Groot;
                    aantalToegestaandeBeurten = 1;
                }
                if(rbKlein.Checked)//voor kleine reparatie
                {
                    type = BeurtType.Klein;
                    aantalToegestaandeBeurten = 4;
                }
                DateTime datum = Convert.ToDateTime(dtpDatum.Text);//geseleceteerde datum
                Onderhoud onderhoud = new Onderhoud(datum, db.GetInsertID("ID", "TRAM_BEURT"), type, tram, DateTime.Now.AddDays(1.0));//nieuw onderhoud object.

                if (tram != null)
                {
                    if (db.GetAantalBeurten(type.ToString(), "Onderhoud", datum, tram.Id) > aantalToegestaandeBeurten)// kijkt of aantal gebeurde beurten niet het aantaal toegestane beurten overschrijd
                    {
                        db.OnderhoudInvoeren(onderhoud);//maakt reparatie aan in de database
                    }
                    else
                    {
                        lblMessage.Text = "De geselecteerde tram kan niet meer worden ingepland op de geselecteerde dag";
                    }
                }
                else
                {
                    lblMessage.Text = "De ingevoerde tram bestaat niet";
                }
            }
        }
    }
}
