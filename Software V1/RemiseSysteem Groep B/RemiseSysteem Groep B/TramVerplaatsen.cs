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
    /// Dit Form word gebruikt voor het plaatsen, verplaatsen en het uitlaten rijden van Trams in de remise.
    /// </summary>
    public partial class TramVerplaatsen : Form
    {
        List<Sector> sectoren;
        List<Spoor> sporen;
        List<Tram> trams;

        /// <summary>
        /// Dit is de constructor voor deze form.
        /// </summary>
        public TramVerplaatsen()
        {
            InitializeComponent();
            sectoren = new List<Sector>();
            sporen = new List<Spoor>();
            trams = new List<Tram>();
            Update1();
        }

        /// <summary>
        /// Dit is de methode die de Sporen-ComboBox en de Trams-ComboBox vult zodat deze hier gekozen kunnen worden.
        /// </summary>
        void Update1()
        {
            sporen.Clear();
            trams.Clear();


            sporen = DatabaseManager.Instance.SporenlijstOpvragen();
            trams = DatabaseManager.Instance.AlleTrams();
            foreach (Tram tr in trams)
            {
                cbbTram.Items.Add(tr.Nummer);
            }
            foreach (Spoor sp in sporen)
            {
                cbbSpoor.Items.Add(sp.Nummer);
            }
            foreach (Sector se in sectoren)
            {
                cbbSector.Items.Add(se.Id);
            }
        }

        /// <summary>
        /// Deze Methode word gebruikt om de Sectoren-ComboBox te vullen als er een Spoor geselcteerd word uit de Sporen-ComboBox.
        /// </summary>
        void UpdateSector()
        {
            cbbSector.Items.Clear();

            foreach (Sector se in sectoren)
            {
                cbbSector.Items.Add(se.Id);
            }
        }

        /// <summary>
        /// Deze Methode word aangeroepen als er op de plaats knop word gedrukt, deze gebruikt de waarden in de ComboBoxen om een Tram te (ver)plaatsen.
        /// </summary>
        private void btnPlaats_Click(object sender, EventArgs e)
        {
            int tram;
            int spoor;
            int sector;
            try
            {
                tram = Convert.ToInt32(cbbTram.SelectedItem.ToString());
            }
            catch
            {
                MessageBox.Show("Controleer of er een tram is geselecteerd.");
                return;
            }
            try
            {
                spoor = Convert.ToInt32(cbbSpoor.SelectedItem.ToString());
            }
            catch
            {
                MessageBox.Show("Controleer of er een Spoor is geselecteerd.");
                return;
            }
            try
            {
                sector = Convert.ToInt32(cbbSector.SelectedItem.ToString());
            }
            catch
            {
                MessageBox.Show("Controleer of er een Secto/r is geselecteerd.");
                return;
            }

            Sector s = new Sector(sector);

            if (DatabaseManager.Instance.TramVerplaatsen(tram, s))
                MessageBox.Show("Tram " + tram + " is verplaatst naar Spoor:" + spoor + "Sector:" + sector + ".");
            else
                MessageBox.Show("Er is iets misgegaan bij het plaatsen van de tram. Controleer of de sector niet Geblokkeerd is of bezet door een andere tram.");
        }

        /// <summary>
        /// Deze Methode word aangeroepen als de index van de Spoor-ComboBox veranderd. Deze zorgt dat de Sector-ComboBox gevuld word met sectoren die bij het spoor horen.
        /// </summary>
        private void cbbSpoor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int temp = Convert.ToInt32(cbbSpoor.SelectedItem.ToString());
            sectoren = DatabaseManager.Instance.GetSectorenFromSpoorNR(temp);
            UpdateSector();
        }

        /// <summary>
        /// Deze Methode word aangeroepen als op de vertrek knop word gedrukt. Deze zorgt dat de geselcteerde tram uit de remise wegrijdt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVertrek_Click(object sender, EventArgs e)
        {
            int tramnummer = Convert.ToInt32(cbbTram.SelectedItem.ToString());
            Tram gekozenTram = DatabaseManager.Instance.ZoekTram(tramnummer);
            DatabaseManager.Instance.TramRijdUitRemise(tramnummer);

            if (DatabaseManager.Instance.TramstatusVeranderen(TramStatus.Dienst, gekozenTram.Id))
            {
                MessageBox.Show("Tram " + tramnummer + " is uit Remise gereden");
            }
            else
            {
                MessageBox.Show("Tram " + tramnummer + " uit remise rijden is mislukt");
            }
        }
    }
}
