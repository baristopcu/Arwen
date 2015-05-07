using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using ARWEN.DTO.Class;
using ARWEN.DTO.Database;
using ARWEN.Forms;
using ARWEN.Forms.Reservation;
using DevExpress.CodeParser;
using DevExpress.Data.Mask;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;


namespace ARWEN
{
    public partial class frmDesks : DevExpress.XtraEditors.XtraForm
    {
        public frmDesks()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private static SimpleButton tableButton;

        public static void ButtonCreate(int kategoriSayisi, FlowLayoutPanel flwLayoutPanel)
        {
            List<string> tableNameList = new List<string>();
            List<byte> tableStateList = new List<byte>();

            using (RestaurantContext dbContext = new RestaurantContext())
            {
                tableNameList.AddRange(dbContext.Get_All_Tables().Select(y => y.TableNo).ToList());
                tableStateList.AddRange(dbContext.Get_All_Tables().Select(y =>  y.State).ToList());
                
            }

            for (int i = 0; i <= kategoriSayisi; i++)
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

        public static List<object> SiparislerList = new List<object>();

        private static void sndrButton_Click(object sender, EventArgs e)
        {
            tableButton = (SimpleButton) sender;

            if (Convert.ToByte(tableButton.Tag) == 2)
            {
                
                frmReservedPassword frm = new frmReservedPassword();               
                frm.TableNo = tableButton.Text;
                frm.ShowDialog();
            }
            else if (Convert.ToByte(tableButton.Tag) == 1)
            {
                using (RestaurantContext dbContext = new RestaurantContext())
                {
                    var query = dbContext.OrderHeader.Where(x => x.TableNo == tableButton.Text).FirstOrDefault();

                    if (query == null)
                    {
                        frmDeskCustomize frm = new frmDeskCustomize();
                        frm.Tag = tableButton.Text;
                        frm.TableState = Convert.ToByte(tableButton.Tag);
                        frm.ShowDialog();
                    }
                    else if (query.LockState == true)
                    {
                        var getUserQuery =
                            dbContext.OrderHeader.AsNoTracking()
                                .Join(dbContext.Users, od => od.LockKeeperUserID, p => p.UserID, (od, p) => new {od, p})
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
                        frmDeskCustomize frm = new frmDeskCustomize();
                        frm.Tag = tableButton.Text;
                        frm.TableState = Convert.ToByte(tableButton.Tag);
                        frm.ShowDialog();
                    }
                }
            }
            else if (Convert.ToByte(tableButton.Tag) == 0)
            {
                frmDeskCustomize frm = new frmDeskCustomize();
                frm.Tag = tableButton.Text;
                frm.TableState = Convert.ToByte(tableButton.Tag);
                frm.ShowDialog();
            }

        }

      
       
        private void frmDesks_Load(object sender, EventArgs e)
        {

            using (RestaurantContext dbContext = new RestaurantContext())
            {
                int sayi = dbContext.Get_All_Tables().Count();
                ButtonCreate(sayi, flwDeskChoose);
            }


        }


        private void btnAddReservation_Click(object sender, EventArgs e)
        {
            frmReservation frm = new frmReservation();
            frm.ShowDialog();
        }

        private void btnMoveDesk_Click(object sender, EventArgs e)
        {

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
           
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
           
            using (RestaurantContext dbContext = new RestaurantContext())
            {
                int sayi = dbContext.Get_All_Tables().Count();
                System.Threading.Thread.Sleep(3);
                ButtonCreate(sayi, flwDeskChoose);
            }
           
        }
    }
}
