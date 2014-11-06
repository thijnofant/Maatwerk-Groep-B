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
    public partial class TramstatusWijzigen : Form
    {
        private Remise remise;
        private List<Tram> trams;
        public TramstatusWijzigen()
        {
            InitializeComponent();
            this.remise = Remise.Instance;
            cbxStatus.Items.Add(TramStatus.Defect.ToString());
            cbxStatus.Items.Add(TramStatus.Dienst.ToString());
            cbxStatus.Items.Add(TramStatus.Remise.ToString());
            cbxStatus.Items.Add(TramStatus.Schoonmaak.ToString());
            HaalTramsOp();
        }

        private void HaalTramsOp()
        {
            lbxTrams.Items.Clear();
            this.trams = new List<Tram>();
            this.trams = this.remise.Database.AlleTrams();
            foreach (Tram tram in this.trams)
            {
                lbxTrams.Items.Add(tram.ToString());
            }
        }

        private void btnWijzigStatus_Click(object sender, EventArgs e)
        {
            TramStatus status = (TramStatus) Enum.Parse(typeof (TramStatus), cbxStatus.SelectedItem.ToString());
            if (lbxTrams.SelectedIndex >= 0)
            {
                string text = lbxTrams.SelectedItem.ToString();
                foreach (Tram tram in this.trams)
                {
                    if (text == tram.ToString())
                    {
                        this.remise.Database.TramstatusVeranderen(status, tram.Id);
                        HaalTramsOp();
                    }
                }
            }
        }

        private void lbxTrams_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxTrams.SelectedIndex >= 0)
            {
                string text = lbxTrams.SelectedItem.ToString();
                foreach (Tram tram in this.trams)
                {
                    if (text == tram.ToString())
                    {
                        for (int i = 0; i < cbxStatus.Items.Count - 1; i++)
                        {
                            if (cbxStatus.Items[i].ToString() == tram.Status.ToString())
                            {
                                cbxStatus.SelectedIndex = i;
                            }
                        }
                    }
                }
            }
        }
    }
}
