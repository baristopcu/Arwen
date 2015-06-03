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

namespace ARWEN.Forms
{
    public partial class frmGroups : DevExpress.XtraEditors.XtraForm
    {
        public frmGroups()
        {
            InitializeComponent();
        }

        Groups g = new Groups();
        bool saveNew = true;
      
        public void SetFreeGroup()
        {
            txtName.Enabled = true;         
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
          
        }

        public void SetLockGroup()
        {
            txtName.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
          
            Clear();
        }

        public void Clear()
        {
            txtName.Text = "";

        }


        private void GetGroups()
        {
            try
            {
                using (var dbContext = new RestaurantContext())
                {
                    dbContext.Configuration.LazyLoadingEnabled = false;
                    var groupsQuery = dbContext.Groups.ToList();
                    gridViewGroups.DataSource = new BindingSource(groupsQuery, "");
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!saveNew)
                {
                    using (RestaurantContext dbContext = new RestaurantContext())
                    {
                        var query = dbContext.Groups.Where(x => x.GroupID == g.GroupID).FirstOrDefault();
                        query.GroupName = txtName.Text;
                        dbContext.SaveChanges();
                        MessageBox.Show("Kategori başarıyla güncellendi.", "ARWEN",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetGroups();
                        SetLockGroup();

                    }
                }
                else if (saveNew)
                {
                    using (RestaurantContext dbContext = new RestaurantContext())
                    {
                        Groups group = new Groups
                        {
                            GroupName = txtName.Text
                        };
                        dbContext.Groups.Add(group);
                        dbContext.SaveChanges();
                        MessageBox.Show("Yeni kategori başarıyla eklendi.", "ARWEN", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        GetGroups();
                        SetLockGroup();
                    }
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGroups_Load(object sender, EventArgs e)
        {
            GetGroups();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Bu kategoriyi silmek istediğinize emin misiniz?", "ARWEN", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    int index = gridView1.FocusedRowHandle;
                    g.GroupID = Convert.ToInt32(gridView1.GetRowCellValue(index, "GroupID").ToString());

                    using (RestaurantContext dbContext = new RestaurantContext())
                    {
                        Groups query = dbContext.Groups.Where(x => x.GroupID == g.GroupID).FirstOrDefault();
                        dbContext.Groups.Remove(query);
                        dbContext.SaveChanges();
                        MessageBox.Show("Kategori silindi.", "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetGroups();
                    }
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void btnNewGroup_Click(object sender, EventArgs e)
        {
            SetFreeGroup();
            saveNew = true;
        }

        private void gridViewGroups_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                SetFreeGroup();
                saveNew = false;
                int index = gridView1.FocusedRowHandle;
                g.GroupID = Convert.ToInt32(gridView1.GetRowCellValue(index, "GroupID").ToString());

                using (RestaurantContext dbContext = new RestaurantContext())
                {
                    var query = dbContext.Groups.Where(x => x.GroupID == g.GroupID).FirstOrDefault();
                    txtName.Text = query.GroupName;

                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }
    }
}