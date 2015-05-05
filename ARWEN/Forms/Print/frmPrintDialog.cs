using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ARWEN.Forms.Print
{
    public partial class frmPrintDialog : DevExpress.XtraEditors.XtraForm
    {
        public frmPrintDialog()
        {
            InitializeComponent();
        }

        private void frmPrintDialog_Load(object sender, EventArgs e)
        {
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                comboBox1.Items.Add(printer);
            }
        }
    }
}