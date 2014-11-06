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
    public partial class TramVerplaatsen : Form
    {
        List<Sector> sectoren;
        List<Spoor> sporen;
        List<Tram> trams;

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        void Update1()
        {
            sporen.Clear();
            trams.Clear();
            

            sporen = DatabaseManager.Instance.SporenlijstOpvragen();
            trams = DatabaseManager.Instance.AlleTrams();
            foreach (Tram tr in trams)
            {
                if (tr.Status != TramStatus.Dienst)
                {
                    cbbTram.Items.Add(tr.Nummer);
                }
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
        /// 
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlaats_Click(object sender, EventArgs e)
        {
            int tram = Convert.ToInt32(cbbTram.SelectedItem.ToString());
            int spoor = Convert.ToInt32(cbbSpoor.SelectedItem.ToString());
            int sector = Convert.ToInt32(cbbSector.SelectedItem.ToString());

            Sector s = new Sector(sector);

            if (DatabaseManager.Instance.TramVerplaatsen(tram, s))
                lblStatus.Text = "Tram " + tram + " is verplaatst naar Spoor:" + spoor + "Sector:" + sector;

            else
                lblStatus.Text = "Er is iets misgegaan bij het plaatsen van de tram";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbSpoor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int temp = Convert.ToInt32(cbbSpoor.SelectedItem.ToString());
            sectoren = DatabaseManager.Instance.GetSectorenFromSpoorNR(temp);
            UpdateSector();
        }

        private void btnVertrek_Click(object sender, EventArgs e)
        {
            int tramnummer = Convert.ToInt32(cbbTram.SelectedItem.ToString());
            Tram gekozenTram = DatabaseManager.Instance.ZoekTram(tramnummer);
            DatabaseManager.Instance.TramRijdUitRemise(tramnummer);

            if (DatabaseManager.Instance.TramstatusVeranderen(TramStatus.Dienst, gekozenTram.Id))
            {
                lblStatus.Text = "Tram " + tramnummer + " is uit Remise gereden";
            }
            else
            {
                lblStatus.Text = "Tram " + tramnummer + " uit remise rijden is mislukt";
            }
        }
    }
}
