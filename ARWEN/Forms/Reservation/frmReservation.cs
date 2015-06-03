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
            try
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
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
     
        private void frmReservation_Load(object sender, EventArgs e)
        {           
            GetTables();
            GetCustomers();
        }

       
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (RestaurantContext dbContext = new RestaurantContext())
                {
                    var pass = dbContext.ReservationPasswords.FirstOrDefault();

                    DTO.Database.Reservation reserve = new DTO.Database.Reservation()
                    {
                        CustomerID = Convert.ToInt32(cmbCustomers.SelectedValue),
                        UserID = GlobalUser.UserID,
                        Capacity = Convert.ToInt32(nudCapacity.Text),
                        TableNo = Convert.ToString(cmbTables.SelectedValue),
                        Password = pass.Password,
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
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
     
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}