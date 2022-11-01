using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmReportHD : Form
    {
        DB db = new DB();
        SqlDataAdapter daBaoCaoHD = null;
        DataSet ds;

        public frmReportHD()
        {
            InitializeComponent();
        }
        public void createReport(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                string sql = "select*from HoaDon where NgayLapHD between @ngayDau and @ngayCuoi";
                daBaoCaoHD = new SqlDataAdapter();
                daBaoCaoHD.SelectCommand = new SqlCommand();
                daBaoCaoHD.SelectCommand.CommandText = sql;
                daBaoCaoHD.SelectCommand.Connection = db.getConnection();
                daBaoCaoHD.SelectCommand.Parameters.AddWithValue("@ngayDau", tuNgay);
                daBaoCaoHD.SelectCommand.Parameters.AddWithValue("@ngayCuoi", denNgay);
                daBaoCaoHD.SelectCommand.CommandType = CommandType.Text;
                ds = new DataSet();
                daBaoCaoHD.Fill(ds);
                rpvHD.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                //Đường dẫn báo cáo
                rpvHD.LocalReport.ReportPath = "rptHD.rdlc";
                //Nếu có dữ liệu
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //Tạo nguồn dữ liệu cho báo cáo
                    ReportDataSource rds = new ReportDataSource();
                    rds.Name = "tblHD";
                    rds.Value = ds.Tables[0];
                    //Xóa dữ liệu của báo cáo cũ trong trường hợp người dùng thực hiện câu truy vấn khác
                    rpvHD.LocalReport.DataSources.Clear();
                    //Add dữ liệu vào báo cáo
                    rpvHD.LocalReport.DataSources.Add(rds);
                    //Refresh lại báo cáo
                    rpvHD.RefreshReport();
                }
            }
            catch (SqlException a)
            {
                db.messageError("Lỗi! HoaDon!", "Không lấy được dữ liệu! " + a.Message);
            }
        }

        private void frmReportHD_Load(object sender, EventArgs e)
        {
            createReport(Convert.ToDateTime("1-1-1980"), Convert.ToDateTime("1-1-9980"));
        }

        private void frmReportHD_FormClosing(object sender, FormClosingEventArgs e)
        {
            db.closeConnection();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnResetReportHD_Click(object sender, EventArgs e)
        {
            createReport(Convert.ToDateTime("1-1-1980"), Convert.ToDateTime("1-1-9980"));
        }

        private void btnReportHD_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = Convert.ToDateTime(dtpTuNgay.Value.ToShortDateString().Trim());
            DateTime denNgay = Convert.ToDateTime(dtpDenNgay.Value.ToShortDateString().Trim());
            createReport(tuNgay, denNgay);
        }
    }
}
