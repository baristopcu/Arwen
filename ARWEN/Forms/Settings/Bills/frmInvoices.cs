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
using ARWEN.DTO.Database;

namespace ARWEN.Forms.Settings.Bills
{
    public partial class frmInvoices : DevExpress.XtraEditors.XtraForm
    {
        public frmInvoices()
        {
            InitializeComponent();

            dtProductLines.Columns.Add("ProductName", typeof(string));
            dtProductLines.Columns.Add("Amount", typeof(int));
            dtProductLines.Columns.Add("UnitName", typeof(string));
            dtProductLines.Columns.Add("Price", typeof(decimal));
            dtProductLines.Columns.Add("Discount", typeof(int));
            dtProductLines.Columns.Add("TotalDiscount", typeof(decimal));
            dtProductLines.Columns.Add("ProductPrice", typeof(decimal));
            dtProductLines.Columns.Add("Tax", typeof(int));
            dtProductLines.Columns.Add("TotalTax", typeof(decimal));
            dtProductLines.Columns.Add("ProductID", typeof(Int64));

           
        }

        #region Fields
        DataTable dtProductLines = new DataTable();
        decimal totalTax, productLinePrice, totalDiscount;
        int lastFiche = 0;
        private List<int> productIds = new List<int>();
        private List<decimal> productPrices = new List<decimal>();
        private List<int> productAmounts = new List<int>();
        #endregion

        private void GetSuppliers()
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

        private void GetFicheTypes()
        {
            using (var dbContext = new RestaurantContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                var query = dbContext.FicheTypes.ToList();
                cmbFicheType.DataSource = query;
                cmbFicheType.ValueMember = "FicheTypeID";
                cmbFicheType.DisplayMember = "Name";

            }
        }

        private void GetProducts()
        {
            using (var dbContext = new RestaurantContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                var query = dbContext.Products.ToArray();
                cmbProducts.DataSource = query;
                cmbProducts.ValueMember = "ProductID";
                cmbProducts.DisplayMember = "ProductName";

            }
        }

        private void CalculateTax()
        {
            if (GroupTax.SelectedIndex < 0)
            {
                if (!string.IsNullOrEmpty(txtTax.Text))
                {
                    totalTax = productLinePrice * Convert.ToInt32(txtTax.Text) / 100;
                }
                else
                {
                    totalTax = productLinePrice * Convert.ToInt32(18) / 100;
                    txtTax.Text = "18";
                }
                
            }  
            else
            {
                int selectedTax = (int)GroupTax.EditValue;
                if (selectedTax > 0)
                {
                    totalTax = productLinePrice * Convert.ToInt32(selectedTax) / 100;
                    txtTax.Text = selectedTax.ToString();
                }
            }
        }

        private void CalculateDiscount()
        {
            if (!string.IsNullOrEmpty(txtDiscount.Text))
            {
                totalDiscount = productLinePrice * Convert.ToInt32(txtDiscount.Text) / 100;
            }
            else
            {
                txtDiscount.Text = "0";
                totalDiscount = 0;
            }
        }
       
        private void GeneralCalculate()
        {
            if (dtProductLines.Rows.Count > 0)
            {
                decimal productPrice = Convert.ToDecimal(dtProductLines.Compute("Sum(ProductPrice)", ""));
                lblProductTotal.Text = productPrice.ToString();
                decimal totalTax = Convert.ToDecimal(dtProductLines.Compute("Sum(TotalTax)", ""));
                lblTotalTax.Text = totalTax.ToString();
                decimal totalDiscount = Convert.ToDecimal(dtProductLines.Compute("Sum(TotalDiscount)", ""));
                lblTotalDiscount.Text = totalDiscount.ToString();
                lblTotalPrice.Text = ((productPrice + totalTax) - totalDiscount).ToString();
            }
        }

        private void ClearGeneral(decimal productTotal, decimal totalTax,decimal totalDiscount, decimal totalPrice)
        {
            if (dtProductLines.Rows.Count > 0)
            {
                lblProductTotal.Text = (Convert.ToDecimal(lblProductTotal.Text) - productTotal).ToString();
                lblTotalTax.Text = (Convert.ToDecimal(lblTotalTax.Text) - totalTax).ToString();
                lblTotalDiscount.Text = (Convert.ToDecimal(lblTotalDiscount.Text) - totalDiscount).ToString();
                lblTotalPrice.Text = (Convert.ToDecimal(lblTotalPrice.Text) - totalPrice).ToString(); 
            }
            else
            {
                lblProductTotal.Text = "[" + label8.Text + "]";
                lblTotalTax.Text = "[" + label11.Text + "]";
                lblTotalDiscount.Text = "[" + label9.Text + "]";
                lblTotalPrice.Text = "[" + label12.Text + "]"; 
            }
           
        }

        private int GetLastFicheNo()
        {
            using(RestaurantContext dbContext = new RestaurantContext())
            {
                var lastFicheNo = dbContext.Purchases.Max(p => p.PurchaseID);
                return Convert.ToInt32(lastFicheNo) + 1;
            }
        }

        private void GetProductsInformation(decimal selectedID)
        {
            using(var dbContext = new RestaurantContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;  
                var query = dbContext.Products.Where(x => x.ProductID == selectedID).FirstOrDefault();
                txtPrice.Text = query.Price.ToString();
                txtStock.Text = query.UnitsInStock.ToString();
            }
        }

        private void GetSuppliersInformation(decimal selectedID)
        {
            using (var dbContext = new RestaurantContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                var lastDate = dbContext.Purchases.Where(x => x.SupplierID == selectedID).Max(y => y.PurchaseDate).ToShortDateString();
                var total = dbContext.Purchases.Where(x => x.SupplierID == selectedID).Sum(y => y.TotalCash);
                var howManyTimes = dbContext.Purchases.Where(x => x.SupplierID == selectedID).Count();
                txtSupplierDate.Text = lastDate.ToString();
                txtSupplierMoney.Text = total.ToString();
                txtSupplierTotal.Text = howManyTimes.ToString();
            }
        }

        private void UserWarning(decimal price)
        {
            if (price > Convert.ToDecimal(txtPrice.Text))
            {
                lblWarning.Visible = true;
                lblWarning.BackColor = Color.Red;
                lblWarning.ForeColor = Color.White;
                lblWarning.Text = "Normalden Düşük Fiyat!";
            }
         
        }

        private void frmBuyBills_Load(object sender, EventArgs e)
        {
            GetSuppliers();
            GetProducts();
            GetFicheTypes();
            txtNo.Text = GetLastFicheNo().ToString();
            gridView1.BestFitColumns();
            dtpBill.DateTime = DateTime.Today;        
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            Purchases purchase = new Purchases();
            PurchaseDetail pDetail = new PurchaseDetail();
            using (RestaurantContext dbContext = new RestaurantContext())
            {
                purchase.Description = txtDescription.Text;
                purchase.Discount = Convert.ToInt32(txtDiscount.Text);
                purchase.TotalDiscount = Convert.ToDecimal(lblTotalDiscount.Text);
                purchase.Tax = Convert.ToInt32(txtTax.Text);
                purchase.TotalTax = Convert.ToDecimal(totalTax);
                purchase.TotalCash = Convert.ToDecimal(lblTotalPrice.Text);
                purchase.PurchaseDate = Convert.ToDateTime(dtpBill.EditValue);
                purchase.SupplierID = Convert.ToInt32(cmbSupplier.SelectedValue);
                purchase.FicheTypeID = Convert.ToInt32(cmbFicheType.SelectedValue);

                dbContext.Purchases.Add(purchase);
                dbContext.SaveChanges();

                lastFiche = Convert.ToInt32(purchase.PurchaseID);

                foreach (DataRow x in dtProductLines.Rows)
                {
                    productIds.Add(Convert.ToInt32(x["ProductId"]));
                    productAmounts.Add(Convert.ToInt32(x["Amount"]));
                    productPrices.Add(Convert.ToDecimal(x["Price"]));

                }

                for (int i = 0; i < dtProductLines.Rows.Count; i++)
                {
                    pDetail.PurchaseID = lastFiche;
                    pDetail.ProductID = productIds[i];
                    pDetail.Amount = productAmounts[i];
                    pDetail.Price = productPrices[i];

                    dbContext.PurchaseDetail.Add(pDetail);
                    dbContext.SaveChanges();

                }

                dbContext.SaveChanges();

                MessageBox.Show("Faturanız başarıyla kayıt edilmiştir.", "ARWEN", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
           
            int productID = Convert.ToInt32(cmbProducts.SelectedValue);
            using (RestaurantContext dbContext = new RestaurantContext())
            {
                var addProduct = dbContext.Get_All_Products()
                    .Where(x => x.ProductID == productID)
                    .FirstOrDefault();

                if (!string.IsNullOrEmpty(txtPrice.Text) && !string.IsNullOrEmpty(txtAmount.Text))
                {
                    productLinePrice = addProduct.Price * Convert.ToDecimal(txtAmount.Text);
                    CalculateDiscount();
                    CalculateTax();
                    UserWarning(addProduct.Price);

                    dtProductLines.Rows.Add(addProduct.ProductName, Convert.ToInt32(txtAmount.Text), addProduct.GroupName, Convert.ToDecimal(txtPrice.Text), Convert.ToInt32(txtDiscount.Text), totalDiscount, productLinePrice, Convert.ToInt32(txtTax.Text), totalTax,Convert.ToInt64(cmbProducts.SelectedValue));

                    GeneralCalculate();
                    gridControl1.DataSource = dtProductLines;     
                }

                GroupTax.SelectedIndex = -1;

            }
        }
      
        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            decimal myselected = (decimal)((cmbProducts.SelectedItem as dynamic).ProductID);

            if (!string.IsNullOrEmpty(txtAmount.Text))
            {
                if (!string.IsNullOrEmpty(txtStock.Text))
                {        
                    using (var dbContext = new RestaurantContext())
                    {
                        dbContext.Configuration.LazyLoadingEnabled = false;
                        var query = dbContext.Products.Where(x => x.ProductID == myselected).FirstOrDefault();
                        if (query.UnitsInStock == null || query.UnitsInStock == 0)
                        {
                            txtStock.Text = txtAmount.Text;
                        }
                        else
                        {
                            txtStock.Text = (Convert.ToInt64(txtAmount.Text) + Convert.ToInt64(query.UnitsInStock)).ToString();
                        }
                    }

                    
                }
                else
                {
                    txtStock.Text = txtAmount.Text;
                }
               
            }
            else
            {
                
                using (var dbContext = new RestaurantContext())
                {
                    dbContext.Configuration.LazyLoadingEnabled = false;
                    var query = dbContext.Products.Where(x => x.ProductID == myselected).FirstOrDefault();                    
                    txtStock.Text = query.UnitsInStock.ToString();
                }
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBuyBills_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Faturada yaptığınız değişiklikler kaydedilmedi çıkmak istediğinize emin misiniz?", "ARWEN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void cmbSupplier_SelectedValueChanged(object sender, EventArgs e)
        {
            decimal myselected = (decimal)((cmbSupplier.SelectedItem as dynamic).SupplierID);
            GetSuppliersInformation(myselected);
        }

        private void cmbProducts_SelectedValueChanged(object sender, EventArgs e)
        {
            lblWarning.Visible = false;
            decimal myselected = (decimal)((cmbProducts.SelectedItem as dynamic).ProductID);
            GetProductsInformation(myselected);
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            int productId;
            DataRowView currow = (DataRowView)gridView1.GetRow(gridView1.FocusedRowHandle);
            if (currow != null)
            {
                productId = Convert.ToInt32(currow["ProductID"]);
                currow.Row.Delete();
                decimal total = (productLinePrice + totalTax) - totalDiscount;
                ClearGeneral(productLinePrice, totalTax, totalDiscount, total);
                //if (_tableState == 1)
                //{

                //    OrderDetail query =
                //        dbContext.OrderDetail.Where(x => x.OrderNo == orderNo && x.ProductID == productId)
                //            .FirstOrDefault();
                //    dbContext.OrderDetail.Remove(query);

                //}

            }
        }
    }
}