using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ARWEN.DTO.Database;
using DevExpress.XtraEditors;

namespace ARWEN.Forms
{
    public partial class frmCompanySettings : DevExpress.XtraEditors.XtraForm
    {
        public frmCompanySettings()
        {
            InitializeComponent();
        }

        private RestaurantContext dbContext = new RestaurantContext();
        private bool contayn = true;
        private void frmCompanySettings_Load(object sender, EventArgs e)
        {

            var query = dbContext.Settings.FirstOrDefault();
            if (query == null)
            {
                contayn = false;
            }
            txtAdres.Text = query.Address;
            txtEmail.Text = query.Email;
            txtTelephone.Text = query.PhoneNumber;
            txtName.Text = query.RestaurantName;
            txtWebSite.Text = query.WebsiteURL;
            imgCompanyLogo.Image = byteArrayToImage(query.Logo);
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            using (RestaurantContext dbContext = new RestaurantContext())
            {
                DTO.Database.Settings setting = new  DTO.Database.Settings()
                {
                    RestaurantName = txtName.Text,
                    PhoneNumber = txtTelephone.Text,
                    WebsiteURL = txtWebSite.Text,
                    Email = txtEmail.Text,
                    Address = txtAdres.Text,
                    Logo = Content
                };
                if (!contayn)
                {
                    dbContext.Settings.Add(setting);
                    dbContext.SaveChanges();
                    MessageBox.Show("Şirket ayarlarınız başarıyla kayıt edildi.", "ARWEN", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                }
                else
                {
                    var query = dbContext.Settings.FirstOrDefault();
                    query.Address = txtAdres.Text;
                    query.Email = txtEmail.Text;
                    query.Logo = Content;
                    query.PhoneNumber = txtTelephone.Text;
                    query.RestaurantName = txtName.Text;
                    query.WebsiteURL = txtWebSite.Text;
                    dbContext.SaveChanges();
                    MessageBox.Show("Şirket ayarlarınız başarıyla güncellendi.", "ARWEN", MessageBoxButtons.OK,
             MessageBoxIcon.Information);
                }
              
            
            }
        }

        public byte[] Content { get; set; }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files|*.jpg;*.png;*.gif";
            DialogResult dgr = ofd.ShowDialog();
            if (dgr == DialogResult.OK)
            {
               Image q  = Image.FromFile(ofd.FileName);
               imgCompanyLogo.Image = q;
               Content = imageToByteArray(q);
               
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}