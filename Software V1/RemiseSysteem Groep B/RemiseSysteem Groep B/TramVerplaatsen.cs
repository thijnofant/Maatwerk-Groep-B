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
    public partial class TramVerplaatsen : Form
    {
        List<Sector> sectoren;
        List<Spoor> sporen;
        public TramVerplaatsen()
        {
            InitializeComponent();
            sectoren = new List<Sector>();
            sporen = DatabaseManager.Instance.SporenlijstOpvragen();
            foreach (Spoor s in sporen)
            {
                cbbSpoor.Items.Add(s.Nummer);
            }
        }

        private void btnPlaats_Click(object sender, EventArgs e)
        {
            //DatabaseManager.Instance.TramVerplaatsen(tramNr, sect);
        }
        //WTF HIJ CRASHT GEWOON ZONDER REDEN
        private void cbbSpoor_SelectedIndexChanged(object sender, EventArgs e)
        {
            sectoren = DatabaseManager.Instance.GetSectorenFromSpoorNR(Convert.ToInt32(cbbSpoor.SelectedText));
        }

        private void cbbSector_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
