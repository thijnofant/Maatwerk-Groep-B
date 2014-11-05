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
            db.TramReserveren(Convert.ToInt32(tbTramnummer.Text), Convert.ToInt32(tbSpoornummer.Text));

            if (chbReparatie.Checked)
            {
                Tram tram = db.ZoekTram(Convert.ToInt32(tbTramnummer.Text));
                DateTime datum = Convert.ToDateTime(dtpDatum.Text);
                Onderhoud onderhoud = new Onderhoud(datum, db.GetInsertID("ID", "TRAM_BEURT"), BeurtType.Klein, tram);
                db.OnderhoudInvoeren(onderhoud);
            }
        }
    }
}
