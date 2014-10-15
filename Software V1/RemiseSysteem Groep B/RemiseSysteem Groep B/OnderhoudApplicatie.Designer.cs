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
            this.btnTijdsIndicatieOpvragen = new System.Windows.Forms.Button();
            this.lbxOnderhoudsMedewerkers = new System.Windows.Forms.ListBox();
            this.lblOnderhoudsMedewerkers = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbxMedewerkers
            // 
            this.lbxMedewerkers.FormattingEnabled = true;
            this.lbxMedewerkers.Location = new System.Drawing.Point(15, 25);
            this.lbxMedewerkers.Name = "lbxMedewerkers";
            this.lbxMedewerkers.Size = new System.Drawing.Size(120, 95);
            this.lbxMedewerkers.TabIndex = 0;
            // 
            // lbxOnderhoudsBeurten
            // 
            this.lbxOnderhoudsBeurten.FormattingEnabled = true;
            this.lbxOnderhoudsBeurten.Location = new System.Drawing.Point(222, 25);
            this.lbxOnderhoudsBeurten.Name = "lbxOnderhoudsBeurten";
            this.lbxOnderhoudsBeurten.Size = new System.Drawing.Size(120, 95);
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
            // 
            // btnVerwijderMedewerker
            // 
            this.btnVerwijderMedewerker.Location = new System.Drawing.Point(642, 344);
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
            this.lblOnderhoud.Location = new System.Drawing.Point(513, 179);
            this.lblOnderhoud.Name = "lblOnderhoud";
            this.lblOnderhoud.Size = new System.Drawing.Size(92, 13);
            this.lblOnderhoud.TabIndex = 6;
            this.lblOnderhoud.Text = "Onderhoudsbeurt:";
            // 
            // dtpDatum
            // 
            this.dtpDatum.Location = new System.Drawing.Point(516, 276);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(200, 20);
            this.dtpDatum.TabIndex = 8;
            // 
            // tbxDatum
            // 
            this.tbxDatum.Enabled = false;
            this.tbxDatum.Location = new System.Drawing.Point(516, 250);
            this.tbxDatum.Name = "tbxDatum";
            this.tbxDatum.Size = new System.Drawing.Size(100, 20);
            this.tbxDatum.TabIndex = 9;
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Location = new System.Drawing.Point(513, 234);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(71, 13);
            this.lblDatum.TabIndex = 10;
            this.lblDatum.Text = "Tijdsindicatie:";
            // 
            // btnTijdsIndicatieWijzigen
            // 
            this.btnTijdsIndicatieWijzigen.Location = new System.Drawing.Point(516, 302);
            this.btnTijdsIndicatieWijzigen.Name = "btnTijdsIndicatieWijzigen";
            this.btnTijdsIndicatieWijzigen.Size = new System.Drawing.Size(75, 23);
            this.btnTijdsIndicatieWijzigen.TabIndex = 11;
            this.btnTijdsIndicatieWijzigen.Text = "Wijzig";
            this.btnTijdsIndicatieWijzigen.UseVisualStyleBackColor = true;
            this.btnTijdsIndicatieWijzigen.Click += new System.EventHandler(this.btnTijdsIndicatieWijzigen_Click);
            // 
            // btnTijdsIndicatieOpvragen
            // 
            this.btnTijdsIndicatieOpvragen.Location = new System.Drawing.Point(622, 248);
            this.btnTijdsIndicatieOpvragen.Name = "btnTijdsIndicatieOpvragen";
            this.btnTijdsIndicatieOpvragen.Size = new System.Drawing.Size(75, 23);
            this.btnTijdsIndicatieOpvragen.TabIndex = 12;
            this.btnTijdsIndicatieOpvragen.Text = "Vernieuwen";
            this.btnTijdsIndicatieOpvragen.UseVisualStyleBackColor = true;
            // 
            // lbxOnderhoudsMedewerkers
            // 
            this.lbxOnderhoudsMedewerkers.FormattingEnabled = true;
            this.lbxOnderhoudsMedewerkers.Location = new System.Drawing.Point(516, 344);
            this.lbxOnderhoudsMedewerkers.Name = "lbxOnderhoudsMedewerkers";
            this.lbxOnderhoudsMedewerkers.Size = new System.Drawing.Size(120, 95);
            this.lbxOnderhoudsMedewerkers.TabIndex = 13;
            this.lbxOnderhoudsMedewerkers.SelectedIndexChanged += new System.EventHandler(this.lbxOnderhoudsMedewerkers_SelectedIndexChanged);
            // 
            // lblOnderhoudsMedewerkers
            // 
            this.lblOnderhoudsMedewerkers.AutoSize = true;
            this.lblOnderhoudsMedewerkers.Location = new System.Drawing.Point(513, 328);
            this.lblOnderhoudsMedewerkers.Name = "lblOnderhoudsMedewerkers";
            this.lblOnderhoudsMedewerkers.Size = new System.Drawing.Size(74, 13);
            this.lblOnderhoudsMedewerkers.TabIndex = 14;
            this.lblOnderhoudsMedewerkers.Text = "Medewerkers:";
            // 
            // OnderhoudApplicatie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1475, 633);
            this.Controls.Add(this.lblOnderhoudsMedewerkers);
            this.Controls.Add(this.lbxOnderhoudsMedewerkers);
            this.Controls.Add(this.btnTijdsIndicatieOpvragen);
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
        private System.Windows.Forms.Button btnTijdsIndicatieOpvragen;
        private System.Windows.Forms.ListBox lbxOnderhoudsMedewerkers;
        private System.Windows.Forms.Label lblOnderhoudsMedewerkers;
    }
}