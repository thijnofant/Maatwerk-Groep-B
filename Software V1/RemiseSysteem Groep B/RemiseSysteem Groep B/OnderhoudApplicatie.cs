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
    public partial class OnderhoudApplicatie : Form
    {
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
            List<Onderhoud> onderhoudsBeurten = Remise.Instance.Database.OnderhoudsBeurtenOpvragen();

            foreach(Onderhoud onderhoud in onderhoudsBeurten)
            {
                lbxOnderhoudsBeurten.Items.Add(onderhoud);
            }
        }
    }
}
