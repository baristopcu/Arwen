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
    public partial class frmUnits : DevExpress.XtraEditors.XtraForm
    {
        public frmUnits()
        {
            InitializeComponent();
        }

        Units u = new Units();
        bool saveNew = true;
        private void GetUnits()
        {
            using (var dbContext = new RestaurantContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                var unitsQuery = dbContext.Units.ToList();
                gridViewUnits.DataSource = new BindingSource(unitsQuery, "");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!saveNew)
            {
                using (RestaurantContext dbContext = new RestaurantContext())
                {
                    var query = dbContext.Units.Where(x => x.UnitName == u.UnitName).FirstOrDefault();     
                    query.ShortName = txtShortName.Text;             
                    dbContext.SaveChanges();
                    MessageBox.Show("Birim başarıyla güncellendi.", "ARWEN",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetUnits();
                    SetLockUnit();

                }
            }
            else if (saveNew)
            {
                Units unit = new Units();
                using (RestaurantContext dbContext = new RestaurantContext())
                {
                    unit.UnitName = txtName.Text;
                    unit.ShortName = txtShortName.Text;
                    dbContext.Units.Add(unit);
                    dbContext.SaveChanges();
                    MessageBox.Show("Yeni birim başarıyla eklendi.", "ARWEN", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    GetUnits();
                    SetLockUnit();
                }
            }
          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUnits_Load(object sender, EventArgs e)
        {
            GetUnits();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Bu birimi silmek istediğinize emin misiniz?", "ARWEN", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int index = gridView1.FocusedRowHandle;
                u.UnitName = gridView1.GetRowCellValue(index, "UnitName").ToString();

                using (RestaurantContext dbContext = new RestaurantContext())
                {
                    Units query = dbContext.Units.Where(x => x.UnitName == u.UnitName).FirstOrDefault();
                    dbContext.Units.Remove(query);
                    dbContext.SaveChanges();
                    MessageBox.Show("Birim silindi.", "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetUnits();
                }
            }
        }

       
        public void SetFreeUnit()
        {
            txtName.Enabled = true;
            txtShortName.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
           
        }

        public void SetLockUnit()
        {
            txtName.Enabled = false;
            txtShortName.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            Clear();
        }

        public void Clear()
        {
            txtShortName.Text = "";
            txtName.Text = "";
           
        }

        private void btnNewUnit_Click(object sender, EventArgs e)
        {
            SetFreeUnit();
            saveNew = true;
        }

        private void gridViewUnits_DoubleClick(object sender, EventArgs e)
        {
            SetFreeUnit();
            saveNew = false;
            int index = gridView1.FocusedRowHandle;
            u.UnitName = gridView1.GetRowCellValue(index, "UnitName").ToString();

            using (RestaurantContext dbContext = new RestaurantContext())
            {
                var query = dbContext.Units.Where(x => x.UnitName == u.UnitName).FirstOrDefault();
                txtName.Text = query.UnitName;
                txtShortName.Text = query.ShortName;
              
            }
        }

      
    }
}