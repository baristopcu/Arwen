using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ARWEN.Class;
using ARWEN.DTO.Database;
using DevExpress.XtraEditors;

namespace ARWEN.Forms
{
    public partial class frmSelectCustomer : DevExpress.XtraEditors.XtraForm
    {
        public frmSelectCustomer()
        {
            InitializeComponent();
        }

      

        private void GetCustomers()
        {
            try
            {
                using (var dbContext = new RestaurantContext())
                {
                    dbContext.Configuration.LazyLoadingEnabled = false;
                    var customersQuery = dbContext.Customers.ToList();
                    gridViewCustomers.DataSource = new BindingSource(customersQuery, "");
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }
        
        private void frmSelectCustomer_Load(object sender, EventArgs e)
        {
            GetCustomers();
        }

        private void gridViewCustomers_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int index = gridView1.FocusedRowHandle;
                GlobalCustomer.CustomerID = Convert.ToInt32(gridView1.GetRowCellValue(index, "CustomerID").ToString());
                GlobalCustomer.FullName = gridView1.GetRowCellValue(index, "ContactName").ToString();
                GlobalCustomer.Choosed = true;
                this.Close();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }
    }
}