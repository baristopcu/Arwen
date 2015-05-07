using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using ARWEN.Class;
using ARWEN.DTO.Database;


namespace ARWEN.Forms
{
    public partial class frmOrderComplete : DevExpress.XtraEditors.XtraForm
    {
        public frmOrderComplete()
        {
            InitializeComponent();
        }

        #region Fields
        private decimal total;
        private string table;
        private DataTable dtProducts = new DataTable();
        private List<int> _productIds = new List<int>();
        private List<decimal> _orderPrices = new List<decimal>();
        private List<int> productAmounts = new List<int>();
        private string orderType = "";
        private long orderNo;

        public long OrderNo
        {
            get { return orderNo; }
            set { orderNo = value; }
        }
        RestaurantContext dbContext = new RestaurantContext();

        public RestaurantContext DbContext
        {
            get { return dbContext; }
            set { dbContext = value; }
        }

        public decimal Total
        {
            get { return total; }
            set { total = value; }
        }

        public string Table
        {
            get { return table; }
            set { table = value; }
        }

        public DataTable DtProducts
        {
            get { return dtProducts; }
            set { dtProducts = value; }
        }

        public List<int> ProductIds
        {
            get { return _productIds; }
            set { _productIds = value; }
        }

        public List<int> ProductAmounts
        {
            get { return productAmounts; }
            set { productAmounts = value; }
        }

        public List<decimal> OrderPrices
        {
            get { return _orderPrices; }
            set { _orderPrices = value; }
        }

        public string OrderType
        {
            get { return orderType; }
            set { orderType = value; }
        }

        #endregion


        private void UnLockOrder(Int64 orderNo)
        {
            using (RestaurantContext dbContext = new RestaurantContext())
            {
                // UPDATE OrderHeader SET LockState=0,LockKeeperUserID=NULL WHERE OrderNo=@OrderNo AND LockKeeperUserID=@LockKeeperUserID

                var query = dbContext.OrderHeader.Where(x => (x.OrderNo == OrderNo)).FirstOrDefault(); // LOCKKEEPER -----
                query.LockState = false;
                query.LockKeeperUserID = null; // LOCKKEEPER -------------------------------
                dbContext.SaveChanges();
            }

        }

        public static int lastId = 0;
        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            OrderHeader oHeader = new OrderHeader();
            OrderDetail oDetail = new OrderDetail();

            if (orderType == "New")
            {
                using (RestaurantContext dbContext = new RestaurantContext())
                {
                    oHeader.TableNo = table;
                    oHeader.CreatorUserID = 1;
                    oHeader.CreationDatetime = DateTime.Now;
                   
                    oHeader.TotalPrice = total;
                    oHeader.LockState = false;
                    oHeader.PrintState = false;
                    oHeader.State = 0;
                    oHeader.Note = txtOrderNote.Text;
                    if (!selectCustomer)
                    {
                        oHeader.CustomerName = txtName.Text;
                    }
                    else
                    {
                        txtName.Text = GlobalCustomer.FullName;
                        oHeader.CustomerID = GlobalCustomer.CustomerID;
                    }
                   
                    dbContext.OrderHeader.Add(oHeader);
                    dbContext.SaveChanges();

                    lastId = Convert.ToInt32(oHeader.OrderNo);



                    for (int i = 0; i < dtProducts.Rows.Count; i++)
                    {
                        oDetail.OrderNo = lastId;
                        oDetail.ProductID = ProductIds[i];
                        oDetail.Amount = productAmounts[i];
                        oDetail.EditState = 0;
                        oDetail.NotEditable = false;
                        oDetail.OrderPrice = OrderPrices[i];

                        dbContext.OrderDetail.Add(oDetail);
                        dbContext.SaveChanges();

                    }

                    dbContext.Update_Table_State(table, true);
                    dbContext.SaveChanges();

                    MessageBox.Show("Siparişiniz başarıyla alındı.", "ARWEN", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else if (orderType == "Edit")
            {

                var query = DbContext.OrderHeader.Where(x => x.OrderNo == orderNo).FirstOrDefault();
                if (!selectCustomer)
                {
                     query.CustomerName = txtName.Text;
                }
                else
                {
                    txtName.Text = GlobalCustomer.FullName;
                    query.CustomerID = GlobalCustomer.CustomerID;
                }
                query.Note = txtOrderNote.Text;
                query.LastEditionDatetime = DateTime.Now;
                query.TotalPrice = total;
                DbContext.SaveChanges();

                MessageBox.Show("Siparişiniz başarıyla güncellendi.", "ARWEN", MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
                this.Close();
            }

        }
        private void btnCancelOrder_Click(object sender, EventArgs e)
        {

        }

        private void frmOrderComplete_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Çıkmak istediğinize emin misiniz?", "ARWEN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (orderType == "Edit")
                    {
                        UnLockOrder(lastId);
                    }
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

        private bool selectCustomer = false;

        private void frmOrderComplete_Load(object sender, EventArgs e)
        {
            lblTable.Text = table;
            lblTotal.Text = total.ToString("C2");
        }

        private void btnSelectCustomer_Click(object sender, EventArgs e)
        {        
            frmSelectCustomer frm = new frmSelectCustomer();
            this.Hide();
            frm.ShowDialog();
            this.Show();
            selectCustomer = true;
        }

    }
}