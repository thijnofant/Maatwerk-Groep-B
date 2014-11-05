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
    public partial class BestuurApplicatie : Form
    {
        DatabaseManager db = DatabaseManager.Instance;
        Remise remise = Remise.Instance;

        public BestuurApplicatie()
        {
            InitializeComponent();     
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            tbxInput.Text = tbxInput.Text += "1";
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            tbxInput.Text = tbxInput.Text += "2";
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            tbxInput.Text = tbxInput.Text += "3";
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            tbxInput.Text = tbxInput.Text += "4";
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            tbxInput.Text = tbxInput.Text += "5";
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            tbxInput.Text = tbxInput.Text += "6";
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            tbxInput.Text = tbxInput.Text += "7";
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            tbxInput.Text = tbxInput.Text += "8";
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            tbxInput.Text = tbxInput.Text += "9";
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            tbxInput.Text = tbxInput.Text += "0";
        }

        private void btnCorrect_Click(object sender, EventArgs e)
        {
            if (tbxInput.Text.Length > 0)
            {
                tbxInput.Text = tbxInput.Text.Remove(tbxInput.Text.Length - 1);
            }
        }

        private void rbnYes_CheckedChanged(object sender, EventArgs e)
        {
            btnConfirm.Visible = true;
        }

        private void rbnNo_CheckedChanged(object sender, EventArgs e)
        {
            btnConfirm.Visible = true;
            
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            bool onderhoud = false;
            bool schoonmaak = false;
            int tramnr = Convert.ToInt32(tbxInput.Text);

            if(rbJa.Checked)
            {
               onderhoud = true;
            }
            if(chbschoonmaak.Checked)
            {
                schoonmaak = true;
            }
            remise.PlaatsAutomatischToewijzen(tramnr, onderhoud, schoonmaak);
            //if(remise.PlaatsAutomatischToewijzen(tramnr, onderhoud, schoonmaak))
            //{

            //}
        }

        private void rbJa_CheckedChanged(object sender, EventArgs e)
        {
            btnConfirm.Visible = true;
        }

        private void rbNee_CheckedChanged(object sender, EventArgs e)
        {
            btnConfirm.Visible = true;
        }
    }
}
