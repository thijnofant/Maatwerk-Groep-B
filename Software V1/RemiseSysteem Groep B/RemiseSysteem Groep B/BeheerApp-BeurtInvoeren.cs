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
            if (Convert.ToString(cbxSoortBeurt.SelectedItem) == "Schoonmaak") 
            {
                int beurtid = db.GetInsertID("ID", "Tram_beurt") + 1;
                string tramstring = Convert.ToString(lbxTrams.SelectedItem);
                int tramnummer = Convert.ToInt32(tramstring.Substring(tramstring.IndexOf("-") + 1));
                BeurtType beurttype = (BeurtType)Enum.Parse(typeof(BeurtType), Convert.ToString(cbxTypeBeurt.SelectedItem), true);
                Tram tram = tramlijst.Find(x => x.Nummer == tramnummer);
                DateTime datum = Convert.ToDateTime(dtpDatum.Value);

                Schoonmaak schoonmaak = new Schoonmaak(datum, beurtid, beurttype, tram);
                db.SchoonmaakInvoeren(schoonmaak);
                this.Close();
            }
            if (Convert.ToString(cbxSoortBeurt.SelectedItem) == "Onderhoud") 
            {
                int beurtid = db.GetInsertID("ID", "Tram_beurt") + 1;
                string tramstring = Convert.ToString(lbxTrams.SelectedItem);
                int tramnummer = Convert.ToInt32(tramstring.Substring(tramstring.IndexOf("-") + 1));
                BeurtType beurttype = (BeurtType)Enum.Parse(typeof(BeurtType), Convert.ToString(cbxTypeBeurt.SelectedItem), true);
                Tram tram = tramlijst.Find(x => x.Nummer == tramnummer);
                DateTime datum = Convert.ToDateTime(dtpDatum.Value);

                Onderhoud onderhoud = new Onderhoud(datum, beurtid, beurttype, tram);
                db.OnderhoudInvoeren(onderhoud);
                this.Close();
            }
        }

        private void btnAnnuleren_Click(object sender, EventArgs e) 
        {
            this.Close();
        }
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
