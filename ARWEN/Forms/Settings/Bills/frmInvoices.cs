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
        private List<OrderDetail> iDetails = new List<OrderDetail>();
        private List<decimal> productPrices = new List<decimal>();
        private List<int> productAmounts = new List<int>();
        long ficheID = 0;
        string invoiceType = "New";
        private bool newIn = false;
        private bool eventSucces = false;

        public long FicheID
        {
            get { return ficheID; }
            set { ficheID = value; }
        }

        #endregion

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

        private void GetFicheTypes()
        {
            try
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
                    var query = dbContext.Products.ToArray();
                    cmbProducts.DataSource = query;
                    cmbProducts.ValueMember = "ProductID";
                    cmbProducts.DisplayMember = "ProductName";

                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void CalculateTax()
        {
            try
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
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void CalculateDiscount()
        {
            try
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
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }

        private void GeneralCalculate()
        {
            try
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
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void ClearGeneral(decimal productTotal, decimal totalTax, decimal totalDiscount, decimal totalPrice)
        {
            try
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
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          

        }

        private int GetLastFicheNo()
        {
            try
            {
                using (RestaurantContext dbContext = new RestaurantContext())
                {
                    var lastFicheNo = dbContext.Purchases.Max(p => p.PurchaseID);
                    return Convert.ToInt32(lastFicheNo) + 1;
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return 0;
        
        }

        private void GetProductsInformation(decimal selectedID)
        {
            try
            {
                using (var dbContext = new RestaurantContext())
                {
                    dbContext.Configuration.LazyLoadingEnabled = false;
                    var query = dbContext.Products.Where(x => x.ProductID == selectedID).FirstOrDefault();
                    txtPrice.Text = query.Price.ToString();
                    txtStock.Text = query.UnitsInStock.ToString();
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }

        private void GetSuppliersInformation(decimal selectedID)
        {
            try
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
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void UserWarning(decimal price)
        {
            try
            {
                if (price > Convert.ToDecimal(txtPrice.Text))
                {
                    lblWarning.Visible = true;
                    lblWarning.BackColor = Color.Red;
                    lblWarning.ForeColor = Color.White;
                    lblWarning.Text = "Normalden Düşük Fiyat!";
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        

        }

        private void InvoiceStateControl(long ficheıdnull)
        {
            try
            {
                if (ficheıdnull == 0)
                {
                    txtNo.Text = GetLastFicheNo().ToString();
                    dtpBill.DateTime = DateTime.Today;
                }
                else
                {
                    invoiceType = "Edit";
                    List<object> invoiceDetailList = new List<object>();

                    using (RestaurantContext dbContext = new RestaurantContext())
                    {
                        var GetInvoiceHeader = dbContext.Purchases.Where(p => p.PurchaseID == FicheID).FirstOrDefault();
                        txtNo.Text = GetInvoiceHeader.PurchaseID.ToString();
                        cmbFicheType.SelectedItem = GetInvoiceHeader.FicheTypes;
                        dtpBill.DateTime = GetInvoiceHeader.PurchaseDate;
                        txtDescription.Text = GetInvoiceHeader.Description;
                        cmbSupplier.SelectedValue = GetInvoiceHeader.SupplierID;
                        cmbFicheType.SelectedValue = GetInvoiceHeader.FicheTypeID;
                       
                            var query =
                                dbContext.Purchases.AsNoTracking()
                                    .Join(dbContext.PurchaseDetail, p => p.PurchaseID, pd => pd.PurchaseID, (p, pd) => new { p, pd }).Join(dbContext.Products, pp => pp.pd.ProductID, pq => pq.ProductID, (pp, pq) => new { pp, pq }).Join(dbContext.Groups, p => p.pq.GroupID, g => g.GroupID, (p, g) => new { p, g })
                                    .Where(b => b.p.pp.pd.PurchaseID == FicheID)
                                    .Select(s => new
                                    {
                                        s.p.pq.ProductName,
                                        s.p.pp.pd.PurchaseDetailID,
                                        UrunFiyat = s.p.pq.Price,
                                        s.p.pp.pd.Amount,
                                        s.p.pq.UnitName,
                                        s.p.pp.pd.Price,
                                        s.p.pp.p.Discount,
                                        s.p.pp.p.TotalDiscount,
                                        s.p.pp.p.Tax,
                                        s.p.pp.p.TotalTax,
                                        s.p.pq.ProductID,
                                        s.g.GroupName


                                    }).AsQueryable();
                            invoiceDetailList.AddRange(query.ToList());

                            foreach (var result in query)
                            {
                                dtProductLines.Rows.Add(result.ProductName, result.Amount, result.GroupName, result.UrunFiyat, result.Discount, result.TotalDiscount, result.Price, result.Tax, result.TotalTax, result.ProductID);
                                gridControl1.DataSource = dtProductLines;
                            }

                            GeneralCalculate();
                            
                        }
                    }
                }            
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void frmBuyBills_Load(object sender, EventArgs e)
        {
            GetSuppliers();
            GetProducts();
            GetFicheTypes();
            InvoiceStateControl(FicheID);

        }

        private int nPurchDetailID;
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (invoiceType == "New")
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
                        eventSucces = true;
                        this.Close();
                    }
                }
                else if (invoiceType == "Edit")
                {

                    var query = dbContext.Purchases.FirstOrDefault(x => x.PurchaseID == FicheID);
                    if (query != null)
                    {

                        if (newIn)
                        {
                            query.Description = txtDescription.Text;
                            query.Discount = Convert.ToInt32(txtDiscount.Text);
                            query.TotalDiscount = Convert.ToDecimal(lblTotalDiscount.Text);
                            query.Tax = Convert.ToInt32(txtTax.Text);
                            query.TotalTax = Convert.ToDecimal(totalTax);
                            query.TotalCash = Convert.ToDecimal(lblTotalPrice.Text);
                            query.PurchaseDate = Convert.ToDateTime(dtpBill.EditValue);
                            query.SupplierID = Convert.ToInt32(cmbSupplier.SelectedValue);
                            query.FicheTypeID = Convert.ToInt32(cmbFicheType.SelectedValue);
                            dbContext.SaveChanges();
                            foreach (var pdResult in pDetails)
                            {
                                PurchaseDetail purD = new PurchaseDetail();
                                purD.ProductID = pdResult.ProductID;
                                purD.Amount = pdResult.Amount;
                                purD.Price = pdResult.Price;
                                purD.PurchaseID = pdResult.PurchaseID;
                                nPurchDetailID = pdResult.PurchaseDetailID;
                                dbContext.PurchaseDetail.Add(purD);
                                dbContext.SaveChanges();
                            }
                        }
                        else
                        {
                            //-----Ürün eklemeden kayıt yaptıgı zaman geldği yer
                            //------------Boş Geçillnez discount felan var onlara ayar 
                            //query.Description = txtDescription.Text;
                            //query.Discount = Convert.ToInt32(txtDiscount.Text);
                            //query.TotalDiscount = Convert.ToDecimal(lblTotalDiscount.Text);
                            //query.Tax = Convert.ToInt32(txtTax.Text);
                            //query.TotalTax = Convert.ToDecimal(totalTax);
                            //query.TotalCash = Convert.ToDecimal(lblTotalPrice.Text);
                            //query.PurchaseDate = Convert.ToDateTime(dtpBill.EditValue);
                            //query.SupplierID = Convert.ToInt32(cmbSupplier.SelectedValue);
                            //query.FicheTypeID = Convert.ToInt32(cmbFicheType.SelectedValue);
                            dbContext.SaveChanges();
                        }
                        MessageBox.Show("Faturanız başarıyla güncellenmiştir", "ARWEN", MessageBoxButtons.OK,
    MessageBoxIcon.Information);
                        eventSucces = true;
                    }
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         

        }

        #region NewList
        private RestaurantContext dbContext = new RestaurantContext();
        List<PurchaseDetail> pDetails = new List<PurchaseDetail>();
        #endregion
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            try
            {
                int productID = Convert.ToInt32(cmbProducts.SelectedValue);
                using (RestaurantContext dbContext = new RestaurantContext())
                {
                    var queryCheck = dbContext.PurchaseDetail.FirstOrDefault(x => x.ProductID == productID && x.PurchaseID == FicheID);
                    var listCHeck = pDetails.FirstOrDefault(x => x.ProductID == productID && x.PurchaseID == FicheID);
                    if (queryCheck != null || listCHeck != null)
                    {
                        MessageBox.Show("Bu ürün faturası zaten bulunmakta ! ", "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        var addProduct = dbContext
                            .Get_All_Products()
                            .FirstOrDefault(x => x.ProductID == productID);

                        if (!string.IsNullOrEmpty(txtPrice.Text) && !string.IsNullOrEmpty(txtAmount.Text))
                        {
                            productLinePrice = addProduct.Price * Convert.ToDecimal(txtAmount.Text);
                            CalculateDiscount();
                            CalculateTax();
                            UserWarning(addProduct.Price);

                            dtProductLines.Rows.Add(addProduct.ProductName, Convert.ToInt32(txtAmount.Text), addProduct.GroupName, Convert.ToDecimal(txtPrice.Text), Convert.ToInt32(txtDiscount.Text), totalDiscount, productLinePrice, Convert.ToInt32(txtTax.Text), totalTax, Convert.ToInt64(cmbProducts.SelectedValue));

                            GeneralCalculate();
                            gridControl1.DataSource = dtProductLines;


                            GroupTax.SelectedIndex = -1;
                        }
                        if (invoiceType == "Edit")
                        {
                            //--Yeni Ürünleri Al
                            var productProp = dbContext.Get_All_Products().FirstOrDefault(x => x.ProductID == productID);

                            PurchaseDetail pDetail = new PurchaseDetail();

                            pDetail.Amount = Convert.ToInt32(txtAmount.Text);
                            pDetail.Price = Convert.ToDecimal(txtPrice.Text);
                            pDetail.Price = productLinePrice;
                            pDetail.ProductID = productProp.ProductID;
                            pDetail.PurchaseID = Convert.ToInt32(ficheID);
                            //product.ProductID = Convert.ToInt32(cmbProducts.SelectedValue);
                            //product.ProductName = productProp.ProductName;               
                            //group.GroupName = addProduct.GroupName;
                            //purchase.Discount = Convert.ToInt32(txtDiscount.Text);
                            //purchase.TotalDiscount = totalDiscount;
                            //purchase.Tax = Convert.ToInt32(txtTax.Text);
                            //purchase.TotalTax = totalTax;
                            //purchase.TotalCash = Convert.ToDecimal(lblTotalPrice.Text);

                            pDetails.Add(pDetail);
                            //Products.Add(product);
                            //Groups.Add(group);
                            //Purchaseses.Add(purchase);

                            newIn = true;

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          

        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            eventSucces = false;
            this.Close();
        }

        private void frmBuyBills_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && eventSucces == false)
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
                e.Cancel = false;
            }
        }

        private void cmbSupplier_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal myselected = (decimal)((cmbSupplier.SelectedItem as dynamic).SupplierID);
                GetSuppliersInformation(myselected);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void cmbProducts_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                lblWarning.Visible = false;
                decimal myselected = (decimal)((cmbProducts.SelectedItem as dynamic).ProductID);
                GetProductsInformation(myselected);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            try
            {
                int productId;
                DataRowView currow = (DataRowView)gridView1.GetRow(gridView1.FocusedRowHandle);
                if (currow != null)
                {
                    productId = Convert.ToInt32(currow["ProductID"]);
                    currow.Row.Delete();
                    decimal total = (productLinePrice + totalTax) - totalDiscount;
                    ClearGeneral(productLinePrice, totalTax, totalDiscount, total);
                    var query = dbContext.PurchaseDetail.FirstOrDefault(x => x.ProductID == productId && x.PurchaseID == FicheID);
                    if (query != null)
                    {
                        dbContext.PurchaseDetail.Remove(query);
                    }
                    else
                    {
                        pDetails.Remove(pDetails.FirstOrDefault(
                            x => x.ProductID == productId && x.PurchaseID == FicheID));
                    }


                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }
    }
}