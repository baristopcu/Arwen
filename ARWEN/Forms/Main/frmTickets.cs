using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ARWEN.DTO.Database;
using ARWEN.Forms.Print;
using DevExpress.XtraEditors;

namespace ARWEN.Forms
{
    public partial class frmTickets : DevExpress.XtraEditors.XtraForm
    {
        public frmTickets()
        {
            InitializeComponent();
        }

        private void GetProducts(DateTime t1, DateTime t2)
        {
            using (var dbContext = new RestaurantContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;

                var query =
                    dbContext.OrderHeader.AsNoTracking().ToList()
                        .Join(dbContext.Payments, oh => oh.OrderNo, p => p.OrderNo, (oh, p) => new {oh, p})
                        .Join(dbContext.PaymentModules, pm => pm.p.PaymentModuleID, x => x.PaymentModuleID,
                            (pm, x) => new {pm, x})
                        .Join(dbContext.Users, u => u.pm.oh.CreatorUserID, y => y.UserID, (u, y) => new {u, y})
                        .Where(
                            ex =>
                                ex.u.pm.oh.CreationDatetime <= t2.Date &&
                                ex.u.pm.p.Date >= t1.Date)
                        .Select(s => new
                        {

                            s.u.pm.p.Date,
                            s.u.x.Name,
                            s.u.pm.oh.TableNo,
                            s.u.pm.oh.CustomerName,
                            s.u.pm.oh.TotalPrice,
                            s.u.pm.oh.Note,
                            s.u.pm.oh.CreationDatetime,
                            s.y.UserName,
                            s.u.pm.oh.OrderNo,
                            s.u.pm.p.PaymentID,
                            s.u.pm.p.Discount,
                            Saat = s.u.pm.oh.CreationDatetime.ToString("hh:mm") + "-" + s.u.pm.p.Date.ToString("hh:mm")

                        }).ToList();

          
                

                gridControlTickets.DataSource = new BindingSource(query, "");
            }
        }

        private void frmTickets_Load(object sender, EventArgs e)
        {
            using (var dbContext = new RestaurantContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;

                var query =
                    dbContext.OrderHeader.AsNoTracking().ToList()
                        .Join(dbContext.Payments, oh => oh.OrderNo, p => p.OrderNo, (oh, p) => new { oh, p })
                        .Join(dbContext.PaymentModules, pm => pm.p.PaymentModuleID, x => x.PaymentModuleID,
                            (pm, x) => new { pm, x })
                        .Join(dbContext.Users, u => u.pm.oh.CreatorUserID, y => y.UserID, (u, y) => new { u, y })
                        .Select(s => new
                        {

                            s.u.pm.p.Date,
                            s.u.x.Name,
                            s.u.pm.oh.TableNo,
                            s.u.pm.oh.CustomerName,
                            s.u.pm.oh.TotalPrice,
                            s.u.pm.oh.Note,
                            s.u.pm.oh.CreationDatetime,
                            s.y.UserName,
                            s.u.pm.oh.OrderNo,
                            s.u.pm.p.PaymentID,
                            s.u.pm.p.Discount,
                            Saat = s.u.pm.oh.CreationDatetime.ToString("hh:mm") + "-" + s.u.pm.p.Date.ToString("hh:mm")

                        }).ToList();


                gridControlTickets.DataSource = new BindingSource(query, "");

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (dateEdit1.Text != dateEdit2.Text)
            {
                if (Convert.ToDateTime(dateEdit1.Text) < Convert.ToDateTime(dateEdit2.Text))
                {
                    GetProducts(Convert.ToDateTime(dateEdit1.EditValue.ToString()),
                        Convert.ToDateTime(dateEdit2.EditValue.ToString()));



                }
                else
                {
                    MessageBox.Show("Başlangıç tarihi Bitiş tarihinden daha büyük olamaz.", "ARWEN",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Tarihler aynı olamaz.", "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnPrint_Click(object sender, EventArgs e)
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

            int index = gridView1.FocusedRowHandle;
            int order = Convert.ToInt32(gridView1.GetRowCellValue(index, "OrderNo").ToString());
            int payment = Convert.ToInt32(gridView1.GetRowCellValue(index, "PaymentID").ToString());
            string ticketDate = gridView1.GetRowCellValue(index, "Date").ToString();
            string table = gridView1.GetRowCellValue(index, "TableNo").ToString();
            string fullName = gridView1.GetRowCellValue(index, "UserName").ToString();
            string discount = gridView1.GetRowCellValue(index, "Discount").ToString();

            if (order != null)
            {

                using (RestaurantContext dbContext = new RestaurantContext())
                {
                    var query =
                        dbContext.OrderDetail.AsNoTracking()
                            .Join(dbContext.Products, od => od.ProductID, p =>

                                p.ProductID, (od, p) => new {od, p})
                            .Where(b => b.od.OrderNo == order)
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




                    Graphics graphic = e.Graphics;
                    Graphics graphics = e.Graphics;
                    Font font = new Font("Courier New", 10);
                    float fontHeight = font.GetHeight();
                    int startX = 50;
                    int startY = 55;
                    int Offset = 40;

                    graphics.DrawString("Welcome to ARWEN", new Font("Courier New", 14),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 20;
                    String underLine = "------------------------------------------"; //ADİSYON BİLGİLERİ
                    graphics.DrawString(underLine, new Font("Courier New", 10),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 20;
                    graphics.DrawString("Ticket No: " + payment,
                        new Font("Courier New", 12),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 20;
                    graphics.DrawString("Ticket Date: " + ticketDate,
                        new Font("Courier New", 12),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 20;
                    graphics.DrawString("Table: " + table,
                        new Font("Courier New", 12),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 20;
                    graphics.DrawString("User: " + fullName,
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

                    foreach (var item in query)
                    {
                        string productDescription = item.ProductName.PadRight(30);
                        string productTotal = item.OrderPrice.ToString();
                        gTotal += Convert.ToDecimal(productTotal);
                        string productLine = productDescription + productTotal;

                        graphic.DrawString(productLine, font, new SolidBrush(Color.Black), startX, startY + Offset);

                        Offset = Offset + (int) fontHeight + 5;

                    }


                    String Grosstotal = "Toplam = " + gTotal.ToString("c");
                    String CDiscount = "İndirim = " + discount;
                    underLine = "------------------------------------------";
                    graphics.DrawString(underLine, new Font("Courier New", 10),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 20;
                    graphics.DrawString(CDiscount, new Font("Courier New", 12),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 20;
                    graphics.DrawString(Grosstotal.PadRight(30), new Font("Courier New", 12),
                        new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 20;
                    String DrawnBy = "Admin";
                    graphics.DrawString("Conductor - " + DrawnBy, new Font("Courier New", 12),
                        new SolidBrush(Color.Black), startX, startY + Offset);

                }
            }
        }
    }
}
    