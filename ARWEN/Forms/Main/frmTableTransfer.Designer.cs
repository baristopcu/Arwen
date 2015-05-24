namespace ARWEN.Forms.Main
{
    partial class frmTableTransfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTableTransfer));
            this.cmbTable = new System.Windows.Forms.ComboBox();
            this.cmbTableTo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTasi = new DevExpress.XtraEditors.SimpleButton();
            this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // cmbTable
            // 
            this.cmbTable.FormattingEnabled = true;
            this.cmbTable.Location = new System.Drawing.Point(143, 24);
            this.cmbTable.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTable.Name = "cmbTable";
            this.cmbTable.Size = new System.Drawing.Size(160, 26);
            this.cmbTable.TabIndex = 0;
            // 
            // cmbTableTo
            // 
            this.cmbTableTo.FormattingEnabled = true;
            this.cmbTableTo.Location = new System.Drawing.Point(143, 65);
            this.cmbTableTo.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTableTo.Name = "cmbTableTo";
            this.cmbTableTo.Size = new System.Drawing.Size(160, 26);
            this.cmbTableTo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 73);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bu Masaya";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bu Masayı ;";
            // 
            // btnTasi
            // 
            this.btnTasi.Image = ((System.Drawing.Image)(resources.GetObject("btnTasi.Image")));
            this.btnTasi.Location = new System.Drawing.Point(28, 122);
            this.btnTasi.Margin = new System.Windows.Forms.Padding(4);
            this.btnTasi.Name = "btnTasi";
            this.btnTasi.Size = new System.Drawing.Size(129, 32);
            this.btnTasi.TabIndex = 4;
            this.btnTasi.Text = "Taşı";
            this.btnTasi.Click += new System.EventHandler(this.btnTasi_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnIptal.Image = ((System.Drawing.Image)(resources.GetObject("btnIptal.Image")));
            this.btnIptal.Location = new System.Drawing.Point(179, 122);
            this.btnIptal.Margin = new System.Windows.Forms.Padding(4);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(125, 32);
            this.btnIptal.TabIndex = 5;
            this.btnIptal.Text = "İptal";
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // frmTableTransfer
            // 
            this.AcceptButton = this.btnTasi;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnIptal;
            this.ClientSize = new System.Drawing.Size(335, 170);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnTasi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTableTo);
            this.Controls.Add(this.cmbTable);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.LookAndFeel.SkinMaskColor2 = System.Drawing.SystemColors.ActiveCaptionText;
            this.LookAndFeel.SkinName = "Darkroom";
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTableTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Masa Taşı | Arwen";
            this.Load += new System.EventHandler(this.frmTableTransfer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTable;
        private System.Windows.Forms.ComboBox cmbTableTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnTasi;
        private DevExpress.XtraEditors.SimpleButton btnIptal;
    }
}