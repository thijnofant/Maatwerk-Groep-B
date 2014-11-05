namespace RemiseSysteem_Groep_B
{
    partial class SchoonmaakGoedkeuren
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
            this.lbxSchoonmaak = new System.Windows.Forms.ListBox();
            this.btnGoedkeuren = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxSchoonmaak
            // 
            this.lbxSchoonmaak.FormattingEnabled = true;
            this.lbxSchoonmaak.ItemHeight = 16;
            this.lbxSchoonmaak.Location = new System.Drawing.Point(12, 12);
            this.lbxSchoonmaak.Name = "lbxSchoonmaak";
            this.lbxSchoonmaak.Size = new System.Drawing.Size(752, 308);
            this.lbxSchoonmaak.TabIndex = 0;
            // 
            // btnGoedkeuren
            // 
            this.btnGoedkeuren.Location = new System.Drawing.Point(277, 333);
            this.btnGoedkeuren.Name = "btnGoedkeuren";
            this.btnGoedkeuren.Size = new System.Drawing.Size(213, 40);
            this.btnGoedkeuren.TabIndex = 1;
            this.btnGoedkeuren.Text = "Goedkeuren";
            this.btnGoedkeuren.UseVisualStyleBackColor = true;
            this.btnGoedkeuren.Click += new System.EventHandler(this.btnGoedkeuren_Click);
            // 
            // SchoonmaakGoedkeuren
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 385);
            this.Controls.Add(this.btnGoedkeuren);
            this.Controls.Add(this.lbxSchoonmaak);
            this.Name = "SchoonmaakGoedkeuren";
            this.Text = "SchoonmaakGoedkeuren";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxSchoonmaak;
        private System.Windows.Forms.Button btnGoedkeuren;


    }
}