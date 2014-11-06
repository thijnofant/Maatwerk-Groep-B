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
    public partial class SchoonmaakApplicatie : Form
    {
        List<Medewerker> schoomaakmedewerkers;
        List<Tram> tramlijst;
        DatabaseManager db;

        /// <summary>
        /// 
        /// </summary>
        public SchoonmaakApplicatie()
        {
            InitializeComponent();
            btnAanvragen.Visible = false;
            db = DatabaseManager.Instance;//singleton design pattern voor database klasse
            schoomaakmedewerkers = new List<Medewerker>();//lijst om alle schoonmaakmedewerkers in op te slaan
            schoomaakmedewerkers = db.SchoonmaakMedewerkersOpvragen();//haalt alle schoonmaakmedewerkers op uit de database
            tramlijst = new List<Tram>();//lijst om alle trams in op te slaan
            tramlijst = db.AlleTrams();//haalt alle trams op uit de database en vult hiermee de lijst

            Updateform();//methode die de comboboxes vult op het form

            cbMedewerker.SelectedIndex = 0;//zorgt dat altijd een waarde is geselecteerd
            cbTram.SelectedIndex = 0;//zorgt dat altijd een waarde is geselecteerd
        }

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAanvragen_Click(object sender, EventArgs e)
        {
            int selectedtramnr = Convert.ToInt32(cbTram.SelectedItem.ToString());//het geselecteerde tramnr
            string selectedmwstring = cbMedewerker.SelectedItem.ToString();//geselecteerde medewerker string
            int mwID = Convert.ToInt32(selectedmwstring.Substring(0, 1));// eerste character uit medewerker string (dit is de ID)
            int allowedbeurten = 0;//het aantalbeurten dat is toegestaan per dag, deze wordt later gevuld , afhankelijk van grote of kleine beurt
            int aantalUitgevoerdeBeurten; //variable om in op te slaan wat het aantal uitgevoerde beurten is van de geselecteerde dag
            BeurtType beurttype = BeurtType.Klein;//variable voor geselecteerde beurttype
            Tram tram = db.ZoekTram(selectedtramnr);//zoekt de tram en voegt deze toe in het tram object
            Medewerker medewerker = db.ZoekMedewerkerOpID(mwID);//zoekt medewerker en voegt deze toe in het medwerker object
            DateTime begindatum = dtpStartDatum.Value;//geselecteerde datum
            if(rbGroot.Checked)//wanneer groot geselecteerd is
            {
                beurttype = BeurtType.Groot;
                allowedbeurten = 2;
            }
            if(rbKlein.Checked)//wanneer klein geselecteerd is
            {
                beurttype = BeurtType.Klein;
                allowedbeurten = 3;
            }
            Schoonmaak s = new Schoonmaak(begindatum, db.GetInsertID("ID", "Tram_Beurt") + 1, beurttype, tram);//maakt nieuw schoonmaak object aan
            aantalUitgevoerdeBeurten = db.GetAantalBeurten(beurttype.ToString(), "Schoonmaak", begindatum, tram.Id);//kijkt hoeveel beurten zijn uitgevoerd op geselecteerde datum
            
            if (aantalUitgevoerdeBeurten <= allowedbeurten)// wanneer dit meer is dan allowed beurten, wordt dit overgeslagen
            {
                db.SchoonmaakInvoeren(s, mwID);//voert nieuwe schoonmaak in in de database
                lblMessage.Text = "Het verzoek is succesvol aangevraagd";
            }
            else
            {
                lblMessage.Text = "De geselecteerde tram kan niet meer worden ingepland op de geselecteerde dag";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbGroot_CheckedChanged(object sender, EventArgs e)
        {
            btnAanvragen.Visible = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbKlein_CheckedChanged(object sender, EventArgs e)
        {
            btnAanvragen.Visible = true;
        }
    }
}
