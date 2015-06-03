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
using DevExpress.XtraRichEdit.API.Native;

namespace ARWEN.Forms
{
    public partial class frmReserved : DevExpress.XtraEditors.XtraForm
    {
        public frmReserved()
        {
            InitializeComponent();
        }

        private string _tableNo;
        private int reservationID;

        public string TableNo
        {
            get { return _tableNo; }
            set { _tableNo = value; }
        }

        private void frmReserved_Load(object sender, EventArgs e)
        {
            using (RestaurantContext dbContext = new RestaurantContext())
            {              
                var getReserveQuery = dbContext.Reservation.Where(x => x.TableNo == _tableNo).FirstOrDefault();
                int customerID = Convert.ToInt32(getReserveQuery.CustomerID);
                var getCustomer = dbContext.Customers.Where(x => x.CustomerID == customerID).FirstOrDefault();

                txtCustomerName.Text = getCustomer.ContactName;
                lblTable.Text = _tableNo;
                txtCapacity.Text = getReserveQuery.Capacity.ToString();
                txtEndDate.Text = getReserveQuery.EndDate.ToString();
                reservationID = getReserveQuery.ReservationID;

            }
        }

        private void EnableFields()
        {
            txtCapacity.Enabled = true;
            txtCustomerName.Enabled = true;
            txtEndDate.Enabled = true;
          
            
        }


        private void DisableFields()
        {
            txtCapacity.Enabled = false;
            txtCustomerName.Enabled = false;
            txtEndDate.Enabled = false;
           

        }


        private void btnReservationCancel_Click(object sender, EventArgs e)
        {
           
            using (RestaurantContext dbContext = new RestaurantContext())
            {
                var cancelReservation =
                    dbContext.Reservation.Where(x => x.ReservationID == reservationID).FirstOrDefault();
                cancelReservation.Cancel = 1;

                var tableValue = dbContext.RestaurantTables.Where(x => x.TableNo == _tableNo).FirstOrDefault();
                tableValue.State = 0;

                dbContext.SaveChanges();
                MessageBox.Show("Rezervasyon iptal edildi.", "ARWEN", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);

                this.Close();
                
            }
        }

        private bool update = false;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            update = true;
            EnableFields();

      
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (update)
                {
                    using (RestaurantContext dbContext = new RestaurantContext())
                    {

                        var updateReservation =
                            dbContext.Reservation.Where(x => x.ReservationID == reservationID).FirstOrDefault();
                        updateReservation.Capacity = Convert.ToInt32(txtCapacity.Text);
                        updateReservation.EndDate = Convert.ToDateTime(txtEndDate.Text);
                        dbContext.SaveChanges();

                    }

                    MessageBox.Show("Rezervasyon bilgileri güncellendi.", "ARWEN", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    DisableFields();
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void btnActivated_Click(object sender, EventArgs e)
        {
            try
            {
                using (RestaurantContext dbContext = new RestaurantContext())
                {
                    var usedReservation =
                        dbContext.Reservation.Where(x => x.ReservationID == reservationID).FirstOrDefault();
                    usedReservation.Used = 1;

                    var tableValue = dbContext.RestaurantTables.Where(x => x.TableNo == _tableNo).FirstOrDefault();
                    tableValue.State = 0;

                    dbContext.SaveChanges();
                    MessageBox.Show("Rezervasyon aktif edildi.", "ARWEN", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);

                    this.Close();

                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}