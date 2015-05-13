﻿using System;
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
using System.Security.Cryptography;

namespace ARWEN.Forms
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Kullanıcı adı veya Şifre alanları boş bırakılamaz.", "ARWEN", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else if (txtPassword.Text.Length < 3)
            {
                MessageBox.Show("Şifre 3 veya 3 karakterden aşağı olamaz.", "ARWEN", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
            else
            {
                if (txtUserName.Text == "Config" && txtPassword.Text == "1234")
                {
                    MessageBox.Show("Ayarlar");
                }
                else
                {
                    using (RestaurantContext dbContext = new RestaurantContext())
                    {
                        string pass = GetMd5Hash(txtPassword.Text);
                       var query = dbContext.Users.Where(
                            x => x.UserName == txtUserName.Text && x.Password == pass)
                            .FirstOrDefault();
                        if (query == null)
                        {
                            MessageBox.Show("Kullanıcı adı veya Şifre yanlış!", "ARWEN", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            txtPassword.Text = "";
                        }
                        else
                        {
                          
                            Global.FullName = query.FullName;
                            Global.UserName = query.FullName;
                            Global.UserID = query.UserID;
                            Global.Password = query.Password;
                            Global.PermissionID = query.PermissionID;

                            //frmMain frm  = new frmMain();
                            //this.Hide();
                            //frm.ShowDialog();
                            //this.Show();
                            
                            MessageBox.Show("Giriş başarılı!", "ARWEN", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }
    }
}