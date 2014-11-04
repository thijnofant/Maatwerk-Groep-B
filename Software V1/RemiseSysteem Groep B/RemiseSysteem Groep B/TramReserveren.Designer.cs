namespace RemiseSysteem_Groep_B
{
    partial class TramReserveren
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
            this.btnBevestig = new System.Windows.Forms.Button();
            this.tbTramnummer = new System.Windows.Forms.TextBox();
            this.tbSpoornummer = new System.Windows.Forms.TextBox();
            this.chbReparatie = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tramnummer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Spoornummer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Reparatie";
            // 
            // btnBevestig
            // 
            this.btnBevestig.Location = new System.Drawing.Point(24, 144);
            this.btnBevestig.Name = "btnBevestig";
            this.btnBevestig.Size = new System.Drawing.Size(75, 23);
            this.btnBevestig.TabIndex = 3;
            this.btnBevestig.Text = "Bevestig";
            this.btnBevestig.UseVisualStyleBackColor = true;
            // 
            // tbTramnummer
            // 
            this.tbTramnummer.Location = new System.Drawing.Point(24, 55);
            this.tbTramnummer.Multiline = true;
            this.tbTramnummer.Name = "tbTramnummer";
            this.tbTramnummer.Size = new System.Drawing.Size(90, 35);
            this.tbTramnummer.TabIndex = 4;
            // 
            // tbSpoornummer
            // 
            this.tbSpoornummer.Location = new System.Drawing.Point(164, 55);
            this.tbSpoornummer.Multiline = true;
            this.tbSpoornummer.Name = "tbSpoornummer";
            this.tbSpoornummer.Size = new System.Drawing.Size(90, 35);
            this.tbSpoornummer.TabIndex = 5;
            // 
            // chbReparatie
            // 
            this.chbReparatie.AutoSize = true;
            this.chbReparatie.Location = new System.Drawing.Point(166, 153);
            this.chbReparatie.Name = "chbReparatie";
            this.chbReparatie.Size = new System.Drawing.Size(15, 14);
            this.chbReparatie.TabIndex = 6;
            this.chbReparatie.UseVisualStyleBackColor = true;
            // 
            // TramReserveren
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 200);
            this.Controls.Add(this.chbReparatie);
            this.Controls.Add(this.tbSpoornummer);
            this.Controls.Add(this.tbTramnummer);
            this.Controls.Add(this.btnBevestig);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TramReserveren";
            this.Text = "TramReserveren";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBevestig;
        private System.Windows.Forms.TextBox tbTramnummer;
        private System.Windows.Forms.TextBox tbSpoornummer;
        private System.Windows.Forms.CheckBox chbReparatie;
    }
}