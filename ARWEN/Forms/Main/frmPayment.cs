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
using System.Globalization;

namespace ARWEN
{
    public partial class frmPayment : DevExpress.XtraEditors.XtraForm
    {
        public frmPayment()
        {
            InitializeComponent();
        }

        #region Fields
        long orderNo;
        decimal totalCash;

        public decimal TotalCash
        {
            get { return totalCash; }
            set { totalCash = value; }
        }
        DataTable dtPayment;

        public DataTable DtPayment
        {
            get { return dtPayment; }
            set { dtPayment = value; }
        }
        public long OrderNo
        {
            get { return orderNo; }
            set { orderNo = value; }
        }
        #endregion


        private void UnLockOrder(Int64 orderNo)
        {
            try
            {
                using (RestaurantContext dbContext = new RestaurantContext())
                {


                    var query = dbContext.OrderHeader.Where(x => (x.OrderNo == OrderNo)).FirstOrDefault();
                    query.LockState = false;
                    query.LockKeeperUserID = null;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

        }

        public void MakeTotalCash()
        {
            try
            {
                gridPaymentProducts.DataSource = dtPayment;

                gridView1.OptionsView.ShowFooter = true;
                gridView1.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns[2].SummaryItem.FieldName = "Price";
                gridView1.Columns[2].SummaryItem.DisplayFormat = "Toplam {0} TL";
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
       


        }

        private decimal discountPrice = 0;
        public decimal GetDiscountPrice(decimal actualPrice)
        {
            try
            {
                decimal r = Convert.ToDecimal(txtCharged.Text);
                decimal a = actualPrice - (1 * r);
                lblDiscount.Text = a.ToString("c");
                lblRound.Text = "%" + txtCharged.Text + "=";
                txtTotalCash.Text = a.ToString();
                discountPrice = totalCash - a;
                txtCharged.Text = "";
                lblDiscount.BackColor = Color.Red;
                lblDiscount.ForeColor = Color.White;
                lblRound.BackColor = Color.Red;
                lblRound.ForeColor = Color.White;
                lblDiscount.Visible = true;
                lblRound.Visible = true;
                return a;
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return actualPrice;
            }
        
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = this.Tag + " " + "ÖDEME";
                txtTotalCash.Text = totalCash.ToString();
                btnTotalValue.Text = totalCash.ToString();
                MakeTotalCash();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          

        }

        private void button_click(object sender, EventArgs e)
        {
            try
            {
                SimpleButton btn = sender as SimpleButton;
                txtCharged.Text += btn.Text;
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnCC_Click(object sender, EventArgs e)
        {
            try
            {
                txtCharged.Text = string.Empty;

            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_banks(object sender, EventArgs e)
        {
            try
            {
                SimpleButton btn = sender as SimpleButton;
                if (!String.IsNullOrEmpty(txtCharged.Text))
                {
                    decimal t = (Convert.ToDecimal(txtCharged.Text) + Convert.ToDecimal(btn.Text));
                    txtCharged.Text = t.ToString();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
          
           
        }

        private void btnGetTotalPrice_Click(object sender, EventArgs e)
        {
            try
            {
                txtCharged.Text = txtTotalCash.Text;
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }

        private void Discharge(int moduleID)
        {
            try
            {
                using (var dbContext = new RestaurantContext())
                {
                    if (!clickedDiscount)
                    {
                        Payments p = new Payments()
                        {
                            TotalPrice = Convert.ToDecimal(txtTotalCash.Text),
                            AmountPaid = Convert.ToDecimal(txtCharged.Text),
                            Date = DateTime.Now,
                            OrderNo = OrderNo,
                            PaymentModuleID = moduleID,

                        };

                        dbContext.Payments.Add(p);
                        dbContext.SaveChanges();

                        dbContext.Update_Table_State(this.Tag.ToString(), false);
                    }
                    else if (clickedDiscount)
                    {
                        int index = lblRound.Text.IndexOf("=");
                        string discountValue = lblRound.Text.Substring(0, index);

                        Payments p = new Payments()
                        {
                            TotalPrice = Convert.ToDecimal(txtTotalCash.Text),
                            AmountPaid = Convert.ToDecimal(txtCharged.Text),
                            Date = DateTime.Now,
                            OrderNo = OrderNo,
                            PaymentModuleID = moduleID,
                            Discount = discountValue,
                            DiscountPrice = discountPrice

                        };

                        dbContext.Payments.Add(p);
                        var paidQuery = dbContext.OrderHeader.Where(x => x.OrderNo == orderNo).FirstOrDefault();
                        paidQuery.State = 5;
                        dbContext.SaveChanges();

                        dbContext.Update_Table_State(this.Tag.ToString(), false);


                    }

                }

                UnLockOrder(OrderNo);
                this.Close();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void btnCash_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtCharged.Text))
            {
                Discharge(2);
            }
            else
            {
                MessageBox.Show("Nakit ödemek için bir ücret girmediniz.","ARWEN", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtCharged.Focus();
            }
           
        }

        private void btnCreditCard_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCharged.Text))
            {
                Discharge(1);
            }
            else
            {
                MessageBox.Show("Kredi kartıyla ödemek için bir ücret girmediniz.", "ARWEN", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtCharged.Focus();
            }
        }

        private void btnRestaurantTicket_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCharged.Text))
            {
                Discharge(3);
            }
            else
            {
                MessageBox.Show("Yemek kartıyla ödemek için bir ücret girmediniz.", "ARWEN", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtCharged.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private bool clickedDiscount = false;

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCharged.Text))
                {
                    if (totalCash.ToString() == txtCharged.Text)
                    {
                        MessageBox.Show("Tüm fiyata indirim yapamazsınız.", "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        GetDiscountPrice(Convert.ToDecimal(totalCash));
                        clickedDiscount = true;
                    }

                }
                else
                {
                    MessageBox.Show("İndirim değeri giriniz.", "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clickedDiscount = false;
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
           
        }

       

        private void btnTicket_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult pdr = printDialog1.ShowDialog();
                if (pdr == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
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
                graphics.DrawString("Masa: " + this.Tag,
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

                foreach (DataRow item in dtPayment.Rows)
                {
                    string productDescription = item[2].ToString().PadRight(30);
                    string productTotal = item[3].ToString();
                    gTotal += Convert.ToDecimal(productTotal);
                    string productLine = productDescription + productTotal;

                    graphic.DrawString(productLine, font, new SolidBrush(Color.Black), startX, startY + Offset);

                    Offset = Offset + (int)fontHeight + 5;

                }


                String Grosstotal = "Toplam = " + gTotal.ToString("c");
                underLine = "------------------------------------------";
                graphics.DrawString(underLine, new Font("Courier New", 10),
                    new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString(Grosstotal.PadRight(30), new Font("Courier New", 10),
                    new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
                String DrawnBy = "Admin";
                graphics.DrawString("Conductor - " + DrawnBy, new Font("Courier New", 10),
                    new SolidBrush(Color.Black), startX, startY + Offset);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        
    }
}