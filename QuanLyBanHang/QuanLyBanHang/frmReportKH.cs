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
    public partial class frmReportKH : Form
    {
        DB db = new DB();
        DataTable dtThanhPho = new DataTable();
        SqlDataAdapter daThanhPho = null;
        SqlDataAdapter daBaoCaoKH = null;
        DataSet ds;

        public frmReportKH()
        {
            InitializeComponent();
        }

        private void frmReportKH_Load(object sender, EventArgs e)
        {
            LoadThanhPho();
            createReport("");
            //this.rpvKH.RefreshReport();
        }
        private void frmReportKH_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtThanhPho.Dispose();
            dtThanhPho = null;
            db.closeConnection();
        }
        public void LoadThanhPho()
        {
            try
            {
                daThanhPho = new SqlDataAdapter("select*from ThanhPho", db.getConnection());
                dtThanhPho.Clear();
                daThanhPho.Fill(dtThanhPho);
                getDataComboxFind(dtThanhPho);
            }
            catch (Exception a)
            {
                db.loadDataError("THANHPHO", a.Message.ToString());
            }
        }
        public void getDataComboxFind(DataTable dtTp)
        {
            cbThanhPho.DataSource = dtTp;
            cbThanhPho.DisplayMember = "TenThanhPho";
            cbThanhPho.ValueMember = "ThanhPho";
        }
        public void createReport(string maTP)
        {
            try
            {
                String sql = "";
                //Khai báo câu lệnh SQL
                if (maTP != "") sql = "Select * from KhachHang Where ThanhPho=N'" + maTP + "'";
                else sql = "Select * from KhachHang";
                daBaoCaoKH = new SqlDataAdapter(sql, db.getConnection());
                ds = new DataSet();
                daBaoCaoKH.Fill(ds);
                rpvKH.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                //Đường dẫn báo cáo
                rpvKH.LocalReport.ReportPath = "rptKH.rdlc";
                //Nếu có dữ liệu
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //Tạo nguồn dữ liệu cho báo cáo
                    ReportDataSource rds = new ReportDataSource();
                    rds.Name = "tblKH";
                    rds.Value = ds.Tables[0];
                    //Xóa dữ liệu của báo cáo cũ trong trường hợp người dùng thực hiện câu truy vấn khác
                    rpvKH.LocalReport.DataSources.Clear();
                    //Add dữ liệu vào báo cáo
                    rpvKH.LocalReport.DataSources.Add(rds);
                    //Refresh lại báo cáo
                    rpvKH.RefreshReport();
                }
            }
            catch (SqlException a)
            {
                db.messageError("Lỗi! KhachHang!", "Không lấy được dữ liệu! " + a.Message);
            }
        }
        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReportKH_Click(object sender, EventArgs e)
        {
            string maTP = cbThanhPho.SelectedValue.ToString().Trim();
            createReport(maTP);
        }

        private void btnResetReportKH_Click(object sender, EventArgs e)
        {
            createReport("");
        }
    }
}
