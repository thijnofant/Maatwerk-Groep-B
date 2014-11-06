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
    /// Het form voor het invoeren van schoonmaakberten en onderhoudsbeurten.
    /// </summary>
    public partial class BeheerderApp_SchoonmaakInvoeren : Form
    {
        Remise remise;
        DatabaseManager db;
        List<Tram> tramlijst;
        List<Beurt> beurtenlijst;

        public BeheerderApp_SchoonmaakInvoeren() 
        {
            InitializeComponent();
            remise = Remise.Instance;
            db = DatabaseManager.Instance;
            tramlijst = db.AlleTrams();
            beurtenlijst = db.ZoekAlleBeurten();
            OpstartMethode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInvoeren_Click(object sender, EventArgs e) 
        {
            if (cbxSoortBeurt.SelectedItem == null) 
            {
                MessageBox.Show("Voer in of de beurt een schoonmaak of een reparatie is.", "Error");
                return;
            }
            if (cbxTypeBeurt.SelectedItem == null) 
            {
                MessageBox.Show("Voer het type beurt in.", "Error");
                return;
            }
            if (lbxTrams.SelectedItem == null) 
            {
                MessageBox.Show("Selecteer een tram voor de beurt.", "Error");
                return;
            }
            if (Convert.ToDateTime(dtpDatum.Text) < DateTime.Today) 
            {
                MessageBox.Show("Kan geen beurt plannen in het verleden.", "Error");
                return;
            }

            DateTime gekozendatum = Convert.ToDateTime(dtpDatum.Text);
            string datumstring = Convert.ToString(gekozendatum).Substring(0, 10);
            int kleincount = 0;
            int grootcount = 0;
            List<Schoonmaak> alleschoonmaak = new List<Schoonmaak>();
            List<Onderhoud> alleonderhoud = new List<Onderhoud>();
            foreach (Beurt b in db.ZoekAlleBeurten()) 
            {
                if (b is Schoonmaak)
                    alleschoonmaak.Add(b as Schoonmaak);
                if (b is Onderhoud)
                    alleonderhoud.Add(b as Onderhoud);
            }

            if (Convert.ToString(cbxSoortBeurt.SelectedItem) == "Schoonmaak") {
                foreach (Schoonmaak s in alleschoonmaak) {
                    DateTime datumschoonmaak = s.BeginDatum;
                    string datumschoonmaakstring = Convert.ToString(datumschoonmaak).Substring(0, 10);

                    if (datumstring == datumschoonmaakstring) {
                        if (s.Soort == BeurtType.Groot && (BeurtType)Enum.Parse(typeof(BeurtType), Convert.ToString(cbxTypeBeurt.SelectedItem), true) == BeurtType.Groot) {
                            grootcount++;
                            if (grootcount >= 2) {
                                MessageBox.Show("Te veel grote beurten op deze datum, kies een andere datum.");
                                return;
                            }
                        }
                        if (s.Soort == BeurtType.Klein && (BeurtType)Enum.Parse(typeof(BeurtType), Convert.ToString(cbxTypeBeurt.SelectedItem), true) == BeurtType.Klein) {
                            kleincount++;
                            if (kleincount >= 3) {
                                MessageBox.Show("Te veel kleine beurten op deze datum, kies een andere datum.");
                                return;
                            }
                        }

                    }
                }
            }
            if (Convert.ToString(cbxSoortBeurt.SelectedItem) == "Onderhoud") {
                foreach (Onderhoud o in alleonderhoud) {
                    DateTime datumonderhoud = o.BeginDatum;
                    string datumonderhoudstring = Convert.ToString(datumonderhoud).Substring(0, 10);

                    if (datumstring == datumonderhoudstring) {
                        if (o.Soort == BeurtType.Groot && (BeurtType)Enum.Parse(typeof(BeurtType), Convert.ToString(cbxTypeBeurt.SelectedItem), true) == BeurtType.Groot) {
                            grootcount++;
                            if (grootcount >= 1) {
                                MessageBox.Show("Te veel grote beurten op deze datum, kies een andere datum.");
                                return;
                            }
                        }
                        if (o.Soort == BeurtType.Klein && (BeurtType)Enum.Parse(typeof(BeurtType), Convert.ToString(cbxTypeBeurt.SelectedItem), true) == BeurtType.Klein) {
                            kleincount++;
                            if (kleincount >= 4) {
                                MessageBox.Show("Te veel kleine beurten op deze datum, kies een andere datum.");
                                return;
                            }
                        }

                    }
                }
            }

            if (Convert.ToString(cbxSoortBeurt.SelectedItem) == "Schoonmaak") 
            {
                int beurtid = db.GetInsertID("ID", "Tram_beurt") + 1;
                string tramstring = Convert.ToString(lbxTrams.SelectedItem);
                int tramnummer = Convert.ToInt32(tramstring.Substring(tramstring.IndexOf("-") + 1));
                BeurtType beurttype = (BeurtType)Enum.Parse(typeof(BeurtType), Convert.ToString(cbxTypeBeurt.SelectedItem), true);
                Tram tram = tramlijst.Find(x => x.Nummer == tramnummer);
                DateTime datum = Convert.ToDateTime(dtpDatum.Value);

                Schoonmaak schoonmaak = new Schoonmaak(datum, beurtid, beurttype, tram);
                
                if (db.SchoonmaakInvoeren(schoonmaak))
                    MessageBox.Show("Invoeren succesvol.");
                else
                    MessageBox.Show("Invoeren mislukt.");
            }
            if (Convert.ToString(cbxSoortBeurt.SelectedItem) == "Onderhoud") 
            {
                int beurtid = db.GetInsertID("ID", "Tram_beurt") + 1;
                string tramstring = Convert.ToString(lbxTrams.SelectedItem);
                int tramnummer = Convert.ToInt32(tramstring.Substring(tramstring.IndexOf("-") + 1));
                BeurtType beurttype = (BeurtType)Enum.Parse(typeof(BeurtType), Convert.ToString(cbxTypeBeurt.SelectedItem), true);
                Tram tram = tramlijst.Find(x => x.Nummer == tramnummer);
                DateTime datum = Convert.ToDateTime(dtpDatum.Value);

                Onderhoud onderhoud = new Onderhoud(datum, beurtid, beurttype, tram, DateTime.Now);
                
                if(db.OnderhoudInvoeren(onderhoud))
                    MessageBox.Show("Invoeren succesvol.");
                else
                    MessageBox.Show("Invoeren mislukt.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnnuleren_Click(object sender, EventArgs e) 
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        private void OpstartMethode() 
        {
            foreach (Tram t in tramlijst) 
            {
                string lbstring = t.Type.Naam + " - " + Convert.ToString(t.Nummer);
                lbxTrams.Items.Add(lbstring);
            }
        }

    }
}
