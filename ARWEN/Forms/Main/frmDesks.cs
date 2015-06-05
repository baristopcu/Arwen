using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ARWEN.DTO.Class;
using ARWEN.DTO.Database;
using ARWEN.Forms;
using ARWEN.Forms.Main;
using ARWEN.Forms.Reservation;
using DevExpress.CodeParser;
using DevExpress.Data.Mask;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using System.Threading;


namespace ARWEN
{
    public partial class frmDesks : DevExpress.XtraEditors.XtraForm
    {
        public frmDesks()
        {
            InitializeComponent();

        }

        private static SimpleButton tableButton;
        int sayi = 0;
        public void ButtonCreate()
        {
            List<string> tableNameList = new List<string>();
            List<byte> tableStateList = new List<byte>();
            try
            {
                using (RestaurantContext dbContext = new RestaurantContext())
                {
                    tableNameList.AddRange(dbContext.Get_All_Tables().Select(y => y.TableNo).ToList());
                    tableStateList.AddRange(dbContext.Get_All_Tables().Select(y => y.State).ToList());

                }

                for (int i = 0; i < sayi; i++)
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

                    flwDeskChoose.Controls.Add(sndrButton);
                    sndrButton.Click += sndrButton_Click;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static List<object> SiparislerList = new List<object>();

    
        private static void sndrButton_Click(object sender, EventArgs e)
        {
            try
            {
                tableButton = (SimpleButton)sender;             

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void frmDesks_Load(object sender, EventArgs e)
        {
           
            try
            {
                Jarvis j = new Jarvis();
                j.cozunurlukAyarla(this);
                CheckForIllegalCrossThreadCalls = false;
                using (var dbContext = new RestaurantContext())
                {
                    sayi = dbContext.Get_All_Tables().Count();
                    ButtonCreate();

                }

                //using (RestaurantContext dbContext = new RestaurantContext())
                //{
                //    int sayi = dbContext.Get_All_Tables().Count();
                //    ButtonCreate(sayi, flwDeskChoose);
                //}
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "ARWEN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAddReservation_Click(object sender, EventArgs e)
        {
            frmReservation frm = new frmReservation();
            frm.ShowDialog();
        }

        private void btnMoveDesk_Click(object sender, EventArgs e)
        {
            frmTableTransfer frm = new frmTableTransfer();
            frm.ShowDialog();
        }

        Thread thread1;


        void GetTable()
        {
            List<string> tableNameList = new List<string>();
            List<byte> tableStateList = new List<byte>();

            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate()
                {
                    if (flwDeskChoose != null)
                    {
                        List<SimpleButton> listControls = flwDeskChoose.Controls.Cast<SimpleButton>().ToList();

                        using (RestaurantContext dbContext = new RestaurantContext())
                        {
                            tableNameList.AddRange(dbContext.Get_All_Tables().Select(y => y.TableNo).ToList());
                            tableStateList.AddRange(dbContext.Get_All_Tables().Select(y => y.State).ToList());

                        }

                        for (int i = 0; i < listControls.Count; i++)
                        {
                            if (listControls[i].Text != tableNameList[i] && Convert.ToByte(listControls[i].Tag) != tableStateList[i])
                            {
                                listControls[i].Text = tableNameList[i];
                                listControls[i].Tag = tableStateList[i];

                                if (tableStateList[i] == 0)
                                {
                                    listControls[i].Image = Image.FromFile(Application.StartupPath + @"\Images\Available.png");
                                }
                                else if (tableStateList[i] == 1)
                                {
                                    listControls[i].Image = Image.FromFile(Application.StartupPath + @"\Images\Busy.png");
                                }
                                else if (tableStateList[i] == 2)
                                {
                                    listControls[i].Image = Image.FromFile(Application.StartupPath + @"\Images\Closed.png");
                                }

                            }

                        }

                    }

                });

            }
            else
            {

                List<SimpleButton> listControls = flwDeskChoose.Controls.Cast<SimpleButton>().ToList();


                using (RestaurantContext dbContext = new RestaurantContext())
                {
                    tableNameList.AddRange(dbContext.Get_All_Tables().Select(y => y.TableNo).ToList());
                    tableStateList.AddRange(dbContext.Get_All_Tables().Select(y => y.State).ToList());

                }

                for (int i = 0; i < listControls.Count; i++)
                {
                    if (listControls[i].Text != tableNameList[i] && Convert.ToByte(listControls[i].Tag) != tableStateList[i])
                    {
                        listControls[i].Text = tableNameList[i];
                        listControls[i].Tag = tableStateList[i];

                        if (tableStateList[i] == 0)
                        {
                            listControls[i].Image = Image.FromFile(Application.StartupPath + @"\Images\Available.png");
                        }
                        else if (tableStateList[i] == 1)
                        {
                            listControls[i].Image = Image.FromFile(Application.StartupPath + @"\Images\Busy.png");
                        }
                        else if (tableStateList[i] == 2)
                        {
                            listControls[i].Image = Image.FromFile(Application.StartupPath + @"\Images\Closed.png");
                        }

                    }

                }

            }
        }

        private void backgroundWorkerDesk_DoWork(object sender, DoWorkEventArgs e)
        {

            thread1 = new Thread(new ThreadStart(GetTable));
            thread1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!backgroundWorkerDesk.IsBusy)
                backgroundWorkerDesk.RunWorkerAsync();
        }
    }
}
