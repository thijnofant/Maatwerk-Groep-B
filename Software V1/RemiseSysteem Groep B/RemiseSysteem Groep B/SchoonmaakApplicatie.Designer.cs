namespace RemiseSysteem_Groep_B
{
    partial class SchoonmaakApplicatie
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMedewerker = new System.Windows.Forms.ComboBox();
            this.cbTram = new System.Windows.Forms.ComboBox();
            this.dtpStartDatum = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbKlein = new System.Windows.Forms.RadioButton();
            this.rbGroot = new System.Windows.Forms.RadioButton();
            this.btnAanvragen = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.tbxMedewerkerOnderhoud = new System.Windows.Forms.TextBox();
            this.lblOnderhoudsMedewerkers = new System.Windows.Forms.Label();
            this.tbxDatum = new System.Windows.Forms.TextBox();
            this.lblSchoonmaak = new System.Windows.Forms.Label();
            this.lblSchoonmaakBeurten = new System.Windows.Forms.Label();
            this.lbxSchoonmaakBeurten = new System.Windows.Forms.ListBox();
            this.chxKlaar = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Medewerker";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tram";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Start datum";
            // 
            // cbMedewerker
            // 
            this.cbMedewerker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMedewerker.FormattingEnabled = true;
            this.cbMedewerker.Location = new System.Drawing.Point(163, 22);
            this.cbMedewerker.Name = "cbMedewerker";
            this.cbMedewerker.Size = new System.Drawing.Size(224, 21);
            this.cbMedewerker.TabIndex = 4;
            // 
            // cbTram
            // 
            this.cbTram.FormattingEnabled = true;
            this.cbTram.Location = new System.Drawing.Point(163, 59);
            this.cbTram.Name = "cbTram";
            this.cbTram.Size = new System.Drawing.Size(224, 21);
            this.cbTram.TabIndex = 5;
            // 
            // dtpStartDatum
            // 
            this.dtpStartDatum.Location = new System.Drawing.Point(163, 100);
            this.dtpStartDatum.Name = "dtpStartDatum";
            this.dtpStartDatum.Size = new System.Drawing.Size(224, 20);
            this.dtpStartDatum.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbKlein);
            this.groupBox1.Controls.Add(this.rbGroot);
            this.groupBox1.Location = new System.Drawing.Point(138, 152);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Soort schoonmaak";
            // 
            // rbKlein
            // 
            this.rbKlein.AutoSize = true;
            this.rbKlein.Location = new System.Drawing.Point(114, 41);
            this.rbKlein.Name = "rbKlein";
            this.rbKlein.Size = new System.Drawing.Size(48, 17);
            this.rbKlein.TabIndex = 1;
            this.rbKlein.TabStop = true;
            this.rbKlein.Text = "Klein";
            this.rbKlein.UseVisualStyleBackColor = true;
            this.rbKlein.CheckedChanged += new System.EventHandler(this.rbKlein_CheckedChanged);
            // 
            // rbGroot
            // 
            this.rbGroot.AutoSize = true;
            this.rbGroot.Location = new System.Drawing.Point(30, 41);
            this.rbGroot.Name = "rbGroot";
            this.rbGroot.Size = new System.Drawing.Size(51, 17);
            this.rbGroot.TabIndex = 0;
            this.rbGroot.TabStop = true;
            this.rbGroot.Text = "Groot";
            this.rbGroot.UseVisualStyleBackColor = true;
            this.rbGroot.CheckedChanged += new System.EventHandler(this.rbGroot_CheckedChanged);
            // 
            // btnAanvragen
            // 
            this.btnAanvragen.Location = new System.Drawing.Point(138, 268);
            this.btnAanvragen.Name = "btnAanvragen";
            this.btnAanvragen.Size = new System.Drawing.Size(200, 43);
            this.btnAanvragen.TabIndex = 2;
            this.btnAanvragen.Text = "Aanvragen";
            this.btnAanvragen.UseVisualStyleBackColor = true;
            this.btnAanvragen.Click += new System.EventHandler(this.btnAanvragen_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(55, 319);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(16, 13);
            this.lblMessage.TabIndex = 9;
            this.lblMessage.Text = "...";
            // 
            // tbxMedewerkerOnderhoud
            // 
            this.tbxMedewerkerOnderhoud.Enabled = false;
            this.tbxMedewerkerOnderhoud.Location = new System.Drawing.Point(141, 374);
            this.tbxMedewerkerOnderhoud.Name = "tbxMedewerkerOnderhoud";
            this.tbxMedewerkerOnderhoud.Size = new System.Drawing.Size(120, 20);
            this.tbxMedewerkerOnderhoud.TabIndex = 33;
            // 
            // lblOnderhoudsMedewerkers
            // 
            this.lblOnderhoudsMedewerkers.AutoSize = true;
            this.lblOnderhoudsMedewerkers.Location = new System.Drawing.Point(141, 358);
            this.lblOnderhoudsMedewerkers.Name = "lblOnderhoudsMedewerkers";
            this.lblOnderhoudsMedewerkers.Size = new System.Drawing.Size(69, 13);
            this.lblOnderhoudsMedewerkers.TabIndex = 32;
            this.lblOnderhoudsMedewerkers.Text = "Medewerker:";
            // 
            // tbxDatum
            // 
            this.tbxDatum.Enabled = false;
            this.tbxDatum.Location = new System.Drawing.Point(141, 335);
            this.tbxDatum.Name = "tbxDatum";
            this.tbxDatum.Size = new System.Drawing.Size(100, 20);
            this.tbxDatum.TabIndex = 29;
            // 
            // lblSchoonmaak
            // 
            this.lblSchoonmaak.AutoSize = true;
            this.lblSchoonmaak.Location = new System.Drawing.Point(138, 319);
            this.lblSchoonmaak.Name = "lblSchoonmaak";
            this.lblSchoonmaak.Size = new System.Drawing.Size(97, 13);
            this.lblSchoonmaak.TabIndex = 27;
            this.lblSchoonmaak.Text = "Schoonmaakbeurt:";
            // 
            // lblSchoonmaakBeurten
            // 
            this.lblSchoonmaakBeurten.AutoSize = true;
            this.lblSchoonmaakBeurten.Location = new System.Drawing.Point(12, 319);
            this.lblSchoonmaakBeurten.Name = "lblSchoonmaakBeurten";
            this.lblSchoonmaakBeurten.Size = new System.Drawing.Size(109, 13);
            this.lblSchoonmaakBeurten.TabIndex = 24;
            this.lblSchoonmaakBeurten.Text = "Schoonmaakbeurten:";
            // 
            // lbxSchoonmaakBeurten
            // 
            this.lbxSchoonmaakBeurten.FormattingEnabled = true;
            this.lbxSchoonmaakBeurten.Location = new System.Drawing.Point(15, 335);
            this.lbxSchoonmaakBeurten.Name = "lbxSchoonmaakBeurten";
            this.lbxSchoonmaakBeurten.Size = new System.Drawing.Size(120, 147);
            this.lbxSchoonmaakBeurten.TabIndex = 22;
            this.lbxSchoonmaakBeurten.SelectedIndexChanged += new System.EventHandler(this.lbxSchoonmaakBeurten_SelectedIndexChanged);
            // 
            // chxKlaar
            // 
            this.chxKlaar.AutoSize = true;
            this.chxKlaar.Location = new System.Drawing.Point(141, 400);
            this.chxKlaar.Name = "chxKlaar";
            this.chxKlaar.Size = new System.Drawing.Size(50, 17);
            this.chxKlaar.TabIndex = 36;
            this.chxKlaar.Text = "Klaar";
            this.chxKlaar.UseVisualStyleBackColor = true;
            this.chxKlaar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chxKlaar_MouseClick);
            // 
            // SchoonmaakApplicatie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 496);
            this.Controls.Add(this.chxKlaar);
            this.Controls.Add(this.tbxMedewerkerOnderhoud);
            this.Controls.Add(this.lblOnderhoudsMedewerkers);
            this.Controls.Add(this.tbxDatum);
            this.Controls.Add(this.lblSchoonmaak);
            this.Controls.Add(this.lblSchoonmaakBeurten);
            this.Controls.Add(this.lbxSchoonmaakBeurten);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnAanvragen);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtpStartDatum);
            this.Controls.Add(this.cbTram);
            this.Controls.Add(this.cbMedewerker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SchoonmaakApplicatie";
            this.Text = "Schoonmaak";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbMedewerker;
        private System.Windows.Forms.ComboBox cbTram;
        private System.Windows.Forms.DateTimePicker dtpStartDatum;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbKlein;
        private System.Windows.Forms.RadioButton rbGroot;
        private System.Windows.Forms.Button btnAanvragen;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox tbxMedewerkerOnderhoud;
        private System.Windows.Forms.Label lblOnderhoudsMedewerkers;
        private System.Windows.Forms.TextBox tbxDatum;
        private System.Windows.Forms.Label lblSchoonmaak;
        private System.Windows.Forms.Label lblSchoonmaakBeurten;
        private System.Windows.Forms.ListBox lbxSchoonmaakBeurten;
        private System.Windows.Forms.CheckBox chxKlaar;
    }
}