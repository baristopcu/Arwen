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

namespace ARWEN.Forms.Main
{
    public partial class frmKitchenUser : DevExpress.XtraEditors.XtraForm
    {
        public frmKitchenUser()
        {
            InitializeComponent();
        }

        private void GetProducts()
        {
            try
            {
                using (var dbContext = new RestaurantContext())
                {
                    dbContext.Configuration.LazyLoadingEnabled = false;
                    var productsQuery = dbContext.Products.ToList();
                    gridControlProducts.DataSource = new BindingSource(productsQuery, "");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }

        public static void ButtonCreate(int kategoriSayisi, FlowLayoutPanel flwLayoutPanel)
        {
            List<string> tableNameList = new List<string>();
            List<byte> tableStateList = new List<byte>();

            try
            {
                using (RestaurantContext dbContext = new RestaurantContext())
                {
                    tableNameList.AddRange(dbContext.RestaurantTables.Where(x => x.State == 1).Select(y => y.TableNo).ToList());
                    tableStateList.AddRange(dbContext.RestaurantTables.Where(x => x.State == 1).Select(y => y.State).ToList());

                }

                for (int i = 0; i < kategoriSayisi; i++)
                {
                    SimpleButton sndrButton = new SimpleButton();
                    sndrButton.Text = tableNameList[i];
                    sndrButton.Tag = tableStateList[i];
                    if (tableStateList[i] == 0)
                    {
                        sndrButton.Image = Image.FromFile(Application.StartupPath + @"\Images\Available.png");
                    }
                    else if (tableStateList[i] == 1)
                    {
                        sndrButton.Image = Image.FromFile(Application.StartupPath + @"\Images\Busy.png");
                    }
                    else if (tableStateList[i] == 2)
                    {
                        sndrButton.Image = Image.FromFile(Application.StartupPath + @"\Images\Closed.png");
                    }

                    sndrButton.Width = 200;
                    sndrButton.Height = 60;

                    flwLayoutPanel.Controls.Add(sndrButton);
                    sndrButton.Click += sndrButton_Click;
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }

        private static SimpleButton tableButton;

        private static void sndrButton_Click(object sender, EventArgs e)
        {
            try
            {
                tableButton = (SimpleButton)sender;

                if (Convert.ToByte(tableButton.Tag) == 1)
                {
                    using (RestaurantContext dbContext = new RestaurantContext())
                    {
                        var query = dbContext.OrderHeader.Where(x => x.TableNo == tableButton.Text).FirstOrDefault();

                        if (query == null)
                        {
                            frmKitchenUserDesk frm = new frmKitchenUserDesk();
                            frm.Tag = tableButton.Text;
                            frm.TableState = Convert.ToByte(tableButton.Tag);
                            frm.ShowDialog();
                        }
                        else if (query.LockState == true)
                        {
                            var getUserQuery =
                                dbContext.OrderHeader.AsNoTracking()
                                    .Join(dbContext.Users, od => od.LockKeeperUserID, p => p.UserID, (od, p) => new { od, p })
                                    .Where(b => b.od.TableNo == tableButton.Text)
                                    .Select(s => new
                                    {
                                        Name = s.p.FullName
                                    }).FirstOrDefault();

                            MessageBox.Show("Bu masa şuan" + " '" + getUserQuery.Name + "' " + "tarafından düzenlenmekte.",
                                "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (query.LockState == false)
                        {
                            frmKitchenUserDesk frm = new frmKitchenUserDesk();
                            frm.Tag = tableButton.Text;
                            frm.TableState = Convert.ToByte(tableButton.Tag);
                            frm.ShowDialog();
                        }
                    }
                }
                else if (Convert.ToByte(tableButton.Tag) == 0)
                {
                    frmKitchenUserDesk frm = new frmKitchenUserDesk();
                    frm.Tag = tableButton.Text;
                    frm.TableState = Convert.ToByte(tableButton.Tag);
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
          

        }

        private void frmKitchenUser_Load(object sender, EventArgs e)
        {
            try
            {
                GetProducts();

                using (RestaurantContext dbContext = new RestaurantContext())
                {
                    int sayi = dbContext.RestaurantTables.Where(x => x.State == 1).Count();
                    ButtonCreate(sayi, flowLayoutPanel2);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "Availability")
                {
                    gridView1.SetRowCellValue(e.RowHandle, e.Column, e.Value);

                    int index = gridView1.FocusedRowHandle;
                    int ID = Convert.ToInt32(gridView1.GetRowCellValue(index, "ProductID").ToString());

                    using (RestaurantContext dbContext = new RestaurantContext())
                    {
                        var checkQuery = dbContext.Products.Where(x => x.ProductID == ID).FirstOrDefault();
                        checkQuery.Availability = Convert.ToBoolean(e.Value);
                        dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
    }
}