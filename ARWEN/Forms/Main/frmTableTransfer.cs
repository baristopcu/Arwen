using System;
using System.Linq;
using System.Windows.Forms;
using ARWEN.DTO.Database;
using DevExpress.XtraEditors;
using ComboBox = System.Windows.Forms.ComboBox;
using ARWEN.DTO.Class;

namespace ARWEN.Forms.Main
{
    public partial class frmTableTransfer : XtraForm
    {
        public frmTableTransfer()
        {
            InitializeComponent();
        }

        string tableNo;

        public string TableNo
        {
            get { return tableNo; }
            set { tableNo = value; }
        }

        private void GetTables(ComboBox cmbTable,ComboBox cmbTableTo)
        {
            try
            {
                using (var dbContext = new RestaurantContext())
                {
                    dbContext.Configuration.LazyLoadingEnabled = false;
                    //--
                    var query = dbContext.RestaurantTables.Where(x => x.State == 1).ToList();
                    cmbTable.DataSource = query;
                    cmbTable.ValueMember = "TableNo";
                    cmbTable.DisplayMember = "TableNo";
                    //--
                    var queryTo = dbContext.RestaurantTables.Where(x => x.State == 0).ToList();
                    cmbTableTo.DataSource = queryTo;
                    cmbTableTo.ValueMember = "TableNo";
                    cmbTableTo.DisplayMember = "TableNo";


                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmTableTransfer_Load(object sender, EventArgs e)
        {
            Jarvis j = new Jarvis();
            j.cozunurlukAyarla(this);
            GetTables(cmbTable,cmbTableTo);
            if (!string.IsNullOrEmpty(tableNo))
            {
                cmbTable.SelectedValue = tableNo;
            }
        }

        private void btnTasi_Click(object sender, EventArgs e)
        {
            try
            {
                string table = cmbTable.SelectedValue.ToString();
                string tableTo = cmbTableTo.SelectedValue.ToString();
                using (RestaurantContext dbContext = new RestaurantContext())
                {
                    var queryOH = dbContext.OrderHeader.Where(x => x.TableNo == table).Where(y=>y.State < 5).FirstOrDefault();
                    queryOH.TableNo = tableTo;
                    var queryRT = dbContext.RestaurantTables.Where(x => x.TableNo == table).FirstOrDefault();
                    queryRT.State = 0;
                    var queryRT2 = dbContext.RestaurantTables.Where(x => x.TableNo == tableTo).FirstOrDefault();
                    queryRT2.State = 1;
                    dbContext.SaveChanges();
                }
                MessageBox.Show(table+" "+"Masası"+" "+tableTo+" "+"Masasına başarıyla taşındı.", "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
           
        }
    }
}