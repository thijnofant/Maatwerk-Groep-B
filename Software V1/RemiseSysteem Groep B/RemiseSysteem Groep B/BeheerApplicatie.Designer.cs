namespace RemiseSysteem_Groep_B
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
            this.lblMeldingen = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tramsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sporenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lijnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medewerkersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgwOverzicht = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 790);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1460, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBox1);
            this.splitContainer1.Panel1.Controls.Add(this.lblMeldingen);
            this.splitContainer1.Size = new System.Drawing.Size(1460, 762);
            this.splitContainer1.SplitterDistance = 486;
            this.splitContainer1.TabIndex = 2;
            // 
            // lblMeldingen
            // 
            this.lblMeldingen.AutoSize = true;
            this.lblMeldingen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeldingen.Location = new System.Drawing.Point(183, 15);
            this.lblMeldingen.Name = "lblMeldingen";
            this.lblMeldingen.Size = new System.Drawing.Size(103, 25);
            this.lblMeldingen.TabIndex = 0;
            this.lblMeldingen.Text = "Meldingen";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(12, 52);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(453, 388);
            this.listBox1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tramsToolStripMenuItem,
            this.sporenToolStripMenuItem,
            this.lijnenToolStripMenuItem,
            this.medewerkersToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1460, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tramsToolStripMenuItem
            // 
            this.tramsToolStripMenuItem.Name = "tramsToolStripMenuItem";
            this.tramsToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this.tramsToolStripMenuItem.Text = "Trams";
            // 
            // sporenToolStripMenuItem
            // 
            this.sporenToolStripMenuItem.Name = "sporenToolStripMenuItem";
            this.sporenToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.sporenToolStripMenuItem.Text = "Sporen";
            // 
            // lijnenToolStripMenuItem
            // 
            this.lijnenToolStripMenuItem.Name = "lijnenToolStripMenuItem";
            this.lijnenToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.lijnenToolStripMenuItem.Text = "Lijnen";
            // 
            // medewerkersToolStripMenuItem
            // 
            this.medewerkersToolStripMenuItem.Name = "medewerkersToolStripMenuItem";
            this.medewerkersToolStripMenuItem.Size = new System.Drawing.Size(109, 24);
            this.medewerkersToolStripMenuItem.Text = "Medewerkers";
            // 
            // BeheerApplicatie
            // 
            this.ClientSize = new System.Drawing.Size(1460, 812);
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
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lblMeldingen;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tramsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sporenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lijnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medewerkersToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker bgwOverzicht;
    }
}

