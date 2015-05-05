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

namespace ARWEN.Forms.Reservation
{
    public partial class frmReservedPassword : DevExpress.XtraEditors.XtraForm
    {
        public frmReservedPassword()
        {
            InitializeComponent();
        }

        private string _tableNo;
        private string reservationPass;

        public string TableNo
        {
            get { return _tableNo; }
            set { _tableNo = value; }
        }


        private void frmReservedPassword_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            using (RestaurantContext dbContext = new RestaurantContext())
            {
                var getReserveQuery = dbContext.Reservation.Where(x => x.TableNo == _tableNo).FirstOrDefault();
                reservationPass = getReserveQuery.Password;
                if (!string.IsNullOrEmpty(txtPassword.Text))
                {
                    if (txtPassword.Text == reservationPass)
                    {
   
                        frmReserved frm = new frmReserved();
                        this.Close();
                        frm.TableNo = _tableNo;
                        frm.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("Rezervasyon şifreniz yanlış.", "ARWEN", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Şifre boş bırakılamaz.", "ARWEN", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }


            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}