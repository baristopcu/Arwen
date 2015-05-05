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
    public partial class frmSuppliers : DevExpress.XtraEditors.XtraForm
    {
        public frmSuppliers()
        {
            InitializeComponent();
        }

        Suppliers s = new Suppliers();
        bool saveNew = true;

        public void SetFreeSupplier()
        {
            txtCompany.Enabled = true;
            txtWebSite.Enabled = true;
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

        public void SetLockSupplier()
        {
            txtCompany.Enabled = false;
            txtWebSite.Enabled = false;
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
            txtCompany.Text = "";
            txtWebSite.Text = "";
            txtName.Text = "";
            txtCity.Text = "";
            txtAddress.Text = "";
            txtCountry.Text = "";
            txtContactTitle.Text = "";
            txtFax.Text = "";
            txtPostalCode.Text = "";
            txtTelephone.Text = "";

        }


        private void GetSuppliers()
        {
            using (var dbContext = new RestaurantContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                var suppliersQuery = dbContext.Suppliers.ToList();
                gridViewSuppliers.DataSource = new BindingSource(suppliersQuery, "");
            }
        }

        private void frmSuppliers_Load(object sender, EventArgs e)
        {
            GetSuppliers();
        }

        private void btnNewSupplier_Click(object sender, EventArgs e)
        {
            SetFreeSupplier();
            saveNew = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!saveNew)
            {

                using (RestaurantContext dbContext = new RestaurantContext())
                {
                    var query = dbContext.Suppliers.Where(x => x.SupplierID == s.SupplierID).FirstOrDefault();
                    query.CompanyName = txtCompany.Text;
                    query.HomePage = txtWebSite.Text;
                    query.ContactName = txtName.Text;
                    query.ContactTitle = txtContactTitle.Text;
                    query.Address = txtAddress.Text;
                    query.Country = txtCountry.Text;
                    query.Fax = txtFax.Text;
                    query.Phone = txtTelephone.Text;
                    query.PostalCode = txtPostalCode.Text;
                    dbContext.SaveChanges();
                    MessageBox.Show("Tedarikçi başarıyla güncellendi.", "ARWEN",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetSuppliers();
                    SetLockSupplier();

                }


            }
            else if (saveNew)
            {
                if (string.IsNullOrEmpty(txtCompany.Text) || string.IsNullOrEmpty(txtAddress.Text) || string.IsNullOrEmpty(txtCity.Text) || string.IsNullOrEmpty(txtContactTitle.Text) || string.IsNullOrEmpty(txtCountry.Text) || string.IsNullOrEmpty(txtFax.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtTelephone.Text) || string.IsNullOrEmpty(txtPostalCode.Text))
                {
                    MessageBox.Show("Alanlardan hiçbiri boş bırakılamaz.", "ARWEN", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
                else
                {
                    using (RestaurantContext dbContext = new RestaurantContext())
                    {
                        Suppliers supplier = new Suppliers()
                        {
                            CompanyName = txtCompany.Text,
                            HomePage = txtWebSite.Text,
                            ContactName = txtName.Text,
                            ContactTitle = txtContactTitle.Text,
                            Country = txtCountry.Text,
                            Address = txtAddress.Text,
                            City = txtCity.Text,
                            Fax = txtFax.Text,
                            Phone = txtTelephone.Text,
                            PostalCode = txtPostalCode.Text

                        };
                        dbContext.Suppliers.Add(supplier);
                        dbContext.SaveChanges();
                        MessageBox.Show("Yeni tedarikçi başarıyla eklendi.", "ARWEN", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        GetSuppliers();
                        SetLockSupplier();
                    }
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Bu tedarikçiyi silmek istediğinize emin misiniz?", "ARWEN", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int index = gridView1.FocusedRowHandle;
                s.SupplierID = Convert.ToInt32(gridView1.GetRowCellValue(index, "SupplierID").ToString());

                using (RestaurantContext dbContext = new RestaurantContext())
                {
                    Suppliers query = dbContext.Suppliers.Where(x => x.SupplierID == s.SupplierID).FirstOrDefault();
                    dbContext.Suppliers.Remove(query);
                    dbContext.SaveChanges();
                    MessageBox.Show("Tedarikçi başarıyla silindi.", "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetSuppliers();
                }
            }
        }

        private void gridViewSuppliers_DoubleClick(object sender, EventArgs e)
        {
            SetFreeSupplier();
            saveNew = false;
            int index = gridView1.FocusedRowHandle;
            s.SupplierID = Convert.ToInt32(gridView1.GetRowCellValue(index, "SupplierID").ToString());

            using (RestaurantContext dbContext = new RestaurantContext())
            {
                var query = dbContext.Suppliers.Where(x => x.SupplierID == s.SupplierID).FirstOrDefault();
                txtCompany.Text = query.CompanyName;
                txtWebSite.Text = query.HomePage;
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

       
    }
}