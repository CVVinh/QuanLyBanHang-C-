namespace QuanLyBanHang
{
    partial class frmReportHD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportHD));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.gbHD = new System.Windows.Forms.GroupBox();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.btnReportHD = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTroVe = new System.Windows.Forms.Button();
            this.btnResetReportHD = new System.Windows.Forms.Button();
            this.gbShowReportHD = new System.Windows.Forms.GroupBox();
            this.rpvHD = new Microsoft.Reporting.WinForms.ReportViewer();
            this.gbHD.SuspendLayout();
            this.gbShowReportHD.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbHD
            // 
            this.gbHD.Controls.Add(this.dtpDenNgay);
            this.gbHD.Controls.Add(this.label2);
            this.gbHD.Controls.Add(this.dtpTuNgay);
            this.gbHD.Controls.Add(this.btnReportHD);
            this.gbHD.Controls.Add(this.label1);
            this.gbHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbHD.Location = new System.Drawing.Point(13, 12);
            this.gbHD.Name = "gbHD";
            this.gbHD.Size = new System.Drawing.Size(698, 68);
            this.gbHD.TabIndex = 9;
            this.gbHD.TabStop = false;
            this.gbHD.Text = "Điều Kiện Cho Báo Cáo";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDenNgay.Location = new System.Drawing.Point(382, 30);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(200, 21);
            this.dtpDenNgay.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(292, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Đến Ngày:";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTuNgay.Location = new System.Drawing.Point(86, 30);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(200, 21);
            this.dtpTuNgay.TabIndex = 5;
            // 
            // btnReportHD
            // 
            this.btnReportHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportHD.ForeColor = System.Drawing.Color.Blue;
            this.btnReportHD.Image = ((System.Drawing.Image)(resources.GetObject("btnReportHD.Image")));
            this.btnReportHD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportHD.Location = new System.Drawing.Point(590, 22);
            this.btnReportHD.Name = "btnReportHD";
            this.btnReportHD.Size = new System.Drawing.Size(90, 34);
            this.btnReportHD.TabIndex = 2;
            this.btnReportHD.Text = "Tạo BC";
            this.btnReportHD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReportHD.UseVisualStyleBackColor = true;
            this.btnReportHD.Click += new System.EventHandler(this.btnReportHD_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Từ Ngày:";
            // 
            // btnTroVe
            // 
            this.btnTroVe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTroVe.ForeColor = System.Drawing.Color.Blue;
            this.btnTroVe.Image = ((System.Drawing.Image)(resources.GetObject("btnTroVe.Image")));
            this.btnTroVe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTroVe.Location = new System.Drawing.Point(621, 454);
            this.btnTroVe.Name = "btnTroVe";
            this.btnTroVe.Size = new System.Drawing.Size(90, 34);
            this.btnTroVe.TabIndex = 8;
            this.btnTroVe.Text = "Trở Về";
            this.btnTroVe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTroVe.UseVisualStyleBackColor = true;
            this.btnTroVe.Click += new System.EventHandler(this.btnTroVe_Click);
            // 
            // btnResetReportHD
            // 
            this.btnResetReportHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetReportHD.ForeColor = System.Drawing.Color.Blue;
            this.btnResetReportHD.Image = ((System.Drawing.Image)(resources.GetObject("btnResetReportHD.Image")));
            this.btnResetReportHD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResetReportHD.Location = new System.Drawing.Point(12, 454);
            this.btnResetReportHD.Name = "btnResetReportHD";
            this.btnResetReportHD.Size = new System.Drawing.Size(83, 34);
            this.btnResetReportHD.TabIndex = 7;
            this.btnResetReportHD.Text = "Reset";
            this.btnResetReportHD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnResetReportHD.UseVisualStyleBackColor = true;
            this.btnResetReportHD.Click += new System.EventHandler(this.btnResetReportHD_Click);
            // 
            // gbShowReportHD
            // 
            this.gbShowReportHD.Controls.Add(this.rpvHD);
            this.gbShowReportHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbShowReportHD.Location = new System.Drawing.Point(13, 86);
            this.gbShowReportHD.Name = "gbShowReportHD";
            this.gbShowReportHD.Size = new System.Drawing.Size(698, 362);
            this.gbShowReportHD.TabIndex = 10;
            this.gbShowReportHD.TabStop = false;
            this.gbShowReportHD.Text = "Hiển Thị Báo Cáo";
            // 
            // rpvHD
            // 
            this.rpvHD.AutoScroll = true;
            this.rpvHD.AutoSize = true;
            reportDataSource1.Name = "tblSP";
            reportDataSource1.Value = null;
            this.rpvHD.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvHD.LocalReport.DisplayName = "Báo Cáo Khách Hàng";
            this.rpvHD.LocalReport.EnableExternalImages = true;
            this.rpvHD.LocalReport.EnableHyperlinks = true;
            this.rpvHD.Location = new System.Drawing.Point(17, 22);
            this.rpvHD.Name = "rpvHD";
            this.rpvHD.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this.rpvHD.ServerReport.BearerToken = null;
            this.rpvHD.Size = new System.Drawing.Size(663, 323);
            this.rpvHD.TabIndex = 0;
            // 
            // frmReportHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(723, 500);
            this.Controls.Add(this.gbHD);
            this.Controls.Add(this.btnTroVe);
            this.Controls.Add(this.btnResetReportHD);
            this.Controls.Add(this.gbShowReportHD);
            this.Name = "frmReportHD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Danh Sách Hóa Đơn Theo Thời Gian";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReportHD_FormClosing);
            this.Load += new System.EventHandler(this.frmReportHD_Load);
            this.gbHD.ResumeLayout(false);
            this.gbHD.PerformLayout();
            this.gbShowReportHD.ResumeLayout(false);
            this.gbShowReportHD.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbHD;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Button btnReportHD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTroVe;
        private System.Windows.Forms.Button btnResetReportHD;
        private System.Windows.Forms.GroupBox gbShowReportHD;
        private Microsoft.Reporting.WinForms.ReportViewer rpvHD;
    }
}