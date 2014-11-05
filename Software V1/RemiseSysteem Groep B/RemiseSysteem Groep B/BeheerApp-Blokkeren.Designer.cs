namespace RemiseSysteem_Groep_B
{
    partial class BeheerApp_Blokkeren
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
            this.lblSpoor = new System.Windows.Forms.Label();
            this.lblSector = new System.Windows.Forms.Label();
            this.lbxSectoren = new System.Windows.Forms.ListBox();
            this.lbxSporen = new System.Windows.Forms.ListBox();
            this.btnBlokkeer = new System.Windows.Forms.Button();
            this.btnDeblokkeer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSpoor
            // 
            this.lblSpoor.AutoSize = true;
            this.lblSpoor.Location = new System.Drawing.Point(12, 12);
            this.lblSpoor.Name = "lblSpoor";
            this.lblSpoor.Size = new System.Drawing.Size(35, 13);
            this.lblSpoor.TabIndex = 0;
            this.lblSpoor.Text = "Spoor";
            // 
            // lblSector
            // 
            this.lblSector.AutoSize = true;
            this.lblSector.Location = new System.Drawing.Point(12, 142);
            this.lblSector.Name = "lblSector";
            this.lblSector.Size = new System.Drawing.Size(38, 13);
            this.lblSector.TabIndex = 1;
            this.lblSector.Text = "Sector";
            // 
            // lbxSectoren
            // 
            this.lbxSectoren.FormattingEnabled = true;
            this.lbxSectoren.Location = new System.Drawing.Point(151, 142);
            this.lbxSectoren.Name = "lbxSectoren";
            this.lbxSectoren.Size = new System.Drawing.Size(121, 108);
            this.lbxSectoren.TabIndex = 3;
            // 
            // lbxSporen
            // 
            this.lbxSporen.FormattingEnabled = true;
            this.lbxSporen.Location = new System.Drawing.Point(151, 12);
            this.lbxSporen.Name = "lbxSporen";
            this.lbxSporen.Size = new System.Drawing.Size(121, 121);
            this.lbxSporen.TabIndex = 4;
            this.lbxSporen.SelectedIndexChanged += new System.EventHandler(this.lbxSporen_SelectedIndexChanged);
            // 
            // btnBlokkeer
            // 
            this.btnBlokkeer.Enabled = false;
            this.btnBlokkeer.Location = new System.Drawing.Point(12, 198);
            this.btnBlokkeer.Name = "btnBlokkeer";
            this.btnBlokkeer.Size = new System.Drawing.Size(75, 23);
            this.btnBlokkeer.TabIndex = 5;
            this.btnBlokkeer.Text = "Blokkeer";
            this.btnBlokkeer.UseVisualStyleBackColor = true;
            // 
            // btnDeblokkeer
            // 
            this.btnDeblokkeer.Enabled = false;
            this.btnDeblokkeer.Location = new System.Drawing.Point(12, 227);
            this.btnDeblokkeer.Name = "btnDeblokkeer";
            this.btnDeblokkeer.Size = new System.Drawing.Size(75, 23);
            this.btnDeblokkeer.TabIndex = 6;
            this.btnDeblokkeer.Text = "Deblokkeer";
            this.btnDeblokkeer.UseVisualStyleBackColor = true;
            // 
            // BeheerApp_Blokkeren
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnDeblokkeer);
            this.Controls.Add(this.btnBlokkeer);
            this.Controls.Add(this.lbxSporen);
            this.Controls.Add(this.lbxSectoren);
            this.Controls.Add(this.lblSector);
            this.Controls.Add(this.lblSpoor);
            this.Name = "BeheerApp_Blokkeren";
            this.Text = "Sporen en sectoren";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSpoor;
        private System.Windows.Forms.Label lblSector;
        private System.Windows.Forms.ListBox lbxSectoren;
        private System.Windows.Forms.ListBox lbxSporen;
        private System.Windows.Forms.Button btnBlokkeer;
        private System.Windows.Forms.Button btnDeblokkeer;
    }
}