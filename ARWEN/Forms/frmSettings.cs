using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ARWEN.Forms.Settings;
using DevExpress.XtraEditors;

namespace ARWEN.Forms
{
    public partial class frmSettings : DevExpress.XtraEditors.XtraForm
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void IsOpenForm(Form frmObject, string frmName, string frmCaption)
        {
            bool IfFound = false;
            foreach (Form var in this.MdiChildren)
            {
                if (var.Name.ToString() == frmName)
                {
                    IfFound = true;
                    var.Focus();
                    break;
                }
            }
            if (!IfFound)
            {
                frmObject.Name = frmName;
                frmObject.Text = frmCaption;
                frmObject.MdiParent = this;
                frmObject.Show();
            }
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {

        }

        private void btnUsers_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmUsers frm = new frmUsers();

            IsOpenForm(frm, "KULLANICI AYARLARI", "KULLANICI AYARLARI");
        }

        private void btnUnits_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmUnits frm = new frmUnits();

            IsOpenForm(frm, "BİRİM AYARLARI", "BİRİM AYARLARI");
        }

        private void btnGroups_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmGroups frm = new frmGroups();

            IsOpenForm(frm, "KATEGORİ AYARLARI", "KATEGORİ AYARLARI");
        }

        private void btnProducts_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmProducts frm = new frmProducts();

            IsOpenForm(frm, "ÜRÜN AYARLARI", "ÜRÜN AYARLARI");
        }

        private void btnTables_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmTables frm = new frmTables();

            IsOpenForm(frm, "MASA AYARLARI", "MASA AYARLARI");
        }

        private void btnCompanySettings_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            frmCompanySettings frm = new frmCompanySettings();

            IsOpenForm(frm, "ŞİRKET AYARLARI", "ŞİRKET AYARLARI");
        }

        private void btnChangePassword_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmChangePassword frm = new frmChangePassword();

            IsOpenForm(frm, "ŞİFRE DEĞİŞTİR", "ŞİFRE DEĞİŞTİR");
        }

        private void btnCustomers_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmCustomers frm = new frmCustomers();

            IsOpenForm(frm, "MÜŞTERİ AYARLARI", "MÜŞTERİ AYARLARI");
        }

        private void btnSuppliers_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmSuppliers frm = new frmSuppliers();

            IsOpenForm(frm, "TEDARİKÇİ AYARLARI", "TEDARİKÇİ AYARLARI");
        }
       
    }
}