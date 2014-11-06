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
    public partial class SchoonmaakApplicatie : Form
    {
        List<Medewerker> schoomaakmedewerkers;
        List<Tram> tramlijst;
        DatabaseManager db;
        public SchoonmaakApplicatie()
        {
            InitializeComponent();
            db = DatabaseManager.Instance;
            schoomaakmedewerkers = new List<Medewerker>();
            schoomaakmedewerkers = db.SchoonmaakMedewerkersOpvragen();
            tramlijst = new List<Tram>();
            tramlijst = db.AlleTrams();

            Updateform();   
        }

        public void Updateform()
        {
            foreach(Medewerker m in schoomaakmedewerkers)
            {
                cbMedewerker.Items.Add(m.ToString());
            }
            foreach(Tram t in tramlijst)
            {
                cbTram.Items.Add(t.Nummer.ToString());
            }
        }


        private void btnAanvragen_Click(object sender, EventArgs e)
        {
            int selectedtramnr = Convert.ToInt32(cbTram.SelectedText);
            int selectedmwid = Convert.ToInt32(cbMedewerker.SelectedText.Substring(0, 1));
            int allowedbeurten = 3;
            BeurtType beurttype = BeurtType.Klein;
            Tram tram = db.ZoekTram(selectedtramnr);
            Medewerker medewerker = db.ZoekMedewerkerOpID(selectedmwid);
            DateTime begindatum = dtpStartDatum.Value;
            if(rbGroot.Checked)
            {
                beurttype = BeurtType.Groot;
                allowedbeurten = 2;
            }
            if(rbKlein.Checked)
            {
                beurttype = BeurtType.Klein;
                allowedbeurten = 3;
            }
            Schoonmaak s = new Schoonmaak(begindatum, db.GetInsertID("ID", "Tram_Beurt") + 1, beurttype, tram);

            if (db.GetAantalBeurten(beurttype.ToString(), "Schoonmaak", begindatum, tram.Id) >= allowedbeurten)
            {
                db.SchoonmaakInvoeren(s);
            }
        }
    }
}
