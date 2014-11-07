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
            this.SuspendLayout();
            // 
            // cbbTram
            // 
            this.cbbTram.FormattingEnabled = true;
            this.cbbTram.Location = new System.Drawing.Point(12, 39);
            this.cbbTram.Name = "cbbTram";
            this.cbbTram.Size = new System.Drawing.Size(121, 21);
            this.cbbTram.TabIndex = 0;
            // 
            // cbbSpoor
            // 
            this.cbbSpoor.FormattingEnabled = true;
            this.cbbSpoor.Location = new System.Drawing.Point(220, 39);
            this.cbbSpoor.Name = "cbbSpoor";
            this.cbbSpoor.Size = new System.Drawing.Size(64, 21);
            this.cbbSpoor.TabIndex = 1;
            this.cbbSpoor.SelectedIndexChanged += new System.EventHandler(this.cbbSpoor_SelectedIndexChanged);
            // 
            // cbbSector
            // 
            this.cbbSector.FormattingEnabled = true;
            this.cbbSector.Location = new System.Drawing.Point(290, 39);
            this.cbbSector.Name = "cbbSector";
            this.cbbSector.Size = new System.Drawing.Size(64, 21);
            this.cbbSector.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tram:";
            // 
            // btnPlaats
            // 
            this.btnPlaats.Location = new System.Drawing.Point(139, 23);
            this.btnPlaats.Name = "btnPlaats";
            this.btnPlaats.Size = new System.Drawing.Size(75, 37);
            this.btnPlaats.TabIndex = 4;
            this.btnPlaats.Text = "(Ver)Plaats";
            this.btnPlaats.UseVisualStyleBackColor = true;
            this.btnPlaats.Click += new System.EventHandler(this.btnPlaats_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Spoor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(287, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Sector:";
            // 
            // btnVertrek
            // 
            this.btnVertrek.Location = new System.Drawing.Point(139, 66);
            this.btnVertrek.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnVertrek.Name = "btnVertrek";
            this.btnVertrek.Size = new System.Drawing.Size(75, 36);
            this.btnVertrek.TabIndex = 7;
            this.btnVertrek.Text = "Vertrek uit Remise";
            this.btnVertrek.UseVisualStyleBackColor = true;
            this.btnVertrek.Click += new System.EventHandler(this.btnVertrek_Click);
            // 
            // TramVerplaatsen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 128);
            this.Controls.Add(this.btnVertrek);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPlaats);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbSector);
            this.Controls.Add(this.cbbSpoor);
            this.Controls.Add(this.cbbTram);
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
    }
}