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
        DatabaseManager databaseManager;

        public BeheerApplicatie()
        {
            InitializeComponent();
            databaseManager = DatabaseManager.Instance;
            this.remise = Remise.Instance;
            List<Sector> sectoren = new List<Sector>();
            List<Lijn> lijnen = new List<Lijn>();
            Sector s;
            s = new Sector(1, false);
            sectoren.Add(s);
            s = new Sector(2, false);
            sectoren.Add(s);
            s = new Sector(3, false);
            sectoren.Add(s);
            s = new Sector(4, false);
            sectoren.Add(s);
            s = new Sector(5, false);
            sectoren.Add(s);
            Spoor spoor1 = new Spoor(1, sectoren, lijnen);
            sectoren = new List<Sector>();
            lijnen = new List<Lijn>();
            s = new Sector(1, false);
            sectoren.Add(s);
            s = new Sector(2, false);
            sectoren.Add(s);
            s = new Sector(3, false);
            sectoren.Add(s);
            s = new Sector(4, false);
            sectoren.Add(s);
            s = new Sector(5, false);
            sectoren.Add(s);
            Spoor spoor2 = new Spoor(1, sectoren, lijnen);
            sectoren = new List<Sector>();
            lijnen = new List<Lijn>();
            s = new Sector(1, false);
            sectoren.Add(s);
            s = new Sector(2, false);
            sectoren.Add(s);
            s = new Sector(3, false);
            sectoren.Add(s);
            s = new Sector(4, false);
            sectoren.Add(s);
            s = new Sector(5, false);
            sectoren.Add(s);
            Spoor spoor3 = new Spoor(1, sectoren, lijnen);
            this.remise.Sporen.Add(spoor1);
            this.remise.Sporen.Add(spoor2);
            this.remise.Sporen.Add(spoor3);
            VulSporen();
        }

        public void VulSporen()
        {
            List<Spoor> sporen = this.remise.Sporen;
            int spoornummer = 1;
            Point location = new Point(splitContainer1.Panel2.Location.X, splitContainer1.Panel2.Location.Y);
            foreach (Spoor spoor in sporen)
            {
                location.X += 5;
                location.Y += 5;
                Control spoorBegin = new Button();
                spoorBegin.Text = "Spoor " + spoornummer;
                spoorBegin.Click += spoorBegin_Click;
                spoorBegin.Name = "";
                this.splitContainer1.Panel2.Controls.Add(spoorBegin);

                foreach (Sector sector in spoor.Sectoren)
                {
                    Control SectorNieuw = new Button();
                    SectorNieuw.Text = "";
                    SectorNieuw.Click += SectorNieuw_Click;
                    SectorNieuw.Location = new Point(location.X, location.Y);
                    this.splitContainer1.Panel2.Controls.Add(SectorNieuw);
                }
                spoornummer++;
            }
        }

        private void SectorNieuw_Click(object sender, EventArgs e)
        {
            MessageBox.Show("gegenereerde button aangeklikt!");
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
            Schoonmaak testSchoonmaak = new Schoonmaak(new DateTime(2014, 10, 31), 1, BeurtType.Groot, new Tram(1, new TramType("pingpong", 0)));
            if (databaseManager.SchoonmaakInvoeren(testSchoonmaak))
                MessageBox.Show("Succes");
            else
                MessageBox.Show("Fail");
            
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

        private void schoonmaakLijstOpvragenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Schoonmaak> temp = new List<Schoonmaak>();

        }
    }
}
