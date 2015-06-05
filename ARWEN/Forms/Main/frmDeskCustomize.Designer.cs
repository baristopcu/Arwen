namespace ARWEN
{
    partial class frmDeskCustomize
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeskCustomize));
            this.btnMoveDesk = new DevExpress.XtraEditors.SimpleButton();
            this.btnWriteTicket = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddNote = new DevExpress.XtraEditors.SimpleButton();
            this.gridProducts = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnPayment = new DevExpress.XtraEditors.SimpleButton();
            this.flwProductGroups = new System.Windows.Forms.FlowLayoutPanel();
            this.flwProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnLess = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeleteRow = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveOrder = new DevExpress.XtraEditors.SimpleButton();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.groupControlTable = new DevExpress.XtraEditors.GroupControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlTable)).BeginInit();
            this.groupControlTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMoveDesk
            // 
            this.btnMoveDesk.Image = global::ARWEN.Properties.Resources.redo_32x32;
            this.btnMoveDesk.Location = new System.Drawing.Point(12, 411);
            this.btnMoveDesk.Name = "btnMoveDesk";
            this.btnMoveDesk.Size = new System.Drawing.Size(142, 85);
            this.btnMoveDesk.TabIndex = 0;
            this.btnMoveDesk.Text = "Masayı Taşı";
            this.btnMoveDesk.Click += new System.EventHandler(this.btnMoveDesk_Click);
            // 
            // btnWriteTicket
            // 
            this.btnWriteTicket.Image = global::ARWEN.Properties.Resources.print_32x32;
            this.btnWriteTicket.Location = new System.Drawing.Point(12, 524);
            this.btnWriteTicket.Name = "btnWriteTicket";
            this.btnWriteTicket.Size = new System.Drawing.Size(142, 85);
            this.btnWriteTicket.TabIndex = 1;
            this.btnWriteTicket.Text = "Fişi Yazdır";
            this.btnWriteTicket.Click += new System.EventHandler(this.btnWriteTicket_Click);
            // 
            // btnAddNote
            // 
            this.btnAddNote.Image = global::ARWEN.Properties.Resources.notes_32x32;
            this.btnAddNote.Location = new System.Drawing.Point(12, 637);
            this.btnAddNote.Name = "btnAddNote";
            this.btnAddNote.Size = new System.Drawing.Size(142, 85);
            this.btnAddNote.TabIndex = 2;
            this.btnAddNote.Text = "Not Ekle";
            this.btnAddNote.Click += new System.EventHandler(this.btnAddNote_Click);
            // 
            // gridProducts
            // 
            this.gridProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridProducts.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridProducts.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridProducts.Location = new System.Drawing.Point(4, 23);
            this.gridProducts.MainView = this.gridView1;
            this.gridProducts.Margin = new System.Windows.Forms.Padding(2);
            this.gridProducts.Name = "gridProducts";
            this.gridProducts.Size = new System.Drawing.Size(457, 584);
            this.gridProducts.TabIndex = 3;
            this.gridProducts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn5,
            this.gridColumn6});
            this.gridView1.GridControl = this.gridProducts;
            this.gridView1.GroupPanelText = "Siparişleriniz";
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
            this.gridColumn1.Width = 297;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "SİPARİŞ ADI";
            this.gridColumn2.FieldName = "ProductName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 634;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "FİYAT";
            this.gridColumn3.FieldName = "Price";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 473;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "EditAmount";
            this.gridColumn5.FieldName = "EditAmount";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "BİRİM";
            this.gridColumn6.FieldName = "UnitName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn6.Width = 225;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(515, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "---------------------------------------------------------------------------------" +
    "----------------------------------------------";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(278, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "Ürün Seçimi";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(964, 638);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(303, 85);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "ÇIKIŞ";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPayment
            // 
            this.btnPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPayment.Image = global::ARWEN.Properties.Resources.currency_32x32;
            this.btnPayment.Location = new System.Drawing.Point(631, 638);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(312, 85);
            this.btnPayment.TabIndex = 15;
            this.btnPayment.Text = "ÖDEME AL";
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // flwProductGroups
            // 
            this.flwProductGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flwProductGroups.Location = new System.Drawing.Point(5, 24);
            this.flwProductGroups.Name = "flwProductGroups";
            this.flwProductGroups.Size = new System.Drawing.Size(630, 167);
            this.flwProductGroups.TabIndex = 18;
            // 
            // flwProducts
            // 
            this.flwProducts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flwProducts.Location = new System.Drawing.Point(5, 247);
            this.flwProducts.Name = "flwProducts";
            this.flwProducts.Size = new System.Drawing.Size(630, 359);
            this.flwProducts.TabIndex = 19;
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Image = global::ARWEN.Properties.Resources.add_32x32;
            this.btnAdd.Location = new System.Drawing.Point(12, 26);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(142, 85);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "+";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnLess
            // 
            this.btnLess.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLess.Appearance.Options.UseFont = true;
            this.btnLess.Image = global::ARWEN.Properties.Resources.remove_32x32;
            this.btnLess.Location = new System.Drawing.Point(12, 142);
            this.btnLess.Name = "btnLess";
            this.btnLess.Size = new System.Drawing.Size(142, 85);
            this.btnLess.TabIndex = 21;
            this.btnLess.Text = "-";
            this.btnLess.Click += new System.EventHandler(this.btnLess_Click);
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDeleteRow.Appearance.Options.UseFont = true;
            this.btnDeleteRow.Image = global::ARWEN.Properties.Resources.cancel_32x32;
            this.btnDeleteRow.Location = new System.Drawing.Point(12, 258);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(142, 85);
            this.btnDeleteRow.TabIndex = 22;
            this.btnDeleteRow.Text = "Kaldır";
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 364);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "---------------------------------";
            // 
            // btnSaveOrder
            // 
            this.btnSaveOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveOrder.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSaveOrder.Appearance.Options.UseFont = true;
            this.btnSaveOrder.Image = global::ARWEN.Properties.Resources.save_32x32;
            this.btnSaveOrder.Location = new System.Drawing.Point(160, 638);
            this.btnSaveOrder.Name = "btnSaveOrder";
            this.btnSaveOrder.Size = new System.Drawing.Size(465, 85);
            this.btnSaveOrder.TabIndex = 25;
            this.btnSaveOrder.Text = "SİPARİŞİ KAYDET";
            this.btnSaveOrder.Click += new System.EventHandler(this.btnSaveOrder_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // groupControlTable
            // 
            this.groupControlTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControlTable.Controls.Add(this.gridProducts);
            this.groupControlTable.Location = new System.Drawing.Point(160, 21);
            this.groupControlTable.Name = "groupControlTable";
            this.groupControlTable.Size = new System.Drawing.Size(466, 611);
            this.groupControlTable.TabIndex = 27;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.flwProductGroups);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.flwProducts);
            this.groupControl1.Location = new System.Drawing.Point(632, 21);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(641, 611);
            this.groupControl1.TabIndex = 28;
            // 
            // frmDeskCustomize
            // 
            this.AcceptButton = this.btnSaveOrder;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1276, 737);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupControlTable);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSaveOrder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDeleteRow);
            this.Controls.Add(this.btnLess);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnPayment);
            this.Controls.Add(this.btnAddNote);
            this.Controls.Add(this.btnWriteTicket);
            this.Controls.Add(this.btnMoveDesk);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDeskCustomize";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Masa Detay | ARWEN";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDeskCustomize_FormClosing);
            this.Load += new System.EventHandler(this.frmDeskCustomize_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlTable)).EndInit();
            this.groupControlTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnMoveDesk;
        private DevExpress.XtraEditors.SimpleButton btnWriteTicket;
        private DevExpress.XtraEditors.SimpleButton btnAddNote;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnPayment;
        private System.Windows.Forms.FlowLayoutPanel flwProductGroups;
        private System.Windows.Forms.FlowLayoutPanel flwProducts;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnLess;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.SimpleButton btnDeleteRow;
        private System.Windows.Forms.Label label4;
        public DevExpress.XtraGrid.GridControl gridProducts;
        private DevExpress.XtraEditors.SimpleButton btnSaveOrder;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.GroupControl groupControlTable;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}