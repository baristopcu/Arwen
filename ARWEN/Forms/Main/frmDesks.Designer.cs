namespace ARWEN
{
    partial class frmDesks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDesks));
            this.flwDeskChoose = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddReservation = new DevExpress.XtraEditors.SimpleButton();
            this.btnMoveDesk = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // flwDeskChoose
            // 
            this.flwDeskChoose.Location = new System.Drawing.Point(31, 74);
            this.flwDeskChoose.Name = "flwDeskChoose";
            this.flwDeskChoose.Size = new System.Drawing.Size(1281, 636);
            this.flwDeskChoose.TabIndex = 5;
            // 
            // btnAddReservation
            // 
            this.btnAddReservation.Image = ((System.Drawing.Image)(resources.GetObject("btnAddReservation.Image")));
            this.btnAddReservation.Location = new System.Drawing.Point(688, 21);
            this.btnAddReservation.Name = "btnAddReservation";
            this.btnAddReservation.Size = new System.Drawing.Size(271, 44);
            this.btnAddReservation.TabIndex = 4;
            this.btnAddReservation.Text = "REZERVASYON EKLE";
            this.btnAddReservation.Click += new System.EventHandler(this.btnAddReservation_Click);
            // 
            // btnMoveDesk
            // 
            this.btnMoveDesk.Image = global::ARWEN.Properties.Resources.redo_32x32;
            this.btnMoveDesk.Location = new System.Drawing.Point(396, 21);
            this.btnMoveDesk.Name = "btnMoveDesk";
            this.btnMoveDesk.Size = new System.Drawing.Size(271, 44);
            this.btnMoveDesk.TabIndex = 3;
            this.btnMoveDesk.Text = "MASAYI TAŞI";
            this.btnMoveDesk.Click += new System.EventHandler(this.btnMoveDesk_Click);
            // 
            // frmDesks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 715);
            this.Controls.Add(this.flwDeskChoose);
            this.Controls.Add(this.btnAddReservation);
            this.Controls.Add(this.btnMoveDesk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDesks";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Masalar | ARWEN";
            this.Load += new System.EventHandler(this.frmDesks_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnAddReservation;
        private DevExpress.XtraEditors.SimpleButton btnMoveDesk;
        private System.Windows.Forms.FlowLayoutPanel flwDeskChoose;
    }
}