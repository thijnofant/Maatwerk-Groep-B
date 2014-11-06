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
    public partial class BeheerApp_Blokkeren : Form
    {
        DatabaseManager db = DatabaseManager.Instance;
        List<Spoor> sporen;
        List<Sector> sectoren;
        public BeheerApp_Blokkeren() {
            InitializeComponent();
            UpdateData();
        }

        public void UpdateDataAlleen() 
        {
            sporen = db.SporenlijstOpvragen();
            sectoren = db.GetSectorenVoorBlokkade();
        }

        public void UpdateData() 
        {
            sporen = db.SporenlijstOpvragen();
            sectoren = db.GetSectorenVoorBlokkade();
            lbxSporen.Items.Clear();
            btnBlokkeer.Enabled = false;
            btnDeblokkeer.Enabled = false;

            foreach (Spoor s in sporen) 
            {
                string spoornummer = Convert.ToString(s.Nummer);
                lbxSporen.Items.Add(spoornummer);
            }
        }

        private void lbxSporen_SelectedIndexChanged(object sender, EventArgs e) 
        {
            btnBlokkeer.Enabled = true;
            btnDeblokkeer.Enabled = true;

            lbxSectoren.Items.Clear();
            int spoorid = -1;
            int spoornr = Convert.ToInt32(lbxSporen.SelectedItem);

            foreach (Spoor spoor in sporen)
            {
                if (spoor.Nummer == spoornr) {
                    spoorid = spoor.Id;
                    break;
                }
            }
            
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

        private void btnBlokkeer_Click(object sender, EventArgs e) 
        {
            UpdateDataAlleen();

            if (lbxSectoren.SelectedItem == null) 
            {
                int spoornummer = Convert.ToInt32(lbxSporen.SelectedItem);
                int spoorID = -1;

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

            string sectorID = Convert.ToString(lbxSectoren.SelectedItem);
            sectorID = sectorID.Substring(0, sectorID.IndexOf(" "));

            if (db.BlokkeerSector(sectorID))
                MessageBox.Show("Sector is succesvol geblokkeerd.");
            else
                MessageBox.Show("Sector blokkeren mislukt.");

            lbxSectoren.Items.Clear();
            UpdateData();
        }

        private void btnDeblokkeer_Click(object sender, EventArgs e) 
        {
            UpdateDataAlleen();

            if (lbxSectoren.SelectedItem == null) 
            {
                int spoornummer = Convert.ToInt32(lbxSporen.SelectedItem);
                int spoorID = -1;

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

            string sectorID = Convert.ToString(lbxSectoren.SelectedItem);
            sectorID = sectorID.Substring(0, sectorID.IndexOf(" "));

            if (db.DeblokkeerSector(sectorID))
                MessageBox.Show("Sector is succesvol gedeblokkeerd.");
            else
                MessageBox.Show("Sector deblokkeren mislukt.");

            lbxSectoren.Items.Clear();
            UpdateData();
        }
    }
}
