﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using ARWEN.DTO.Database;
using ARWEN.Class;

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
        private List<OrderDetail> oDetails = new List<OrderDetail>();
        private List<decimal> _orderPrices = new List<decimal>();
        private List<int> productAmounts = new List<int>();
        private string orderType = "";
        long orderNo;

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

        DataTable OriginalOrderDetail = new DataTable();




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

        public List<OrderDetail> ODetails
        {
            get { return oDetails; }
            set { oDetails = value; }
        }

        #endregion


        private void UnLockOrder(Int64 orderNo)
        {
            try
            {
                using (RestaurantContext dbContext = new RestaurantContext())
                {
                    // UPDATE OrderHeader SET LockState=0,LockKeeperUserID=NULL WHERE OrderNo=@OrderNo AND LockKeeperUserID=@LockKeeperUserID

                    var query = dbContext.OrderHeader.Where(x => (x.OrderNo == OrderNo)).FirstOrDefault(); // LOCKKEEPER -----
                    query.LockState = false;
                    query.LockKeeperUserID = GlobalUser.PermissionID; // LOCKKEEPER -------------------------------
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {               
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
           

        }

        public static int lastId = 0;
        private bool eventSucces = false;

        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            OrderHeader oHeader = new OrderHeader();
            OrderDetail oDetail = new OrderDetail();

            try
            {
                if (orderType == "New")
                {
                    using (RestaurantContext dbContext = new RestaurantContext())
                    {
                        oHeader.TableNo = table;
                        oHeader.CreatorUserID = 1;
                        oHeader.CreationDatetime = DateTime.Now;
                        if (GlobalCustomer.Choosed)
                        {
                            oHeader.CustomerID = GlobalCustomer.CustomerID;
                        }
                        oHeader.TotalPrice = total;
                        oHeader.LockState = false;
                        oHeader.PrintState = false;
                        oHeader.State = 0;
                        oHeader.Note = txtOrderNote.Text;

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

                        MessageBox.Show(
                            "Siparişiniz " + GlobalCustomer.FullName + " " +
                            "adlı müşterinizle başarıyla ilişkilendirilip kayıt edildi.", "ARWEN", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        eventSucces = true;
                        this.Close();
                    }
                }
                else if (orderType == "Edit")
                {
                    var query = DbContext.OrderHeader.Where(x => x.OrderNo == orderNo).FirstOrDefault();
                    if (query != null)
                    {
                        query.Note = txtOrderNote.Text;
                        if (GlobalCustomer.Choosed)
                        {
                            query.CustomerID = GlobalCustomer.CustomerID;
                        }
                        query.LastEditionDatetime = DateTime.Now;
                        query.TotalPrice = total;
                        var oDetailNull = oDetails.FirstOrDefault();
                        if (oDetailNull == null)
                        {
                            dbContext.SaveChanges();
                        }
                        else
                        {
                            dbContext.OrderDetail.Remove(oDetails.Last());

                            foreach (var item in oDetails)
                            {
                                oDetail.OrderNo = orderNo;
                                oDetail.ProductID = item.ProductID;
                                oDetail.Amount = item.Amount;
                                oDetail.EditAmount = item.EditAmount;
                                oDetail.EditState = 0;
                                oDetail.NotEditable = false;
                                oDetail.OrderPrice = item.OrderPrice;
                                dbContext.OrderDetail.AddOrUpdate(oDetail);
                                dbContext.SaveChanges();
                            }

                        }



                    }
                    MessageBox.Show("Siparişiniz başarıyla güncellendi.", "ARWEN", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    eventSucces = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         

        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            eventSucces = false;
            Close();
        }

        private void frmOrderComplete_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (e.CloseReason == CloseReason.UserClosing && eventSucces == false)
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
                    e.Cancel = false;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }

        private void frmOrderComplete_Load(object sender, EventArgs e)
        {
            try
            {
                lblTable.Text = table;
                lblTotal.Text = total.ToString("C2");
                if (orderType == "New")
                {
                    this.Text = "Siparişi Tamamla";
                }
                else if (orderType == "Edit")
                {
                    this.Text = "Siparişi Güncelle";

                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
       
           
        }

        private void btnSelectCustomer_Click(object sender, EventArgs e)
        {
            frmSelectCustomer frm = new frmSelectCustomer();
            frm.ShowDialog();
        }


    }
}