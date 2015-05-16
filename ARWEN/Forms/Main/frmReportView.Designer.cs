namespace ARWEN.Forms.Main
{
    partial class frmReportView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMostChoosedTables = new DevExpress.XtraEditors.SimpleButton();
            this.btnMostChoosedProducts = new DevExpress.XtraEditors.SimpleButton();
            this.btnMostChoosedGruops = new DevExpress.XtraEditors.SimpleButton();
            this.btnMostChoosedSuppliers = new DevExpress.XtraEditors.SimpleButton();
            this.btnMostChoosedPayment = new DevExpress.XtraEditors.SimpleButton();
            this.btnHardWorkedWaiters = new DevExpress.XtraEditors.SimpleButton();
            this.btnXCustomerYTable = new DevExpress.XtraEditors.SimpleButton();
            this.btnMostReservationCustomer = new DevExpress.XtraEditors.SimpleButton();
            this.btnResevationCanceledTime = new DevExpress.XtraEditors.SimpleButton();
            this.btnReservationUsedTime = new DevExpress.XtraEditors.SimpleButton();
            this.btnTableTime = new DevExpress.XtraEditors.SimpleButton();
            this.grpDate = new DevExpress.XtraEditors.GroupControl();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEnd = new DevExpress.XtraEditors.DateEdit();
            this.dtpStart = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grpDate)).BeginInit();
            this.grpDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMostChoosedTables
            // 
            this.btnMostChoosedTables.Location = new System.Drawing.Point(22, 126);
            this.btnMostChoosedTables.Name = "btnMostChoosedTables";
            this.btnMostChoosedTables.Size = new System.Drawing.Size(449, 59);
            this.btnMostChoosedTables.TabIndex = 1;
            this.btnMostChoosedTables.Text = "En Çok Tercih Edilen Masalar";
            this.btnMostChoosedTables.Click += new System.EventHandler(this.btnMostChoosedTables_Click);
            // 
            // btnMostChoosedProducts
            // 
            this.btnMostChoosedProducts.Location = new System.Drawing.Point(22, 221);
            this.btnMostChoosedProducts.Name = "btnMostChoosedProducts";
            this.btnMostChoosedProducts.Size = new System.Drawing.Size(449, 59);
            this.btnMostChoosedProducts.TabIndex = 2;
            this.btnMostChoosedProducts.Text = "En Çok Tercih Edilen Yicekler";
            this.btnMostChoosedProducts.Click += new System.EventHandler(this.btnMostChoosedEats_Click);
            // 
            // btnMostChoosedGruops
            // 
            this.btnMostChoosedGruops.Location = new System.Drawing.Point(22, 316);
            this.btnMostChoosedGruops.Name = "btnMostChoosedGruops";
            this.btnMostChoosedGruops.Size = new System.Drawing.Size(449, 59);
            this.btnMostChoosedGruops.TabIndex = 3;
            this.btnMostChoosedGruops.Text = "En Çok Tercih Edilen Kategoriler";
            this.btnMostChoosedGruops.Click += new System.EventHandler(this.btnMostChoosedGruops_Click);
            // 
            // btnMostChoosedSuppliers
            // 
            this.btnMostChoosedSuppliers.Location = new System.Drawing.Point(22, 411);
            this.btnMostChoosedSuppliers.Name = "btnMostChoosedSuppliers";
            this.btnMostChoosedSuppliers.Size = new System.Drawing.Size(449, 59);
            this.btnMostChoosedSuppliers.TabIndex = 4;
            this.btnMostChoosedSuppliers.Text = "En Çok Tercih Edilen Tedarikçiler";
            this.btnMostChoosedSuppliers.Click += new System.EventHandler(this.btnMostChoosedSuppliers_Click);
            // 
            // btnMostChoosedPayment
            // 
            this.btnMostChoosedPayment.Location = new System.Drawing.Point(531, 126);
            this.btnMostChoosedPayment.Name = "btnMostChoosedPayment";
            this.btnMostChoosedPayment.Size = new System.Drawing.Size(449, 59);
            this.btnMostChoosedPayment.TabIndex = 5;
            this.btnMostChoosedPayment.Text = "En Çok Tercih Edilen Ödeme Tipleri";
            this.btnMostChoosedPayment.Click += new System.EventHandler(this.btnMostChoosedPayment_Click);
            // 
            // btnHardWorkedWaiters
            // 
            this.btnHardWorkedWaiters.Location = new System.Drawing.Point(531, 221);
            this.btnHardWorkedWaiters.Name = "btnHardWorkedWaiters";
            this.btnHardWorkedWaiters.Size = new System.Drawing.Size(449, 59);
            this.btnHardWorkedWaiters.TabIndex = 5;
            this.btnHardWorkedWaiters.Text = "En Çok Sipariş Toplayan Garsonlar";
            this.btnHardWorkedWaiters.Click += new System.EventHandler(this.btnMostHardWorkedWaiters_Click);
            // 
            // btnXCustomerYTable
            // 
            this.btnXCustomerYTable.Location = new System.Drawing.Point(531, 316);
            this.btnXCustomerYTable.Name = "btnXCustomerYTable";
            this.btnXCustomerYTable.Size = new System.Drawing.Size(449, 59);
            this.btnXCustomerYTable.TabIndex = 6;
            this.btnXCustomerYTable.Text = "Müşteri Bazlı Masa Raporu";
            this.btnXCustomerYTable.Click += new System.EventHandler(this.btnXCustomerYTable_Click);
            // 
            // btnMostReservationCustomer
            // 
            this.btnMostReservationCustomer.Location = new System.Drawing.Point(531, 411);
            this.btnMostReservationCustomer.Name = "btnMostReservationCustomer";
            this.btnMostReservationCustomer.Size = new System.Drawing.Size(449, 59);
            this.btnMostReservationCustomer.TabIndex = 7;
            this.btnMostReservationCustomer.Text = "En Çok Rezervasyon Yaptıran Müşteriler";
            this.btnMostReservationCustomer.Click += new System.EventHandler(this.btnMostReservationCustomer_Click);
            // 
            // btnResevationCanceledTime
            // 
            this.btnResevationCanceledTime.Location = new System.Drawing.Point(531, 506);
            this.btnResevationCanceledTime.Name = "btnResevationCanceledTime";
            this.btnResevationCanceledTime.Size = new System.Drawing.Size(449, 59);
            this.btnResevationCanceledTime.TabIndex = 9;
            this.btnResevationCanceledTime.Text = "Müşteri Bazlı Rezervasyon İptal Raporu";
            this.btnResevationCanceledTime.Click += new System.EventHandler(this.btnReservationCanceledTime_Click);
            // 
            // btnReservationUsedTime
            // 
            this.btnReservationUsedTime.Location = new System.Drawing.Point(22, 506);
            this.btnReservationUsedTime.Name = "btnReservationUsedTime";
            this.btnReservationUsedTime.Size = new System.Drawing.Size(449, 59);
            this.btnReservationUsedTime.TabIndex = 8;
            this.btnReservationUsedTime.Text = "Müşteri Bazlı Rezervasyon Kullanım Raporu";
            this.btnReservationUsedTime.Click += new System.EventHandler(this.btnReservationUsedTime_Click);
            // 
            // btnTableTime
            // 
            this.btnTableTime.Location = new System.Drawing.Point(22, 582);
            this.btnTableTime.Name = "btnTableTime";
            this.btnTableTime.Size = new System.Drawing.Size(958, 59);
            this.btnTableTime.TabIndex = 10;
            this.btnTableTime.Text = "Masa Bazlı Ortalama Süre Raporu";
            this.btnTableTime.Click += new System.EventHandler(this.btnTableTime_Click);
            // 
            // grpDate
            // 
            this.grpDate.Controls.Add(this.label2);
            this.grpDate.Controls.Add(this.label1);
            this.grpDate.Controls.Add(this.dtpEnd);
            this.grpDate.Controls.Add(this.dtpStart);
            this.grpDate.Location = new System.Drawing.Point(22, 12);
            this.grpDate.Name = "grpDate";
            this.grpDate.Size = new System.Drawing.Size(958, 100);
            this.grpDate.TabIndex = 11;
            this.grpDate.Text = "Belirli Tarihler Arasında Listele";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(506, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Bitiş Tarihi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Başlangıç Tarihi";
            // 
            // dtpEnd
            // 
            this.dtpEnd.EditValue = null;
            this.dtpEnd.Location = new System.Drawing.Point(509, 52);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpEnd.Properties.Appearance.Options.UseFont = true;
            this.dtpEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpEnd.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI;
            this.dtpEnd.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.dtpEnd.Size = new System.Drawing.Size(408, 30);
            this.dtpEnd.TabIndex = 7;
            // 
            // dtpStart
            // 
            this.dtpStart.EditValue = null;
            this.dtpStart.Location = new System.Drawing.Point(27, 52);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpStart.Properties.Appearance.Options.UseFont = true;
            this.dtpStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpStart.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI;
            this.dtpStart.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.dtpStart.Size = new System.Drawing.Size(408, 30);
            this.dtpStart.TabIndex = 6;
            // 
            // frmReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 670);
            this.Controls.Add(this.grpDate);
            this.Controls.Add(this.btnTableTime);
            this.Controls.Add(this.btnResevationCanceledTime);
            this.Controls.Add(this.btnReservationUsedTime);
            this.Controls.Add(this.btnMostReservationCustomer);
            this.Controls.Add(this.btnXCustomerYTable);
            this.Controls.Add(this.btnHardWorkedWaiters);
            this.Controls.Add(this.btnMostChoosedPayment);
            this.Controls.Add(this.btnMostChoosedSuppliers);
            this.Controls.Add(this.btnMostChoosedGruops);
            this.Controls.Add(this.btnMostChoosedProducts);
            this.Controls.Add(this.btnMostChoosedTables);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReportView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReportView";
            this.Load += new System.EventHandler(this.frmReportView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpDate)).EndInit();
            this.grpDate.ResumeLayout(false);
            this.grpDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnMostChoosedTables;
        private DevExpress.XtraEditors.SimpleButton btnMostChoosedProducts;
        private DevExpress.XtraEditors.SimpleButton btnMostChoosedGruops;
        private DevExpress.XtraEditors.SimpleButton btnMostChoosedSuppliers;
        private DevExpress.XtraEditors.SimpleButton btnMostChoosedPayment;
        private DevExpress.XtraEditors.SimpleButton btnHardWorkedWaiters;
        private DevExpress.XtraEditors.SimpleButton btnXCustomerYTable;
        private DevExpress.XtraEditors.SimpleButton btnMostReservationCustomer;
        private DevExpress.XtraEditors.SimpleButton btnResevationCanceledTime;
        private DevExpress.XtraEditors.SimpleButton btnReservationUsedTime;
        private DevExpress.XtraEditors.SimpleButton btnTableTime;
        private DevExpress.XtraEditors.GroupControl grpDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit dtpEnd;
        private DevExpress.XtraEditors.DateEdit dtpStart;
    }
}