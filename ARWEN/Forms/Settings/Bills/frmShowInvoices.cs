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
    public partial class frmShowInvoices : DevExpress.XtraEditors.XtraForm
    {
        DataTable dtInvoices;
        DataTable dtInvoiceDetail;
        string focusedRowNIdNumber;

        public frmShowInvoices()
        {
            InitializeComponent();

            dtInvoices = new DataTable("INVOICES");
            dtInvoices.Columns.Add("PurchaseID", typeof(Int64));
            dtInvoices.Columns.Add("CompanyName", typeof(string));
            dtInvoices.Columns.Add("Name", typeof(string));
            dtInvoices.Columns.Add("PurchaseDate", typeof(string));
            dtInvoices.Columns.Add("TotalCash", typeof(decimal));
            dtInvoices.Columns.Add("Description", typeof(string));
            dtInvoices.Columns.Add("Tax", typeof(int));
            dtInvoices.Columns.Add("TotalTax", typeof(decimal));
            dtInvoices.Columns.Add("Discount", typeof(int));
            dtInvoices.Columns.Add("TotalDiscount", typeof(decimal));
            dtInvoices.PrimaryKey = new DataColumn[] { dtInvoices.Columns["PurchaseID"] };

            dtInvoiceDetail = new DataTable("INVOICEDETAIL");
            dtInvoiceDetail.Columns.Add("PurchaseDetailID", typeof(Int64));
            dtInvoiceDetail.Columns.Add("PurchaseID", typeof(Int64));
            dtInvoiceDetail.Columns.Add("ProductName", typeof(string));
            dtInvoiceDetail.Columns.Add("Amount", typeof(Int32));
            dtInvoiceDetail.Columns.Add("Price", typeof(decimal));
            dtInvoiceDetail.PrimaryKey = new DataColumn[] { dtInvoiceDetail.Columns["PurchaseDetailID"] };

        }

        private void GetInvoices()
        {
            using (var dbContext = new RestaurantContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                var productsQuery =
                   dbContext.Purchases.AsNoTracking()
                       .Join(dbContext.Suppliers, p => p.SupplierID, s => s.SupplierID, (p, s) => new { p, s }).Join(dbContext.FicheTypes, p => p.p.FicheTypeID, g => g.FicheTypeID, (p, g) => new { p, g })
                       .Select(y => new
                       {
                           y.p.p.Description,
                           y.g.Name,
                           y.p.s.CompanyName,
                           y.p.p.TotalCash,
                           y.p.p.TotalDiscount,
                           y.p.p.TotalTax,
                           y.p.p.Tax,
                           y.p.p.Discount,
                           y.p.p.PurchaseID,
                           y.p.p.PurchaseDate

                       }).ToList();

                gridControl1.DataSource = new BindingSource(productsQuery, "");
            }
        }

        void LoadTable()
        {
            dtInvoices.Clear(); 

            using (var dbContext = new RestaurantContext())
            {
                #region InvoiceQuery
                dbContext.Configuration.LazyLoadingEnabled = false;
                var invoiceQuery =
                   dbContext.Purchases.AsNoTracking()
                       .Join(dbContext.Suppliers, p => p.SupplierID, s => s.SupplierID, (p, s) => new { p, s }).Join(dbContext.FicheTypes, p => p.p.FicheTypeID, g => g.FicheTypeID, (p, g) => new { p, g })
                       .Select(y => new
                       {
                           y.p.p.Description,
                           y.g.Name,
                           y.p.s.CompanyName,
                           y.p.p.TotalCash,
                           y.p.p.TotalDiscount,
                           y.p.p.TotalTax,
                           y.p.p.Tax,
                           y.p.p.Discount,
                           y.p.p.PurchaseID,
                           y.p.p.PurchaseDate

                       }).ToList();

                foreach (var item in invoiceQuery)
                {
                    dtInvoices.Rows.Add(item.PurchaseID, item.CompanyName,item.Name, item.PurchaseDate, item.TotalCash, item.Description, item.Tax, item.TotalTax, item.Discount, item.TotalDiscount);
                } 
                #endregion

                #region InvoiceDetailQuery
                var invoiceDetailQuery =
                         dbContext.PurchaseDetail.AsNoTracking()
                             .Join(dbContext.Products, p => p.ProductID, s => s.ProductID, (p, s) => new { p, s })
                             .Select(y => new
                             {
                                 y.p.Amount,
                                 y.p.Price,
                                 y.s.ProductName,
                                 y.p.PurchaseID,
                                 y.p.PurchaseDetailID

                             }).ToList();

                foreach (var item in invoiceDetailQuery)
                {
                    dtInvoiceDetail.Rows.Add(item.PurchaseDetailID, item.PurchaseID, item.ProductName, item.Amount, item.Price);
                }  
                #endregion

            }

            DataSet dsRel = new DataSet();
            dsRel.Tables.Add(dtInvoices);
            dsRel.Tables.Add(dtInvoiceDetail);

            dsRel.Relations.Add("Fatura Detay", dtInvoices.Columns["PurchaseID"], dtInvoiceDetail.Columns["PurchaseID"]);

            gridControl1.LevelTree.Nodes.Add(dsRel.Relations["Fatura Detay"].RelationName, gridView2);

            gridControl1.DataSource = dsRel.Tables["INVOICES"];
            gridControl1.Refresh();
            gridControl1.RefreshDataSource();
        }

        private void frmShowInvoices_Load(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void gridView2_Click(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView a = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            if (a.FocusedRowHandle > -1) 
            {
                focusedRowNIdNumber = a.GetFocusedRowCellValue("PurchaseID").ToString();
            }
        }

        private void btnCustomize_Click(object sender, EventArgs e)
        {
            int index = gridView1.FocusedRowHandle;
            int InvocideID = Convert.ToInt32(gridView1.GetRowCellValue(index, "PurchaseID").ToString());
            frmInvoices frm = new frmInvoices();
            frm.FicheID = InvocideID;
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
    }
}