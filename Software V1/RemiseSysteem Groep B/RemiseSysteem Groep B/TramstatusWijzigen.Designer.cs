namespace RemiseSysteem_Groep_B
{
    partial class TramstatusWijzigen
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
            this.lbxTrams = new System.Windows.Forms.ListBox();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.btnWijzigStatus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxTrams
            // 
            this.lbxTrams.FormattingEnabled = true;
            this.lbxTrams.ItemHeight = 16;
            this.lbxTrams.Location = new System.Drawing.Point(12, 12);
            this.lbxTrams.Name = "lbxTrams";
            this.lbxTrams.Size = new System.Drawing.Size(884, 372);
            this.lbxTrams.TabIndex = 0;
            this.lbxTrams.SelectedIndexChanged += new System.EventHandler(this.lbxTrams_SelectedIndexChanged);
            // 
            // cbxStatus
            // 
            this.cbxStatus.FormattingEnabled = true;
            this.cbxStatus.Location = new System.Drawing.Point(151, 416);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(161, 24);
            this.cbxStatus.TabIndex = 1;
            // 
            // btnWijzigStatus
            // 
            this.btnWijzigStatus.Location = new System.Drawing.Point(386, 400);
            this.btnWijzigStatus.Name = "btnWijzigStatus";
            this.btnWijzigStatus.Size = new System.Drawing.Size(206, 54);
            this.btnWijzigStatus.TabIndex = 2;
            this.btnWijzigStatus.Text = "Wijzigstatus";
            this.btnWijzigStatus.UseVisualStyleBackColor = true;
            this.btnWijzigStatus.Click += new System.EventHandler(this.btnWijzigStatus_Click);
            // 
            // TramstatusWijzigen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 483);
            this.Controls.Add(this.btnWijzigStatus);
            this.Controls.Add(this.cbxStatus);
            this.Controls.Add(this.lbxTrams);
            this.Name = "TramstatusWijzigen";
            this.Text = "TramstatusWijzigen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxTrams;
        private System.Windows.Forms.ComboBox cbxStatus;
        private System.Windows.Forms.Button btnWijzigStatus;
    }
}