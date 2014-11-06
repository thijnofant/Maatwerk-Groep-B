namespace RemiseSysteem_Groep_B
{
    partial class OnderhoudGoedkeuren
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
            this.btnGoedkeuren = new System.Windows.Forms.Button();
            this.lbxOnderhoud = new System.Windows.Forms.ListBox();
            this.btnAfkeuren = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGoedkeuren
            // 
            this.btnGoedkeuren.Location = new System.Drawing.Point(323, 387);
            this.btnGoedkeuren.Name = "btnGoedkeuren";
            this.btnGoedkeuren.Size = new System.Drawing.Size(213, 40);
            this.btnGoedkeuren.TabIndex = 3;
            this.btnGoedkeuren.Text = "Goedkeuren";
            this.btnGoedkeuren.UseVisualStyleBackColor = true;
            this.btnGoedkeuren.Click += new System.EventHandler(this.btnGoedkeuren_Click);
            // 
            // lbxOnderhoud
            // 
            this.lbxOnderhoud.FormattingEnabled = true;
            this.lbxOnderhoud.ItemHeight = 16;
            this.lbxOnderhoud.Location = new System.Drawing.Point(12, 12);
            this.lbxOnderhoud.Name = "lbxOnderhoud";
            this.lbxOnderhoud.Size = new System.Drawing.Size(1075, 356);
            this.lbxOnderhoud.TabIndex = 2;
            // 
            // btnAfkeuren
            // 
            this.btnAfkeuren.Location = new System.Drawing.Point(542, 387);
            this.btnAfkeuren.Name = "btnAfkeuren";
            this.btnAfkeuren.Size = new System.Drawing.Size(213, 40);
            this.btnAfkeuren.TabIndex = 4;
            this.btnAfkeuren.Text = "Afkeuren";
            this.btnAfkeuren.UseVisualStyleBackColor = true;
            this.btnAfkeuren.Click += new System.EventHandler(this.btnAfkeuren_Click);
            // 
            // OnderhoudGoedkeuren
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 449);
            this.Controls.Add(this.btnAfkeuren);
            this.Controls.Add(this.btnGoedkeuren);
            this.Controls.Add(this.lbxOnderhoud);
            this.MaximizeBox = false;
            this.Name = "OnderhoudGoedkeuren";
            this.Text = "OnderhoudGoedkeuren";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGoedkeuren;
        private System.Windows.Forms.ListBox lbxOnderhoud;
        private System.Windows.Forms.Button btnAfkeuren;
    }
}