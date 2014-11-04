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
    public partial class BeheerderApp_SchoonmaakInvoeren : Form
    {
        Remise remise;
        DatabaseManager db;

        public BeheerderApp_SchoonmaakInvoeren() 
        {
            InitializeComponent();
            remise = Remise.Instance;
            db = DatabaseManager.Instance;
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
        }

        private void btnAnnuleren_Click(object sender, EventArgs e) 
        {
            this.Close();
        }
        private void OpstartMethode() 
        {
            foreach (Tram t in db.AlleTrams()) 
            {
                string lbstring = t.Type.Naam + Convert.ToString(t.Nummer);
            }
        }

    }
}
