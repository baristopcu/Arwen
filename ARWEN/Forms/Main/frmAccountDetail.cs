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
using ARWEN.DTO.Class;

namespace ARWEN.Forms
{
    public partial class frmAccountDetail : DevExpress.XtraEditors.XtraForm
    {
        public frmAccountDetail()
        {
            InitializeComponent();
        }

        Jarvis j = new Jarvis();

        private string detailName;

        public string DetailName
        {
            get { return detailName; }
            set { detailName = value; }
        }

        private void GetAccountDetails(string accountName)
        {
            try
            {
                using (RestaurantContext dbContext = new RestaurantContext())
                {
                    switch (accountName)
                    {
                        case "Satışlar":
                            var sellQuery = dbContext.Payments.AsNoTracking().Join(dbContext.PaymentModules, p => p.PaymentModuleID, pm => pm.PaymentModuleID, (p, pm) => new { p, pm }).Select(x => new
                            {
                                x.p.PaymentID,
                                x.p.OrderNo,
                                x.p.TotalPrice,
                                x.p.Date,
                                x.p.AmountPaid,
                                x.p.Discount,
                                x.p.DiscountPrice,
                                x.pm.Name
                            }).ToList();

                            gridControl1.DataSource = new BindingSource(sellQuery, "");
                            break;

                        case "Nakit":
                            var cashQuery = dbContext.Payments.AsNoTracking().Join(dbContext.PaymentModules, p => p.PaymentModuleID, pm => pm.PaymentModuleID, (p, pm) => new { p, pm }).Where(y => y.p.PaymentModuleID == 2).Select(x => new
                            {
                                x.p.PaymentID,
                                x.p.OrderNo,
                                x.p.TotalPrice,
                                x.p.Date,
                                x.p.AmountPaid,
                                x.p.Discount,
                                x.p.DiscountPrice,
                                x.pm.Name
                            }).ToList();
                            gridControl1.DataSource = new BindingSource(cashQuery, "");
                            break;

                        case "Kredi Kartı":
                            var creditQuery = dbContext.Payments.AsNoTracking().Join(dbContext.PaymentModules, p => p.PaymentModuleID, pm => pm.PaymentModuleID, (p, pm) => new { p, pm }).Where(y => y.p.PaymentModuleID == 1).Select(x => new
                            {
                                x.p.PaymentID,
                                x.p.OrderNo,
                                x.p.TotalPrice,
                                x.p.Date,
                                x.p.AmountPaid,
                                x.p.Discount,
                                x.p.DiscountPrice,
                                x.pm.Name
                            }).ToList();
                            gridControl1.DataSource = new BindingSource(creditQuery, "");
                            break;

                        case "İndirimler":
                            var discountQuery = dbContext.Payments.AsNoTracking().Join(dbContext.PaymentModules, p => p.PaymentModuleID, pm => pm.PaymentModuleID, (p, pm) => new { p, pm }).Where(y => y.p.Discount != null).Select(x => new
                            {
                                x.p.PaymentID,
                                x.p.OrderNo,
                                x.p.TotalPrice,
                                x.p.Date,
                                x.p.AmountPaid,
                                x.p.Discount,
                                x.p.DiscountPrice,
                                x.pm.Name
                            }).ToList();
                            gridControl1.DataSource = new BindingSource(discountQuery, "");
                            break;
                        case "Yemek Kartı":
                            var ticketQuery = dbContext.Payments.AsNoTracking().Join(dbContext.PaymentModules, p => p.PaymentModuleID, pm => pm.PaymentModuleID, (p, pm) => new { p, pm }).Where(y => y.p.PaymentModuleID == 3).Select(x => new
                            {
                                x.p.PaymentID,
                                x.p.OrderNo,
                                x.p.TotalPrice,
                                x.p.Date,
                                x.p.AmountPaid,
                                x.p.Discount,
                                x.p.DiscountPrice,
                                x.pm.Name
                            }).ToList();
                            gridControl1.DataSource = new BindingSource(ticketQuery, "");
                            break;


                    }
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void frmAccountDetail_Load(object sender, EventArgs e)
        {
            try
            {
                j.cozunurlukAyarla(this);
                GetAccountDetails(detailName);
                this.Text = detailName;
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
    }
}