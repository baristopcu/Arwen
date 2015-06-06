using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ARWEN.DTO.Database;
using DevExpress.XtraEditors;

namespace ARWEN.Forms.Settings
{
    public partial class frmCustomers : DevExpress.XtraEditors.XtraForm
    {
        public frmCustomers()
        {
            InitializeComponent();
        }

        Customers c = new Customers();
        bool saveNew = true;

        public void SetFreeCustomer()
        {
            txtName.Enabled = true;
            txtCity.Enabled = true;
            txtCountry.Enabled = true;
            txtAddress.Enabled = true;
            txtContactTitle.Enabled = true;
            txtFax.Enabled = true;
            txtPostalCode.Enabled = true;
            txtTelephone.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;

        }

        public void SetLockCustomer()
        {
            txtName.Enabled = false;
            txtCity.Enabled = false;
            txtCountry.Enabled = false;
            txtAddress.Enabled = false;
            txtContactTitle.Enabled = false;
            txtFax.Enabled = false;
            txtPostalCode.Enabled = false;
            txtTelephone.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            Clear();
        }

        public void Clear()
        {
            txtName.Text = "";
            txtCity.Text = "";
            txtAddress.Text = "";
            txtCountry.Text = "";
            txtContactTitle.Text = "";
            txtFax.Text = "";
            txtPostalCode.Text = "";
            txtTelephone.Text = "";

        }


        private void GetCustomers()
        {
            using (var dbContext = new RestaurantContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                var customersQuery = dbContext.Customers.ToList();
                gridViewCustomers.DataSource = new BindingSource(customersQuery, "");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!saveNew)
            {

                using (RestaurantContext dbContext = new RestaurantContext())
                {
                    var query = dbContext.Customers.Where(x => x.CustomerID == c.CustomerID).FirstOrDefault();
                    query.ContactName = txtName.Text;
                    query.ContactTitle = txtContactTitle.Text;
                    query.Address = txtAddress.Text;
                    query.Country = txtCountry.Text;
                    query.Fax = txtFax.Text;
                    query.Phone = txtTelephone.Text;
                    query.PostalCode = txtPostalCode.Text;
                    dbContext.SaveChanges();
                    MessageBox.Show("Müşteri başarıyla güncellendi.", "ARWEN",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetCustomers();
                    SetLockCustomer();

                }


            }
            else if (saveNew)
            {
                if (string.IsNullOrEmpty(txtAddress.Text) || string.IsNullOrEmpty(txtCity.Text) || string.IsNullOrEmpty(txtContactTitle.Text) || string.IsNullOrEmpty(txtCountry.Text) || string.IsNullOrEmpty(txtFax.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtTelephone.Text) || string.IsNullOrEmpty(txtPostalCode.Text))
                {
                    MessageBox.Show("Alanlardan hiçbiri boş bırakılamaz.", "ARWEN", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
                else
                {
                    using (RestaurantContext dbContext = new RestaurantContext())
                    {
                        Customers customer = new Customers
                        {
                            ContactName = txtName.Text,
                            ContactTitle = txtContactTitle.Text,
                            Country = txtCountry.Text,
                            Address = txtAddress.Text,
                            City = txtCity.Text,
                            Fax = txtFax.Text,
                            Phone = txtTelephone.Text,
                            PostalCode = txtPostalCode.Text

                        };
                        dbContext.Customers.Add(customer);
                        dbContext.SaveChanges();
                        MessageBox.Show("Yeni müşteri başarıyla eklendi.", "ARWEN", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        GetCustomers();
                        SetLockCustomer();
                    }
                }
              
            }
        }


        private void frmCustomers_Load(object sender, EventArgs e)
        {
            GetCustomers();
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            SetFreeCustomer();
            saveNew = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Bu müşteriyi silmek istediğinize emin misiniz?", "ARWEN", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int index = gridView1.FocusedRowHandle;
                c.CustomerID = Convert.ToInt32(gridView1.GetRowCellValue(index, "CustomerID").ToString());

                using (RestaurantContext dbContext = new RestaurantContext())
                {
                    Customers query = dbContext.Customers.Where(x => x.CustomerID == c.CustomerID).FirstOrDefault();
                    dbContext.Customers.Remove(query);
                    dbContext.SaveChanges();
                    MessageBox.Show("Müşteri başarıyla silindi.", "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetCustomers();
                }
            }
        }

        private void gridViewCustomers_DoubleClick(object sender, EventArgs e)
        {
            SetFreeCustomer();
            saveNew = false;
            int index = gridView1.FocusedRowHandle;
           c.CustomerID = Convert.ToInt32(gridView1.GetRowCellValue(index, "CustomerID").ToString());

            using (RestaurantContext dbContext = new RestaurantContext())
            {
                var query = dbContext.Customers.Where(x => x.CustomerID == c.CustomerID).FirstOrDefault();
                txtName.Text = query.ContactName;
                txtAddress.Text = query.Address;
                txtCity.Text = query.City;
                txtContactTitle.Text = query.ContactTitle;
                txtCountry.Text = query.Country;
                txtTelephone.Text = query.Phone;
                txtPostalCode.Text = query.PostalCode;
                txtFax.Text = query.Fax;


            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}