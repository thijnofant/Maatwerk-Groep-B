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
    public partial class TramReserveren : Form
    {
        DatabaseManager db = DatabaseManager.Instance;
        public TramReserveren()
        {
            InitializeComponent();
            gbReparatie.Visible = false;
        }

        private void chbReparatie_CheckedChanged(object sender, EventArgs e)
        {
            if(chbReparatie.Checked)
            {
                gbReparatie.Visible = true;
            }
            else
            {
                gbReparatie.Visible = false;
            }
        }

        private void btnBevestig_Click_1(object sender, EventArgs e)
        {
            Tram tram = db.ZoekTram(Convert.ToInt32(tbTramnummer.Text));
            db.TramReserveren(tram.Id, Convert.ToInt32(tbSpoornummer.Text));
            BeurtType type = BeurtType.Klein;
            int aantalToegestaandeBeurten = 0;

            if (chbReparatie.Checked)
            {
                if(rbGroot.Checked)
                {
                    type = BeurtType.Groot;
                    aantalToegestaandeBeurten = 1;
                }
                if(rbKlein.Checked)
                {
                    type = BeurtType.Klein;
                    aantalToegestaandeBeurten = 4;
                }
                DateTime datum = Convert.ToDateTime(dtpDatum.Text);
                Onderhoud onderhoud = new Onderhoud(datum, db.GetInsertID("ID", "TRAM_BEURT"), type, tram);

                if (db.GetAantalBeurten(type.ToString(), datum, tram.Id) > aantalToegestaandeBeurten)
                {
                    db.OnderhoudInvoeren(onderhoud);
                }
                
            }
        }
    }
}
