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
            Update();
            //Update2();

            //this.remise.Sporen = this.remise.Database.SporenlijstOpvragen(); moet weggegooit worden

            //List<Sector> sectoren = new List<Sector>();
            //List<Lijn> lijnen = new List<Lijn>();
            //Sector s;
            //s = new Sector(1, false);
            //sectoren.Add(s);
            //s = new Sector(2, false);
            //sectoren.Add(s);
            //s = new Sector(3, false);
            //sectoren.Add(s);
            //s = new Sector(4, false);
            //sectoren.Add(s);
            //s = new Sector(5, false);
            //sectoren.Add(s);
            //Spoor spoor1 = new Spoor(1, sectoren, lijnen);
            //sectoren = new List<Sector>();
            //lijnen = new List<Lijn>();
            //s = new Sector(1, false);
            //sectoren.Add(s);
            //s = new Sector(2, false);
            //sectoren.Add(s);
            //s = new Sector(3, false);
            //sectoren.Add(s);
            //s = new Sector(4, false);
            //sectoren.Add(s);
            //s = new Sector(5, false);
            //sectoren.Add(s);
            //Spoor spoor2 = new Spoor(1, sectoren, lijnen);
            //sectoren = new List<Sector>();
            //lijnen = new List<Lijn>();
            //s = new Sector(1, false);
            //sectoren.Add(s);
            //s = new Sector(2, false);
            //sectoren.Add(s);
            //s = new Sector(3, false);
            //sectoren.Add(s);
            //s = new Sector(4, false);
            //sectoren.Add(s);
            //s = new Sector(5, false);
            //sectoren.Add(s);
            //Spoor spoor3 = new Spoor(1, sectoren, lijnen);
            //this.remise.Sporen.Add(spoor1);
            //this.remise.Sporen.Add(spoor2);
            //this.remise.Sporen.Add(spoor3);
        }

        private void verplaatsenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TramVerplaatsen app = new TramVerplaatsen();
            timer1.Enabled = false;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            Update();
            if (timer2.Enabled == false)
                timer2.Enabled = true;
        }

        private void Update()
        {
            s12_1.Text = GetTrainString(1, 1);
            s13_1.Text = GetTrainString(1, 2);
            s14_1.Text = GetTrainString(1, 3);
            s15_1.Text = GetTrainString(1, 4);
            s16_1.Text = GetTrainString(1, 5);
            s17_1.Text = GetTrainString(1, 6);
            s18_1.Text = GetTrainString(1, 7);
            s19_1.Text = GetTrainString(1, 8);
            s20_1.Text = GetTrainString(1, 9);
            s21_1.Text = GetTrainString(1, 10);
            s30_1.Text = GetTrainString(1, 11);
            s30_2.Text = GetTrainString(2, 11);
            s30_3.Text = GetTrainString(3, 11);
            s31_1.Text = GetTrainString(1, 12);
            s31_2.Text = GetTrainString(2, 12);
            s31_3.Text = GetTrainString(3, 12);
            s32_1.Text = GetTrainString(1, 13);
            s32_2.Text = GetTrainString(2, 13);
            s32_3.Text = GetTrainString(3, 13);
            s32_4.Text = GetTrainString(4, 13);
            s33_1.Text = GetTrainString(1, 14);
            s33_2.Text = GetTrainString(2, 14);
            s33_3.Text = GetTrainString(3, 14);
            s33_4.Text = GetTrainString(4, 14);
            s34_1.Text = GetTrainString(1, 15);
            s34_2.Text = GetTrainString(2, 15);
            s34_3.Text = GetTrainString(3, 15);
            s34_4.Text = GetTrainString(4, 15);
            s35_1.Text = GetTrainString(1, 16);
            s35_2.Text = GetTrainString(2, 16);
            s35_3.Text = GetTrainString(3, 16);
            s35_4.Text = GetTrainString(4, 16);
            s36_1.Text = GetTrainString(1, 17);
            s36_2.Text = GetTrainString(2, 17);
            s36_3.Text = GetTrainString(3, 17);
            s36_4.Text = GetTrainString(4, 17);
            s37_1.Text = GetTrainString(1, 18);
            s37_2.Text = GetTrainString(2, 18);
            s37_3.Text = GetTrainString(3, 18);
            s37_4.Text = GetTrainString(4, 18);
            s38_1.Text = GetTrainString(1, 19);
            s38_2.Text = GetTrainString(2, 19);
            s38_3.Text = GetTrainString(3, 19);
            s38_4.Text = GetTrainString(4, 19);
            s40_1.Text = GetTrainString(1, 20);
            s40_2.Text = GetTrainString(2, 20);
            s40_3.Text = GetTrainString(3, 20);
            s40_4.Text = GetTrainString(4, 20);
            s40_5.Text = GetTrainString(5, 20);
            s40_6.Text = GetTrainString(6, 20);
            s40_7.Text = GetTrainString(7, 20);
            s41_1.Text = GetTrainString(1, 21);
            s41_2.Text = GetTrainString(2, 21);
            s41_3.Text = GetTrainString(3, 21);
            s42_1.Text = GetTrainString(1, 22);
            s42_2.Text = GetTrainString(2, 22);
            s42_3.Text = GetTrainString(3, 22);
            s43_1.Text = GetTrainString(1, 23);
            s43_2.Text = GetTrainString(2, 23);
            s43_3.Text = GetTrainString(3, 23);
            s44_1.Text = GetTrainString(1, 24);
            s44_2.Text = GetTrainString(2, 24);
            s44_3.Text = GetTrainString(3, 24);
        }
        private void Update2()
        {

            s45_1.Text = GetTrainString(1, 25);
            s45_2.Text = GetTrainString(2, 25);
            s45_3.Text = GetTrainString(3, 25);
            s51_1.Text = GetTrainString(1, 27);
            s51_2.Text = GetTrainString(2, 27);
            s51_3.Text = GetTrainString(3, 27);
            s51_4.Text = GetTrainString(4, 27);
            s51_5.Text = GetTrainString(5, 27);
            s51_6.Text = GetTrainString(6, 27);
            s52_1.Text = GetTrainString(1, 28);
            s52_2.Text = GetTrainString(2, 28);
            s52_3.Text = GetTrainString(3, 28);
            s52_4.Text = GetTrainString(4, 28);
            s52_5.Text = GetTrainString(5, 28);
            s52_6.Text = GetTrainString(6, 28);
            s52_7.Text = GetTrainString(7, 28);
            s53_1.Text = GetTrainString(1, 29);
            s53_2.Text = GetTrainString(2, 29);
            s53_3.Text = GetTrainString(3, 29);
            s53_4.Text = GetTrainString(4, 29);
            s53_5.Text = GetTrainString(5, 29);
            s53_6.Text = GetTrainString(6, 29);
            s53_7.Text = GetTrainString(7, 29);
            s54_1.Text = GetTrainString(1, 30);
            s54_2.Text = GetTrainString(2, 30);
            s54_3.Text = GetTrainString(3, 30);
            s54_4.Text = GetTrainString(4, 30);
            s54_5.Text = GetTrainString(5, 30);
            s54_6.Text = GetTrainString(6, 30);
            s54_7.Text = GetTrainString(7, 30);
            s55_1.Text = GetTrainString(1, 31);
            s55_2.Text = GetTrainString(2, 31);
            s55_3.Text = GetTrainString(3, 31);
            s55_4.Text = GetTrainString(4, 31);
            s55_5.Text = GetTrainString(5, 31);
            s55_6.Text = GetTrainString(6, 31);
            s55_7.Text = GetTrainString(7, 31);
            s55_8.Text = GetTrainString(8, 31);
            s56_1.Text = GetTrainString(1, 32);
            s56_2.Text = GetTrainString(2, 32);
            s56_3.Text = GetTrainString(3, 32);
            s56_4.Text = GetTrainString(4, 32);
            s56_5.Text = GetTrainString(5, 32);
            s56_6.Text = GetTrainString(6, 32);
            s56_7.Text = GetTrainString(7, 32);
            s56_8.Text = GetTrainString(8, 32);
            s57_1.Text = GetTrainString(1, 33);
            s57_2.Text = GetTrainString(2, 33);
            s57_3.Text = GetTrainString(3, 33);
            s57_4.Text = GetTrainString(4, 33);
            s57_5.Text = GetTrainString(5, 33);
            s57_6.Text = GetTrainString(6, 33);
            s57_7.Text = GetTrainString(7, 33);
            s57_8.Text = GetTrainString(8, 33);
            s58_1.Text = GetTrainString(1, 34);
            s58_2.Text = GetTrainString(2, 34);
            s58_3.Text = GetTrainString(3, 34);
            s61_1.Text = GetTrainString(1, 36);
            s61_2.Text = GetTrainString(2, 36);
            s61_3.Text = GetTrainString(3, 36);
            s62_1.Text = GetTrainString(1, 37);
            s62_2.Text = GetTrainString(2, 37);
            s62_3.Text = GetTrainString(3, 37);
            s63_1.Text = GetTrainString(1, 38);
            s63_2.Text = GetTrainString(2, 38);
            s63_3.Text = GetTrainString(3, 38);
            s63_4.Text = GetTrainString(4, 38);
            s64_1.Text = GetTrainString(1, 39);
            s64_2.Text = GetTrainString(2, 39);
            s64_3.Text = GetTrainString(3, 39);
            s64_4.Text = GetTrainString(4, 39);
            s64_5.Text = GetTrainString(5, 39);
            s74_1.Text = GetTrainString(1, 40);
            s74_2.Text = GetTrainString(2, 40);
            s74_3.Text = GetTrainString(3, 40);
            s74_4.Text = GetTrainString(4, 40);
            s74_5.Text = GetTrainString(5, 40);
            s75_1.Text = GetTrainString(1, 41);
            s75_2.Text = GetTrainString(2, 41);
            s75_3.Text = GetTrainString(3, 41);
            s75_4.Text = GetTrainString(4, 41);
            s76_1.Text = GetTrainString(1, 42);
            s76_2.Text = GetTrainString(2, 42);
            s76_3.Text = GetTrainString(3, 42);
            s76_4.Text = GetTrainString(4, 42);
            s76_5.Text = GetTrainString(5, 42);
            s77_1.Text = GetTrainString(1, 43);
            s77_2.Text = GetTrainString(2, 43);
            s77_3.Text = GetTrainString(3, 43);
            s77_4.Text = GetTrainString(4, 43);
            s77_5.Text = GetTrainString(5, 43);
        }

        private string GetTrainString(int x, int SpoorId)
        {
            return Remise.Instance.Database.tramNRFromSectorID(Remise.Instance.Database.SectorXfromSpoor(x, SpoorId).Id).ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Update2();
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

        private void goedkeurenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OnderhoudGoedkeuren onderhoudGoedkeuren = new OnderhoudGoedkeuren();
            onderhoudGoedkeuren.Show();
        }
    }
}
