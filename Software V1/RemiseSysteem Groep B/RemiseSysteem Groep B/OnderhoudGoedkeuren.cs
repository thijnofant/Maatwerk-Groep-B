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
    /// Dit is de Form voor het Goedkeuren of Afkeuren van een Onderhoud.
    /// </summary>
    public partial class OnderhoudGoedkeuren : Form
    {
        private Remise remise;

        private List<Onderhoud> onderhoudsBeurten;

        /// <summary>
        /// dit is de constructor van dit form
        /// </summary>
        public OnderhoudGoedkeuren()
        {
            InitializeComponent();
            this.remise = Remise.Instance;
            HaalOnderhoudsBeurtenOp();
        }

        /// <summary>
        /// Dit is de Methode die gebruikt wordt om de Listbox op het Form te vullen met alle OnderhoudsBeurten die nog niet goed gekeurt zijn.
        /// </summary>
        private void HaalOnderhoudsBeurtenOp()
        {
            lbxOnderhoud.Items.Clear();
            List<Beurt> alleBeurten = new List<Beurt>();
            alleBeurten = this.remise.Database.ZoekAlleBeurten();
            this.onderhoudsBeurten = new List<Onderhoud>();
            foreach (Beurt beurt in alleBeurten)
            {
                if (beurt is Onderhoud)
                {
                        Onderhoud onderhoud = beurt as Onderhoud;
                        onderhoudsBeurten.Add(onderhoud);
                        lbxOnderhoud.Items.Add(onderhoud.ToString());
                }
            }
        }

        /// <summary>
        /// Dit is de Methode die wordt aangeroepen als er op de Goedkeuren-Button word gedrukt en deze zorgt dat de geselecteerde Onderhoud in de Database Goedgekeurt word.
        /// </summary>
        private void btnGoedkeuren_Click(object sender, EventArgs e)
        {
            string text = lbxOnderhoud.SelectedItem.ToString();
            foreach (Onderhoud onderhoud in onderhoudsBeurten)
            {
                if (text == onderhoud.ToString())
                {
                    this.remise.Database.BeurtGoedkeurenAfkeuren(onderhoud.ID, true);
                    HaalOnderhoudsBeurtenOp();
                }
            }
        }

        /// <summary>
        /// Dit is de Methode die wordt aangeroepen als er op de Afkeuren-Button word gedrukt en deze zorgt dat de geselecteerde Onderhoud in de Database Afgekeurt word.
        /// </summary>
        private void btnAfkeuren_Click(object sender, EventArgs e)
        {
            string text = lbxOnderhoud.SelectedItem.ToString();
            foreach (Onderhoud onderhoud in onderhoudsBeurten)
            {
                if (text == onderhoud.ToString())
                {
                    this.remise.Database.BeurtGoedkeurenAfkeuren(onderhoud.ID, false);
                    HaalOnderhoudsBeurtenOp();
                }
            }
        }
    }
}
