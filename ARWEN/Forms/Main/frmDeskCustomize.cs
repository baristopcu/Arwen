using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ARWEN.DTO.Database;
using ARWEN.Forms;
using DevExpress.Xpo.DB.Helpers;
using DevExpress.XtraEditors;

namespace ARWEN
{
    public partial class frmDeskCustomize : DevExpress.XtraEditors.XtraForm
    {

        /* Manager = 1     Edit = 1   Deleted= 2
         * Cashier = 2     Ready = 3 Print State = 1 olursa yazdırmaz
         * Kitchen = 3     Served = 4
         */

        public frmDeskCustomize()
        {
            InitializeComponent();

            dtProducts.Columns.Add("ProductID", typeof (Int64));
            dtProducts.Columns.Add("Amount", typeof (int));
            dtProducts.Columns.Add("ProductName", typeof (string));
            dtProducts.Columns.Add("Price", typeof (decimal));
            dtProducts.Columns.Add("UnitName", typeof(string));
        }

        #region Fields

        private static SimpleButton groupButton;
        private static SimpleButton productButton;
        private string orderType = "";
        private List<int> ProductIds = new List<int>();
        private List<int> ProductAmounts = new List<int>();
        private List<decimal> OrderPrices = new List<decimal>();
        private DataTable dtProducts = new DataTable();
        private Products products = new Products();
        private int Adet;
        private byte _tableState;
        private long orderNo;

        public byte TableState
        {
            get { return _tableState; }
            set { _tableState = value; }
        }

        #endregion

        private void LockOrder(Int64 orderNo)
        {
            using (RestaurantContext dbContext = new RestaurantContext())
            {
                OrderHeader oHeader = new OrderHeader();
                // x.LockKeeperUserID == 1)
                if (orderType == "New")
                {
                    using (RestaurantContext dbOrderContext = new RestaurantContext())
                    {
                        var query =
                            dbOrderContext.OrderHeader.Where(
                                x =>
                                    (x.OrderNo == orderNo && x.LockState == false) ||
                                    (x.OrderNo == orderNo && x.LockState == true)).FirstOrDefault(); // LOCKKEEPER -----
                        query.LockState = true;
                        query.LockKeeperUserID = 1; // LOCKKEEPER -------------------------------
                        dbOrderContext.SaveChanges();
                    }

                }
                else if (orderType == "Edit")
                {
                    var query =
                        dbContext.OrderHeader.Where(
                            x =>
                                (x.OrderNo == orderNo && x.LockState == false) ||
                                (x.OrderNo == orderNo && x.LockState == true)).FirstOrDefault(); // LOCKKEEPER -----
                    query.LockState = true;
                    query.LockKeeperUserID = 1; // LOCKKEEPER -------------------------------
                    dbContext.SaveChanges();
                }


            }

        }


        public void StateControl(byte State)
        {
            List<object> orderProductsList = new List<object>();
            int Adet, Dadet;
            orderType = "Edit";
            if (State == 1) //EDİT
            {
                using (RestaurantContext dbContext = new RestaurantContext())
                {

                    orderNo = dbContext.Get_Orders_Of_A_Table(this.Tag.ToString()).Select(y => y.OrderNo).Single();
                    int detailRow = dbContext.Get_Order_Detail(orderNo).Count();


                    for (int i = 0; i < detailRow; i++)
                    {
                        var query =
                            dbContext.OrderDetail.AsNoTracking()
                                .Join(dbContext.Products, od => od.ProductID, p => p.ProductID, (od, p) => new {od, p})
                                .Where(b => b.od.OrderNo == orderNo)
                                .Select(s => new
                                {
                                    s.od.OrderDetailID,
                                    s.od.ProductID,
                                    s.p.ProductName,
                                    s.p.UnitName,
                                    s.od.Amount,
                                    s.od.EditState,
                                    s.od.NotEditable,
                                    s.od.OrderPrice,
                                    s.od.EditAmount
                                }).AsQueryable();

                        orderProductsList.AddRange(query.ToList());

                        foreach (var result in query)
                        {
                            Adet = result.Amount;
                            products.ProductName = result.ProductName;
                            products.Price = Convert.ToDecimal(result.OrderPrice);
                            products.ProductID = result.ProductID;
                            Dadet = Convert.ToInt32(result.EditAmount);
                            dtProducts.Rows.Add(products.ProductID, Adet, products.ProductName, products.Price, Dadet);
                            gridProducts.DataSource = dtProducts;
                        }
                        break;
                    }

                    gridView1.OptionsView.ShowFooter = true;
                    gridView1.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[2].SummaryItem.FieldName = "Price";
                    gridView1.Columns[2].SummaryItem.DisplayFormat = "Toplam {0} TL";


                }
            }
            else if (State == 0) //NEW
            {
                orderType = "New";
                btnPayment.Enabled = false;

            }
            else if (State == 2) // RESERVED
            {
                orderType = "Reserved";

            }
            else
            {
                MessageBox.Show("HATA");
            }

        }

        public void ProductButtonCreate(int grupSayisi, FlowLayoutPanel flwLayoutPanel)
        {
            List<string> productNameList = new List<string>();
            List<int> productIdList = new List<int>();
            int productUsedButton = Convert.ToInt32(groupButton.Tag);

            using (RestaurantContext dbContext = new RestaurantContext())
            {

                productNameList.AddRange(
                    dbContext.Products.Where(x => x.GroupID == productUsedButton).Select(y => y.ProductName).ToList());
                productIdList.AddRange(
                    dbContext.Products.Where(x => x.GroupID == productUsedButton).Select(y => y.ProductID).ToList());

            }

            for (int i = 0; i < grupSayisi; i++)
            {
                SimpleButton sndrButton = new SimpleButton();
                sndrButton.Text = productNameList[i];
                sndrButton.Tag = productIdList[i];
                sndrButton.Width = 150;
                sndrButton.Height = 60;
                flwLayoutPanel.Controls.Add(sndrButton);
                sndrButton.Click += productButton_Click;
            }
        }

        public void GroupButtonCreate(int grupSayisi, FlowLayoutPanel flwLayoutPanel)
        {
            List<string> groupNameList = new List<string>();
            List<int> groupIdList = new List<int>();

            using (RestaurantContext dbContext = new RestaurantContext())
            {

                groupNameList.AddRange(dbContext.Groups.Select(x => x.GroupName).ToList());
                groupIdList.AddRange(dbContext.Groups.Select(x => x.GroupID).ToList());

            }
            for (int i = 0; i <= grupSayisi; i++)
            {
                SimpleButton sndrButton = new SimpleButton();
                sndrButton.Text = groupNameList[i];
                sndrButton.Tag = groupIdList[i];
                sndrButton.Width = 150;
                sndrButton.Height = 60;
                flwLayoutPanel.Controls.Add(sndrButton);
                sndrButton.Click += groupButton_Click;
            }
        }

        private void productButton_Click(object sender, EventArgs e)
        {

            productButton = (SimpleButton) sender;
            int productUsedButton = Convert.ToInt32(productButton.Tag);

            if (orderType == "New")
            {
                btnPayment.Enabled = true;
                using (RestaurantContext dbContext = new RestaurantContext())
                {

                    var addProduct = dbContext.Get_All_Products()
                        .Where(x => x.ProductID == productUsedButton)
                        .Select(y => new {Ad = y.ProductName, Fiyat = y.Price, Id = y.ProductID, Birim = y.UnitName})
                        .ToList();



                    foreach (var result in addProduct)
                    {
                        Adet = 1;
                        products.ProductName = result.Ad;
                        products.Price = result.Fiyat;
                        products.ProductID = result.Id;
                        products.UnitName = result.Birim;

                    }

                    dtProducts.Rows.Add(products.ProductID, Adet, products.ProductName, products.Price, products.UnitName);

                    gridView1.OptionsView.ShowFooter = true;
                    gridView1.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns[2].SummaryItem.FieldName = "Price";
                    gridView1.Columns[2].SummaryItem.DisplayFormat = "Toplam {0} TL";

                    gridProducts.DataSource = dtProducts;
                }
            }
            else if (orderType == "Edit")
            {

                var addProduct = dbContext.Get_All_Products()
                    .Where(x => x.ProductID == productUsedButton)
                    .FirstOrDefault();
                OrderDetail oDetail = new OrderDetail();
                products.ProductName = addProduct.ProductName;
                oDetail.OrderNo = orderNo;
                oDetail.ProductID = addProduct.ProductID;
                oDetail.Amount = 1;
                oDetail.EditState = 0;
                oDetail.OrderPrice = addProduct.Price;
                var query =
                    dbContext.OrderDetail.Where(x => x.OrderNo == orderNo)
                        .Where(x => x.ProductID == addProduct.ProductID)
                        .FirstOrDefault();
                if (query == null)
                {
                    dtProducts.Rows.Add(oDetail.ProductID, oDetail.Amount, products.ProductName, oDetail.OrderPrice);
                    dbContext.OrderDetail.Add(oDetail);
                    gridProducts.DataSource = dtProducts;
                    //-------------------------------------------------------------------------------------------------------
                }
                else if (query.OrderNo == orderNo && query.ProductID == addProduct.ProductID) //?????
                {
                    MessageBox.Show("Bu yemek zaten var");
                }



            }

        }

        private void groupButton_Click(object sender, EventArgs e)
        {
            flwProducts.Controls.Clear();
            groupButton = (SimpleButton) sender;
            int productCount;
            using (RestaurantContext dbContext = new RestaurantContext())
            {
                productCount =
                    dbContext.Get_All_Products().Where(x => x.GroupID == Convert.ToInt32(groupButton.Tag)).Count();
            }
            ProductButtonCreate(productCount, flwProducts);


        }

        private void frmDeskCustomize_Load(object sender, EventArgs e)
        {
            lblTableNo.Text = Tag.ToString() + " " + "DETAY";
            StateControl(TableState);
            if (orderType == "Edit")
            {
                LockOrder(orderNo);
            }

            using (RestaurantContext dbContext = new RestaurantContext())
            {

                int groupCount = dbContext.Get_All_Groups().Count();
                GroupButtonCreate(groupCount, flwProductGroups);

            }

        }

        #region Add,Delete Fields

        private int productId, amount, editAmount;
        private decimal totalPrice, price;

        #endregion

        private void UnLockOrder(Int64 orderNo)
        {
            using (RestaurantContext dbContext = new RestaurantContext())
            {
                // UPDATE OrderHeader SET LockState=0,LockKeeperUserID=NULL WHERE OrderNo=@OrderNo AND LockKeeperUserID=@LockKeeperUserID

                var query = dbContext.OrderHeader.Where(x => (x.OrderNo == orderNo)).FirstOrDefault();
                // LOCKKEEPER -----
                query.LockState = false;
                query.LockKeeperUserID = null; // LOCKKEEPER -------------------------------
                query.LastEditionDatetime = DateTime.Now;
                dbContext.SaveChanges();
            }

        }

        private RestaurantContext dbContext = new RestaurantContext();

        private void btnAdd_Click(object sender, EventArgs e)
        {

            DataRowView currow = (DataRowView) gridView1.GetRow(gridView1.FocusedRowHandle);
            if (currow != null)
            {

                productId = Convert.ToInt32(currow["ProductID"]);


                var query = dbContext.Products.Where(x => x.ProductID == productId).FirstOrDefault();
                price = query.Price;

                amount = Convert.ToInt32(currow["Amount"]);
                editAmount = amount + 1;
                currow[1] = editAmount;
                totalPrice = price*editAmount;
                currow[3] = totalPrice;

            }
            if (_tableState == 1)
            {
                var query =
                    dbContext.OrderDetail.Where(x => x.OrderNo == orderNo && x.ProductID == productId).FirstOrDefault();
                query.Amount = 1;
                query.EditAmount = 1;
                query.Amount = editAmount;
                query.EditAmount = editAmount;
                query.OrderPrice = totalPrice;


            }


        }

        private void btnLess_Click(object sender, EventArgs e)
        {
            DataRowView currow = (DataRowView) gridView1.GetRow(gridView1.FocusedRowHandle);
            if (currow != null)
            {

                if (Convert.ToInt32(currow["Amount"]) >= 1)
                {

                    productId = Convert.ToInt32(currow["ProductID"]);

                    var query = dbContext.Products.Where(x => x.ProductID == productId).FirstOrDefault();
                    price = query.Price;

                    amount = Convert.ToInt32(currow["Amount"]);
                    editAmount = amount - 1;
                    currow[1] = editAmount;

                    totalPrice = Convert.ToDecimal(currow["Price"]) - price;
                    currow[3] = totalPrice;

                    if (_tableState == 1)
                    {
                        var result =
                            dbContext.OrderDetail.Where(x => x.OrderNo == orderNo && x.ProductID == productId)
                                .FirstOrDefault();
                        result.Amount = editAmount;
                        result.EditAmount = editAmount;
                        result.OrderPrice = totalPrice;
                    }


                }
                else
                {
                    return;
                }



            }
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            DataRowView currow = (DataRowView) gridView1.GetRow(gridView1.FocusedRowHandle);
            if (currow != null)
            {
                productId = Convert.ToInt32(currow["ProductID"]);
                currow.Row.Delete();
                if (_tableState == 1)
                {

                    OrderDetail query =
                        dbContext.OrderDetail.Where(x => x.OrderNo == orderNo && x.ProductID == productId)
                            .FirstOrDefault();
                    dbContext.OrderDetail.Remove(query);

                }

            }

        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            frmPayment frm = new frmPayment();
            frm.Tag = this.Tag;
            frm.OrderNo = orderNo;
            frm.DtPayment = dtProducts;
            frm.TotalCash = Convert.ToDecimal(dtProducts.Compute("Sum(Price)", ""));
            this.Close();
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            foreach (DataRow x in dtProducts.Rows)
            {
                ProductIds.Add(Convert.ToInt32(x["ProductId"]));
                ProductAmounts.Add(Convert.ToInt32(x["Amount"]));
                OrderPrices.Add(Convert.ToDecimal(x["Price"]));

            }

            frmOrderComplete frm = new frmOrderComplete();
            frm.Total = Convert.ToDecimal(dtProducts.Compute("Sum(Price)", ""));
            frm.Table = this.Tag.ToString();
            frm.DtProducts = dtProducts;
            frm.ProductIds = ProductIds;
            frm.ProductAmounts = ProductAmounts;
            frm.OrderPrices = OrderPrices;
            frm.OrderType = orderType;
            frm.DbContext = dbContext;
            frm.OrderNo = orderNo;
            frm.ShowDialog();
        }

        private void frmDeskCustomize_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (orderType == "Edit")
            {
                UnLockOrder(orderNo);

            }
            //else if (orderType == "New")
            //{
            //    UnLockOrder(lastId);
            //}

        }

        private void btnMoveDesk_Click(object sender, EventArgs e)
        {

        }

        private void btnWriteTicket_Click(object sender, EventArgs e)
        {
            DialogResult pdr = printDialog1.ShowDialog();
            if (pdr == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            decimal gTotal = 0;

            Graphics graphic = e.Graphics;
            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 10);
            float fontHeight = font.GetHeight();
            int startX = 50;
            int startY = 55;
            int Offset = 40;

            graphics.DrawString("Sipariş Formu", new Font("Courier New", 14),
                new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            String underLine = "------------------------------------------"; //ADİSYON BİLGİLERİ
            graphics.DrawString(underLine, new Font("Courier New", 10),
                new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("Masa: " + lblTableNo.Text,
                new Font("Courier New", 12),
                new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("Tarih: " + DateTime.Now,
                new Font("Courier New", 12),
                new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("User: " + "Admin",
                new Font("Courier New", 12),
                new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            underLine = "------------------------------------------"; //ADİSYON BİLGİLERİ
            graphics.DrawString(underLine, new Font("Courier New", 10),
                new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 10;
            string top = "Item Name".PadRight(30) + "Price";
            graphics.DrawString(top, new Font("Courier New", 10),
                new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 10;
            underLine = "------------------------------------------"; // ÜRÜN BİLGİLERİ
            graphics.DrawString(underLine, new Font("Courier New", 10),
                new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;

            foreach (DataRow item in dtProducts.Rows)
            {
                string productDescription = item[2].ToString().PadRight(30);
                string productTotal = item[3].ToString();
                gTotal += Convert.ToDecimal(productTotal);
                string productLine = productDescription + productTotal;

                graphic.DrawString(productLine, font, new SolidBrush(Color.Black), startX, startY + Offset);

                Offset = Offset + (int) fontHeight + 5;

            }


            String Grosstotal = "Toplam = " + gTotal.ToString("c");
            underLine = "------------------------------------------";
            graphics.DrawString(underLine, new Font("Courier New", 12),
                new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString(Grosstotal.PadRight(30), new Font("Courier New", 12),
                new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            String DrawnBy = "Admin";
            graphics.DrawString("Conductor - " + DrawnBy, new Font("Courier New", 12),
                new SolidBrush(Color.Black), startX, startY + Offset);

        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            if (orderType == "Edit")
            {
                frmAddOrderNote frm = new frmAddOrderNote();
                frm.OrderNo = orderNo;
                this.Hide();
                frm.ShowDialog();
                this.Show();
            }
        }
    }
}


