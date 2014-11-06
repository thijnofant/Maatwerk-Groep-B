namespace RemiseSysteem_Groep_B
{
    partial class TramVerplaatsen
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
            this.cbbTram = new System.Windows.Forms.ComboBox();
            this.cbbSpoor = new System.Windows.Forms.ComboBox();
            this.cbbSector = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPlaats = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnVertrek = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbbTram
            // 
            this.cbbTram.FormattingEnabled = true;
            this.cbbTram.Location = new System.Drawing.Point(16, 48);
            this.cbbTram.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbTram.Name = "cbbTram";
            this.cbbTram.Size = new System.Drawing.Size(160, 24);
            this.cbbTram.TabIndex = 0;
            // 
            // cbbSpoor
            // 
            this.cbbSpoor.FormattingEnabled = true;
            this.cbbSpoor.Location = new System.Drawing.Point(293, 48);
            this.cbbSpoor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbSpoor.Name = "cbbSpoor";
            this.cbbSpoor.Size = new System.Drawing.Size(84, 24);
            this.cbbSpoor.TabIndex = 1;
            this.cbbSpoor.SelectedIndexChanged += new System.EventHandler(this.cbbSpoor_SelectedIndexChanged);
            // 
            // cbbSector
            // 
            this.cbbSector.FormattingEnabled = true;
            this.cbbSector.Location = new System.Drawing.Point(387, 48);
            this.cbbSector.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbSector.Name = "cbbSector";
            this.cbbSector.Size = new System.Drawing.Size(84, 24);
            this.cbbSector.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tram:";
            // 
            // btnPlaats
            // 
            this.btnPlaats.Location = new System.Drawing.Point(185, 28);
            this.btnPlaats.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPlaats.Name = "btnPlaats";
            this.btnPlaats.Size = new System.Drawing.Size(100, 46);
            this.btnPlaats.TabIndex = 4;
            this.btnPlaats.Text = "(Ver)Plaats";
            this.btnPlaats.UseVisualStyleBackColor = true;
            this.btnPlaats.Click += new System.EventHandler(this.btnPlaats_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(289, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Spoor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(383, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Sector:";
            // 
            // btnVertrek
            // 
            this.btnVertrek.Location = new System.Drawing.Point(185, 81);
            this.btnVertrek.Name = "btnVertrek";
            this.btnVertrek.Size = new System.Drawing.Size(100, 44);
            this.btnVertrek.TabIndex = 7;
            this.btnVertrek.Text = "Vertrek uit Remise";
            this.btnVertrek.UseVisualStyleBackColor = true;
            this.btnVertrek.Click += new System.EventHandler(this.btnVertrek_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(207, 132);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            this.lblStatus.TabIndex = 8;
            // 
            // TramVerplaatsen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 158);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnVertrek);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPlaats);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbSector);
            this.Controls.Add(this.cbbSpoor);
            this.Controls.Add(this.cbbTram);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TramVerplaatsen";
            this.Text = "Tram (ver)plaatsen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbTram;
        private System.Windows.Forms.ComboBox cbbSpoor;
        private System.Windows.Forms.ComboBox cbbSector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPlaats;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnVertrek;
        private System.Windows.Forms.Label lblStatus;
    }
}