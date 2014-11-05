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
    public partial class SchoonmaakGoedkeuren : Form
    {
        public SchoonmaakGoedkeuren()
        {
            InitializeComponent();
        }

        private void btnGoedkeuren_Click(object sender, EventArgs e)
        {
            string text = lbxSchoonmaak.SelectedValue.ToString();
        }
    }
}
