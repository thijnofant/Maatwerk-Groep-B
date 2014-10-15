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
    public partial class OnderhoudApplicatie : Form
    {
        List<Onderhoud> onderhoudsBeurten = new List<Onderhoud>();
        Onderhoud onderhoud;
        List<Medewerker> medewerkersOnderhoud;
        Medewerker medewerkerOnderhoud;


        public OnderhoudApplicatie()
        {
            InitializeComponent();

            LaadMedewerkers();
            LaadOnderhoud();
        }

        public void LaadMedewerkers()
        {
            List<Medewerker> medewerkers = Remise.Instance.Database.MedewerkersOpvragen();

            foreach(Medewerker medewerker in medewerkers)
            {
                lbxMedewerkers.Items.Add(medewerker);
            }
        }

        public void LaadOnderhoud()
        {
            onderhoudsBeurten = Remise.Instance.Database.OnderhoudsBeurtenOpvragen();

            foreach(Onderhoud onderhoud in onderhoudsBeurten)
            {
                lbxOnderhoudsBeurten.Items.Add(onderhoud);
            }
        }

        private void lbxOnderhoudsBeurten_SelectedIndexChanged(object sender, EventArgs e)
        {
            onderhoud = onderhoudsBeurten[lbxOnderhoudsBeurten.SelectedIndex];
            UpdateOnderhoudInfo(onderhoud);
        }

        public void UpdateOnderhoudInfo(Onderhoud onderhoud)
        {
            tbxDatum.Text = Convert.ToString(onderhoud.BeginDatum);

            medewerkersOnderhoud = Remise.Instance.Database.MedewerkersOpvragen(onderhoud);

            foreach (Medewerker medewerker in medewerkersOnderhoud)
            {
                lbxOnderhoudsMedewerkers.Items.Add(medewerker);
            }
        }

        private void btnVerwijderMedewerker_Click(object sender, EventArgs e)
        {
            onderhoud.VerwijderMedewerker(medewerkerOnderhoud);
        }

        private void lbxOnderhoudsMedewerkers_SelectedIndexChanged(object sender, EventArgs e)
        {
            medewerkerOnderhoud = medewerkersOnderhoud[lbxOnderhoudsMedewerkers.SelectedIndex];
        }
    }
}