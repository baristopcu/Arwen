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

namespace ARWEN.Forms
{
    public partial class frmProducts : DevExpress.XtraEditors.XtraForm
    {
        public frmProducts()
        {
            InitializeComponent();
        }

        private Products p = new Products();
        bool saveNew = true;

        public void SetFreeProduct()
        {
            txtName.Enabled = true;
            txtStock.Enabled = true;
            txtPrice.Enabled = true;
            cmbGroups.Enabled = true;
            cmbUnits.Enabled = true;
            cmbSupplier.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            
        }

        public void SetLockProduct()
        {
            txtName.Enabled = false;
            txtPrice.Enabled = false;
            txtStock.Enabled = false;
            cmbGroups.Enabled = false;
            cmbUnits.Enabled = false;
            cmbSupplier.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            Clear();
        }

        public void Clear()
        {
            txtName.Text = "";
            txtPrice.Text = "";

        }

        private void GetGroups()
        {
            try
            {
                using (var dbContext = new RestaurantContext())
                {
                    dbContext.Configuration.LazyLoadingEnabled = false;
                    var query = dbContext.Groups.ToList();
                    cmbGroups.DataSource = query;
                    cmbGroups.ValueMember = "GroupID";
                    cmbGroups.DisplayMember = "GroupName";

                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void GetUnits()
        {
            try
            {
                using (var dbContext = new RestaurantContext())
                {
                    dbContext.Configuration.LazyLoadingEnabled = false;
                    var query = dbContext.Units.ToList();
                    cmbUnits.DataSource = query;
                    cmbUnits.ValueMember = "UnitName";
                    cmbUnits.DisplayMember = "UnitName";

                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }

        private void GetSuppliers()
        {
            try
            {
                using (var dbContext = new RestaurantContext())
                {
                    dbContext.Configuration.LazyLoadingEnabled = false;
                    var query = dbContext.Suppliers.ToList();
                    cmbSupplier.DataSource = query;
                    cmbSupplier.ValueMember = "SupplierID";
                    cmbSupplier.DisplayMember = "CompanyName";

                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void GetProducts()
        {
            try
            {
                using (var dbContext = new RestaurantContext())
                {
                    dbContext.Configuration.LazyLoadingEnabled = false;
                    var productsQuery =
                       dbContext.Products.AsNoTracking()
                           .Join(dbContext.Suppliers, p => p.SupplierID, s => s.SupplierID, (p, s) => new { p, s }).Join(dbContext.Groups, p => p.p.GroupID, g => g.GroupID, (p, g) => new { p, g })
                           .Select(y => new
                           {
                               y.p.p.ProductName,
                               y.p.p.UnitName,
                               y.p.s.CompanyName,
                               y.g.GroupName,
                               y.p.p.Price,
                               y.p.p.ProductID,
                               y.p.p.UnitsInStock

                           }).ToList();
                    gridViewProducts.DataSource = new BindingSource(productsQuery, "");
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }


        private void frmProducts_Load(object sender, EventArgs e)
        {
            GetGroups();
            GetUnits();
            GetProducts();
            GetSuppliers();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!saveNew)
                {
                    using (RestaurantContext dbContext = new RestaurantContext())
                    {
                        var query = dbContext.Products.Where(x => x.ProductID == p.ProductID).FirstOrDefault();
                        query.ProductName = txtName.Text;
                        query.Price = Convert.ToDecimal(txtPrice.Text);
                        query.UnitName = Convert.ToString(cmbUnits.SelectedValue);
                        query.GroupID = Convert.ToInt32(cmbGroups.SelectedValue);
                        query.SupplierID = Convert.ToInt32(cmbSupplier.SelectedValue);
                        query.UnitsInStock = Convert.ToInt16(txtStock.Text);
                        dbContext.SaveChanges();
                        MessageBox.Show("Ürün başarıyla güncellendi.", "ARWEN",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetUnits();
                        SetLockProduct();

                    }
                }
                else if (saveNew)
                {
                    using (RestaurantContext dbContext = new RestaurantContext())
                    {
                        Products product = new Products
                        {
                            ProductName = txtName.Text,
                            GroupID = Convert.ToInt32(cmbGroups.SelectedValue),
                            UnitName = Convert.ToString(cmbUnits.SelectedValue),
                            Price = Convert.ToDecimal(txtPrice.Text),
                            SupplierID = Convert.ToInt32(cmbSupplier.SelectedValue)

                        };
                        dbContext.Products.Add(product);
                        dbContext.SaveChanges();
                        MessageBox.Show("Yeni ürün başarıyla eklendi.", "ARWEN", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        GetProducts();
                        SetLockProduct();
                    }
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
         
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Bu ürünü silmek istediğinize emin misiniz?", "ARWEN", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    int index = gridView1.FocusedRowHandle;
                    p.ProductID = Convert.ToInt32(gridView1.GetRowCellValue(index, "ProductID").ToString());

                    using (RestaurantContext dbContext = new RestaurantContext())
                    {
                        Products query = dbContext.Products.Where(x => x.ProductID == p.ProductID).FirstOrDefault();
                        dbContext.Products.Remove(query);
                        dbContext.SaveChanges();
                        MessageBox.Show("Ürün başarıyla silindi.", "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetProducts();
                    }
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            SetFreeProduct();
            saveNew = true;
        }

        private void gridViewProducts_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                SetFreeProduct();
                saveNew = false;
                int index = gridView1.FocusedRowHandle;
                p.ProductID = Convert.ToInt32(gridView1.GetRowCellValue(index, "ProductID").ToString());

                using (RestaurantContext dbContext = new RestaurantContext())
                {
                    var query = dbContext.Products.Where(x => x.ProductID == p.ProductID).FirstOrDefault();
                    txtName.Text = query.ProductName;
                    txtPrice.Text = query.Price.ToString();
                    cmbGroups.SelectedValue = query.GroupID;
                    cmbUnits.SelectedValue = query.UnitName;
                    txtStock.Text = query.UnitsInStock.ToString();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}