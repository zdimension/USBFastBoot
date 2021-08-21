namespace USBFastBoot
{
    partial class MainWindow
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbxUSB = new System.Windows.Forms.CheckBox();
            this.cbxISO = new System.Windows.Forms.CheckBox();
            this.btnInstall = new System.Windows.Forms.Button();
            this.cbxIMG = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // cbxUSB
            // 
            this.cbxUSB.AutoSize = true;
            this.cbxUSB.Location = new System.Drawing.Point(20, 30);
            this.cbxUSB.Name = "cbxUSB";
            this.cbxUSB.Size = new System.Drawing.Size(163, 19);
            this.cbxUSB.TabIndex = 0;
            this.cbxUSB.Text = "Drives (HDD, CD and USB)";
            this.cbxUSB.UseVisualStyleBackColor = true;
            this.cbxUSB.CheckedChanged += new System.EventHandler(this.cbxUSB_CheckedChanged);
            // 
            // cbxISO
            // 
            this.cbxISO.AutoSize = true;
            this.cbxISO.Location = new System.Drawing.Point(20, 55);
            this.cbxISO.Name = "cbxISO";
            this.cbxISO.Size = new System.Drawing.Size(68, 19);
            this.cbxISO.TabIndex = 1;
            this.cbxISO.Text = "ISO files";
            this.cbxISO.UseVisualStyleBackColor = true;
            this.cbxISO.CheckedChanged += new System.EventHandler(this.cbxUSB_CheckedChanged);
            // 
            // btnInstall
            // 
            this.btnInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInstall.Enabled = false;
            this.btnInstall.Location = new System.Drawing.Point(12, 106);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(176, 27);
            this.btnInstall.TabIndex = 2;
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // cbxIMG
            // 
            this.cbxIMG.AutoSize = true;
            this.cbxIMG.Location = new System.Drawing.Point(20, 80);
            this.cbxIMG.Name = "cbxIMG";
            this.cbxIMG.Size = new System.Drawing.Size(72, 19);
            this.cbxIMG.TabIndex = 3;
            this.cbxIMG.Text = "IMG files";
            this.cbxIMG.UseVisualStyleBackColor = true;
            this.cbxIMG.CheckedChanged += new System.EventHandler(this.cbxUSB_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Add \"Boot on QEMU\" to :";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(12, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 27);
            this.button1.TabIndex = 5;
            this.button1.Text = "Uninstall";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(13, 126);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(174, 23);
            this.progressBar.TabIndex = 7;
            this.progressBar.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 180);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxIMG);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.cbxISO);
            this.Controls.Add(this.cbxUSB);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.Text = "USBFastBoot";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbxUSB;
        private System.Windows.Forms.CheckBox cbxISO;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.CheckBox cbxIMG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

