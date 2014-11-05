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
        public BeheerApp_Blokkeren() {
            InitializeComponent();
        }

        public void UpdateData() 
        {
            List<Spoor> sporen = db.SporenlijstOpvragen();
            //List<Sector> sectoren = 
        }
    }
}
