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
    public partial class SchoonmaakGoedkeuren : Form
    {
        private Remise remise;
        private List<Schoonmaak> schoonmaakbeurten;
        public SchoonmaakGoedkeuren()
        {
            InitializeComponent();
            this.remise = Remise.Instance;
            HaalSchoonmakenOp();
        }

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
                    if (!beurt.IsGoedgekeurd)
                    {
                        Schoonmaak schoonmaak = beurt as Schoonmaak;
                        schoonmaakbeurten.Add(schoonmaak);
                        lbxSchoonmaak.Items.Add(schoonmaak.ToString());
                    }
                }
            }
        }

        private void btnGoedkeuren_Click(object sender, EventArgs e)
        {
            string text = lbxSchoonmaak.SelectedItem.ToString();
            foreach (Schoonmaak schoonmaak in schoonmaakbeurten)
            {
                if (text == schoonmaak.ToString())
                {
                    this.remise.Database.beurtGoedkeuren(schoonmaak.ID);
                    HaalSchoonmakenOp();
                }
            }
        }
    }
}
