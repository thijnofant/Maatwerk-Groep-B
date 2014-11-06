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
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.rbGroot = new System.Windows.Forms.RadioButton();
            this.rbKlein = new System.Windows.Forms.RadioButton();
            this.gbReparatie = new System.Windows.Forms.GroupBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.gbReparatie.SuspendLayout();
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
            this.label3.Location = new System.Drawing.Point(27, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Reparatie";
            // 
            // btnBevestig
            // 
            this.btnBevestig.Location = new System.Drawing.Point(166, 118);
            this.btnBevestig.Name = "btnBevestig";
            this.btnBevestig.Size = new System.Drawing.Size(88, 30);
            this.btnBevestig.TabIndex = 3;
            this.btnBevestig.Text = "Bevestig";
            this.btnBevestig.UseVisualStyleBackColor = true;
            this.btnBevestig.Click += new System.EventHandler(this.btnBevestig_Click_1);
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
            this.chbReparatie.Location = new System.Drawing.Point(30, 134);
            this.chbReparatie.Name = "chbReparatie";
            this.chbReparatie.Size = new System.Drawing.Size(15, 14);
            this.chbReparatie.TabIndex = 6;
            this.chbReparatie.UseVisualStyleBackColor = true;
            this.chbReparatie.CheckedChanged += new System.EventHandler(this.chbReparatie_CheckedChanged);
            // 
            // dtpDatum
            // 
            this.dtpDatum.Location = new System.Drawing.Point(6, 30);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(200, 20);
            this.dtpDatum.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Soort reparatie";
            // 
            // rbGroot
            // 
            this.rbGroot.AutoSize = true;
            this.rbGroot.Location = new System.Drawing.Point(63, 98);
            this.rbGroot.Name = "rbGroot";
            this.rbGroot.Size = new System.Drawing.Size(51, 17);
            this.rbGroot.TabIndex = 9;
            this.rbGroot.TabStop = true;
            this.rbGroot.Text = "Groot";
            this.rbGroot.UseVisualStyleBackColor = true;
            // 
            // rbKlein
            // 
            this.rbKlein.AutoSize = true;
            this.rbKlein.Location = new System.Drawing.Point(9, 98);
            this.rbKlein.Name = "rbKlein";
            this.rbKlein.Size = new System.Drawing.Size(48, 17);
            this.rbKlein.TabIndex = 10;
            this.rbKlein.TabStop = true;
            this.rbKlein.Text = "Klein";
            this.rbKlein.UseVisualStyleBackColor = true;
            // 
            // gbReparatie
            // 
            this.gbReparatie.Controls.Add(this.dtpDatum);
            this.gbReparatie.Controls.Add(this.rbKlein);
            this.gbReparatie.Controls.Add(this.label4);
            this.gbReparatie.Controls.Add(this.rbGroot);
            this.gbReparatie.Location = new System.Drawing.Point(24, 154);
            this.gbReparatie.Name = "gbReparatie";
            this.gbReparatie.Size = new System.Drawing.Size(237, 136);
            this.gbReparatie.TabIndex = 11;
            this.gbReparatie.TabStop = false;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(30, 308);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(16, 13);
            this.lblMessage.TabIndex = 12;
            this.lblMessage.Text = "...";
            // 
            // TramReserveren
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 347);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.gbReparatie);
            this.Controls.Add(this.chbReparatie);
            this.Controls.Add(this.tbSpoornummer);
            this.Controls.Add(this.tbTramnummer);
            this.Controls.Add(this.btnBevestig);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TramReserveren";
            this.Text = "TramReserveren";
            this.gbReparatie.ResumeLayout(false);
            this.gbReparatie.PerformLayout();
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
        private System.Windows.Forms.DateTimePicker dtpDatum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbGroot;
        private System.Windows.Forms.RadioButton rbKlein;
        private System.Windows.Forms.GroupBox gbReparatie;
        private System.Windows.Forms.Label lblMessage;
    }
}