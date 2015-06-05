namespace ARWEN
{
    partial class frmPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayment));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalCash = new DevExpress.XtraEditors.TextEdit();
            this.txtCharged = new DevExpress.XtraEditors.TextEdit();
            this.btn5 = new DevExpress.XtraEditors.SimpleButton();
            this.btn10 = new DevExpress.XtraEditors.SimpleButton();
            this.btn20 = new DevExpress.XtraEditors.SimpleButton();
            this.btn1 = new DevExpress.XtraEditors.SimpleButton();
            this.btn100 = new DevExpress.XtraEditors.SimpleButton();
            this.btn50 = new DevExpress.XtraEditors.SimpleButton();
            this.btnDiscount = new DevExpress.XtraEditors.SimpleButton();
            this.btnTicket = new DevExpress.XtraEditors.SimpleButton();
            this.btnCash = new DevExpress.XtraEditors.SimpleButton();
            this.btnCreditCard = new DevExpress.XtraEditors.SimpleButton();
            this.btnRestaurantTicket = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.gridPaymentProducts = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnC1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnC4 = new DevExpress.XtraEditors.SimpleButton();
            this.btnC7 = new DevExpress.XtraEditors.SimpleButton();
            this.btnCV = new DevExpress.XtraEditors.SimpleButton();
            this.btnC2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnC3 = new DevExpress.XtraEditors.SimpleButton();
            this.btnC6 = new DevExpress.XtraEditors.SimpleButton();
            this.btnC5 = new DevExpress.XtraEditors.SimpleButton();
            this.btnC9 = new DevExpress.XtraEditors.SimpleButton();
            this.btnC8 = new DevExpress.XtraEditors.SimpleButton();
            this.btnCC = new DevExpress.XtraEditors.SimpleButton();
            this.btnC0 = new DevExpress.XtraEditors.SimpleButton();
            this.btnGetTotalPrice = new DevExpress.XtraEditors.SimpleButton();
            this.btnTotalValue = new DevExpress.XtraEditors.SimpleButton();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblRound = new System.Windows.Forms.Label();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalCash.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCharged.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPaymentProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(413, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 25);
            this.label1.TabIndex = 20;
            this.label1.Text = "TOPLAM TUTAR ";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(481, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 25);
            this.label2.TabIndex = 21;
            this.label2.Text = "ÖDENEN ";
            // 
            // txtTotalCash
            // 
            this.txtTotalCash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalCash.Location = new System.Drawing.Point(663, 12);
            this.txtTotalCash.Name = "txtTotalCash";
            this.txtTotalCash.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txtTotalCash.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTotalCash.Properties.Appearance.Options.UseBackColor = true;
            this.txtTotalCash.Properties.Appearance.Options.UseFont = true;
            this.txtTotalCash.Properties.ReadOnly = true;
            this.txtTotalCash.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalCash.Size = new System.Drawing.Size(410, 42);
            this.txtTotalCash.TabIndex = 22;
            // 
            // txtCharged
            // 
            this.txtCharged.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCharged.Location = new System.Drawing.Point(663, 74);
            this.txtCharged.Name = "txtCharged";
            this.txtCharged.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txtCharged.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCharged.Properties.Appearance.Options.UseBackColor = true;
            this.txtCharged.Properties.Appearance.Options.UseFont = true;
            this.txtCharged.Properties.ReadOnly = true;
            this.txtCharged.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCharged.Size = new System.Drawing.Size(410, 42);
            this.txtCharged.TabIndex = 23;
            // 
            // btn5
            // 
            this.btn5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn5.Location = new System.Drawing.Point(429, 231);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(160, 52);
            this.btn5.TabIndex = 25;
            this.btn5.Text = "5";
            this.btn5.Click += new System.EventHandler(this.button_banks);
            // 
            // btn10
            // 
            this.btn10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn10.Location = new System.Drawing.Point(429, 303);
            this.btn10.Name = "btn10";
            this.btn10.Size = new System.Drawing.Size(160, 52);
            this.btn10.TabIndex = 24;
            this.btn10.Text = "10";
            this.btn10.Click += new System.EventHandler(this.button_banks);
            // 
            // btn20
            // 
            this.btn20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn20.Location = new System.Drawing.Point(429, 375);
            this.btn20.Name = "btn20";
            this.btn20.Size = new System.Drawing.Size(160, 52);
            this.btn20.TabIndex = 27;
            this.btn20.Text = "20";
            this.btn20.Click += new System.EventHandler(this.button_banks);
            // 
            // btn1
            // 
            this.btn1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn1.Location = new System.Drawing.Point(429, 159);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(160, 52);
            this.btn1.TabIndex = 26;
            this.btn1.Text = "1";
            this.btn1.Click += new System.EventHandler(this.button_banks);
            // 
            // btn100
            // 
            this.btn100.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn100.Location = new System.Drawing.Point(429, 522);
            this.btn100.Name = "btn100";
            this.btn100.Size = new System.Drawing.Size(160, 52);
            this.btn100.TabIndex = 29;
            this.btn100.Text = "100";
            this.btn100.Click += new System.EventHandler(this.button_banks);
            // 
            // btn50
            // 
            this.btn50.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn50.Location = new System.Drawing.Point(429, 447);
            this.btn50.Name = "btn50";
            this.btn50.Size = new System.Drawing.Size(160, 52);
            this.btn50.TabIndex = 28;
            this.btn50.Text = "50";
            this.btn50.Click += new System.EventHandler(this.button_banks);
            // 
            // btnDiscount
            // 
            this.btnDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDiscount.Location = new System.Drawing.Point(609, 586);
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.Size = new System.Drawing.Size(228, 49);
            this.btnDiscount.TabIndex = 30;
            this.btnDiscount.Text = "(%) İNDİRİM";
            this.btnDiscount.Click += new System.EventHandler(this.btnDiscount_Click);
            // 
            // btnTicket
            // 
            this.btnTicket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTicket.Image = ((System.Drawing.Image)(resources.GetObject("btnTicket.Image")));
            this.btnTicket.Location = new System.Drawing.Point(843, 586);
            this.btnTicket.Name = "btnTicket";
            this.btnTicket.Size = new System.Drawing.Size(228, 49);
            this.btnTicket.TabIndex = 31;
            this.btnTicket.Text = "FİŞİ YAZDIR";
            this.btnTicket.Click += new System.EventHandler(this.btnTicket_Click);
            // 
            // btnCash
            // 
            this.btnCash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCash.Location = new System.Drawing.Point(1247, 15);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(265, 125);
            this.btnCash.TabIndex = 32;
            this.btnCash.Text = "NAKİT";
            this.btnCash.Click += new System.EventHandler(this.btnCash_Click);
            // 
            // btnCreditCard
            // 
            this.btnCreditCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreditCard.Location = new System.Drawing.Point(1247, 159);
            this.btnCreditCard.Name = "btnCreditCard";
            this.btnCreditCard.Size = new System.Drawing.Size(265, 125);
            this.btnCreditCard.TabIndex = 33;
            this.btnCreditCard.Text = "KREDİ KARTI";
            this.btnCreditCard.Click += new System.EventHandler(this.btnCreditCard_Click);
            // 
            // btnRestaurantTicket
            // 
            this.btnRestaurantTicket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestaurantTicket.Location = new System.Drawing.Point(1247, 306);
            this.btnRestaurantTicket.Name = "btnRestaurantTicket";
            this.btnRestaurantTicket.Size = new System.Drawing.Size(265, 125);
            this.btnRestaurantTicket.TabIndex = 34;
            this.btnRestaurantTicket.Text = "YEMEK KARTI";
            this.btnRestaurantTicket.Click += new System.EventHandler(this.btnRestaurantTicket_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(1247, 447);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(265, 125);
            this.btnClose.TabIndex = 35;
            this.btnClose.Text = "KAPAT";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gridPaymentProducts
            // 
            this.gridPaymentProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPaymentProducts.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridPaymentProducts.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridPaymentProducts.Location = new System.Drawing.Point(11, 36);
            this.gridPaymentProducts.MainView = this.gridView1;
            this.gridPaymentProducts.Margin = new System.Windows.Forms.Padding(2);
            this.gridPaymentProducts.Name = "gridPaymentProducts";
            this.gridPaymentProducts.Size = new System.Drawing.Size(363, 599);
            this.gridPaymentProducts.TabIndex = 36;
            this.gridPaymentProducts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn5});
            this.gridView1.GridControl = this.gridPaymentProducts;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Toplam", this.gridColumn3, "c0")});
            this.gridView1.Name = "gridView1";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "ID";
            this.gridColumn4.FieldName = "ProductID";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ADET";
            this.gridColumn1.FieldName = "Amount";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 120;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "SİPARİŞ ADI";
            this.gridColumn2.FieldName = "ProductName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 307;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "FİYAT";
            this.gridColumn3.FieldName = "Price";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 155;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "EditAmount";
            this.gridColumn5.FieldName = "EditAmount";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            // 
            // btnC1
            // 
            this.btnC1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnC1.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnC1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnC1.Appearance.Options.UseBackColor = true;
            this.btnC1.Appearance.Options.UseFont = true;
            this.btnC1.Location = new System.Drawing.Point(609, 159);
            this.btnC1.Name = "btnC1";
            this.btnC1.Size = new System.Drawing.Size(150, 96);
            this.btnC1.TabIndex = 37;
            this.btnC1.Text = "1";
            this.btnC1.Click += new System.EventHandler(this.button_click);
            // 
            // btnC4
            // 
            this.btnC4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnC4.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnC4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnC4.Appearance.Options.UseBackColor = true;
            this.btnC4.Appearance.Options.UseFont = true;
            this.btnC4.Location = new System.Drawing.Point(609, 265);
            this.btnC4.Name = "btnC4";
            this.btnC4.Size = new System.Drawing.Size(150, 96);
            this.btnC4.TabIndex = 38;
            this.btnC4.Text = "4";
            this.btnC4.Click += new System.EventHandler(this.button_click);
            // 
            // btnC7
            // 
            this.btnC7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnC7.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnC7.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnC7.Appearance.Options.UseBackColor = true;
            this.btnC7.Appearance.Options.UseFont = true;
            this.btnC7.Location = new System.Drawing.Point(609, 371);
            this.btnC7.Name = "btnC7";
            this.btnC7.Size = new System.Drawing.Size(150, 96);
            this.btnC7.TabIndex = 39;
            this.btnC7.Text = "7";
            this.btnC7.Click += new System.EventHandler(this.button_click);
            // 
            // btnCV
            // 
            this.btnCV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCV.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnCV.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCV.Appearance.Options.UseBackColor = true;
            this.btnCV.Appearance.Options.UseFont = true;
            this.btnCV.Location = new System.Drawing.Point(609, 478);
            this.btnCV.Name = "btnCV";
            this.btnCV.Size = new System.Drawing.Size(150, 96);
            this.btnCV.TabIndex = 40;
            this.btnCV.Text = ",";
            this.btnCV.Click += new System.EventHandler(this.button_click);
            // 
            // btnC2
            // 
            this.btnC2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnC2.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnC2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnC2.Appearance.Options.UseBackColor = true;
            this.btnC2.Appearance.Options.UseFont = true;
            this.btnC2.Location = new System.Drawing.Point(765, 159);
            this.btnC2.Name = "btnC2";
            this.btnC2.Size = new System.Drawing.Size(150, 96);
            this.btnC2.TabIndex = 41;
            this.btnC2.Text = "2";
            this.btnC2.Click += new System.EventHandler(this.button_click);
            // 
            // btnC3
            // 
            this.btnC3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnC3.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnC3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnC3.Appearance.Options.UseBackColor = true;
            this.btnC3.Appearance.Options.UseFont = true;
            this.btnC3.Location = new System.Drawing.Point(921, 159);
            this.btnC3.Name = "btnC3";
            this.btnC3.Size = new System.Drawing.Size(150, 96);
            this.btnC3.TabIndex = 42;
            this.btnC3.Text = "3";
            this.btnC3.Click += new System.EventHandler(this.button_click);
            // 
            // btnC6
            // 
            this.btnC6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnC6.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnC6.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnC6.Appearance.Options.UseBackColor = true;
            this.btnC6.Appearance.Options.UseFont = true;
            this.btnC6.Location = new System.Drawing.Point(921, 265);
            this.btnC6.Name = "btnC6";
            this.btnC6.Size = new System.Drawing.Size(150, 96);
            this.btnC6.TabIndex = 44;
            this.btnC6.Text = "6";
            this.btnC6.Click += new System.EventHandler(this.button_click);
            // 
            // btnC5
            // 
            this.btnC5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnC5.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnC5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnC5.Appearance.Options.UseBackColor = true;
            this.btnC5.Appearance.Options.UseFont = true;
            this.btnC5.Location = new System.Drawing.Point(765, 265);
            this.btnC5.Name = "btnC5";
            this.btnC5.Size = new System.Drawing.Size(150, 96);
            this.btnC5.TabIndex = 43;
            this.btnC5.Text = "5";
            this.btnC5.Click += new System.EventHandler(this.button_click);
            // 
            // btnC9
            // 
            this.btnC9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnC9.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnC9.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnC9.Appearance.Options.UseBackColor = true;
            this.btnC9.Appearance.Options.UseFont = true;
            this.btnC9.Location = new System.Drawing.Point(921, 371);
            this.btnC9.Name = "btnC9";
            this.btnC9.Size = new System.Drawing.Size(150, 96);
            this.btnC9.TabIndex = 46;
            this.btnC9.Text = "9";
            this.btnC9.Click += new System.EventHandler(this.button_click);
            // 
            // btnC8
            // 
            this.btnC8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnC8.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnC8.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnC8.Appearance.Options.UseBackColor = true;
            this.btnC8.Appearance.Options.UseFont = true;
            this.btnC8.Location = new System.Drawing.Point(765, 371);
            this.btnC8.Name = "btnC8";
            this.btnC8.Size = new System.Drawing.Size(150, 96);
            this.btnC8.TabIndex = 45;
            this.btnC8.Text = "8";
            this.btnC8.Click += new System.EventHandler(this.button_click);
            // 
            // btnCC
            // 
            this.btnCC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCC.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnCC.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCC.Appearance.Options.UseBackColor = true;
            this.btnCC.Appearance.Options.UseFont = true;
            this.btnCC.Location = new System.Drawing.Point(921, 478);
            this.btnCC.Name = "btnCC";
            this.btnCC.Size = new System.Drawing.Size(150, 96);
            this.btnCC.TabIndex = 48;
            this.btnCC.Text = "X";
            this.btnCC.Click += new System.EventHandler(this.btnCC_Click);
            // 
            // btnC0
            // 
            this.btnC0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnC0.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnC0.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnC0.Appearance.Options.UseBackColor = true;
            this.btnC0.Appearance.Options.UseFont = true;
            this.btnC0.Location = new System.Drawing.Point(765, 478);
            this.btnC0.Name = "btnC0";
            this.btnC0.Size = new System.Drawing.Size(150, 96);
            this.btnC0.TabIndex = 47;
            this.btnC0.Text = "0";
            this.btnC0.Click += new System.EventHandler(this.button_click);
            // 
            // btnGetTotalPrice
            // 
            this.btnGetTotalPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetTotalPrice.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnGetTotalPrice.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGetTotalPrice.Appearance.Options.UseBackColor = true;
            this.btnGetTotalPrice.Appearance.Options.UseFont = true;
            this.btnGetTotalPrice.Location = new System.Drawing.Point(1077, 159);
            this.btnGetTotalPrice.Name = "btnGetTotalPrice";
            this.btnGetTotalPrice.Size = new System.Drawing.Size(150, 202);
            this.btnGetTotalPrice.TabIndex = 49;
            this.btnGetTotalPrice.Text = "HEPSİ";
            this.btnGetTotalPrice.Click += new System.EventHandler(this.btnGetTotalPrice_Click);
            // 
            // btnTotalValue
            // 
            this.btnTotalValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTotalValue.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnTotalValue.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTotalValue.Appearance.Options.UseBackColor = true;
            this.btnTotalValue.Appearance.Options.UseFont = true;
            this.btnTotalValue.Location = new System.Drawing.Point(1077, 370);
            this.btnTotalValue.Name = "btnTotalValue";
            this.btnTotalValue.Size = new System.Drawing.Size(150, 202);
            this.btnTotalValue.TabIndex = 50;
            this.btnTotalValue.Text = "0,00";
            // 
            // lblDiscount
            // 
            this.lblDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDiscount.Location = new System.Drawing.Point(925, 122);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(28, 18);
            this.lblDiscount.TabIndex = 51;
            this.lblDiscount.Text = "[2]";
            this.lblDiscount.Visible = false;
            // 
            // lblRound
            // 
            this.lblRound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRound.AutoSize = true;
            this.lblRound.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblRound.Location = new System.Drawing.Point(873, 122);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(28, 18);
            this.lblRound.TabIndex = 52;
            this.lblRound.Text = "[1]";
            this.lblRound.Visible = false;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // frmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1524, 642);
            this.Controls.Add(this.lblRound);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.btnTotalValue);
            this.Controls.Add(this.btnGetTotalPrice);
            this.Controls.Add(this.btnCC);
            this.Controls.Add(this.btnC0);
            this.Controls.Add(this.btnC9);
            this.Controls.Add(this.btnC8);
            this.Controls.Add(this.btnC6);
            this.Controls.Add(this.btnC5);
            this.Controls.Add(this.btnC3);
            this.Controls.Add(this.btnC2);
            this.Controls.Add(this.btnCV);
            this.Controls.Add(this.btnC7);
            this.Controls.Add(this.btnC4);
            this.Controls.Add(this.btnC1);
            this.Controls.Add(this.gridPaymentProducts);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRestaurantTicket);
            this.Controls.Add(this.btnCreditCard);
            this.Controls.Add(this.btnCash);
            this.Controls.Add(this.btnTicket);
            this.Controls.Add(this.btnDiscount);
            this.Controls.Add(this.btn100);
            this.Controls.Add(this.btn50);
            this.Controls.Add(this.btn20);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn10);
            this.Controls.Add(this.txtCharged);
            this.Controls.Add(this.txtTotalCash);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPayment";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ÖDEME";
            this.Load += new System.EventHandler(this.frmPayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalCash.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCharged.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPaymentProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtTotalCash;
        private DevExpress.XtraEditors.TextEdit txtCharged;
        private DevExpress.XtraEditors.SimpleButton btn5;
        private DevExpress.XtraEditors.SimpleButton btn10;
        private DevExpress.XtraEditors.SimpleButton btn20;
        private DevExpress.XtraEditors.SimpleButton btn1;
        private DevExpress.XtraEditors.SimpleButton btn100;
        private DevExpress.XtraEditors.SimpleButton btn50;
        private DevExpress.XtraEditors.SimpleButton btnDiscount;
        private DevExpress.XtraEditors.SimpleButton btnTicket;
        private DevExpress.XtraEditors.SimpleButton btnCash;
        private DevExpress.XtraEditors.SimpleButton btnCreditCard;
        private DevExpress.XtraEditors.SimpleButton btnRestaurantTicket;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        public DevExpress.XtraGrid.GridControl gridPaymentProducts;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.SimpleButton btnC1;
        private DevExpress.XtraEditors.SimpleButton btnC4;
        private DevExpress.XtraEditors.SimpleButton btnC7;
        private DevExpress.XtraEditors.SimpleButton btnCV;
        private DevExpress.XtraEditors.SimpleButton btnC2;
        private DevExpress.XtraEditors.SimpleButton btnC3;
        private DevExpress.XtraEditors.SimpleButton btnC6;
        private DevExpress.XtraEditors.SimpleButton btnC5;
        private DevExpress.XtraEditors.SimpleButton btnC9;
        private DevExpress.XtraEditors.SimpleButton btnC8;
        private DevExpress.XtraEditors.SimpleButton btnCC;
        private DevExpress.XtraEditors.SimpleButton btnC0;
        private DevExpress.XtraEditors.SimpleButton btnGetTotalPrice;
        private DevExpress.XtraEditors.SimpleButton btnTotalValue;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblRound;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}