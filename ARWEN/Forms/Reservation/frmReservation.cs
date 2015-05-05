using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ARWEN.Class;
using ARWEN.DTO.Database;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Layout;

namespace ARWEN.Forms
{
    public partial class frmReservation : DevExpress.XtraEditors.XtraForm
    {
        public frmReservation()
        {
            InitializeComponent();
        }

        private static string lastId;

        private void GetTables()
        {
            using (var dbContext = new RestaurantContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                var query = dbContext.RestaurantTables.Where(x => x.State == 0).ToList();
                cmbTables.DataSource = query;
                cmbTables.ValueMember = "TableNo";
                cmbTables.DisplayMember = "TableNo";

            }
        }

        private void GetCustomers()
        {
            using (var dbContext = new RestaurantContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                var query = dbContext.Customers.ToList();
                cmbCustomers.DataSource = query;
                cmbCustomers.ValueMember = "CustomerID";
                cmbCustomers.DisplayMember = "ContactName";

            }
        }

        private void DateTimeSelectHour()
        {
            dtEndDate.Format = DateTimePickerFormat.Custom;
            dtEndDate.CustomFormat = "HH:mm"; // Only use hours and minutes
            dtEndDate.ShowUpDown = true;
        }

        public string CreatePassword()
        {
            string pas = Guid.NewGuid().ToString();
            string sonKod = string.Empty;
            foreach (char item in pas)
            {
                if (char.IsNumber(item))
                {
                    sonKod += item;
                }
            }

            sonKod = sonKod.Substring(0, 5);

            return sonKod;

        }

        private void frmReservation_Load(object sender, EventArgs e)
        {           
            GetTables();
            GetCustomers();
        }

       
        private void btnSave_Click(object sender, EventArgs e)
        {
            string pass = CreatePassword();
            using (RestaurantContext dbContext = new RestaurantContext())
            {
                DTO.Database.Reservation reserve = new DTO.Database.Reservation()
                {
                    CustomerID = Convert.ToInt32(cmbCustomers.SelectedValue),
                    UserID = Global.UserID,
                    Capacity = Convert.ToInt32(nudCapacity.Text),
                    TableNo = Convert.ToString(cmbTables.SelectedValue),
                    Password = pass,
                    StartDate = Convert.ToDateTime(dtStartDate.Value),
                    EndDate = Convert.ToDateTime(dtEndDate.Value)
                    
                };

                dbContext.Reservation.Add(reserve);
                dbContext.SaveChanges();

                lastId = Convert.ToString(reserve.TableNo);

                var query = dbContext.RestaurantTables.Where(x => x.TableNo == lastId).FirstOrDefault();
                query.State = 2;
                dbContext.SaveChanges();
                

                MessageBox.Show("Rezervasyon başarıyla kayıt edildi.", "ARWEN", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);          
                this.Close();

            }
        }
    }
}