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
using System.Security.Cryptography;

namespace ARWEN.Forms.Settings.Reserve
{
    public partial class frmChangeReservePassword : DevExpress.XtraEditors.XtraForm
    {
        public frmChangeReservePassword()
        {
            InitializeComponent();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (RestaurantContext dbContext = new RestaurantContext())
            {
                var query = dbContext.ReservationPasswords.FirstOrDefault();
                if (query.Password == GetMd5Hash(txtOldPass.Text))
                {
                    if (txtNewPass.Text == txtNewPassAgain.Text)
                    {
                        if (txtNewPass.Text == txtOldPass.Text)
                        {
                            MessageBox.Show("Yeni şifreniz eski şifrenizle aynı olamaz.", "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            query.Password = GetMd5Hash(txtNewPass.Text);
                            dbContext.SaveChanges();
                            MessageBox.Show("Rezervasyon şifreleriniz başarıyla değiştirildi.",
                                "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Şifreler uyuşmuyor.", "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Eski şifrenizi doğru giriniz.", "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}