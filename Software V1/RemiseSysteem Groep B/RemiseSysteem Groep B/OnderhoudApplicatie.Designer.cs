﻿namespace RemiseSysteem_Groep_B
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
            this.lblOnderhoud = new System.Windows.Forms.Label();
            this.btnVoegMedewerkerToe = new System.Windows.Forms.Button();
            this.btnVerwijderMedewerker = new System.Windows.Forms.Button();
            this.lblReparatie = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
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
            // lblOnderhoud
            // 
            this.lblOnderhoud.AutoSize = true;
            this.lblOnderhoud.Location = new System.Drawing.Point(219, 9);
            this.lblOnderhoud.Name = "lblOnderhoud";
            this.lblOnderhoud.Size = new System.Drawing.Size(104, 13);
            this.lblOnderhoud.TabIndex = 3;
            this.lblOnderhoud.Text = "Onderhoudsbeurten:";
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
            this.btnVerwijderMedewerker.Location = new System.Drawing.Point(141, 54);
            this.btnVerwijderMedewerker.Name = "btnVerwijderMedewerker";
            this.btnVerwijderMedewerker.Size = new System.Drawing.Size(75, 23);
            this.btnVerwijderMedewerker.TabIndex = 5;
            this.btnVerwijderMedewerker.Text = "Verwijder";
            this.btnVerwijderMedewerker.UseVisualStyleBackColor = true;
            // 
            // lblReparatie
            // 
            this.lblReparatie.AutoSize = true;
            this.lblReparatie.Location = new System.Drawing.Point(513, 220);
            this.lblReparatie.Name = "lblReparatie";
            this.lblReparatie.Size = new System.Drawing.Size(56, 13);
            this.lblReparatie.TabIndex = 6;
            this.lblReparatie.Text = "Reparatie:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(516, 236);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // OnderhoudApplicatie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1475, 633);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lblReparatie);
            this.Controls.Add(this.btnVerwijderMedewerker);
            this.Controls.Add(this.btnVoegMedewerkerToe);
            this.Controls.Add(this.lblOnderhoud);
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
        private System.Windows.Forms.Label lblOnderhoud;
        private System.Windows.Forms.Button btnVoegMedewerkerToe;
        private System.Windows.Forms.Button btnVerwijderMedewerker;
        private System.Windows.Forms.Label lblReparatie;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}