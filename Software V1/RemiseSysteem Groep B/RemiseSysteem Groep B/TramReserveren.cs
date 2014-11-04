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
        }

        private void btnBevestig_Click(object sender, EventArgs e)
        {
            db.TramReserveren(Convert.ToInt32(tbTramnummer.Text), Convert.ToInt32(tbSpoornummer.Text));
            
            if(chbReparatie.Checked)
            {
                Onderhoud onderhoud = new Onderhoud(DateTime.Now, )
            }
        }
    }
}
