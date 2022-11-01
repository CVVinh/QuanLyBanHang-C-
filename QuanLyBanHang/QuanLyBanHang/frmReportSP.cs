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
    public partial class frmReportSP : Form
    {
        DB db = new DB();
        SqlDataAdapter daBaoCaoSP = null;
        DataSet ds;

        public frmReportSP()
        {
            InitializeComponent();
        }
        public void createReport(DateTime tuDau, DateTime denCuoi)
        {
            try
            {
                db.getConnection().Open();
                //daBaoCaoSP = new SqlDataAdapter("SanPhamTheoNgay", db.getConnection());
                // hoặc sử dụng như sau
                daBaoCaoSP = new SqlDataAdapter();
                daBaoCaoSP.SelectCommand = new SqlCommand();
                daBaoCaoSP.SelectCommand.CommandText = String.Format("SanPhamTheoNgay");
                daBaoCaoSP.SelectCommand.Connection = db.getConnection();
                // @TuNgay, @DenNgay: phải giống với tên biến trong Proceduce trong SQL
                daBaoCaoSP.SelectCommand.Parameters.Add(new SqlParameter("@TuNgay", tuDau));
                daBaoCaoSP.SelectCommand.Parameters.Add(new SqlParameter("@DenNgay", denCuoi));
                daBaoCaoSP.SelectCommand.CommandType = CommandType.StoredProcedure;
                ds = new DataSet();
                daBaoCaoSP.Fill(ds);
                // mô hình báo cáo cục bộ
                rpvSP.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                //Đường dẫn báo cáo
                rpvSP.LocalReport.ReportPath = "rptSP.rdlc";
                //Nếu có dữ liệu
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //Tạo nguồn dữ liệu cho báo cáo
                    ReportDataSource rds = new ReportDataSource();
                    rds.Name = "tblSP";
                    rds.Value = ds.Tables[0];
                    //Xóa dữ liệu của báo cáo cũ trong trường hợp người dùng thực hiện câu truy vấn khác
                    rpvSP.LocalReport.DataSources.Clear();
                    //Add dữ liệu vào báo cáo
                    rpvSP.LocalReport.DataSources.Add(rds);
                    //Refresh lại báo cáo
                    rpvSP.RefreshReport();
                }
                db.getConnection().Close();
            }
            catch(SqlException a)
            {
                db.messageError("Lỗi! Proceduce SanPhamTheoNgay()!", "Không lấy được dữ liệu! "+a.Message);
            }
        }

        private void frmReportSP_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSetSP.SanPhamTheoNgay' table. You can move, or remove it, as needed.
            //this.SanPhamTheoNgayTableAdapter.Fill(this.DataSetSP.SanPhamTheoNgay);
            //rpvSP.RefreshReport();
            createReport(Convert.ToDateTime("1-1-1980"), Convert.ToDateTime("1-1-9980"));
        }

        private void frmReportSP_FormClosing(object sender, FormClosingEventArgs e)
        {
            db.closeConnection();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnResetReportSP_Click(object sender, EventArgs e)
        {
            createReport(Convert.ToDateTime("1-1-1980"), Convert.ToDateTime("1-1-9980"));
        }

        private void btnReportSP_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = Convert.ToDateTime(dtpTuNgay.Value.ToString().Trim());
            DateTime denNgay = Convert.ToDateTime(dtpDenNgay.Value.ToString().Trim());
            createReport(tuNgay, denNgay);
        }
    }
}
