namespace RemiseSysteem_Groep_B
{
    partial class OpstartForm
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
            this.btnBeheerdersApp = new System.Windows.Forms.Button();
            this.btnBestuurdersApp = new System.Windows.Forms.Button();
            this.btnOnderhoudsApp = new System.Windows.Forms.Button();
            this.btnSchoonmaakApp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBeheerdersApp
            // 
            this.btnBeheerdersApp.Location = new System.Drawing.Point(12, 12);
            this.btnBeheerdersApp.Name = "btnBeheerdersApp";
            this.btnBeheerdersApp.Size = new System.Drawing.Size(130, 119);
            this.btnBeheerdersApp.TabIndex = 1;
            this.btnBeheerdersApp.Text = "Beheerdersapplicatie";
            this.btnBeheerdersApp.UseVisualStyleBackColor = true;
            this.btnBeheerdersApp.Click += new System.EventHandler(this.btnBeheerdersApp_Click);
            // 
            // btnBestuurdersApp
            // 
            this.btnBestuurdersApp.Location = new System.Drawing.Point(142, 12);
            this.btnBestuurdersApp.Name = "btnBestuurdersApp";
            this.btnBestuurdersApp.Size = new System.Drawing.Size(130, 119);
            this.btnBestuurdersApp.TabIndex = 2;
            this.btnBestuurdersApp.Text = "Bestuurdersapplicatie";
            this.btnBestuurdersApp.UseVisualStyleBackColor = true;
            this.btnBestuurdersApp.Click += new System.EventHandler(this.btnBestuurdersApp_Click);
            // 
            // btnOnderhoudsApp
            // 
            this.btnOnderhoudsApp.Location = new System.Drawing.Point(12, 131);
            this.btnOnderhoudsApp.Name = "btnOnderhoudsApp";
            this.btnOnderhoudsApp.Size = new System.Drawing.Size(130, 119);
            this.btnOnderhoudsApp.TabIndex = 3;
            this.btnOnderhoudsApp.Text = "Onderhoudsapplicatie";
            this.btnOnderhoudsApp.UseVisualStyleBackColor = true;
            this.btnOnderhoudsApp.Click += new System.EventHandler(this.btnOnderhoudsApp_Click);
            // 
            // btnSchoonmaakApp
            // 
            this.btnSchoonmaakApp.Location = new System.Drawing.Point(142, 131);
            this.btnSchoonmaakApp.Name = "btnSchoonmaakApp";
            this.btnSchoonmaakApp.Size = new System.Drawing.Size(130, 119);
            this.btnSchoonmaakApp.TabIndex = 4;
            this.btnSchoonmaakApp.Text = "Schoonmaakapplicatie";
            this.btnSchoonmaakApp.UseVisualStyleBackColor = true;
            this.btnSchoonmaakApp.Click += new System.EventHandler(this.btnSchoonmaakApp_Click);
            // 
            // OpstartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnSchoonmaakApp);
            this.Controls.Add(this.btnOnderhoudsApp);
            this.Controls.Add(this.btnBestuurdersApp);
            this.Controls.Add(this.btnBeheerdersApp);
            this.Name = "OpstartForm";
            this.Text = "Applicatiemenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBeheerdersApp;
        private System.Windows.Forms.Button btnBestuurdersApp;
        private System.Windows.Forms.Button btnOnderhoudsApp;
        private System.Windows.Forms.Button btnSchoonmaakApp;
    }
}