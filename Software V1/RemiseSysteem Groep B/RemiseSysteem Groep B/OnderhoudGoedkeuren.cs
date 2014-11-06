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
    public partial class OnderhoudGoedkeuren : Form
    {
        private Remise remise;

        private List<Onderhoud> onderhoudsBeurten;

        /// <summary>
        /// 
        /// </summary>
        public OnderhoudGoedkeuren()
        {
            InitializeComponent();
            this.remise = Remise.Instance;
            HaalOnderhoudsBeurtenOp();
        }

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
