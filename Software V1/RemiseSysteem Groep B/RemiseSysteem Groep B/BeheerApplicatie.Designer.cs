﻿namespace RemiseSysteem_Groep_B
{
    partial class BeheerApplicatie
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblMeldingen = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tramsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verplaatsenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reparatieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aanvragenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schoonmaakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invoerenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verwijderenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sporenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blokkerenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deblokkerenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lijnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beherenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medewerkersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beherenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.actiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schoonmaakLijstOpvragenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgwOverzicht = new System.ComponentModel.BackgroundWorker();
            this.bgwMeldingen = new System.ComponentModel.BackgroundWorker();
            this.reserverenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 493);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1370, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel1.Controls.Add(this.lblMeldingen);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.splitContainer1.Size = new System.Drawing.Size(1370, 469);
            this.splitContainer1.SplitterDistance = 504;
            this.splitContainer1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(524, 444);
            this.dataGridView1.TabIndex = 1;
            // 
            // lblMeldingen
            // 
            this.lblMeldingen.AutoSize = true;
            this.lblMeldingen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeldingen.Location = new System.Drawing.Point(183, 15);
            this.lblMeldingen.Name = "lblMeldingen";
            this.lblMeldingen.Size = new System.Drawing.Size(82, 20);
            this.lblMeldingen.TabIndex = 0;
            this.lblMeldingen.Text = "Meldingen";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tramsToolStripMenuItem,
            this.sporenToolStripMenuItem,
            this.lijnenToolStripMenuItem,
            this.medewerkersToolStripMenuItem,
            this.actiesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1370, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tramsToolStripMenuItem
            // 
            this.tramsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verplaatsenToolStripMenuItem,
            this.reparatieToolStripMenuItem,
            this.schoonmaakToolStripMenuItem,
            this.verwijderenToolStripMenuItem,
            this.reserverenToolStripMenuItem});
            this.tramsToolStripMenuItem.Name = "tramsToolStripMenuItem";
            this.tramsToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.tramsToolStripMenuItem.Text = "Trams";
            // 
            // verplaatsenToolStripMenuItem
            // 
            this.verplaatsenToolStripMenuItem.Name = "verplaatsenToolStripMenuItem";
            this.verplaatsenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.verplaatsenToolStripMenuItem.Text = "Verplaatsen";
            this.verplaatsenToolStripMenuItem.Click += new System.EventHandler(this.verplaatsenToolStripMenuItem_Click);
            // 
            // reparatieToolStripMenuItem
            // 
            this.reparatieToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aanvragenToolStripMenuItem});
            this.reparatieToolStripMenuItem.Name = "reparatieToolStripMenuItem";
            this.reparatieToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.reparatieToolStripMenuItem.Text = "Reparatie";
            this.reparatieToolStripMenuItem.Click += new System.EventHandler(this.reparatieToolStripMenuItem_Click);
            // 
            // aanvragenToolStripMenuItem
            // 
            this.aanvragenToolStripMenuItem.Name = "aanvragenToolStripMenuItem";
            this.aanvragenToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.aanvragenToolStripMenuItem.Text = "Aanvragen";
            // 
            // schoonmaakToolStripMenuItem
            // 
            this.schoonmaakToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.invoerenToolStripMenuItem});
            this.schoonmaakToolStripMenuItem.Name = "schoonmaakToolStripMenuItem";
            this.schoonmaakToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.schoonmaakToolStripMenuItem.Text = "Schoonmaak";
            this.schoonmaakToolStripMenuItem.Click += new System.EventHandler(this.schoonmaakToolStripMenuItem_Click);
            // 
            // invoerenToolStripMenuItem
            // 
            this.invoerenToolStripMenuItem.Name = "invoerenToolStripMenuItem";
            this.invoerenToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.invoerenToolStripMenuItem.Text = "Invoeren";
            this.invoerenToolStripMenuItem.Click += new System.EventHandler(this.invoerenToolStripMenuItem_Click);
            // 
            // verwijderenToolStripMenuItem
            // 
            this.verwijderenToolStripMenuItem.Name = "verwijderenToolStripMenuItem";
            this.verwijderenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.verwijderenToolStripMenuItem.Text = "Verwijderen";
            this.verwijderenToolStripMenuItem.Click += new System.EventHandler(this.verwijderenToolStripMenuItem_Click);
            // 
            // sporenToolStripMenuItem
            // 
            this.sporenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blokkerenToolStripMenuItem,
            this.deblokkerenToolStripMenuItem});
            this.sporenToolStripMenuItem.Name = "sporenToolStripMenuItem";
            this.sporenToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.sporenToolStripMenuItem.Text = "Sporen";
            // 
            // blokkerenToolStripMenuItem
            // 
            this.blokkerenToolStripMenuItem.Name = "blokkerenToolStripMenuItem";
            this.blokkerenToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.blokkerenToolStripMenuItem.Text = "Blokkeren";
            this.blokkerenToolStripMenuItem.Click += new System.EventHandler(this.blokkerenToolStripMenuItem_Click);
            // 
            // deblokkerenToolStripMenuItem
            // 
            this.deblokkerenToolStripMenuItem.Name = "deblokkerenToolStripMenuItem";
            this.deblokkerenToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.deblokkerenToolStripMenuItem.Text = "Deblokkeren";
            this.deblokkerenToolStripMenuItem.Click += new System.EventHandler(this.deblokkerenToolStripMenuItem_Click);
            // 
            // lijnenToolStripMenuItem
            // 
            this.lijnenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beherenToolStripMenuItem});
            this.lijnenToolStripMenuItem.Name = "lijnenToolStripMenuItem";
            this.lijnenToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.lijnenToolStripMenuItem.Text = "Lijnen";
            // 
            // beherenToolStripMenuItem
            // 
            this.beherenToolStripMenuItem.Name = "beherenToolStripMenuItem";
            this.beherenToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.beherenToolStripMenuItem.Text = "Beheren";
            this.beherenToolStripMenuItem.Click += new System.EventHandler(this.beherenToolStripMenuItem_Click);
            // 
            // medewerkersToolStripMenuItem
            // 
            this.medewerkersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beherenToolStripMenuItem1});
            this.medewerkersToolStripMenuItem.Name = "medewerkersToolStripMenuItem";
            this.medewerkersToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.medewerkersToolStripMenuItem.Text = "Medewerkers";
            // 
            // beherenToolStripMenuItem1
            // 
            this.beherenToolStripMenuItem1.Name = "beherenToolStripMenuItem1";
            this.beherenToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.beherenToolStripMenuItem1.Text = "Beheren";
            this.beherenToolStripMenuItem1.Click += new System.EventHandler(this.beherenToolStripMenuItem1_Click);
            // 
            // actiesToolStripMenuItem
            // 
            this.actiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.schoonmaakLijstOpvragenToolStripMenuItem});
            this.actiesToolStripMenuItem.Name = "actiesToolStripMenuItem";
            this.actiesToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.actiesToolStripMenuItem.Text = "Acties";
            // 
            // schoonmaakLijstOpvragenToolStripMenuItem
            // 
            this.schoonmaakLijstOpvragenToolStripMenuItem.Name = "schoonmaakLijstOpvragenToolStripMenuItem";
            this.schoonmaakLijstOpvragenToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.schoonmaakLijstOpvragenToolStripMenuItem.Text = "Schoonmaak lijst opvragen";
            this.schoonmaakLijstOpvragenToolStripMenuItem.Click += new System.EventHandler(this.schoonmaakLijstOpvragenToolStripMenuItem_Click);
            // 
            // reserverenToolStripMenuItem
            // 
            this.reserverenToolStripMenuItem.Name = "reserverenToolStripMenuItem";
            this.reserverenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.reserverenToolStripMenuItem.Text = "Reserveren";
            this.reserverenToolStripMenuItem.Click += new System.EventHandler(this.reserverenToolStripMenuItem_Click);
            // 
            // BeheerApplicatie
            // 
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1370, 515);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "BeheerApplicatie";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblMeldingen;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tramsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sporenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lijnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medewerkersToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker bgwOverzicht;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.ComponentModel.BackgroundWorker bgwMeldingen;
        private System.Windows.Forms.ToolStripMenuItem verplaatsenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reparatieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aanvragenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schoonmaakToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verwijderenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blokkerenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deblokkerenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beherenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beherenToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem actiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schoonmaakLijstOpvragenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invoerenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reserverenToolStripMenuItem;
    }
}

