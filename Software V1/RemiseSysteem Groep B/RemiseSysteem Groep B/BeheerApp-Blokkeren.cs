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

        public void UpdateData() 
        {
            sporen = db.SporenlijstOpvragen();
            sectoren = db.GetSectorenVoorBlokkade();

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
            if (lbxSectoren.SelectedItem == null) {

            }
        }

        private void btnDeblokkeer_Click(object sender, EventArgs e) 
        {

        }
    }
}
