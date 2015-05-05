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

namespace ARWEN.Forms
{
    public partial class frmUsers : DevExpress.XtraEditors.XtraForm
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        Users u = new Users();
        RestaurantContext dbContext = new RestaurantContext();
        bool saveNew = true;


        public void GetPermission()
        {

            var query = dbContext.Permissions.ToList();
            cmbPermission.DataSource = query;
            cmbPermission.ValueMember = "PermissionID";
            cmbPermission.DisplayMember = "Description";


        }

        public void GetUsers()
        {

            using (var dbContext = new RestaurantContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;         
                var usersQuery =
                    dbContext.Users.AsNoTracking()
                        .Join(dbContext.Permissions, u => u.PermissionID, p => p.PermissionID, (u, p) => new {u, p})
                        .Select(y=> new
                        {
                            y.u.UserName,
                            y.u.FullName,
                            y.u.UserID,
                            y.p.Description,
                            y.u.Password

                        }).ToList();

                gridViewUsers.DataSource = new BindingSource(usersQuery, "");
                
            }


        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            GetPermission();
            GetUsers();
            SetLockUser();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if (saveNew)
            {
                using (RestaurantContext dbContext = new RestaurantContext())
                {
                    Users user = new Users();
                    if (txtPassword.Text == txtConfirmPassword.Text)
                    {
                        user.FullName = txtFullName.Text;
                        user.UserName = txtName.Text;
                        user.Password = GetMd5Hash(txtPassword.Text);
                        user.PermissionID = Convert.ToByte(cmbPermission.SelectedValue);
                        dbContext.Users.Add(user);
                        dbContext.SaveChanges();
                        GetUsers();
                        SetLockUser();
                        MessageBox.Show("Yeni kullanıcı başarıyla eklendi.", "ARWEN",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Girilen şifreler uyuşmuyor, lütfen kontrol edip tekrar deneyiniz.", "ARWEN",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else if (!saveNew)
            {
                using (RestaurantContext dbContext = new RestaurantContext())
                {
                    Users user = new Users();
                    if (txtPassword.Text == txtConfirmPassword.Text)
                    {
                        var query = dbContext.Users.Where(x => x.UserID == u.UserID).FirstOrDefault();
                        query.UserName = txtName.Text;
                        query.FullName = txtFullName.Text;
                        query.Password = txtPassword.Text;
                        query.PermissionID = Convert.ToByte(cmbPermission.SelectedValue);
                        dbContext.SaveChanges();
                        MessageBox.Show("Kullanıcı başarıyla güncellendi.", "ARWEN",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetUsers();
                        SetLockUser();
                    }
                }
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Bu kullanıcıyı silmek istediğinize emin misiniz?", "ARWEN", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int index = gridView1.FocusedRowHandle;
                u.UserID = Convert.ToInt32(gridView1.GetRowCellValue(index, "UserID").ToString());

                using (RestaurantContext dbContext = new RestaurantContext())
                {
                    Users query = dbContext.Users.Where(x => x.UserID == u.UserID).FirstOrDefault();
                    dbContext.Users.Remove(query);
                    dbContext.SaveChanges();
                    MessageBox.Show("Kullanıcı silindi.", "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetUsers();
                }
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Bu kullanıcının şifresini sıfırlamak istediğinize emin misiniz?", "ARWEN", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int index = gridView1.FocusedRowHandle;
                u.UserID = Convert.ToInt32(gridView1.GetRowCellValue(index, "UserID").ToString());
                u.FullName = gridView1.GetRowCellValue(index, "FullName").ToString();
                using (RestaurantContext dbContext = new RestaurantContext())
                {
                    dbContext.Reset_User_Password(u.UserID);
                    MessageBox.Show("'" + u.FullName + "' " + "Adlı kullanıcının şifresi başarıyla sıfırlandı.", "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetUsers();
                }

            }
        }

       
        public void SetFreeUser()
        {
            txtName.Enabled = true;
            txtFullName.Enabled = true;
            txtConfirmPassword.Enabled = true;
            txtPassword.Enabled = true;
            cmbPermission.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;

        }

        public void SetLockUser()
        {
            txtName.Enabled = false;
            txtFullName.Enabled = false;
            txtConfirmPassword.Enabled = false;
            txtPassword.Enabled = false;
            cmbPermission.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            
            Clear();
        }

        public void Clear()
        {
            txtFullName.Text = "";
            txtName.Text = "";
            txtConfirmPassword.Text = "";
            txtPassword.Text = "";
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            SetFreeUser();
            saveNew = true;
        }

        private void gridViewUsers_DoubleClick(object sender, EventArgs e)
        {
            SetFreeUser();
            saveNew = false;
            int index = gridView1.FocusedRowHandle;
            u.UserID = Convert.ToInt32(gridView1.GetRowCellValue(index, "UserID").ToString());


            var query = dbContext.Users.Where(x => x.UserID == u.UserID).FirstOrDefault();
            cmbPermission.SelectedValue = query.PermissionID;
            txtName.Text = query.UserName;
            txtFullName.Text = query.FullName;
            txtPassword.Text = query.Password;
            txtConfirmPassword.Text = query.Password;

        }
    }
}