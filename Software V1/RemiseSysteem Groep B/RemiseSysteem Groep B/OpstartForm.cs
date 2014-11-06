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
    public partial class OpstartForm : Form
    {
        BeheerApplicatie beheerdersApp;
        BestuurApplicatie bestuurdersApp;
        OnderhoudApplicatie onderhoudsApp;
        SchoonmaakApplicatie schoonmaakApp;

        /// <summary>
        /// 
        /// </summary>
        public OpstartForm() 
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBeheerdersApp_Click(object sender, EventArgs e) 
        {
            beheerdersApp = new BeheerApplicatie();
            beheerdersApp.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBestuurdersApp_Click(object sender, EventArgs e) 
        {
            bestuurdersApp = new BestuurApplicatie();
            bestuurdersApp.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOnderhoudsApp_Click(object sender, EventArgs e) 
        {
            onderhoudsApp = new OnderhoudApplicatie();
            onderhoudsApp.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSchoonmaakApp_Click(object sender, EventArgs e) 
        {
            schoonmaakApp = new SchoonmaakApplicatie();
            schoonmaakApp.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSimulatie_Click(object sender, EventArgs e)
        {
            simulatieapp simulatie = new simulatieapp();
            simulatie.Show();
        }
        
    }
}
