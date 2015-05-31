namespace ARWEN
{
    partial class frmMain
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
            this.LookAndFellDefaultValue = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.btnTickets = new DevExpress.XtraEditors.SimpleButton();
            this.btnAccounts = new DevExpress.XtraEditors.SimpleButton();
            this.btnReports = new DevExpress.XtraEditors.SimpleButton();
            this.btnSettings = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnDesks = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // LookAndFellDefaultValue
            // 
            this.LookAndFellDefaultValue.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            // 
            // btnTickets
            // 
            this.btnTickets.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTickets.Appearance.Options.UseFont = true;
            this.btnTickets.Location = new System.Drawing.Point(720, 51);
            this.btnTickets.Name = "btnTickets";
            this.btnTickets.Size = new System.Drawing.Size(456, 154);
            this.btnTickets.TabIndex = 1;
            this.btnTickets.Text = "FİŞLER";
            this.btnTickets.Click += new System.EventHandler(this.btnTickets_Click);
            // 
            // btnAccounts
            // 
            this.btnAccounts.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAccounts.Appearance.Options.UseFont = true;
            this.btnAccounts.Location = new System.Drawing.Point(167, 270);
            this.btnAccounts.Name = "btnAccounts";
            this.btnAccounts.Size = new System.Drawing.Size(456, 154);
            this.btnAccounts.TabIndex = 2;
            this.btnAccounts.Text = "GENEL HESAP";
            this.btnAccounts.Click += new System.EventHandler(this.btnAccounts_Click);
            // 
            // btnReports
            // 
            this.btnReports.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnReports.Appearance.Options.UseFont = true;
            this.btnReports.Location = new System.Drawing.Point(720, 270);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(456, 154);
            this.btnReports.TabIndex = 3;
            this.btnReports.Text = "RAPORLAR";
            this.btnReports.Click += new System.EventHandler(this.btnWareHouse_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSettings.Appearance.Options.UseFont = true;
            this.btnSettings.Location = new System.Drawing.Point(167, 486);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(456, 154);
            this.btnSettings.TabIndex = 4;
            this.btnSettings.Text = "AYARLAR";
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnExit
            // 
            this.btnExit.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(720, 486);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(456, 154);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "ÇIKIŞ";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDesks
            // 
            this.btnDesks.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDesks.Appearance.Options.UseFont = true;
            this.btnDesks.Location = new System.Drawing.Point(167, 51);
            this.btnDesks.Name = "btnDesks";
            this.btnDesks.Size = new System.Drawing.Size(456, 154);
            this.btnDesks.TabIndex = 0;
            this.btnDesks.Text = "MASALAR";
            this.btnDesks.Click += new System.EventHandler(this.btnDesks_Click);
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnDesks;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(1276, 722);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnAccounts);
            this.Controls.Add(this.btnTickets);
            this.Controls.Add(this.btnDesks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yönet | ARWEN";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnDesks;
        private DevExpress.XtraEditors.SimpleButton btnTickets;
        private DevExpress.XtraEditors.SimpleButton btnAccounts;
        private DevExpress.XtraEditors.SimpleButton btnReports;
        private DevExpress.XtraEditors.SimpleButton btnSettings;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        public DevExpress.LookAndFeel.DefaultLookAndFeel LookAndFellDefaultValue;


    }
}

