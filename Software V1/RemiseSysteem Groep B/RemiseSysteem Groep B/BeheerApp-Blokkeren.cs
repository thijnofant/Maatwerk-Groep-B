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
    /// Het form voor het blokkeren van sporen en sectoren.
    /// </summary>
    public partial class BeheerApp_Blokkeren : Form
    {
        DatabaseManager db = DatabaseManager.Instance;
        List<Spoor> sporen;
        List<Sector> sectoren;

        public BeheerApp_Blokkeren() {
            InitializeComponent();
            UpdateData();
        }

        /// <summary>
        /// Deze methode vult de lijsten sectoren en sporen vanuit de database.
        /// </summary>
        public void UpdateDataAlleen() 
        {
            sporen = db.SporenlijstOpvragen();
            sectoren = db.GetSectorenVoorBlokkade();
        }

        /// <summary>
        /// Deze methode vult de lijsten sectoren en sporen uit de database en vult de listbox met spoornummers.
        /// </summary>
        public void UpdateData() 
        {
            UpdateDataAlleen();
            lbxSporen.Items.Clear();
            btnBlokkeer.Enabled = false;
            btnDeblokkeer.Enabled = false;

            foreach (Spoor s in sporen) 
            {
                string spoornummer = Convert.ToString(s.Nummer);
                lbxSporen.Items.Add(spoornummer);
            }
        }

        /// <summary>
        /// Wanneer er een spoor wordt aangeklikt in de listbox worden de bijbehorende sectoren gezocht en in de tweede listbox gezet.
        /// </summary>
        private void lbxSporen_SelectedIndexChanged(object sender, EventArgs e) 
        {
            btnBlokkeer.Enabled = true;
            btnDeblokkeer.Enabled = true;

            lbxSectoren.Items.Clear();
            int spoorid = -1;
            int spoornr = Convert.ToInt32(lbxSporen.SelectedItem);

            //SpoorID wordt opgehaald aan de hand van het spoornummer uit de listbox.
            foreach (Spoor spoor in sporen)
            {
                if (spoor.Nummer == spoornr) 
                {
                    spoorid = spoor.Id;
                    break;
                }
            }
            
            //Sectoren worden opgehaald bij het spoor en daarnaast wordt voor iedere sector gekeken of het geblokkeerd is of niet.
            foreach (Sector sector in sectoren) 
            {
                string sectorstring;
                if (spoorid == sector.SpoorID) 
                {
                    sectorstring = Convert.ToString(sector.Id);
                    if (sector.IsGeblokkeerd)
                        sectorstring += " - Geblokkeerd";
                    else
                        sectorstring += " - Open";
                    lbxSectoren.Items.Add(sectorstring);
                }
            }
        }

        /// <summary>
        /// Wanneer er op deze button geklikt wordt worden de geselecteerde sectoren geblokkeerd.
        /// </summary>
        private void btnBlokkeer_Click(object sender, EventArgs e) 
        {
            
            UpdateDataAlleen();
            //Hier wordt gecheckt of er een sector geselecteerd is, is dit niet het geval dan zullen alle sectoren in het geselecteerde spoor geblokkeerd worden.
            if (lbxSectoren.SelectedItem == null) 
            {
                int spoornummer = Convert.ToInt32(lbxSporen.SelectedItem);
                int spoorID = -1;

                //Spoornummer wordt vertaald naar SpoorID
                foreach (Spoor s in sporen) 
                {
                    if (spoornummer == s.Nummer) 
                    {
                        spoorID = s.Id;
                    }
                }
               
                if (db.BlokkeerSpoor(Convert.ToString(spoorID)))
                    MessageBox.Show("Spoor is succesvol geblokkeerd");
                else
                    MessageBox.Show("Spoor blokkeren mislukt.");
                lbxSectoren.Items.Clear();
                UpdateData();
                return;
            }

            //SectorID wordt opgehaald uit string.
            string sectorID = Convert.ToString(lbxSectoren.SelectedItem);
            sectorID = sectorID.Substring(0, sectorID.IndexOf(" "));

            //Sector wordt geblokkeerd.
            if (db.BlokkeerSector(sectorID))
                MessageBox.Show("Sector is succesvol geblokkeerd.");
            else
                MessageBox.Show("Sector blokkeren mislukt.");

            lbxSectoren.Items.Clear();
            UpdateData();
        }

        /// <summary>
        /// Wanneer er op deze button geklikt wordt worden de geselecteerde sectoren gedeblokkeerd.
        /// </summary>
        private void btnDeblokkeer_Click(object sender, EventArgs e) 
        {
            UpdateDataAlleen();

            //Hier wordt gecheckt of er een sector geselecteerd is, is dit niet het geval dan zullen alle sectoren in het geselecteerde spoor gedeblokkeerd worden.
            if (lbxSectoren.SelectedItem == null) 
            {
                int spoornummer = Convert.ToInt32(lbxSporen.SelectedItem);
                int spoorID = -1;

                //Spoornummer wordt vertaald naar SpoorID
                foreach (Spoor s in sporen) 
                {
                    if (spoornummer == s.Nummer) 
                    {
                        spoorID = s.Id;
                    }
                }
               
                if (db.DeblokkeerSpoor(Convert.ToString(spoorID)))
                    MessageBox.Show("Spoor is succesvol gedeblokkeerd");
                else
                    MessageBox.Show("Spoor deblokkeren mislukt.");
                lbxSectoren.Items.Clear();
                UpdateData();
                return;
            }

            //SectorID wordt opgehaald uit string.
            string sectorID = Convert.ToString(lbxSectoren.SelectedItem);
            sectorID = sectorID.Substring(0, sectorID.IndexOf(" "));

            //Sector wordt gedeblokkeerd.
            if (db.DeblokkeerSector(sectorID))
                MessageBox.Show("Sector is succesvol gedeblokkeerd.");
            else
                MessageBox.Show("Sector deblokkeren mislukt.");

            lbxSectoren.Items.Clear();
            UpdateData();
        }
    }
}
