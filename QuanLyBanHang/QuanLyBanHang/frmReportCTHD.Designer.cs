namespace QuanLyBanHang
{
    partial class frmReportCTHD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportCTHD));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.gbCTHD = new System.Windows.Forms.GroupBox();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.btnReportCTHD = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTroVe = new System.Windows.Forms.Button();
            this.btnResetReportCTHD = new System.Windows.Forms.Button();
            this.gbShowReportCTHD = new System.Windows.Forms.GroupBox();
            this.rpvCTHD = new Microsoft.Reporting.WinForms.ReportViewer();
            this.gbDSHD = new System.Windows.Forms.GroupBox();
            this.dgvDSHD = new System.Windows.Forms.DataGridView();
            this.MaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayLapHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayNhanHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbCTHD.SuspendLayout();
            this.gbShowReportCTHD.SuspendLayout();
            this.gbDSHD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHD)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCTHD
            // 
            this.gbCTHD.Controls.Add(this.dtpDenNgay);
            this.gbCTHD.Controls.Add(this.label2);
            this.gbCTHD.Controls.Add(this.dtpTuNgay);
            this.gbCTHD.Controls.Add(this.btnReportCTHD);
            this.gbCTHD.Controls.Add(this.label1);
            this.gbCTHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCTHD.Location = new System.Drawing.Point(13, 12);
            this.gbCTHD.Name = "gbCTHD";
            this.gbCTHD.Size = new System.Drawing.Size(698, 68);
            this.gbCTHD.TabIndex = 13;
            this.gbCTHD.TabStop = false;
            this.gbCTHD.Text = "Điều Kiện Cho Báo Cáo";
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
            // btnReportCTHD
            // 
            this.btnReportCTHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportCTHD.ForeColor = System.Drawing.Color.Blue;
            this.btnReportCTHD.Image = ((System.Drawing.Image)(resources.GetObject("btnReportCTHD.Image")));
            this.btnReportCTHD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportCTHD.Location = new System.Drawing.Point(590, 22);
            this.btnReportCTHD.Name = "btnReportCTHD";
            this.btnReportCTHD.Size = new System.Drawing.Size(90, 34);
            this.btnReportCTHD.TabIndex = 2;
            this.btnReportCTHD.Text = "Tạo BC";
            this.btnReportCTHD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReportCTHD.UseVisualStyleBackColor = true;
            this.btnReportCTHD.Click += new System.EventHandler(this.btnReportCTHD_Click);
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
            this.btnTroVe.Location = new System.Drawing.Point(621, 630);
            this.btnTroVe.Name = "btnTroVe";
            this.btnTroVe.Size = new System.Drawing.Size(90, 34);
            this.btnTroVe.TabIndex = 12;
            this.btnTroVe.Text = "Trở Về";
            this.btnTroVe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTroVe.UseVisualStyleBackColor = true;
            this.btnTroVe.Click += new System.EventHandler(this.btnTroVe_Click);
            // 
            // btnResetReportCTHD
            // 
            this.btnResetReportCTHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetReportCTHD.ForeColor = System.Drawing.Color.Blue;
            this.btnResetReportCTHD.Image = ((System.Drawing.Image)(resources.GetObject("btnResetReportCTHD.Image")));
            this.btnResetReportCTHD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResetReportCTHD.Location = new System.Drawing.Point(12, 630);
            this.btnResetReportCTHD.Name = "btnResetReportCTHD";
            this.btnResetReportCTHD.Size = new System.Drawing.Size(83, 34);
            this.btnResetReportCTHD.TabIndex = 11;
            this.btnResetReportCTHD.Text = "Reset";
            this.btnResetReportCTHD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnResetReportCTHD.UseVisualStyleBackColor = true;
            this.btnResetReportCTHD.Click += new System.EventHandler(this.btnResetReportCTHD_Click);
            // 
            // gbShowReportCTHD
            // 
            this.gbShowReportCTHD.Controls.Add(this.rpvCTHD);
            this.gbShowReportCTHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbShowReportCTHD.Location = new System.Drawing.Point(13, 292);
            this.gbShowReportCTHD.Name = "gbShowReportCTHD";
            this.gbShowReportCTHD.Size = new System.Drawing.Size(698, 332);
            this.gbShowReportCTHD.TabIndex = 14;
            this.gbShowReportCTHD.TabStop = false;
            this.gbShowReportCTHD.Text = "Hiển Thị Báo Cáo";
            // 
            // rpvCTHD
            // 
            this.rpvCTHD.AutoScroll = true;
            this.rpvCTHD.AutoSize = true;
            reportDataSource1.Name = "tblSP";
            reportDataSource1.Value = null;
            this.rpvCTHD.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvCTHD.LocalReport.DisplayName = "Báo Cáo Khách Hàng";
            this.rpvCTHD.LocalReport.EnableExternalImages = true;
            this.rpvCTHD.LocalReport.EnableHyperlinks = true;
            this.rpvCTHD.Location = new System.Drawing.Point(17, 22);
            this.rpvCTHD.Name = "rpvCTHD";
            this.rpvCTHD.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this.rpvCTHD.ServerReport.BearerToken = null;
            this.rpvCTHD.Size = new System.Drawing.Size(663, 295);
            this.rpvCTHD.TabIndex = 0;
            // 
            // gbDSHD
            // 
            this.gbDSHD.Controls.Add(this.dgvDSHD);
            this.gbDSHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDSHD.Location = new System.Drawing.Point(12, 86);
            this.gbDSHD.Name = "gbDSHD";
            this.gbDSHD.Size = new System.Drawing.Size(698, 200);
            this.gbDSHD.TabIndex = 14;
            this.gbDSHD.TabStop = false;
            this.gbDSHD.Text = "Danh Sách Hóa Đơn Theo Ngày";
            // 
            // dgvDSHD
            // 
            this.dgvDSHD.AllowUserToAddRows = false;
            this.dgvDSHD.AllowUserToDeleteRows = false;
            this.dgvDSHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDSHD.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDSHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSHD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHD,
            this.MaKH,
            this.MaNV,
            this.NgayLapHD,
            this.NgayNhanHang});
            this.dgvDSHD.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDSHD.Location = new System.Drawing.Point(18, 22);
            this.dgvDSHD.MultiSelect = false;
            this.dgvDSHD.Name = "dgvDSHD";
            this.dgvDSHD.ReadOnly = true;
            this.dgvDSHD.Size = new System.Drawing.Size(663, 164);
            this.dgvDSHD.TabIndex = 0;
            this.dgvDSHD.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSHD_CellClick);
            this.dgvDSHD.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDSHD_DataError);
            // 
            // MaHD
            // 
            this.MaHD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaHD.DataPropertyName = "MaHD";
            this.MaHD.HeaderText = "Mã HD";
            this.MaHD.Name = "MaHD";
            this.MaHD.ReadOnly = true;
            // 
            // MaKH
            // 
            this.MaKH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaKH.DataPropertyName = "MaKH";
            this.MaKH.HeaderText = "Mã KH";
            this.MaKH.Name = "MaKH";
            this.MaKH.ReadOnly = true;
            // 
            // MaNV
            // 
            this.MaNV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaNV.DataPropertyName = "MaNV";
            this.MaNV.HeaderText = "Mã NV";
            this.MaNV.Name = "MaNV";
            this.MaNV.ReadOnly = true;
            // 
            // NgayLapHD
            // 
            this.NgayLapHD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NgayLapHD.DataPropertyName = "NgayLapHD";
            this.NgayLapHD.HeaderText = "Ngày Lập HD";
            this.NgayLapHD.Name = "NgayLapHD";
            this.NgayLapHD.ReadOnly = true;
            // 
            // NgayNhanHang
            // 
            this.NgayNhanHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NgayNhanHang.DataPropertyName = "NgayNhanHang";
            this.NgayNhanHang.HeaderText = "Ngày Nhận Hàng";
            this.NgayNhanHang.Name = "NgayNhanHang";
            this.NgayNhanHang.ReadOnly = true;
            // 
            // frmReportCTHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(723, 669);
            this.Controls.Add(this.gbDSHD);
            this.Controls.Add(this.gbCTHD);
            this.Controls.Add(this.btnTroVe);
            this.Controls.Add(this.btnResetReportCTHD);
            this.Controls.Add(this.gbShowReportCTHD);
            this.Name = "frmReportCTHD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Danh Sách Sản Phẩm Theo Hóa Đơn";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReportCTHD_FormClosing);
            this.Load += new System.EventHandler(this.frmReportCTHD_Load);
            this.gbCTHD.ResumeLayout(false);
            this.gbCTHD.PerformLayout();
            this.gbShowReportCTHD.ResumeLayout(false);
            this.gbShowReportCTHD.PerformLayout();
            this.gbDSHD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCTHD;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Button btnReportCTHD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTroVe;
        private System.Windows.Forms.Button btnResetReportCTHD;
        private System.Windows.Forms.GroupBox gbShowReportCTHD;
        private Microsoft.Reporting.WinForms.ReportViewer rpvCTHD;
        private System.Windows.Forms.GroupBox gbDSHD;
        private System.Windows.Forms.DataGridView dgvDSHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayLapHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayNhanHang;
    }
}