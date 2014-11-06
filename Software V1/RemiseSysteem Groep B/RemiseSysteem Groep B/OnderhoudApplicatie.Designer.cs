namespace RemiseSysteem_Groep_B
{
    partial class OnderhoudApplicatie
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbxMedewerkers = new System.Windows.Forms.ListBox();
            this.lbxOnderhoudsBeurten = new System.Windows.Forms.ListBox();
            this.lblMedewerkers = new System.Windows.Forms.Label();
            this.lblOnderhoudsBeurten = new System.Windows.Forms.Label();
            this.btnVoegMedewerkerToe = new System.Windows.Forms.Button();
            this.btnVerwijderMedewerker = new System.Windows.Forms.Button();
            this.lblOnderhoud = new System.Windows.Forms.Label();
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.tbxDatum = new System.Windows.Forms.TextBox();
            this.lblDatum = new System.Windows.Forms.Label();
            this.btnTijdsIndicatieWijzigen = new System.Windows.Forms.Button();
            this.lblOnderhoudsMedewerkers = new System.Windows.Forms.Label();
            this.tbxMedewerkerOnderhoud = new System.Windows.Forms.TextBox();
            this.nudUur = new System.Windows.Forms.NumericUpDown();
            this.nudMinuut = new System.Windows.Forms.NumericUpDown();
            this.chxKlaar = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudUur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinuut)).BeginInit();
            this.SuspendLayout();
            // 
            // lbxMedewerkers
            // 
            this.lbxMedewerkers.FormattingEnabled = true;
            this.lbxMedewerkers.Location = new System.Drawing.Point(15, 25);
            this.lbxMedewerkers.Name = "lbxMedewerkers";
            this.lbxMedewerkers.Size = new System.Drawing.Size(120, 147);
            this.lbxMedewerkers.TabIndex = 0;
            // 
            // lbxOnderhoudsBeurten
            // 
            this.lbxOnderhoudsBeurten.FormattingEnabled = true;
            this.lbxOnderhoudsBeurten.Location = new System.Drawing.Point(222, 25);
            this.lbxOnderhoudsBeurten.Name = "lbxOnderhoudsBeurten";
            this.lbxOnderhoudsBeurten.Size = new System.Drawing.Size(120, 147);
            this.lbxOnderhoudsBeurten.TabIndex = 1;
            this.lbxOnderhoudsBeurten.SelectedIndexChanged += new System.EventHandler(this.lbxOnderhoudsBeurten_SelectedIndexChanged);
            // 
            // lblMedewerkers
            // 
            this.lblMedewerkers.AutoSize = true;
            this.lblMedewerkers.Location = new System.Drawing.Point(12, 9);
            this.lblMedewerkers.Name = "lblMedewerkers";
            this.lblMedewerkers.Size = new System.Drawing.Size(74, 13);
            this.lblMedewerkers.TabIndex = 2;
            this.lblMedewerkers.Text = "Medewerkers:";
            // 
            // lblOnderhoudsBeurten
            // 
            this.lblOnderhoudsBeurten.AutoSize = true;
            this.lblOnderhoudsBeurten.Location = new System.Drawing.Point(219, 9);
            this.lblOnderhoudsBeurten.Name = "lblOnderhoudsBeurten";
            this.lblOnderhoudsBeurten.Size = new System.Drawing.Size(104, 13);
            this.lblOnderhoudsBeurten.TabIndex = 3;
            this.lblOnderhoudsBeurten.Text = "Onderhoudsbeurten:";
            // 
            // btnVoegMedewerkerToe
            // 
            this.btnVoegMedewerkerToe.Location = new System.Drawing.Point(141, 25);
            this.btnVoegMedewerkerToe.Name = "btnVoegMedewerkerToe";
            this.btnVoegMedewerkerToe.Size = new System.Drawing.Size(75, 23);
            this.btnVoegMedewerkerToe.TabIndex = 4;
            this.btnVoegMedewerkerToe.Text = "Voeg Toe";
            this.btnVoegMedewerkerToe.UseVisualStyleBackColor = true;
            this.btnVoegMedewerkerToe.Click += new System.EventHandler(this.btnVoegMedewerkerToe_Click);
            // 
            // btnVerwijderMedewerker
            // 
            this.btnVerwijderMedewerker.Location = new System.Drawing.Point(477, 128);
            this.btnVerwijderMedewerker.Name = "btnVerwijderMedewerker";
            this.btnVerwijderMedewerker.Size = new System.Drawing.Size(75, 23);
            this.btnVerwijderMedewerker.TabIndex = 5;
            this.btnVerwijderMedewerker.Text = "Verwijder";
            this.btnVerwijderMedewerker.UseVisualStyleBackColor = true;
            this.btnVerwijderMedewerker.Click += new System.EventHandler(this.btnVerwijderMedewerker_Click);
            // 
            // lblOnderhoud
            // 
            this.lblOnderhoud.AutoSize = true;
            this.lblOnderhoud.Location = new System.Drawing.Point(348, 9);
            this.lblOnderhoud.Name = "lblOnderhoud";
            this.lblOnderhoud.Size = new System.Drawing.Size(92, 13);
            this.lblOnderhoud.TabIndex = 6;
            this.lblOnderhoud.Text = "Onderhoudsbeurt:";
            // 
            // dtpDatum
            // 
            this.dtpDatum.Location = new System.Drawing.Point(351, 64);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(200, 20);
            this.dtpDatum.TabIndex = 8;
            // 
            // tbxDatum
            // 
            this.tbxDatum.Enabled = false;
            this.tbxDatum.Location = new System.Drawing.Point(351, 38);
            this.tbxDatum.Name = "tbxDatum";
            this.tbxDatum.Size = new System.Drawing.Size(100, 20);
            this.tbxDatum.TabIndex = 9;
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Location = new System.Drawing.Point(348, 22);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(71, 13);
            this.lblDatum.TabIndex = 10;
            this.lblDatum.Text = "Tijdsindicatie:";
            // 
            // btnTijdsIndicatieWijzigen
            // 
            this.btnTijdsIndicatieWijzigen.Location = new System.Drawing.Point(457, 36);
            this.btnTijdsIndicatieWijzigen.Name = "btnTijdsIndicatieWijzigen";
            this.btnTijdsIndicatieWijzigen.Size = new System.Drawing.Size(75, 23);
            this.btnTijdsIndicatieWijzigen.TabIndex = 12;
            this.btnTijdsIndicatieWijzigen.Text = "Update";
            this.btnTijdsIndicatieWijzigen.UseVisualStyleBackColor = true;
            this.btnTijdsIndicatieWijzigen.Click += new System.EventHandler(this.btnTijdsIndicatieWijzigen_Click);
            // 
            // lblOnderhoudsMedewerkers
            // 
            this.lblOnderhoudsMedewerkers.AutoSize = true;
            this.lblOnderhoudsMedewerkers.Location = new System.Drawing.Point(348, 114);
            this.lblOnderhoudsMedewerkers.Name = "lblOnderhoudsMedewerkers";
            this.lblOnderhoudsMedewerkers.Size = new System.Drawing.Size(74, 13);
            this.lblOnderhoudsMedewerkers.TabIndex = 14;
            this.lblOnderhoudsMedewerkers.Text = "Medewerkers:";
            // 
            // tbxMedewerkerOnderhoud
            // 
            this.tbxMedewerkerOnderhoud.Enabled = false;
            this.tbxMedewerkerOnderhoud.Location = new System.Drawing.Point(351, 128);
            this.tbxMedewerkerOnderhoud.Name = "tbxMedewerkerOnderhoud";
            this.tbxMedewerkerOnderhoud.Size = new System.Drawing.Size(120, 20);
            this.tbxMedewerkerOnderhoud.TabIndex = 16;
            // 
            // nudUur
            // 
            this.nudUur.Location = new System.Drawing.Point(351, 91);
            this.nudUur.Name = "nudUur";
            this.nudUur.Size = new System.Drawing.Size(47, 20);
            this.nudUur.TabIndex = 17;
            // 
            // nudMinuut
            // 
            this.nudMinuut.Location = new System.Drawing.Point(404, 91);
            this.nudMinuut.Name = "nudMinuut";
            this.nudMinuut.Size = new System.Drawing.Size(47, 20);
            this.nudMinuut.TabIndex = 18;
            // 
            // chxKlaar
            // 
            this.chxKlaar.AutoSize = true;
            this.chxKlaar.Location = new System.Drawing.Point(351, 154);
            this.chxKlaar.Name = "chxKlaar";
            this.chxKlaar.Size = new System.Drawing.Size(50, 17);
            this.chxKlaar.TabIndex = 20;
            this.chxKlaar.Text = "Klaar";
            this.chxKlaar.UseVisualStyleBackColor = true;
            this.chxKlaar.CheckedChanged += new System.EventHandler(this.chxKlaar_CheckedChanged);
            // 
            // OnderhoudApplicatie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 186);
            this.Controls.Add(this.chxKlaar);
            this.Controls.Add(this.nudMinuut);
            this.Controls.Add(this.nudUur);
            this.Controls.Add(this.tbxMedewerkerOnderhoud);
            this.Controls.Add(this.lblOnderhoudsMedewerkers);
            this.Controls.Add(this.btnTijdsIndicatieWijzigen);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.tbxDatum);
            this.Controls.Add(this.dtpDatum);
            this.Controls.Add(this.lblOnderhoud);
            this.Controls.Add(this.btnVerwijderMedewerker);
            this.Controls.Add(this.btnVoegMedewerkerToe);
            this.Controls.Add(this.lblOnderhoudsBeurten);
            this.Controls.Add(this.lblMedewerkers);
            this.Controls.Add(this.lbxOnderhoudsBeurten);
            this.Controls.Add(this.lbxMedewerkers);
            this.Name = "OnderhoudApplicatie";
            this.Text = "Onderhoud";
            ((System.ComponentModel.ISupportInitialize)(this.nudUur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinuut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxMedewerkers;
        private System.Windows.Forms.ListBox lbxOnderhoudsBeurten;
        private System.Windows.Forms.Label lblMedewerkers;
        private System.Windows.Forms.Label lblOnderhoudsBeurten;
        private System.Windows.Forms.Button btnVoegMedewerkerToe;
        private System.Windows.Forms.Button btnVerwijderMedewerker;
        private System.Windows.Forms.Label lblOnderhoud;
        private System.Windows.Forms.DateTimePicker dtpDatum;
        private System.Windows.Forms.TextBox tbxDatum;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.Button btnTijdsIndicatieWijzigen;
        private System.Windows.Forms.Label lblOnderhoudsMedewerkers;
        private System.Windows.Forms.TextBox tbxMedewerkerOnderhoud;
        private System.Windows.Forms.NumericUpDown nudUur;
        private System.Windows.Forms.NumericUpDown nudMinuut;
        private System.Windows.Forms.CheckBox chxKlaar;
    }
}