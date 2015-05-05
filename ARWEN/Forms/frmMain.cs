using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ARWEN.Forms;
using DevExpress.Utils.Drawing.Helpers;

namespace ARWEN
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
          
        }

        private void btnDesks_Click(object sender, EventArgs e)
        {
            frmDesks frm = new frmDesks();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettings frm = new frmSettings();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTickets_Click(object sender, EventArgs e)
        {
            frmTickets frm = new frmTickets();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            frmAccounts frm = new frmAccounts();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btnWareHouse_Click(object sender, EventArgs e)
        {
            
        }

       
       
    }
}
