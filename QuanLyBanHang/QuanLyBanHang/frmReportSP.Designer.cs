namespace QuanLyBanHang
{
    partial class frmReportSP
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportSP));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.SanPhamTheoNgayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetSP = new QuanLyBanHang.DataSetSP();
            this.gbSP = new System.Windows.Forms.GroupBox();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.btnReportSP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTroVe = new System.Windows.Forms.Button();
            this.btnResetReportSP = new System.Windows.Forms.Button();
            this.gbShowReportSP = new System.Windows.Forms.GroupBox();
            this.rpvSP = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SanPhamTheoNgayTableAdapter = new QuanLyBanHang.DataSetSPTableAdapters.SanPhamTheoNgayTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SanPhamTheoNgayBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetSP)).BeginInit();
            this.gbSP.SuspendLayout();
            this.gbShowReportSP.SuspendLayout();
            this.SuspendLayout();
            // 
            // SanPhamTheoNgayBindingSource
            // 
            this.SanPhamTheoNgayBindingSource.DataMember = "SanPhamTheoNgay";
            this.SanPhamTheoNgayBindingSource.DataSource = this.DataSetSP;
            // 
            // DataSetSP
            // 
            this.DataSetSP.DataSetName = "DataSetSP";
            this.DataSetSP.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gbSP
            // 
            this.gbSP.Controls.Add(this.dtpDenNgay);
            this.gbSP.Controls.Add(this.label2);
            this.gbSP.Controls.Add(this.dtpTuNgay);
            this.gbSP.Controls.Add(this.btnReportSP);
            this.gbSP.Controls.Add(this.label1);
            this.gbSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSP.Location = new System.Drawing.Point(12, 12);
            this.gbSP.Name = "gbSP";
            this.gbSP.Size = new System.Drawing.Size(698, 68);
            this.gbSP.TabIndex = 5;
            this.gbSP.TabStop = false;
            this.gbSP.Text = "Điều Kiện Cho Báo Cáo";
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
            // btnReportSP
            // 
            this.btnReportSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportSP.ForeColor = System.Drawing.Color.Blue;
            this.btnReportSP.Image = ((System.Drawing.Image)(resources.GetObject("btnReportSP.Image")));
            this.btnReportSP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportSP.Location = new System.Drawing.Point(590, 22);
            this.btnReportSP.Name = "btnReportSP";
            this.btnReportSP.Size = new System.Drawing.Size(90, 34);
            this.btnReportSP.TabIndex = 2;
            this.btnReportSP.Text = "Tạo BC";
            this.btnReportSP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReportSP.UseVisualStyleBackColor = true;
            this.btnReportSP.Click += new System.EventHandler(this.btnReportSP_Click);
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
            this.btnTroVe.Location = new System.Drawing.Point(620, 454);
            this.btnTroVe.Name = "btnTroVe";
            this.btnTroVe.Size = new System.Drawing.Size(90, 34);
            this.btnTroVe.TabIndex = 4;
            this.btnTroVe.Text = "Trở Về";
            this.btnTroVe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTroVe.UseVisualStyleBackColor = true;
            this.btnTroVe.Click += new System.EventHandler(this.btnTroVe_Click);
            // 
            // btnResetReportSP
            // 
            this.btnResetReportSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetReportSP.ForeColor = System.Drawing.Color.Blue;
            this.btnResetReportSP.Image = ((System.Drawing.Image)(resources.GetObject("btnResetReportSP.Image")));
            this.btnResetReportSP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResetReportSP.Location = new System.Drawing.Point(11, 454);
            this.btnResetReportSP.Name = "btnResetReportSP";
            this.btnResetReportSP.Size = new System.Drawing.Size(83, 34);
            this.btnResetReportSP.TabIndex = 3;
            this.btnResetReportSP.Text = "Reset";
            this.btnResetReportSP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnResetReportSP.UseVisualStyleBackColor = true;
            this.btnResetReportSP.Click += new System.EventHandler(this.btnResetReportSP_Click);
            // 
            // gbShowReportSP
            // 
            this.gbShowReportSP.Controls.Add(this.rpvSP);
            this.gbShowReportSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbShowReportSP.Location = new System.Drawing.Point(12, 86);
            this.gbShowReportSP.Name = "gbShowReportSP";
            this.gbShowReportSP.Size = new System.Drawing.Size(698, 362);
            this.gbShowReportSP.TabIndex = 6;
            this.gbShowReportSP.TabStop = false;
            this.gbShowReportSP.Text = "Hiển Thị Báo Cáo";
            // 
            // rpvSP
            // 
            this.rpvSP.AutoScroll = true;
            this.rpvSP.AutoSize = true;
            reportDataSource1.Name = "tblSP";
            reportDataSource1.Value = this.SanPhamTheoNgayBindingSource;
            this.rpvSP.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvSP.LocalReport.DisplayName = "Báo Cáo Khách Hàng";
            this.rpvSP.LocalReport.EnableExternalImages = true;
            this.rpvSP.LocalReport.EnableHyperlinks = true;
            this.rpvSP.Location = new System.Drawing.Point(17, 22);
            this.rpvSP.Name = "rpvSP";
            this.rpvSP.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this.rpvSP.ServerReport.BearerToken = null;
            this.rpvSP.Size = new System.Drawing.Size(663, 323);
            this.rpvSP.TabIndex = 0;
            // 
            // SanPhamTheoNgayTableAdapter
            // 
            this.SanPhamTheoNgayTableAdapter.ClearBeforeFill = true;
            // 
            // frmReportSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 500);
            this.Controls.Add(this.gbSP);
            this.Controls.Add(this.btnTroVe);
            this.Controls.Add(this.btnResetReportSP);
            this.Controls.Add(this.gbShowReportSP);
            this.Name = "frmReportSP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Danh Sách Sản Phẩm Bán Theo Ngày";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReportSP_FormClosing);
            this.Load += new System.EventHandler(this.frmReportSP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SanPhamTheoNgayBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetSP)).EndInit();
            this.gbSP.ResumeLayout(false);
            this.gbSP.PerformLayout();
            this.gbShowReportSP.ResumeLayout(false);
            this.gbShowReportSP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSP;
        private System.Windows.Forms.Button btnTroVe;
        private System.Windows.Forms.Button btnResetReportSP;
        private System.Windows.Forms.Button btnReportSP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbShowReportSP;
        private Microsoft.Reporting.WinForms.ReportViewer rpvSP;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource SanPhamTheoNgayBindingSource;
        private DataSetSP DataSetSP;
        private DataSetSPTableAdapters.SanPhamTheoNgayTableAdapter SanPhamTheoNgayTableAdapter;
    }
}