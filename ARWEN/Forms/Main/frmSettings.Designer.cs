namespace ARWEN.Forms
{
    partial class frmSettings
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
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnUsers = new DevExpress.XtraNavBar.NavBarItem();
            this.btnUnits = new DevExpress.XtraNavBar.NavBarItem();
            this.btnGroups = new DevExpress.XtraNavBar.NavBarItem();
            this.btnProducts = new DevExpress.XtraNavBar.NavBarItem();
            this.btnTables = new DevExpress.XtraNavBar.NavBarItem();
            this.btnCustomers = new DevExpress.XtraNavBar.NavBarItem();
            this.btnSuppliers = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup4 = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnBuyBills = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnCompanySettings = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup3 = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnChangePassword = new DevExpress.XtraNavBar.NavBarItem();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup4,
            this.navBarGroup2,
            this.navBarGroup3});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.btnUsers,
            this.btnUnits,
            this.btnCompanySettings,
            this.btnGroups,
            this.btnProducts,
            this.btnTables,
            this.btnChangePassword,
            this.btnCustomers,
            this.btnSuppliers,
            this.btnBuyBills});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 140;
            this.navBarControl1.Size = new System.Drawing.Size(140, 663);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Tanım";
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnUsers),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnUnits),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnGroups),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnProducts),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnTables),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnCustomers),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnSuppliers)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // btnUsers
            // 
            this.btnUsers.Caption = "Kullanıcılar";
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnUsers_LinkClicked);
            // 
            // btnUnits
            // 
            this.btnUnits.Caption = "Birimler";
            this.btnUnits.Name = "btnUnits";
            this.btnUnits.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnUnits_LinkClicked);
            // 
            // btnGroups
            // 
            this.btnGroups.Caption = "Katerigoriler";
            this.btnGroups.Name = "btnGroups";
            this.btnGroups.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnGroups_LinkClicked);
            // 
            // btnProducts
            // 
            this.btnProducts.Caption = "Ürünler";
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnProducts_LinkClicked);
            // 
            // btnTables
            // 
            this.btnTables.Caption = "Masalar";
            this.btnTables.Name = "btnTables";
            this.btnTables.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnTables_LinkClicked);
            // 
            // btnCustomers
            // 
            this.btnCustomers.Caption = "Müşteri";
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnCustomers_LinkClicked);
            // 
            // btnSuppliers
            // 
            this.btnSuppliers.Caption = "Tedarikçi";
            this.btnSuppliers.Name = "btnSuppliers";
            this.btnSuppliers.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnSuppliers_LinkClicked);
            // 
            // navBarGroup4
            // 
            this.navBarGroup4.Caption = "Fatura";
            this.navBarGroup4.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroup4.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnBuyBills)});
            this.navBarGroup4.Name = "navBarGroup4";
            // 
            // btnBuyBills
            // 
            this.btnBuyBills.Caption = "Ürün Alım Faturası";
            this.btnBuyBills.Name = "btnBuyBills";
            this.btnBuyBills.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnBuyBills_LinkClicked);
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "Firma";
            this.navBarGroup2.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnCompanySettings)});
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // btnCompanySettings
            // 
            this.btnCompanySettings.Caption = "Bilgiler";
            this.btnCompanySettings.Name = "btnCompanySettings";
            this.btnCompanySettings.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnCompanySettings_LinkClicked);
            // 
            // navBarGroup3
            // 
            this.navBarGroup3.Caption = "Kullanıcı";
            this.navBarGroup3.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroup3.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnChangePassword)});
            this.navBarGroup3.Name = "navBarGroup3";
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Caption = "Şifre Değiştir";
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnChangePassword_LinkClicked);
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1434, 663);
            this.Controls.Add(this.navBarControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.IsMdiContainer = true;
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSettings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarItem btnCompanySettings;
        private DevExpress.XtraNavBar.NavBarItem btnUsers;
        private DevExpress.XtraNavBar.NavBarItem btnUnits;
        private DevExpress.XtraNavBar.NavBarItem btnGroups;
        private DevExpress.XtraNavBar.NavBarItem btnProducts;
        private DevExpress.XtraNavBar.NavBarItem btnTables;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup3;
        private DevExpress.XtraNavBar.NavBarItem btnChangePassword;
        private DevExpress.XtraNavBar.NavBarItem btnCustomers;
        private DevExpress.XtraNavBar.NavBarItem btnSuppliers;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup4;
        private DevExpress.XtraNavBar.NavBarItem btnBuyBills;
    }
}