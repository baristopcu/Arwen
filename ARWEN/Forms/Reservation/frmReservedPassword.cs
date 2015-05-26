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
using System.Security.Cryptography;

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


        public static string GetMd5Hash(string input)
        {
            MD5 md5Hasher = MD5.Create();

            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("X2"));
            }

            return sBuilder.ToString();
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
                if (!string.IsNullOrEmpty(GetMd5Hash(txtPassword.Text)))
                {
                    if (GetMd5Hash(txtPassword.Text) == reservationPass)
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