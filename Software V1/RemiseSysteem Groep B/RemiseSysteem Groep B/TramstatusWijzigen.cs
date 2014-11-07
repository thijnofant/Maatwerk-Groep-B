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
    /// Dit is de form waar de Status van een Tram gewijzigd kan worden.
    /// </summary>
    public partial class TramstatusWijzigen : Form
    {
        private Remise remise;
        private List<Tram> trams;

        /// <summary>
        /// Dit is de Constructor van deze Form.
        /// </summary>
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

        /// <summary>
        /// Dit is de Methode die zorgt dat alle Trams met hun actueele Status uit de Database worden geladen en in de Listbox op het Form komen.
        /// </summary>
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

        /// <summary>
        /// Deze Methode wordt aangeroepen als er op de Status Wijzigen Knop gedrukt wordt. Dit veranderd de Status van de Tram in de Database en vernieuwd daarna de Listbox op het Form.
        /// </summary>
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

        /// <summary>
        /// Deze Methode wordt aangeroepen als de SelectedIndex word veranderd in de ListBox op het form. Deze laat in de ComboBox op het form de juiste status zien die de geselecteerde Tram heeft.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
