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
    public partial class frmReportCTHD : Form
    {
        DB db = new DB();
        DataTable dtHoaDon = new DataTable();
        SqlDataAdapter daHoaDon = null;
        SqlDataAdapter daBaoCaoCTHD = null;
        DataSet ds;

        public frmReportCTHD()
        {
            InitializeComponent();
        }
        public void LoadHoaDon(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                string sql = "select*from HoaDon where NgayLapHD between @ngayDau and @ngayCuoi";
                daHoaDon = new SqlDataAdapter();
                daHoaDon.SelectCommand = new SqlCommand();
                daHoaDon.SelectCommand.CommandText = sql;
                daHoaDon.SelectCommand.Connection = db.getConnection();
                daHoaDon.SelectCommand.Parameters.AddWithValue("@ngayDau", tuNgay);
                daHoaDon.SelectCommand.Parameters.AddWithValue("@ngayCuoi", denNgay);
                daHoaDon.SelectCommand.CommandType = CommandType.Text;
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);
                dgvDSHD.DataSource = dtHoaDon;
            }
            catch (Exception a)
            {
                db.loadDataError("HOADON", a.Message.ToString());
            }
        }
        public void createReport(string maHD)
        {
            try
            {
                string sql = "";
                if (maHD != "")
                {
                    sql = "select distinct sp.* " +
                    "from HoaDon hd join ChiTietHoaDon ct on hd.MaHD = ct.MaHD join SanPham sp on sp.MaSP = ct.MaSP " +
                    "where hd.MaHD = @MaHD " +
                    "order by sp.MaSP";
                }else sql = "select distinct sp.* " +
                    "from HoaDon hd join ChiTietHoaDon ct on hd.MaHD = ct.MaHD join SanPham sp on sp.MaSP = ct.MaSP " +
                    "order by sp.MaSP";

                daBaoCaoCTHD = new SqlDataAdapter();
                daBaoCaoCTHD.SelectCommand = new SqlCommand();
                daBaoCaoCTHD.SelectCommand.CommandText = sql;
                daBaoCaoCTHD.SelectCommand.Connection = db.getConnection();
                daBaoCaoCTHD.SelectCommand.Parameters.AddWithValue("@MaHD", maHD);
                daBaoCaoCTHD.SelectCommand.CommandType = CommandType.Text;
                ds = new DataSet();
                daBaoCaoCTHD.Fill(ds);
                rpvCTHD.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                //Đường dẫn báo cáo
                rpvCTHD.LocalReport.ReportPath = "rptCTHD.rdlc";
                //Nếu có dữ liệu
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //Tạo nguồn dữ liệu cho báo cáo
                    ReportDataSource rds = new ReportDataSource();
                    rds.Name = "tblCTHD";
                    rds.Value = ds.Tables[0];
                    //Xóa dữ liệu của báo cáo cũ trong trường hợp người dùng thực hiện câu truy vấn khác
                    rpvCTHD.LocalReport.DataSources.Clear();
                    //Add dữ liệu vào báo cáo
                    rpvCTHD.LocalReport.DataSources.Add(rds);
                    //Refresh lại báo cáo
                    rpvCTHD.RefreshReport();
                }
            }
            catch (SqlException a)
            {
                db.messageError("Lỗi! ChiTietHoaDon!", "Không lấy được dữ liệu! " + a.Message);
            }
        }

        private void frmReportCTHD_Load(object sender, EventArgs e)
        {
            LoadHoaDon(Convert.ToDateTime("1-1-1980"), Convert.ToDateTime("1-1-9980"));
            createReport("");
        }

        private void frmReportCTHD_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtHoaDon.Dispose();
            dtHoaDon = null;
            db.closeConnection();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnResetReportCTHD_Click(object sender, EventArgs e)
        {
            LoadHoaDon(Convert.ToDateTime("1-1-1980"), Convert.ToDateTime("1-1-9980"));
            createReport("");
        }

        private void btnReportCTHD_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = Convert.ToDateTime(dtpTuNgay.Value.ToShortDateString().Trim());
            DateTime denNgay = Convert.ToDateTime(dtpDenNgay.Value.ToShortDateString().Trim());
            LoadHoaDon(tuNgay, denNgay);
        }

        private void dgvDSHD_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dgvDSHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvDSHD.CurrentCell.RowIndex;
            string mahd = dgvDSHD.Rows[r].Cells[0].Value.ToString();
            createReport(mahd);
        }
    }
}
