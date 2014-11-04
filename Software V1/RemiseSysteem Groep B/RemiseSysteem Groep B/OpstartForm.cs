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
    public partial class OpstartForm : Form
    {
        BeheerApplicatie beheerdersApp;
        BestuurApplicatie bestuurdersApp;
        OnderhoudApplicatie onderhoudsApp;
        SchoonmaakApplicatie schoonmaakApp;

        public OpstartForm() {
            InitializeComponent();
            beheerdersApp = new BeheerApplicatie();
            bestuurdersApp = new BestuurApplicatie();
            onderhoudsApp = new OnderhoudApplicatie();
            schoonmaakApp = new SchoonmaakApplicatie();
            Simulatie();
        }

        private void btnBeheerdersApp_Click(object sender, EventArgs e) 
        {
            beheerdersApp.Show();
        }

        private void btnBestuurdersApp_Click(object sender, EventArgs e) 
        {
            bestuurdersApp.Show();
        }

        private void btnOnderhoudsApp_Click(object sender, EventArgs e) 
        {
            onderhoudsApp.Show();
        }

        private void btnSchoonmaakApp_Click(object sender, EventArgs e) 
        {
            schoonmaakApp.Show();
        }

        private void Simulatie()
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random willekeurigGetalGenerator = new Random();
            int willekeurigGetal = willekeurigGetalGenerator.Next(0, 5);
            if (willekeurigGetal == 1)
            {
                
            }
            else if (willekeurigGetal == 2)
            {
                
            }
            else if (willekeurigGetal == 3)
            {
                
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            timer1.Interval = 5000;
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }
    }
}
