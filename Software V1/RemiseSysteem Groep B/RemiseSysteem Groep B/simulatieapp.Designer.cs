namespace RemiseSysteem_Groep_B
{
    partial class simulatieapp
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
            this.components = new System.ComponentModel.Container();
            this.lbxSimulatie = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbxSimulatie
            // 
            this.lbxSimulatie.FormattingEnabled = true;
            this.lbxSimulatie.ItemHeight = 16;
            this.lbxSimulatie.Location = new System.Drawing.Point(12, 12);
            this.lbxSimulatie.Name = "lbxSimulatie";
            this.lbxSimulatie.Size = new System.Drawing.Size(905, 484);
            this.lbxSimulatie.TabIndex = 0;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork_1);
            // 
            // simulatieapp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 505);
            this.Controls.Add(this.lbxSimulatie);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(947, 552);
            this.MinimumSize = new System.Drawing.Size(947, 552);
            this.Name = "simulatieapp";
            this.Text = "simulatieapp";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxSimulatie;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
    }
}