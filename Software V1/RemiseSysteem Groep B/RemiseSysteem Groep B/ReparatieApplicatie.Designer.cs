namespace RemiseSysteem_Groep_B
{
    partial class ReparatieApplicatie
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
            this.lbxMedewerkers = new System.Windows.Forms.ListBox();
            this.lbxReparaties = new System.Windows.Forms.ListBox();
            this.lblMedewerkers = new System.Windows.Forms.Label();
            this.lblReparaties = new System.Windows.Forms.Label();
            this.btnVoegMedewerkerToe = new System.Windows.Forms.Button();
            this.btnVerwijderMedewerker = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxMedewerkers
            // 
            this.lbxMedewerkers.FormattingEnabled = true;
            this.lbxMedewerkers.Location = new System.Drawing.Point(166, 210);
            this.lbxMedewerkers.Name = "lbxMedewerkers";
            this.lbxMedewerkers.Size = new System.Drawing.Size(120, 95);
            this.lbxMedewerkers.TabIndex = 0;
            // 
            // lbxReparaties
            // 
            this.lbxReparaties.FormattingEnabled = true;
            this.lbxReparaties.Location = new System.Drawing.Point(373, 210);
            this.lbxReparaties.Name = "lbxReparaties";
            this.lbxReparaties.Size = new System.Drawing.Size(120, 95);
            this.lbxReparaties.TabIndex = 1;
            // 
            // lblMedewerkers
            // 
            this.lblMedewerkers.AutoSize = true;
            this.lblMedewerkers.Location = new System.Drawing.Point(163, 194);
            this.lblMedewerkers.Name = "lblMedewerkers";
            this.lblMedewerkers.Size = new System.Drawing.Size(74, 13);
            this.lblMedewerkers.TabIndex = 2;
            this.lblMedewerkers.Text = "Medewerkers:";
            // 
            // lblReparaties
            // 
            this.lblReparaties.AutoSize = true;
            this.lblReparaties.Location = new System.Drawing.Point(370, 194);
            this.lblReparaties.Name = "lblReparaties";
            this.lblReparaties.Size = new System.Drawing.Size(58, 13);
            this.lblReparaties.TabIndex = 3;
            this.lblReparaties.Text = "Reparaties";
            // 
            // btnVoegMedewerkerToe
            // 
            this.btnVoegMedewerkerToe.Location = new System.Drawing.Point(292, 210);
            this.btnVoegMedewerkerToe.Name = "btnVoegMedewerkerToe";
            this.btnVoegMedewerkerToe.Size = new System.Drawing.Size(75, 23);
            this.btnVoegMedewerkerToe.TabIndex = 4;
            this.btnVoegMedewerkerToe.Text = "Voeg Toe";
            this.btnVoegMedewerkerToe.UseVisualStyleBackColor = true;
            // 
            // btnVerwijderMedewerker
            // 
            this.btnVerwijderMedewerker.Location = new System.Drawing.Point(292, 239);
            this.btnVerwijderMedewerker.Name = "btnVerwijderMedewerker";
            this.btnVerwijderMedewerker.Size = new System.Drawing.Size(75, 23);
            this.btnVerwijderMedewerker.TabIndex = 5;
            this.btnVerwijderMedewerker.Text = "Verwijder";
            this.btnVerwijderMedewerker.UseVisualStyleBackColor = true;
            // 
            // ReparatieApplicatie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1475, 633);
            this.Controls.Add(this.btnVerwijderMedewerker);
            this.Controls.Add(this.btnVoegMedewerkerToe);
            this.Controls.Add(this.lblReparaties);
            this.Controls.Add(this.lblMedewerkers);
            this.Controls.Add(this.lbxReparaties);
            this.Controls.Add(this.lbxMedewerkers);
            this.Name = "ReparatieApplicatie";
            this.Text = "Reparatie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxMedewerkers;
        private System.Windows.Forms.ListBox lbxReparaties;
        private System.Windows.Forms.Label lblMedewerkers;
        private System.Windows.Forms.Label lblReparaties;
        private System.Windows.Forms.Button btnVoegMedewerkerToe;
        private System.Windows.Forms.Button btnVerwijderMedewerker;
    }
}