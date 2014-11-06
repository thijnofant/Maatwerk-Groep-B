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
    public partial class BeheerApplicatie : Form
    {
        private Remise remise;
        DatabaseManager databaseManager;

        public BeheerApplicatie()
        {
            InitializeComponent();
            databaseManager = DatabaseManager.Instance;
            this.remise = Remise.Instance;
            Updater();
        }

        private void verplaatsenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TramVerplaatsen app = new TramVerplaatsen();
            app.Show();
        }

        private void reparatieToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void schoonmaakToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void verwijderenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void blokkerenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeheerApp_Blokkeren form = new BeheerApp_Blokkeren();
            form.Show();
        }

        private void deblokkerenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void beherenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void beherenToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void schoonmaakLijstOpvragenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SchoonmaakApplicatie app = new SchoonmaakApplicatie();
            app.Show();

        }

        private void invoerenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeheerderApp_SchoonmaakInvoeren form = new BeheerderApp_SchoonmaakInvoeren();
            form.Show();
        }

        private void reserverenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TramReserveren form = new TramReserveren();
            form.Show();
        }

        private void invoerenToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            BeheerderApp_SchoonmaakInvoeren form = new BeheerderApp_SchoonmaakInvoeren();
            form.Show();
        }

        private void Updater()
        {
            string[] Spoor_Sector = DatabaseManager.Instance.SpoorSectorArray();
            s12_1.Text = Spoor_Sector[1].ToString();
            s13_1.Text = Spoor_Sector[2].ToString();
            s14_1.Text = Spoor_Sector[3].ToString();
            s15_1.Text = Spoor_Sector[4].ToString();
            s16_1.Text = Spoor_Sector[5].ToString();
            s17_1.Text = Spoor_Sector[6].ToString();
            s18_1.Text = Spoor_Sector[7].ToString();
            s19_1.Text = Spoor_Sector[8].ToString();
            s20_1.Text = Spoor_Sector[9].ToString();
            s21_1.Text = Spoor_Sector[10].ToString();
            s30_1.Text = Spoor_Sector[11].ToString();
            s30_2.Text = Spoor_Sector[13].ToString();
            s30_3.Text = Spoor_Sector[14].ToString();
            s31_1.Text = Spoor_Sector[15].ToString();
            s31_2.Text = Spoor_Sector[16].ToString();
            s31_3.Text = Spoor_Sector[17].ToString();
            s32_1.Text = Spoor_Sector[18].ToString();
            s32_2.Text = Spoor_Sector[19].ToString();
            s32_3.Text = Spoor_Sector[20].ToString();
            s32_4.Text = Spoor_Sector[21].ToString();
            s33_1.Text = Spoor_Sector[22].ToString();
            s33_2.Text = Spoor_Sector[23].ToString();
            s33_3.Text = Spoor_Sector[24].ToString();
            s33_4.Text = Spoor_Sector[25].ToString();
            s34_1.Text = Spoor_Sector[26].ToString();
            s34_2.Text = Spoor_Sector[27].ToString();
            s34_3.Text = Spoor_Sector[28].ToString();
            s34_4.Text = Spoor_Sector[29].ToString();
            s35_1.Text = Spoor_Sector[30].ToString();
            s35_2.Text = Spoor_Sector[31].ToString();
            s35_3.Text = Spoor_Sector[32].ToString();
            s35_4.Text = Spoor_Sector[33].ToString();
            s36_1.Text = Spoor_Sector[34].ToString();
            s36_2.Text = Spoor_Sector[35].ToString();
            s36_3.Text = Spoor_Sector[36].ToString();
            s36_4.Text = Spoor_Sector[37].ToString();
            s37_1.Text = Spoor_Sector[38].ToString();
            s37_2.Text = Spoor_Sector[39].ToString();
            s37_3.Text = Spoor_Sector[40].ToString();
            s37_4.Text = Spoor_Sector[41].ToString();
            s38_1.Text = Spoor_Sector[42].ToString();
            s38_2.Text = Spoor_Sector[43].ToString();
            s38_3.Text = Spoor_Sector[44].ToString();
            s38_4.Text = Spoor_Sector[45].ToString();
            s40_1.Text = Spoor_Sector[46].ToString();
            s40_2.Text = Spoor_Sector[47].ToString();
            s40_3.Text = Spoor_Sector[48].ToString();
            s40_4.Text = Spoor_Sector[49].ToString();
            s40_5.Text = Spoor_Sector[50].ToString();
            s40_6.Text = Spoor_Sector[51].ToString();
            s40_7.Text = Spoor_Sector[52].ToString();
            s41_1.Text = Spoor_Sector[53].ToString();
            s41_2.Text = Spoor_Sector[54].ToString();
            s41_3.Text = Spoor_Sector[55].ToString();
            s42_1.Text = Spoor_Sector[56].ToString();
            s42_2.Text = Spoor_Sector[57].ToString();
            s42_3.Text = Spoor_Sector[58].ToString();
            s43_1.Text = Spoor_Sector[59].ToString();
            s43_2.Text = Spoor_Sector[60].ToString();
            s43_3.Text = Spoor_Sector[61].ToString();
            s44_1.Text = Spoor_Sector[62].ToString();
            s44_2.Text = Spoor_Sector[63].ToString();
            s44_3.Text = Spoor_Sector[64].ToString();
            s45_1.Text = Spoor_Sector[65].ToString();
            s45_2.Text = Spoor_Sector[66].ToString();
            s45_3.Text = Spoor_Sector[67].ToString();
            s51_1.Text = Spoor_Sector[68].ToString();
            s51_2.Text = Spoor_Sector[69].ToString();
            s51_3.Text = Spoor_Sector[70].ToString();
            s51_4.Text = Spoor_Sector[71].ToString();
            s51_5.Text = Spoor_Sector[72].ToString();
            s51_6.Text = Spoor_Sector[73].ToString();
            s52_1.Text = Spoor_Sector[74].ToString();
            s52_2.Text = Spoor_Sector[75].ToString();
            s52_3.Text = Spoor_Sector[76].ToString();
            s52_4.Text = Spoor_Sector[77].ToString();
            s52_5.Text = Spoor_Sector[78].ToString();
            s52_6.Text = Spoor_Sector[79].ToString();
            s52_7.Text = Spoor_Sector[80].ToString();
            s53_1.Text = Spoor_Sector[81].ToString();
            s53_2.Text = Spoor_Sector[82].ToString();
            s53_3.Text = Spoor_Sector[83].ToString();
            s53_4.Text = Spoor_Sector[84].ToString();
            s53_5.Text = Spoor_Sector[85].ToString();
            s53_6.Text = Spoor_Sector[86].ToString();
            s53_7.Text = Spoor_Sector[87].ToString();
            s54_1.Text = Spoor_Sector[88].ToString();
            s54_2.Text = Spoor_Sector[89].ToString();
            s54_3.Text = Spoor_Sector[90].ToString();
            s54_4.Text = Spoor_Sector[91].ToString();
            s54_5.Text = Spoor_Sector[92].ToString();
            s54_6.Text = Spoor_Sector[93].ToString();
            s54_7.Text = Spoor_Sector[94].ToString();
            s55_1.Text = Spoor_Sector[95].ToString();
            s55_2.Text = Spoor_Sector[96].ToString();
            s55_3.Text = Spoor_Sector[97].ToString();
            s55_4.Text = Spoor_Sector[98].ToString();
            s55_5.Text = Spoor_Sector[99].ToString();
            s55_6.Text = Spoor_Sector[100].ToString();
            s55_7.Text = Spoor_Sector[101].ToString();
            s55_8.Text = Spoor_Sector[102].ToString();
            s56_1.Text = Spoor_Sector[103].ToString();
            s56_2.Text = Spoor_Sector[104].ToString();
            s56_3.Text = Spoor_Sector[105].ToString();
            s56_4.Text = Spoor_Sector[106].ToString();
            s56_5.Text = Spoor_Sector[107].ToString();
            s56_6.Text = Spoor_Sector[108].ToString();
            s56_7.Text = Spoor_Sector[109].ToString();
            s56_8.Text = Spoor_Sector[110].ToString();
            s57_1.Text = Spoor_Sector[111].ToString();
            s57_2.Text = Spoor_Sector[112].ToString();
            s57_3.Text = Spoor_Sector[113].ToString();
            s57_4.Text = Spoor_Sector[114].ToString();
            s57_5.Text = Spoor_Sector[115].ToString();
            s57_6.Text = Spoor_Sector[116].ToString();
            s57_7.Text = Spoor_Sector[117].ToString();
            s57_8.Text = Spoor_Sector[118].ToString();
            s58_1.Text = Spoor_Sector[119].ToString();
            s58_2.Text = Spoor_Sector[120].ToString();
            s58_3.Text = Spoor_Sector[121].ToString();
            s61_1.Text = Spoor_Sector[122].ToString();
            s61_2.Text = Spoor_Sector[123].ToString();
            s61_3.Text = Spoor_Sector[124].ToString();
            s62_1.Text = Spoor_Sector[125].ToString();
            s62_2.Text = Spoor_Sector[126].ToString();
            s62_3.Text = Spoor_Sector[127].ToString();
            s63_1.Text = Spoor_Sector[128].ToString();
            s63_2.Text = Spoor_Sector[129].ToString();
            s63_3.Text = Spoor_Sector[130].ToString();
            s63_4.Text = Spoor_Sector[131].ToString();
            s64_1.Text = Spoor_Sector[132].ToString();
            s64_2.Text = Spoor_Sector[133].ToString();
            s64_3.Text = Spoor_Sector[134].ToString();
            s64_4.Text = Spoor_Sector[135].ToString();
            s64_5.Text = Spoor_Sector[136].ToString();
            s74_1.Text = Spoor_Sector[137].ToString();
            s74_2.Text = Spoor_Sector[138].ToString();
            s74_3.Text = Spoor_Sector[139].ToString();
            s74_4.Text = Spoor_Sector[140].ToString();
            s74_5.Text = Spoor_Sector[141].ToString();
            s75_1.Text = Spoor_Sector[142].ToString();
            s75_2.Text = Spoor_Sector[143].ToString();
            s75_3.Text = Spoor_Sector[144].ToString();
            s75_4.Text = Spoor_Sector[145].ToString();
            s76_1.Text = Spoor_Sector[146].ToString();
            s76_2.Text = Spoor_Sector[147].ToString();
            s76_3.Text = Spoor_Sector[148].ToString();
            s76_4.Text = Spoor_Sector[149].ToString();
            s76_5.Text = Spoor_Sector[150].ToString();
            s77_1.Text = Spoor_Sector[151].ToString();
            s77_2.Text = Spoor_Sector[152].ToString();
            s77_3.Text = Spoor_Sector[153].ToString();
            s77_4.Text = Spoor_Sector[154].ToString();
            s77_5.Text = Spoor_Sector[155].ToString();
        }
        private void onderhoudLijstOpvragenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnderhoudApplicatie app = new OnderhoudApplicatie();
            app.Show();
        }

        private void goedkeurenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SchoonmaakGoedkeuren schoonmaakGoedkeuren = new SchoonmaakGoedkeuren();
            schoonmaakGoedkeuren.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Updater();
        }
    }
}
