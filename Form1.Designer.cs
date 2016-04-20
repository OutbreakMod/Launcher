namespace OutbreakLauncher
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.verifyFilesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.Label();
            this.txtWeapons = new System.Windows.Forms.Label();
            this.txtAIATP = new System.Windows.Forms.Label();
            this.txtVersionStatus = new System.Windows.Forms.Label();
            this.txtWeaponsStatus = new System.Windows.Forms.Label();
            this.txtTerrainStatus = new System.Windows.Forms.Label();
            this.txtVersionDisplay = new System.Windows.Forms.Label();
            this.txtCBAA3Status = new System.Windows.Forms.Label();
            this.txtCBAA3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(812, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verifyFilesToolStripMenuItem1});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(93, 20);
            this.toolStripMenuItem1.Text = "Install/Update";
            // 
            // verifyFilesToolStripMenuItem1
            // 
            this.verifyFilesToolStripMenuItem1.Name = "verifyFilesToolStripMenuItem1";
            this.verifyFilesToolStripMenuItem1.Size = new System.Drawing.Size(129, 22);
            this.verifyFilesToolStripMenuItem1.Text = "Verify Files";
            this.verifyFilesToolStripMenuItem1.Click += new System.EventHandler(this.verifyFilesToolStripMenuItem1_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mod Status";
            // 
            // txtVersion
            // 
            this.txtVersion.AutoSize = true;
            this.txtVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVersion.Location = new System.Drawing.Point(12, 60);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(42, 13);
            this.txtVersion.TabIndex = 2;
            this.txtVersion.Text = "Version";
            // 
            // txtWeapons
            // 
            this.txtWeapons.AutoSize = true;
            this.txtWeapons.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeapons.Location = new System.Drawing.Point(12, 202);
            this.txtWeapons.Name = "txtWeapons";
            this.txtWeapons.Size = new System.Drawing.Size(120, 13);
            this.txtWeapons.TabIndex = 3;
            this.txtWeapons.Text = "CUP Weapons Installed";
            this.txtWeapons.Click += new System.EventHandler(this.txtMasWeapons_Click);
            // 
            // txtAIATP
            // 
            this.txtAIATP.AutoSize = true;
            this.txtAIATP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAIATP.Location = new System.Drawing.Point(12, 155);
            this.txtAIATP.Name = "txtAIATP";
            this.txtAIATP.Size = new System.Drawing.Size(112, 13);
            this.txtAIATP.TabIndex = 4;
            this.txtAIATP.Text = "CUP Terrains Installed";
            // 
            // txtVersionStatus
            // 
            this.txtVersionStatus.AutoSize = true;
            this.txtVersionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVersionStatus.ForeColor = System.Drawing.Color.Red;
            this.txtVersionStatus.Location = new System.Drawing.Point(12, 84);
            this.txtVersionStatus.Name = "txtVersionStatus";
            this.txtVersionStatus.Size = new System.Drawing.Size(140, 13);
            this.txtVersionStatus.TabIndex = 5;
            this.txtVersionStatus.Text = "Not Installed (Click to Install)";
            this.txtVersionStatus.Click += new System.EventHandler(this.txtVersionStatus_Click);
            // 
            // txtWeaponsStatus
            // 
            this.txtWeaponsStatus.AutoSize = true;
            this.txtWeaponsStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeaponsStatus.ForeColor = System.Drawing.Color.Red;
            this.txtWeaponsStatus.Location = new System.Drawing.Point(12, 225);
            this.txtWeaponsStatus.Name = "txtWeaponsStatus";
            this.txtWeaponsStatus.Size = new System.Drawing.Size(66, 13);
            this.txtWeaponsStatus.TabIndex = 6;
            this.txtWeaponsStatus.Text = "Not Installed";
            // 
            // txtTerrainStatus
            // 
            this.txtTerrainStatus.AutoSize = true;
            this.txtTerrainStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTerrainStatus.ForeColor = System.Drawing.Color.Red;
            this.txtTerrainStatus.Location = new System.Drawing.Point(12, 177);
            this.txtTerrainStatus.Name = "txtTerrainStatus";
            this.txtTerrainStatus.Size = new System.Drawing.Size(66, 13);
            this.txtTerrainStatus.TabIndex = 7;
            this.txtTerrainStatus.Text = "Not Installed";
            // 
            // txtVersionDisplay
            // 
            this.txtVersionDisplay.AutoSize = true;
            this.txtVersionDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVersionDisplay.Location = new System.Drawing.Point(60, 60);
            this.txtVersionDisplay.Name = "txtVersionDisplay";
            this.txtVersionDisplay.Size = new System.Drawing.Size(0, 13);
            this.txtVersionDisplay.TabIndex = 8;
            // 
            // txtCBAA3Status
            // 
            this.txtCBAA3Status.AutoSize = true;
            this.txtCBAA3Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCBAA3Status.ForeColor = System.Drawing.Color.Red;
            this.txtCBAA3Status.Location = new System.Drawing.Point(12, 132);
            this.txtCBAA3Status.Name = "txtCBAA3Status";
            this.txtCBAA3Status.Size = new System.Drawing.Size(66, 13);
            this.txtCBAA3Status.TabIndex = 10;
            this.txtCBAA3Status.Text = "Not Installed";
            // 
            // txtCBAA3
            // 
            this.txtCBAA3.AutoSize = true;
            this.txtCBAA3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCBAA3.Location = new System.Drawing.Point(12, 110);
            this.txtCBAA3.Name = "txtCBAA3";
            this.txtCBAA3.Size = new System.Drawing.Size(86, 13);
            this.txtCBAA3.TabIndex = 9;
            this.txtCBAA3.Text = "CBA A3 Installed";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 405);
            this.Controls.Add(this.txtCBAA3Status);
            this.Controls.Add(this.txtCBAA3);
            this.Controls.Add(this.txtVersionDisplay);
            this.Controls.Add(this.txtTerrainStatus);
            this.Controls.Add(this.txtWeaponsStatus);
            this.Controls.Add(this.txtVersionStatus);
            this.Controls.Add(this.txtAIATP);
            this.Controls.Add(this.txtWeapons);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verifyFilesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtVersion;
        private System.Windows.Forms.Label txtWeapons;
        private System.Windows.Forms.Label txtAIATP;
        public System.Windows.Forms.Label txtVersionStatus;
        private System.Windows.Forms.Label txtWeaponsStatus;
        private System.Windows.Forms.Label txtTerrainStatus;
        private System.Windows.Forms.Label txtVersionDisplay;
        private System.Windows.Forms.Label txtCBAA3Status;
        private System.Windows.Forms.Label txtCBAA3;
    }
}

