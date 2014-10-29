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
    public partial class BeheerApplicatie : Form
    {
        private Remise remise;

        public BeheerApplicatie()
        {
            InitializeComponent();
            this.remise = Remise.Instance;
            

        }

        public void VulSporen()
        {
           List<Spoor> sporen = this.remise.Sporen;
            int spoornummer = 1;
            foreach (Spoor spoor in sporen)
            {
                Control spoorBegin = new Button();
                spoorBegin.Text = "";
                spoorBegin.Click += spoorBegin_Click;
                spoorBegin.Name = "";
                this.splitContainer1.Panel2.Controls.Add(spoorBegin);
                foreach (Sector sector in spoor.Sectoren)
                {
                    Control SectorNieuw = new Button();
                    SectorNieuw.Text = "";
                    SectorNieuw.Click += SectorNieuw_Click;
                    this.splitContainer1.Panel2.Controls.Add(SectorNieuw);
                }
                spoornummer++;
            }
        }

        private void SectorNieuw_Click(object sender, EventArgs e)
        {
            
        }

        private void spoorBegin_Click(object sender, EventArgs e)
        {
            
        }

        private void verplaatsenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reparatieToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void schoonmaakToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void verwijderenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void blokkerenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deblokkerenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void beherenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void beherenToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
