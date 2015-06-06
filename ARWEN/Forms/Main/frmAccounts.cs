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
    public partial class frmAccounts : DevExpress.XtraEditors.XtraForm
    {
        public frmAccounts()
        {
            InitializeComponent();
        }
  

        private void frmAccounts_Load(object sender, EventArgs e)
        {
            using (RestaurantContext dbContext = new RestaurantContext())
            {
                var creditCardTotal = dbContext.Payments.Where(x => x.PaymentModuleID == 1).Sum(y => y.TotalPrice);
                var restaurantTicketTotal = dbContext.Payments.Where(x => x.PaymentModuleID == 3).Sum(y => y.TotalPrice);
                var cashTotal = dbContext.Payments.Where(x => x.PaymentModuleID == 2).Sum(y => y.TotalPrice);
                var total = dbContext.Payments.Sum(y => y.TotalPrice);
                var discountTotal = dbContext.Payments.Sum(y => y.DiscountPrice);

                SetAccounts(total);
                SetCredits(discountTotal);
                SetCash(cashTotal);
                SetCreditCard(creditCardTotal);
                SetRestaurantTicket(restaurantTicketTotal);

            }
        }

        private void SetAccounts(decimal? total)
        {
            ListViewItem li = new ListViewItem();
            li.Text = "Satışlar";
            li.SubItems.Add(total.ToString());
            li.SubItems.Add("(" + total.ToString() + ")");
            listView1.Items.Add(li);
        }
        private void SetCredits(decimal? total)
        {
            ListViewItem li = new ListViewItem();
            li.Text = "İndirimler";
            li.SubItems.Add("-");
            li.SubItems.Add(total.ToString());
            listView1.Items.Add(li);
        }
        private void SetCash(decimal? total)
        {
            ListViewItem li = new ListViewItem();
            li.Text = "Nakit";
            li.SubItems.Add("-");
            li.SubItems.Add(total.ToString());
            listView1.Items.Add(li);
        }
        private void SetCreditCard(decimal? total)
        {
            ListViewItem li = new ListViewItem();
            li.Text = "Kredi Kartı";
            li.SubItems.Add("-");
            li.SubItems.Add(total.ToString());
            listView1.Items.Add(li);
        }
        private void SetRestaurantTicket(decimal? total)
        {
            ListViewItem li = new ListViewItem();
            li.Text = "Yemek Kartı";
            li.SubItems.Add("-");
            li.SubItems.Add(total.ToString());
            listView1.Items.Add(li);
        }

        private void btnFindTicket_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                string a = listView1.SelectedItems[0].Text;
                frmAccountDetail frm = new frmAccountDetail();
                frm.DetailName = a;
                this.Hide();
                frm.ShowDialog();
                this.Show();
            }
            else
            {
                return;
            }
            
        }

     

        private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listView1.Columns[e.ColumnIndex].Width;
        }

    }
}