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
    /// Dit Form word gebruikt om de aplicatie te openen voor testen en presentatie.
    /// </summary>
    public partial class OpstartForm : Form
    {
        BeheerApplicatie beheerdersApp;
        BestuurApplicatie bestuurdersApp;
        OnderhoudApplicatie onderhoudsApp;
        SchoonmaakApplicatie schoonmaakApp;

        /// <summary>
        /// Dit is de Constructor voor dit Form.
        /// </summary>
        public OpstartForm() 
        {
            InitializeComponent();
        }

        /// <summary>
        /// Dit is de Methode die wordt aangeroepen als de Beheerder knop wordt aangeklikt. Dit opent het BeheerForm.
        /// </summary>
        private void btnBeheerdersApp_Click(object sender, EventArgs e) 
        {
            beheerdersApp = new BeheerApplicatie();
            beheerdersApp.Show();
        }

        /// <summary>
        /// /// Dit is de Methode die wordt aangeroepen als de Bestuurder knop wordt aangeklikt. Dit opent het BestuurderForm.
        /// </summary>
        private void btnBestuurdersApp_Click(object sender, EventArgs e) 
        {
            bestuurdersApp = new BestuurApplicatie();
            bestuurdersApp.Show();
        }

        /// <summary>
        /// /// Dit is de Methode die wordt aangeroepen als de Onderhoud knop wordt aangeklikt. Dit opent het OnderhoudForm.
        /// </summary>
        private void btnOnderhoudsApp_Click(object sender, EventArgs e) 
        {
            onderhoudsApp = new OnderhoudApplicatie();
            onderhoudsApp.Show();
        }

        /// <summary>
        /// /// Dit is de Methode die wordt aangeroepen als de Schoonmaak knop wordt aangeklikt. Dit opent het SchoonmaakForm.
        /// </summary>
        private void btnSchoonmaakApp_Click(object sender, EventArgs e) 
        {
            schoonmaakApp = new SchoonmaakApplicatie();
            schoonmaakApp.Show();
        }

        /// <summary>
        /// /// Dit is de Methode die wordt aangeroepen als de Simulatie knop wordt aangeklikt. Dit opent het SimulatieForm.
        /// </summary>
        private void btnSimulatie_Click(object sender, EventArgs e)
        {
            simulatieapp simulatie = new simulatieapp();
            simulatie.Show();
        }
        
    }
}
