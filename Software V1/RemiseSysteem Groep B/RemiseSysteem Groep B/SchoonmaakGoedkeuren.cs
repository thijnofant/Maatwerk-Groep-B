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
    /// 
    /// </summary>
    public partial class SchoonmaakGoedkeuren : Form
    {
        private Remise remise;
        private List<Schoonmaak> schoonmaakbeurten;

        /// <summary>
        /// 
        /// </summary>
        public SchoonmaakGoedkeuren()
        {
            InitializeComponent();
            this.remise = Remise.Instance;
            HaalSchoonmakenOp();
        }

        /// <summary>
        /// 
        /// </summary>
        private void HaalSchoonmakenOp()
        {
            lbxSchoonmaak.Items.Clear();
            List<Beurt> alleBeurten = new List<Beurt>();
            alleBeurten = this.remise.Database.ZoekAlleBeurten();
            this.schoonmaakbeurten = new List<Schoonmaak>();
            foreach (Beurt beurt in alleBeurten)
            {
                if (beurt is Schoonmaak)
                {
                    Schoonmaak schoonmaak = beurt as Schoonmaak;
                    if (!schoonmaak.IsGoedgekeurd)
                    {
                        schoonmaakbeurten.Add(schoonmaak);
                        lbxSchoonmaak.Items.Add(schoonmaak.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGoedkeuren_Click(object sender, EventArgs e)
        {
            string text = lbxSchoonmaak.SelectedItem.ToString();
            foreach (Schoonmaak schoonmaak in schoonmaakbeurten)
            {
                if (text == schoonmaak.ToString())
                {
                    this.remise.Database.BeurtGoedkeurenAfkeuren(schoonmaak.ID, true);
                    HaalSchoonmakenOp();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAfkeuren_Click(object sender, EventArgs e)
        {
            string text = lbxSchoonmaak.SelectedItem.ToString();
            foreach (Schoonmaak schoonmaak in schoonmaakbeurten)
            {
                if (text == schoonmaak.ToString())
                {
                    this.remise.Database.BeurtVerwijderen(schoonmaak);
                    HaalSchoonmakenOp();
                }
            }
        }
    }
}
