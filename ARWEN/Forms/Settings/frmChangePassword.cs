using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ARWEN.Class;
using ARWEN.DTO.Database;
using DevExpress.XtraEditors;

namespace ARWEN.Forms.Settings
{
    public partial class frmChangePassword : DevExpress.XtraEditors.XtraForm
    {
        public frmChangePassword()
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
                var query = dbContext.Users.Where(x => x.UserID == Global.UserID).FirstOrDefault();
                if (query.Password == GetMd5Hash(txtOldPass.Text))
                {
                    if (txtNewPass.Text == txtNewPassAgain.Text)
                    {
                        if (txtNewPass.Text == txtOldPass.Text)
                        {
                            MessageBox.Show("Yeni şifreniz eski şifrenizle aynı olamaz .", "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            dbContext.Update_User_Pass(Global.UserID, GetMd5Hash(txtNewPass.Text));
                            dbContext.SaveChanges();
                            MessageBox.Show("Sayın" + " '" + Global.FullName + "' " + "şifreniz başarıyla değiştirildi.",
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

        private void frmChangePassword_Load(object sender, EventArgs e)
        {

        }
    }
}