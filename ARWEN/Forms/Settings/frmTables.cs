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
    public partial class frmTables : DevExpress.XtraEditors.XtraForm
    {
        public frmTables()
        {
            InitializeComponent();
        }

        bool saveNew = true;
        public void SetFreeTable()
        {
            txtName.Enabled = true;
            txtDescription.Enabled = true;
            txtCapacity.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
           
        }

        public void SetLockTable()
        {
            txtName.Enabled = false;
            txtDescription.Enabled = false;
            txtCapacity.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            Clear();
        }

        public void Clear()
        {
            txtDescription.Text = "";
            txtName.Text = "";
            txtCapacity.Text = "";

        }

        private RestaurantTables t = new RestaurantTables();

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!saveNew)
            {
                using (RestaurantContext dbContext = new RestaurantContext())
                {
                    var query = dbContext.RestaurantTables.Where(x => x.TableNo == t.TableNo).FirstOrDefault();
                    query.Capacity = Convert.ToByte(txtCapacity.Text);
                    query.Description = txtDescription.Text;
                    dbContext.SaveChanges();
                    MessageBox.Show("Masa başarıyla güncellendi.", "ARWEN",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetTables();
                    SetLockTable();

                }
            }
            else if (saveNew)
            {
                RestaurantTables table = new RestaurantTables();
                using (RestaurantContext dbContext = new RestaurantContext())
                {
                    table.TableNo = txtName.Text;
                    table.Capacity = Convert.ToByte(txtCapacity.Text);
                    table.Description = txtDescription.Text;
                    dbContext.RestaurantTables.Add(table);
                    dbContext.SaveChanges();
                    MessageBox.Show("Yeni masa başarıyla eklendi.", "ARWEN", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    GetTables();
                    SetLockTable();
                }
            }
          
        }

        private void GetTables()
        {
            using (var dbContext = new RestaurantContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                var tablesQuery = dbContext.RestaurantTables.ToList();
                gridViewTables.DataSource = new BindingSource(tablesQuery, "");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTables_Load(object sender, EventArgs e)
        {
            GetTables();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Bu masayı silmek istediğinize emin misiniz?", "ARWEN", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int index = gridView1.FocusedRowHandle;
                t.TableNo = gridView1.GetRowCellValue(index, "TableNo").ToString();

                using (RestaurantContext dbContext = new RestaurantContext())
                {
                    RestaurantTables query = dbContext.RestaurantTables.Where(x => x.TableNo == t.TableNo).FirstOrDefault();
                    dbContext.RestaurantTables.Remove(query);
                    dbContext.SaveChanges();
                    MessageBox.Show("Masa silindi.", "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetTables();
                }
            }
        }

        private void gridViewTables_DoubleClick(object sender, EventArgs e)
        {
            SetFreeTable();
            saveNew = false;
            int index = gridView1.FocusedRowHandle;
            t.TableNo = gridView1.GetRowCellValue(index, "TableNo").ToString();

            using (RestaurantContext dbContext = new RestaurantContext())
            {
                var query = dbContext.RestaurantTables.Where(x => x.TableNo == t.TableNo).FirstOrDefault();
                txtName.Text = query.TableNo;
                txtCapacity.Text = query.Capacity.ToString();
                txtDescription.Text = query.Description;
            }
        }

        private void btnNewTable_Click(object sender, EventArgs e)
        {
            SetFreeTable();
            saveNew = true;
        }
    }
}