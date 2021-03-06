﻿using System;
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
    /// form voor het aanvragen van schoonmaakbeurten
    /// </summary>
    public partial class SchoonmaakApplicatie : Form
    {
        List<Medewerker> schoonmaakmedewerkers;
        List<Tram> tramlijst;
        DatabaseManager db;

        Medewerker medewerkerSchoonmaak;
        List<Schoonmaak> schoonmaakBeurten;
        Schoonmaak schoonmaak;
        int medewerkerID;

        /// <summary>
        /// Dit is de Constructor voor deze Form.
        /// </summary>
        public SchoonmaakApplicatie()
        {
            InitializeComponent();
            btnAanvragen.Visible = false;
            db = DatabaseManager.Instance;//singleton design pattern voor database klasse
            schoonmaakmedewerkers = new List<Medewerker>();//lijst om alle schoonmaakmedewerkers in op te slaan
            schoonmaakmedewerkers = db.SchoonmaakMedewerkersOpvragen();//haalt alle schoonmaakmedewerkers op uit de database
            tramlijst = new List<Tram>();//lijst om alle trams in op te slaan
            tramlijst = db.AlleTrams();//haalt alle trams op uit de database en vult hiermee de lijst

            Updateform();//methode die de comboboxes vult op het form

            cbMedewerker.SelectedIndex = 0;//zorgt dat altijd een waarde is geselecteerd
            cbTram.SelectedIndex = 0;//zorgt dat altijd een waarde is geselecteerd

            LaadSchoonmaakBeurten();
        }

        /// <summary>
        /// Dit is de Methode die de Schoonmaakbeurten die in de Dabase Staan ophaalt en deze in de Lijst op het form zet.
        /// </summary>
        private void LaadSchoonmaakBeurten()
        {
            schoonmaakBeurten = this.db.SchoonmaakOpvragen();

            foreach (Schoonmaak sm in schoonmaakBeurten)
            {
                lbxSchoonmaakBeurten.Items.Add(Convert.ToInt32(sm.ID));
            }
        }

        /// <summary>
        /// Dit is de Methode die word gebruikt om de Lijsten op het Form van de nieuwste informatie te vorzien.
        /// </summary>
        public void Updateform()
        {
            foreach(Medewerker m in schoonmaakmedewerkers)
            {
                cbMedewerker.Items.Add(m.ToString());
            }
            foreach(Tram t in tramlijst)
            {
                cbTram.Items.Add(t.Nummer.ToString());
            }
        }

        /// <summary>
        /// Deze Methode word aangeroepen als op de aanvragenknop word gedrukt. Dit maakt een nieuwe (nog) niet goedgekeurde Schoonmaak aan in de Database.
        /// </summary>
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
            if (tram != null)
            {
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
            else
            {
                lblMessage.Text = "Ingevoerde tram bestaat niet";
            }
            
        }

        /// <summary>
        /// Deze metode word aangeroepen als de checkbox voor een Grote Beurt wordt gechecked. Hierdoor wordt de Aanvraag-Button Beschikbaar.
        /// </summary>
        private void rbGroot_CheckedChanged(object sender, EventArgs e)
        {
            btnAanvragen.Visible = true;
        }

        /// <summary>
        /// Deze metode word aangeroepen als de checkbox voor een Grote Beurt wordt gechecked. Hierdoor wordt de Aanvraag-Button Beschikbaar.
        /// </summary>
        private void rbKlein_CheckedChanged(object sender, EventArgs e)
        {
            btnAanvragen.Visible = true;
        }

        /// <summary>
        /// Deze Methode wordt aangeroepen als de SelectedIndex veranderd in de lijst van Schoonmaakbeurten en zorgt dat de lijst ge-update wordt.
        /// </summary>
        private void lbxSchoonmaakBeurten_SelectedIndexChanged(object sender, EventArgs e)
        {
            schoonmaak = schoonmaakBeurten[lbxSchoonmaakBeurten.SelectedIndex];
            UpdateSchoonmaakInfo(schoonmaak);
        }

        /// <summary>
        /// Deze Methode Update de informatie van een schoonmaak.
        /// </summary>
        /// <param name="schoonmaak">De schoonmaak die ge-update wordt.</param>
        private void UpdateSchoonmaakInfo(Schoonmaak schoonmaak)
        {
            tbxDatum.Text = Convert.ToString(schoonmaak.BeginDatum);
            if (tbxDatum.Text == "01/01/0001 00:00:00")
            {
                tbxDatum.Text = "";
            }
            medewerkerID = Remise.Instance.Database.MedewerkerOpvragen(schoonmaak);

            if (medewerkerID != -1)
            {
                medewerkerSchoonmaak = this.db.ZoekMedewerkerOpID(medewerkerID);

                tbxMedewerkerOnderhoud.Text = medewerkerSchoonmaak.Naam;
            }
            else
            {
                tbxMedewerkerOnderhoud.Text = "Geen medewerker.";
            }

            if (this.db.IsKlaar(schoonmaak))
            {
                chxKlaar.Checked = true;
            }
            else
            {
                chxKlaar.Checked = false;
            }
        }

        /// <summary>
        /// Deze Methode wordt aangeroepen als er in de checkbox Klaar wordt geklikt en deze veranderd de geselecteerde Schoonmaak naar Klaar.
        /// </summary>
        private void chxKlaar_MouseClick(object sender, MouseEventArgs e)
        {
            if (chxKlaar.Checked == true)
            {
                this.db.WijzigKlaar(schoonmaak, true);
            }
            else
            {
                this.db.WijzigKlaar(schoonmaak, false);
            }
        }
    }
}
