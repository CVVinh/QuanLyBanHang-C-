namespace QuanLyBanHang
{
    partial class frmReportNV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportNV));
            this.gbNV = new System.Windows.Forms.GroupBox();
            this.txtSLHD = new System.Windows.Forms.TextBox();
            this.btnTroVe = new System.Windows.Forms.Button();
            this.btnResetReportKH = new System.Windows.Forms.Button();
            this.btnReportKH = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gbShowReportNV = new System.Windows.Forms.GroupBox();
            this.rpvNV = new Microsoft.Reporting.WinForms.ReportViewer();
            this.gbNV.SuspendLayout();
            this.gbShowReportNV.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbNV
            // 
            this.gbNV.Controls.Add(this.txtSLHD);
            this.gbNV.Controls.Add(this.btnTroVe);
            this.gbNV.Controls.Add(this.btnResetReportKH);
            this.gbNV.Controls.Add(this.btnReportKH);
            this.gbNV.Controls.Add(this.label1);
            this.gbNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbNV.Location = new System.Drawing.Point(12, 12);
            this.gbNV.Name = "gbNV";
            this.gbNV.Size = new System.Drawing.Size(698, 68);
            this.gbNV.TabIndex = 5;
            this.gbNV.TabStop = false;
            this.gbNV.Text = "Điều Kiện Cho Báo Cáo";
            // 
            // txtSLHD
            // 
            this.txtSLHD.Location = new System.Drawing.Point(186, 28);
            this.txtSLHD.Name = "txtSLHD";
            this.txtSLHD.Size = new System.Drawing.Size(133, 23);
            this.txtSLHD.TabIndex = 5;
            this.txtSLHD.TextChanged += new System.EventHandler(this.txtSLHD_TextChanged);
            // 
            // btnTroVe
            // 
            this.btnTroVe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTroVe.ForeColor = System.Drawing.Color.Blue;
            this.btnTroVe.Image = ((System.Drawing.Image)(resources.GetObject("btnTroVe.Image")));
            this.btnTroVe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTroVe.Location = new System.Drawing.Point(590, 22);
            this.btnTroVe.Name = "btnTroVe";
            this.btnTroVe.Size = new System.Drawing.Size(90, 34);
            this.btnTroVe.TabIndex = 4;
            this.btnTroVe.Text = "Trở Về";
            this.btnTroVe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTroVe.UseVisualStyleBackColor = true;
            this.btnTroVe.Click += new System.EventHandler(this.btnTroVe_Click);
            // 
            // btnResetReportKH
            // 
            this.btnResetReportKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetReportKH.ForeColor = System.Drawing.Color.Blue;
            this.btnResetReportKH.Image = ((System.Drawing.Image)(resources.GetObject("btnResetReportKH.Image")));
            this.btnResetReportKH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResetReportKH.Location = new System.Drawing.Point(491, 22);
            this.btnResetReportKH.Name = "btnResetReportKH";
            this.btnResetReportKH.Size = new System.Drawing.Size(83, 34);
            this.btnResetReportKH.TabIndex = 3;
            this.btnResetReportKH.Text = "Reset";
            this.btnResetReportKH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnResetReportKH.UseVisualStyleBackColor = true;
            this.btnResetReportKH.Click += new System.EventHandler(this.btnResetReportKH_Click);
            // 
            // btnReportKH
            // 
            this.btnReportKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportKH.ForeColor = System.Drawing.Color.Blue;
            this.btnReportKH.Image = ((System.Drawing.Image)(resources.GetObject("btnReportKH.Image")));
            this.btnReportKH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportKH.Location = new System.Drawing.Point(340, 21);
            this.btnReportKH.Name = "btnReportKH";
            this.btnReportKH.Size = new System.Drawing.Size(137, 34);
            this.btnReportKH.TabIndex = 2;
            this.btnReportKH.Text = "Tạo Báo Cáo";
            this.btnReportKH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReportKH.UseVisualStyleBackColor = true;
            this.btnReportKH.Click += new System.EventHandler(this.btnReportKH_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(31, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chọn Số Lượng HD:";
            // 
            // gbShowReportNV
            // 
            this.gbShowReportNV.Controls.Add(this.rpvNV);
            this.gbShowReportNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbShowReportNV.Location = new System.Drawing.Point(12, 86);
            this.gbShowReportNV.Name = "gbShowReportNV";
            this.gbShowReportNV.Size = new System.Drawing.Size(698, 324);
            this.gbShowReportNV.TabIndex = 6;
            this.gbShowReportNV.TabStop = false;
            this.gbShowReportNV.Text = "Hiển Thị Báo Cáo";
            // 
            // rpvNV
            // 
            this.rpvNV.AutoScroll = true;
            this.rpvNV.AutoSize = true;
            this.rpvNV.LocalReport.DisplayName = "Báo Cáo Khách Hàng";
            this.rpvNV.LocalReport.EnableExternalImages = true;
            this.rpvNV.LocalReport.EnableHyperlinks = true;
            this.rpvNV.Location = new System.Drawing.Point(17, 33);
            this.rpvNV.Name = "rpvNV";
            this.rpvNV.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this.rpvNV.ServerReport.BearerToken = null;
            this.rpvNV.Size = new System.Drawing.Size(663, 271);
            this.rpvNV.TabIndex = 0;
            // 
            // frmReportNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 423);
            this.Controls.Add(this.gbNV);
            this.Controls.Add(this.gbShowReportNV);
            this.Name = "frmReportNV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Hiệu Quả Sử Dụng Lao Động";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReportNV_FormClosing);
            this.Load += new System.EventHandler(this.frmReportNV_Load);
            this.gbNV.ResumeLayout(false);
            this.gbNV.PerformLayout();
            this.gbShowReportNV.ResumeLayout(false);
            this.gbShowReportNV.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbNV;
        private System.Windows.Forms.TextBox txtSLHD;
        private System.Windows.Forms.Button btnTroVe;
        private System.Windows.Forms.Button btnResetReportKH;
        private System.Windows.Forms.Button btnReportKH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbShowReportNV;
        private Microsoft.Reporting.WinForms.ReportViewer rpvNV;
    }
}