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
    public partial class frmKitchenUserDesk : DevExpress.XtraEditors.XtraForm
    {
        public frmKitchenUserDesk()
        {
            InitializeComponent();

            dtProducts.Columns.Add("ProductID", typeof(Int64));
            dtProducts.Columns.Add("Amount", typeof(int));
            dtProducts.Columns.Add("ProductName", typeof(string));
            dtProducts.Columns.Add("UnitName", typeof(string));
            dtProducts.Columns.Add("NotEditable",typeof(Boolean));

        }

        #region Fields
        long orderNo;
        DataTable dtProducts = new DataTable();
        Products products = new Products();
        byte _tableState;
        public byte TableState
        {
            get { return _tableState; }
            set { _tableState = value; }
        } 
        #endregion

        public void StateControl(byte State)
        {
            List<object> orderProductsList = new List<object>();
            int Adet;
            if (State == 1) //EDİT
            {
                using (RestaurantContext dbContext = new RestaurantContext())
                {
                    string controlTableNo = this.Tag.ToString();
                    orderNo = dbContext.OrderHeader.Where(o => o.TableNo == controlTableNo).Where(x => x.State < 5).Select(y => y.OrderNo).FirstOrDefault();
                    int detailRow = dbContext.Get_Order_Detail(orderNo).Count();

                    for (int i = 0; i < detailRow; i++)
                    {
                        var query =
                            dbContext.OrderDetail.AsNoTracking()
                                .Join(dbContext.Products, od => od.ProductID, p => p.ProductID, (od, p) => new { od, p })
                                .Where(b => b.od.OrderNo == orderNo)
                                .Select(s => new
                                {
                                    s.od.OrderDetailID,
                                    s.od.ProductID,
                                    s.p.ProductName,
                                    s.p.UnitName,
                                    s.od.Amount,
                                    s.od.EditState,
                                    s.od.NotEditable,
                                    s.od.OrderPrice,
                                    s.od.EditAmount
                                }).AsQueryable();

                        orderProductsList.AddRange(query.ToList());

                        foreach (var result in query)
                        {
                            Adet = result.Amount;
                            products.ProductName = result.ProductName;
                            products.Price = Convert.ToDecimal(result.OrderPrice);
                            products.ProductID = result.ProductID;
                            products.UnitName = result.UnitName;
                            dtProducts.Rows.Add(products.ProductID, Adet, products.ProductName, products.UnitName, result.NotEditable);
                            gridControl1.DataSource = dtProducts;
                        }
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("HATA");
            }

        }

        private void frmKitchenUserDesk_Load(object sender, EventArgs e)
        {
            StateControl(TableState);
            this.Text = this.Tag.ToString();
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "NotEditable")
            {             
                int index = gridView1.FocusedRowHandle;
                int ID = Convert.ToInt32(gridView1.GetRowCellValue(index, "ProductID").ToString());

                using (RestaurantContext dbContext = new RestaurantContext())
                {

                    var checkQuery = dbContext.Products.Where(x => x.ProductID == ID).FirstOrDefault();
                    if(!checkQuery.Availability)
                    {
                        gridView1.SetRowCellValue(e.RowHandle, e.Column, e.Value);

                        var notEditableQuery = dbContext.OrderDetail.Where(x => x.ProductID == ID && x.OrderNo == orderNo).FirstOrDefault();
                        notEditableQuery.NotEditable = Convert.ToBoolean(e.Value);
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Ürün mutfakta yok.", "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnNotEditable.ValueUnchecked = false;
                    }
                  
                }
            }
        }
    }
}