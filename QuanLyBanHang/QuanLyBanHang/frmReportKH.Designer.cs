namespace QuanLyBanHang
{
    partial class frmReportKH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportKH));
            this.gbKH = new System.Windows.Forms.GroupBox();
            this.btnTroVe = new System.Windows.Forms.Button();
            this.btnResetReportKH = new System.Windows.Forms.Button();
            this.btnReportKH = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbThanhPho = new System.Windows.Forms.ComboBox();
            this.gbShowReportKH = new System.Windows.Forms.GroupBox();
            this.rpvKH = new Microsoft.Reporting.WinForms.ReportViewer();
            this.gbKH.SuspendLayout();
            this.gbShowReportKH.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbKH
            // 
            this.gbKH.Controls.Add(this.btnTroVe);
            this.gbKH.Controls.Add(this.btnResetReportKH);
            this.gbKH.Controls.Add(this.btnReportKH);
            this.gbKH.Controls.Add(this.label1);
            this.gbKH.Controls.Add(this.cbThanhPho);
            this.gbKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbKH.Location = new System.Drawing.Point(13, 13);
            this.gbKH.Name = "gbKH";
            this.gbKH.Size = new System.Drawing.Size(698, 68);
            this.gbKH.TabIndex = 0;
            this.gbKH.TabStop = false;
            this.gbKH.Text = "Điều Kiện Cho Báo Cáo";
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
            this.label1.Location = new System.Drawing.Point(46, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chọn Thành Phố:";
            // 
            // cbThanhPho
            // 
            this.cbThanhPho.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbThanhPho.FormattingEnabled = true;
            this.cbThanhPho.Location = new System.Drawing.Point(186, 27);
            this.cbThanhPho.Name = "cbThanhPho";
            this.cbThanhPho.Size = new System.Drawing.Size(137, 24);
            this.cbThanhPho.TabIndex = 0;
            // 
            // gbShowReportKH
            // 
            this.gbShowReportKH.Controls.Add(this.rpvKH);
            this.gbShowReportKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbShowReportKH.Location = new System.Drawing.Point(13, 87);
            this.gbShowReportKH.Name = "gbShowReportKH";
            this.gbShowReportKH.Size = new System.Drawing.Size(698, 324);
            this.gbShowReportKH.TabIndex = 4;
            this.gbShowReportKH.TabStop = false;
            this.gbShowReportKH.Text = "Hiển Thị Báo Cáo";
            // 
            // rpvKH
            // 
            this.rpvKH.AutoScroll = true;
            this.rpvKH.AutoSize = true;
            this.rpvKH.LocalReport.DisplayName = "Báo Cáo Khách Hàng";
            this.rpvKH.LocalReport.EnableExternalImages = true;
            this.rpvKH.LocalReport.EnableHyperlinks = true;
            this.rpvKH.Location = new System.Drawing.Point(17, 33);
            this.rpvKH.Name = "rpvKH";
            this.rpvKH.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this.rpvKH.ServerReport.BearerToken = null;
            this.rpvKH.Size = new System.Drawing.Size(663, 271);
            this.rpvKH.TabIndex = 0;
            // 
            // frmReportKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 423);
            this.Controls.Add(this.gbShowReportKH);
            this.Controls.Add(this.gbKH);
            this.Name = "frmReportKH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Danh Sách Khách Hàng Theo Thành Phố";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReportKH_FormClosing);
            this.Load += new System.EventHandler(this.frmReportKH_Load);
            this.gbKH.ResumeLayout(false);
            this.gbKH.PerformLayout();
            this.gbShowReportKH.ResumeLayout(false);
            this.gbShowReportKH.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbKH;
        private System.Windows.Forms.Button btnResetReportKH;
        private System.Windows.Forms.Button btnReportKH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbThanhPho;
        private System.Windows.Forms.GroupBox gbShowReportKH;
        private Microsoft.Reporting.WinForms.ReportViewer rpvKH;
        private System.Windows.Forms.Button btnTroVe;
    }
}