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
    public partial class frmAddOrderNote : DevExpress.XtraEditors.XtraForm
    {
        public frmAddOrderNote()
        {
            InitializeComponent();
        }

        private long _orderNo;

        public long OrderNo
        {
            get { return _orderNo; }
            set { _orderNo = value; }
        }

        private void frmAddOrderNote_Load(object sender, EventArgs e)
        {
          
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (RestaurantContext dbContext = new RestaurantContext())
            {
                var query = dbContext.OrderHeader.Where(x => x.OrderNo == _orderNo).FirstOrDefault();
                query.Note = txtNote.Text;
                dbContext.SaveChanges();
                this.Close();
            }
        }
    }
}