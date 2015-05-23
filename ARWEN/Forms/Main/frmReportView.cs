using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ARWEN.Dataset;
using ARWEN.DTO.Class;
using DevExpress.XtraEditors;
using ARWEN.Forms.Reports;
using DevExpress.XtraReports.UI;

namespace ARWEN.Forms.Main
{
    public partial class frmReportView : DevExpress.XtraEditors.XtraForm
    {
        public frmReportView()
        {
            InitializeComponent();
        }

        private void frmReportView_Load(object sender, EventArgs e)
        {
            dtpEnd.DateTime = DateTime.Today;
            dtpStart.DateTime = DateTime.Today;
        }

        private Jarvis jarvis = new Jarvis();
        private void btnMostChoosedTables_Click(object sender, EventArgs e)
        {
            RestaurantDataSet ds = new RestaurantDataSet();

            // Get Company Properties --
            string queryComp = "select * from Settings";
            jarvis.ConnectToDb(jarvis.GetConnStr("Restaurant"));
            jarvis.GetDataForReport(queryComp, ds, "CompanyProperties");

            // Get Report's Data--
            string queryData =
                "SELECT        OrderHeader.TableNo, COUNT(OrderHeader.TableNo) AS Toplam FROM OrderHeader INNER JOIN Payments ON OrderHeader.OrderNo = Payments.OrderNo WHERE (CreationDatetime BETWEEN CONVERT(datetime, @dtpStart , 103) AND CONVERT(datetime, @dtpEnd, 103)) GROUP BY OrderHeader.TableNo ORDER BY Toplam DESC";
            jarvis.Command.Parameters.Clear();
            jarvis.Command.Parameters.AddWithValue("@dtpStart", dtpStart.DateTime);
            jarvis.Command.Parameters.AddWithValue("@dtpEnd", dtpEnd.DateTime);
            jarvis.GetDataForReport(queryData, ds, "OrderHeader");

            //Close Connections
            jarvis.NtpDbConnection.Close();

            //Send to Report
            MostChoosedTables rptMCT = new MostChoosedTables();
            rptMCT.DataSource = ds;
            rptMCT.ShowPreviewDialog();
        }

       

        private void btnMostChoosedEats_Click(object sender, EventArgs e)
        {
            RestaurantDataSet ds = new RestaurantDataSet();

            // Get Company Properties --
            string queryComp = "select * from Settings";
            jarvis.ConnectToDb(jarvis.GetConnStr("Restaurant"));
            jarvis.GetDataForReport(queryComp, ds, "CompanyProperties");

            // Get Report's Data--
            string queryData =
                "SELECT        Products.ProductName, COUNT(OrderDetail.ProductID) AS Toplam FROM OrderDetail INNER JOIN Products ON OrderDetail.ProductID = Products.ProductID INNER JOIN OrderHeader ON OrderDetail.OrderNo = OrderHeader.OrderNo INNER JOIN Payments ON OrderHeader.OrderNo = Payments.OrderNo WHERE (CreationDatetime BETWEEN CONVERT(datetime, @dtpStart, 103) AND CONVERT(datetime, @dtpEnd, 103)) GROUP BY Products.ProductName ORDER BY Toplam DESC";
            jarvis.Command.Parameters.Clear();
            jarvis.Command.Parameters.AddWithValue("@dtpStart", dtpStart.DateTime);
            jarvis.Command.Parameters.AddWithValue("@dtpEnd", dtpEnd.DateTime);
            jarvis.GetDataForReport(queryData, ds, "ProductReport");

            //Close Connections
            jarvis.NtpDbConnection.Close();

            //Send to Report
            MostChoosedProducts rptMCT = new MostChoosedProducts();
            rptMCT.DataSource = ds;
            rptMCT.ShowPreviewDialog();
        }

        private void btnMostChoosedGruops_Click(object sender, EventArgs e)
        {
            RestaurantDataSet ds = new RestaurantDataSet();

            // Get Company Properties --
            string queryComp = "select * from Settings";
            jarvis.ConnectToDb(jarvis.GetConnStr("Restaurant"));
            jarvis.GetDataForReport(queryComp, ds, "CompanyProperties");

            // Get Report's Data--
            string queryData =
                "SELECT        Groups.GroupName, COUNT(Products.ProductID) AS Toplam FROM Groups INNER JOIN Products ON Groups.GroupID = Products.GroupID INNER JOIN OrderDetail ON Products.ProductID = OrderDetail.ProductID INNER JOIN OrderHeader ON OrderDetail.OrderNo = OrderHeader.OrderNo INNER JOIN Payments ON OrderHeader.OrderNo = Payments.OrderNo WHERE (CreationDatetime BETWEEN CONVERT(datetime,@dtpStart, 103) AND CONVERT(datetime, @dtpEnd, 103)) GROUP BY Groups.GroupName ORDER BY Toplam DESC";
            jarvis.Command.Parameters.Clear();
            jarvis.Command.Parameters.AddWithValue("@dtpStart", dtpStart.DateTime);
            jarvis.Command.Parameters.AddWithValue("@dtpEnd", dtpEnd.DateTime);
            jarvis.GetDataForReport(queryData, ds, "GroupReport");

            //Close Connections
            jarvis.NtpDbConnection.Close();

            //Send to Report
            MostChoosedGroups rptMCT = new MostChoosedGroups();
            rptMCT.DataSource = ds;
            rptMCT.ShowPreviewDialog();
        }

        private void btnMostChoosedSuppliers_Click(object sender, EventArgs e)
        {
            RestaurantDataSet ds = new RestaurantDataSet();

            // Get Company Properties --
            string queryComp = "select * from Settings";
            jarvis.ConnectToDb(jarvis.GetConnStr("Restaurant"));
            jarvis.GetDataForReport(queryComp, ds, "CompanyProperties");

            // Get Report's Data--
            string queryData =
                "SELECT        Suppliers.CompanyName, COUNT(Products.ProductID) AS Toplam FROM Products INNER JOIN Suppliers ON Products.SupplierID = Suppliers.SupplierID INNER JOIN Purchases ON Suppliers.SupplierID = Purchases.SupplierID WHERE (Purchases.PurchaseDate BETWEEN CONVERT(datetime,@dtpStart, 103) AND CONVERT(datetime, @dtpEnd, 103)) and FicheTypeID = 1 GROUP BY Suppliers.CompanyName ORDER BY Toplam DESC";
            jarvis.Command.Parameters.Clear();
            jarvis.Command.Parameters.AddWithValue("@dtpStart", dtpStart.DateTime);
            jarvis.Command.Parameters.AddWithValue("@dtpEnd", dtpEnd.DateTime);
            jarvis.GetDataForReport(queryData, ds, "SupplierReport");

            //Close Connections
            jarvis.NtpDbConnection.Close();

            //Send to Report
            MostChoosedSuppliers rptMCT = new MostChoosedSuppliers();
            rptMCT.DataSource = ds;
            rptMCT.ShowPreviewDialog();

        }

        private void btnMostChoosedPayment_Click(object sender, EventArgs e)
        {
            RestaurantDataSet ds = new RestaurantDataSet();

            // Get Company Properties --
            string queryComp = "select * from Settings";
            jarvis.ConnectToDb(jarvis.GetConnStr("Restaurant"));
            jarvis.GetDataForReport(queryComp, ds, "CompanyProperties");

            // Get Report's Data--
            string queryData =
                " SELECT        PaymentModules.Name,COUNT(PaymentModules.PaymentModuleID) AS Toplam FROM PaymentModules INNER JOIN Payments   ON PaymentModules.PaymentModuleID = Payments.PaymentModuleID WHERE        (Date BETWEEN CONVERT(datetime, @dtpStart, 103) AND CONVERT(datetime, @dtpEnd, 103)) GROUP BY PaymentModules.Name ORDER BY Toplam DESC";
            jarvis.Command.Parameters.Clear();
            jarvis.Command.Parameters.AddWithValue("@dtpStart", dtpStart.DateTime);
            jarvis.Command.Parameters.AddWithValue("@dtpEnd", dtpEnd.DateTime);
            jarvis.GetDataForReport(queryData, ds, "PaymentReport");

            //Close Connections
            jarvis.NtpDbConnection.Close();

            //Send to Report
            MostChoosedPayment rptMCT = new MostChoosedPayment();
            rptMCT.DataSource = ds;
            rptMCT.ShowPreviewDialog();
        }
        private void btnMostHardWorkedWaiters_Click(object sender, EventArgs e)
        {
            RestaurantDataSet ds = new RestaurantDataSet();

            // Get Company Properties --
            string queryComp = "select * from Settings";
            jarvis.ConnectToDb(jarvis.GetConnStr("Restaurant"));
            jarvis.GetDataForReport(queryComp, ds, "CompanyProperties");

            // Get Report's Data--
            string queryData =
                "SELECT Users.FullName, COUNT(OrderHeader.CreatorUserID) AS Toplam FROM OrderHeader INNER JOIN Users ON OrderHeader.CreatorUserID = Users.UserID INNER JOIN Payments ON OrderHeader.OrderNo = Payments.OrderNo WHERE (CreationDatetime BETWEEN CONVERT(datetime,@dtpStart , 103) AND CONVERT(datetime, @dtpEnd, 103)) GROUP BY Users.FullName ORDER BY Toplam DESC";
            jarvis.Command.Parameters.Clear();
            jarvis.Command.Parameters.AddWithValue("@dtpStart", dtpStart.DateTime);
            jarvis.Command.Parameters.AddWithValue("@dtpEnd", dtpEnd.DateTime);
            jarvis.GetDataForReport(queryData, ds, "WaitersReport");

            //Close Connections
            jarvis.NtpDbConnection.Close();

            //Send to Report
            MostHardWorkedWaiters rptMCT = new MostHardWorkedWaiters();
            rptMCT.DataSource = ds;
            rptMCT.ShowPreviewDialog();
        }

        private void btnXCustomerYTable_Click(object sender, EventArgs e)
        {

            RestaurantDataSet ds = new RestaurantDataSet();

            // Get Company Properties --
            string queryComp = "select * from Settings";
            jarvis.ConnectToDb(jarvis.GetConnStr("Restaurant"));
            jarvis.GetDataForReport(queryComp, ds, "CompanyProperties");

            // Get Report's Data--
            string queryData =
                "SELECT        Customers.ContactName, COUNT(OrderHeader.CustomerID) AS Toplam, RestaurantTables.TableNo FROM            Customers INNER JOIN                        OrderHeader ON Customers.CustomerID = OrderHeader.CustomerID INNER JOIN                      RestaurantTables ON OrderHeader.TableNo = RestaurantTables.TableNo INNER JOIN                      Payments ON OrderHeader.OrderNo = Payments.OrderNo WHERE (CreationDatetime BETWEEN CONVERT(datetime,@dtpStart, 103) AND CONVERT(datetime,@dtpEnd, 103)) GROUP BY Customers.ContactName, RestaurantTables.TableNo ORDER BY Toplam DESC";
            jarvis.Command.Parameters.Clear();
            jarvis.Command.Parameters.AddWithValue("@dtpStart", dtpStart.DateTime);
            jarvis.Command.Parameters.AddWithValue("@dtpEnd", dtpEnd.DateTime);
            jarvis.GetDataForReport(queryData, ds, "XCustomerYTableReport");

            //Close Connections
            jarvis.NtpDbConnection.Close();

            //Send to Report
            XCustomerYTable rptMCT = new XCustomerYTable();
            rptMCT.DataSource = ds;
            rptMCT.ShowPreviewDialog();
        }

        private void btnMostReservationCustomer_Click(object sender, EventArgs e)
        {
            RestaurantDataSet ds = new RestaurantDataSet();

            // Get Company Properties --
            string queryComp = "select * from Settings";
            jarvis.ConnectToDb(jarvis.GetConnStr("Restaurant"));
            jarvis.GetDataForReport(queryComp, ds, "CompanyProperties");

            // Get Report's Data--
            string queryData =
                "SELECT        Customers.ContactName, COUNT(Reservation.CustomerID) AS Toplam FROM Reservation INNER JOIN Customers ON Reservation.CustomerID = Customers.CustomerID WHERE (StartDate BETWEEN CONVERT(datetime,@dtpStart, 103) AND CONVERT(datetime, @dtpEnd, 103)) GROUP BY Customers.ContactName ORDER BY Toplam DESC";
            jarvis.Command.Parameters.Clear();
            jarvis.Command.Parameters.AddWithValue("@dtpStart", dtpStart.DateTime);
            jarvis.Command.Parameters.AddWithValue("@dtpEnd", dtpEnd.DateTime);
            jarvis.GetDataForReport(queryData, ds, "CustomerReservationReport");

            //Close Connections
            jarvis.NtpDbConnection.Close();

            //Send to Report
            MostReservationCustomer rptMCT = new MostReservationCustomer();
            rptMCT.DataSource = ds;
            rptMCT.ShowPreviewDialog();
        }

        private void btnReservationCanceledTime_Click(object sender, EventArgs e)
        {
            RestaurantDataSet ds = new RestaurantDataSet();

            // Get Company Properties --
            string queryComp = "select * from Settings";
            jarvis.ConnectToDb(jarvis.GetConnStr("Restaurant"));
            jarvis.GetDataForReport(queryComp, ds, "CompanyProperties");

            // Get Report's Data--
            string queryData =
               "SELECT        Customers.ContactName, COUNT(Reservation.CustomerID) AS Toplam FROM Reservation INNER JOIN Customers ON Reservation.CustomerID = Customers.CustomerID WHERE (StartDate BETWEEN CONVERT(datetime,@dtpStart, 103) AND CONVERT(datetime, @dtpEnd, 103)) and Cancel = 1 GROUP BY Customers.ContactName ORDER BY Toplam DESC";
            jarvis.Command.Parameters.Clear();
            jarvis.Command.Parameters.AddWithValue("@dtpStart", dtpStart.DateTime);
            jarvis.Command.Parameters.AddWithValue("@dtpEnd", dtpEnd.DateTime);
            jarvis.GetDataForReport(queryData, ds, "ReservationCanceledTimeReport");

            //Close Connections
            jarvis.NtpDbConnection.Close();

            //Send to Report
            ReservationCanceledTimeReport rptMCT = new ReservationCanceledTimeReport();
            rptMCT.DataSource = ds;
            rptMCT.ShowPreviewDialog();
        }

        private void btnReservationUsedTime_Click(object sender, EventArgs e)
        {
            RestaurantDataSet ds = new RestaurantDataSet();

            // Get Company Properties --
            string queryComp = "select * from Settings";
            jarvis.ConnectToDb(jarvis.GetConnStr("Restaurant"));
            jarvis.GetDataForReport(queryComp, ds, "CompanyProperties");

            // Get Report's Data--
            string queryData =
                "SELECT        Customers.ContactName, COUNT(Reservation.CustomerID) AS Toplam FROM Reservation INNER JOIN Customers ON Reservation.CustomerID = Customers.CustomerID WHERE (StartDate BETWEEN CONVERT(datetime,@dtpStart, 103) AND CONVERT(datetime, @dtpEnd, 103)) and Used = 1 GROUP BY Customers.ContactName ORDER BY Toplam DESC";
            jarvis.Command.Parameters.Clear();
            jarvis.Command.Parameters.AddWithValue("@dtpStart", dtpStart.DateTime);
            jarvis.Command.Parameters.AddWithValue("@dtpEnd", dtpEnd.DateTime);
            jarvis.GetDataForReport(queryData, ds, "ReservationUsedTimeReport");

            //Close Connections
            jarvis.NtpDbConnection.Close();

            //Send to Report
            ReservationUsedTimeReport rptMCT = new ReservationUsedTimeReport();
            rptMCT.DataSource = ds;
            rptMCT.ShowPreviewDialog();
        }

        private void btnTableTime_Click(object sender, EventArgs e)
        {
            RestaurantDataSet ds = new RestaurantDataSet();

            // Get Company Properties --
            string queryComp = "select * from Settings";
            jarvis.ConnectToDb(jarvis.GetConnStr("Restaurant"));
            jarvis.GetDataForReport(queryComp, ds, "CompanyProperties");

            // Get Report's Data--
            string queryData =
                "SELECT TableNo,AVG(DATEDIFF(MINUTE,OrderHeader.CreationDatetime,Payments.Date)) as SaatFarki FROM OrderHeader INNER JOIN Payments ON OrderHeader.OrderNo = Payments.OrderNo WHERE  (CreationDatetime BETWEEN CONVERT(datetime,@dtpStart , 103) AND CONVERT(datetime, @dtpEnd, 103)) GROUP BY TableNo ORDER BY SaatFarki DESC";
            jarvis.Command.Parameters.Clear();
            jarvis.Command.Parameters.AddWithValue("@dtpStart", dtpStart.DateTime);
            jarvis.Command.Parameters.AddWithValue("@dtpEnd", dtpEnd.DateTime);
            jarvis.GetDataForReport(queryData, ds, "TableTimesReport");

            //Close Connections
            jarvis.NtpDbConnection.Close();

            //Send to Report
            TableTimes rptMCT = new TableTimes();
            rptMCT.DataSource = ds;
            rptMCT.ShowPreviewDialog();
        }




    }
}