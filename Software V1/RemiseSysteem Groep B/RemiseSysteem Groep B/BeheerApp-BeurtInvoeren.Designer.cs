namespace RemiseSysteem_Groep_B
{
    partial class BeheerderApp_SchoonmaakInvoeren
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lblSoortBeurt = new System.Windows.Forms.Label();
            this.cbxSoortBeurt = new System.Windows.Forms.ComboBox();
            this.lblTypeBeurt = new System.Windows.Forms.Label();
            this.cbxTypeBeurt = new System.Windows.Forms.ComboBox();
            this.lblTram = new System.Windows.Forms.Label();
            this.lblDatum = new System.Windows.Forms.Label();
            this.lbxTrams = new System.Windows.Forms.ListBox();
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.btnInvoeren = new System.Windows.Forms.Button();
            this.btnAnnuleren = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSoortBeurt
            // 
            this.lblSoortBeurt.AutoSize = true;
            this.lblSoortBeurt.Location = new System.Drawing.Point(12, 24);
            this.lblSoortBeurt.Name = "lblSoortBeurt";
            this.lblSoortBeurt.Size = new System.Drawing.Size(62, 13);
            this.lblSoortBeurt.TabIndex = 0;
            this.lblSoortBeurt.Text = "Soort beurt:";
            // 
            // cbxSoortBeurt
            // 
            this.cbxSoortBeurt.FormattingEnabled = true;
            this.cbxSoortBeurt.Items.AddRange(new object[] {
            "Schoonmaak",
            "Reparatie"});
            this.cbxSoortBeurt.Location = new System.Drawing.Point(151, 21);
            this.cbxSoortBeurt.Name = "cbxSoortBeurt";
            this.cbxSoortBeurt.Size = new System.Drawing.Size(121, 21);
            this.cbxSoortBeurt.TabIndex = 1;
            // 
            // lblTypeBeurt
            // 
            this.lblTypeBeurt.AutoSize = true;
            this.lblTypeBeurt.Location = new System.Drawing.Point(12, 51);
            this.lblTypeBeurt.Name = "lblTypeBeurt";
            this.lblTypeBeurt.Size = new System.Drawing.Size(58, 13);
            this.lblTypeBeurt.TabIndex = 2;
            this.lblTypeBeurt.Text = "Beurt type:";
            // 
            // cbxTypeBeurt
            // 
            this.cbxTypeBeurt.FormattingEnabled = true;
            this.cbxTypeBeurt.Items.AddRange(new object[] {
            "Klein",
            "Groot"});
            this.cbxTypeBeurt.Location = new System.Drawing.Point(151, 48);
            this.cbxTypeBeurt.Name = "cbxTypeBeurt";
            this.cbxTypeBeurt.Size = new System.Drawing.Size(121, 21);
            this.cbxTypeBeurt.TabIndex = 3;
            // 
            // lblTram
            // 
            this.lblTram.AutoSize = true;
            this.lblTram.Location = new System.Drawing.Point(12, 75);
            this.lblTram.Name = "lblTram";
            this.lblTram.Size = new System.Drawing.Size(34, 13);
            this.lblTram.TabIndex = 4;
            this.lblTram.Text = "Tram:";
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Location = new System.Drawing.Point(12, 176);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(41, 13);
            this.lblDatum.TabIndex = 5;
            this.lblDatum.Text = "Datum:";
            // 
            // lbxTrams
            // 
            this.lbxTrams.FormattingEnabled = true;
            this.lbxTrams.Location = new System.Drawing.Point(102, 75);
            this.lbxTrams.Name = "lbxTrams";
            this.lbxTrams.Size = new System.Drawing.Size(170, 95);
            this.lbxTrams.TabIndex = 6;
            // 
            // dtpDatum
            // 
            this.dtpDatum.Location = new System.Drawing.Point(72, 176);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(200, 20);
            this.dtpDatum.TabIndex = 7;
            // 
            // btnInvoeren
            // 
            this.btnInvoeren.Location = new System.Drawing.Point(12, 205);
            this.btnInvoeren.Name = "btnInvoeren";
            this.btnInvoeren.Size = new System.Drawing.Size(75, 23);
            this.btnInvoeren.TabIndex = 8;
            this.btnInvoeren.Text = "Invoeren";
            this.btnInvoeren.UseVisualStyleBackColor = true;
            this.btnInvoeren.Click += new System.EventHandler(this.btnInvoeren_Click);
            // 
            // btnAnnuleren
            // 
            this.btnAnnuleren.Location = new System.Drawing.Point(197, 205);
            this.btnAnnuleren.Name = "btnAnnuleren";
            this.btnAnnuleren.Size = new System.Drawing.Size(75, 23);
            this.btnAnnuleren.TabIndex = 9;
            this.btnAnnuleren.Text = "Sluiten";
            this.btnAnnuleren.UseVisualStyleBackColor = true;
            this.btnAnnuleren.Click += new System.EventHandler(this.btnAnnuleren_Click);
            // 
            // BeheerderApp_SchoonmaakInvoeren
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 240);
            this.Controls.Add(this.btnAnnuleren);
            this.Controls.Add(this.btnInvoeren);
            this.Controls.Add(this.dtpDatum);
            this.Controls.Add(this.lbxTrams);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.lblTram);
            this.Controls.Add(this.cbxTypeBeurt);
            this.Controls.Add(this.lblTypeBeurt);
            this.Controls.Add(this.cbxSoortBeurt);
            this.Controls.Add(this.lblSoortBeurt);
            this.Name = "BeheerderApp_SchoonmaakInvoeren";
            this.Text = "Beurt invoeren";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSoortBeurt;
        private System.Windows.Forms.ComboBox cbxSoortBeurt;
        private System.Windows.Forms.Label lblTypeBeurt;
        private System.Windows.Forms.ComboBox cbxTypeBeurt;
        private System.Windows.Forms.Label lblTram;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.ListBox lbxTrams;
        private System.Windows.Forms.DateTimePicker dtpDatum;
        private System.Windows.Forms.Button btnInvoeren;
        private System.Windows.Forms.Button btnAnnuleren;
    }
}