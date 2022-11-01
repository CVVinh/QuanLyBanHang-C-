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
    public partial class frmReportNV : Form
    {
        DB db = new DB();
        SqlDataAdapter daBaoCaoNV = null;
        DataSet ds;

        public frmReportNV()
        {
            InitializeComponent();
        }
        public void createReport(int soluong)
        {
            try
            {
                String sql = "";
                //Khai báo câu lệnh SQL
                if (soluong >= 0) sql = "select*from NhanVien where MaNV in (" +
                        "select distinct nv.MaNV " +
                        "from NhanVien nv join HoaDon hd on nv.MaNV = hd.MaNV " +
                        "group by nv.MaNV " +
                        "having count(*) = " + soluong + ")";
                else sql = "Select * from NhanVien";
                daBaoCaoNV = new SqlDataAdapter(sql, db.getConnection());
                ds = new DataSet();
                daBaoCaoNV.Fill(ds);
                rpvNV.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                //Đường dẫn báo cáo
                rpvNV.LocalReport.ReportPath = "rptNV.rdlc";
                //Nếu có dữ liệu
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //Tạo nguồn dữ liệu cho báo cáo
                    ReportDataSource rds = new ReportDataSource();
                    rds.Name = "tblNV";
                    rds.Value = ds.Tables[0];
                    //Xóa dữ liệu của báo cáo cũ trong trường hợp người dùng thực hiện câu truy vấn khác
                    rpvNV.LocalReport.DataSources.Clear();
                    //Add dữ liệu vào báo cáo
                    rpvNV.LocalReport.DataSources.Add(rds);
                    //Refresh lại báo cáo
                    rpvNV.RefreshReport();
                }
            }
            catch (SqlException a)
            {
                db.messageError("Lỗi! NhanVien!", "Không lấy được dữ liệu! " + a.Message);
            }

        }

        private void frmReportNV_Load(object sender, EventArgs e)
        {
            createReport(-1);
        }

        private void frmReportNV_FormClosing(object sender, FormClosingEventArgs e)
        {
            db.closeConnection();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnResetReportKH_Click(object sender, EventArgs e)
        {
            createReport(-1);
        }

        private void btnReportKH_Click(object sender, EventArgs e)
        {
            createReport(int.Parse(txtSLHD.Text.ToString().Trim()));
        }

        private void txtSLHD_TextChanged(object sender, EventArgs e)
        {
            string soluong = txtSLHD.Text.ToString().Trim();
            if (soluong != "")
            {
                int isInt;
                bool check = int.TryParse(soluong, out isInt);
                if (check != true)
                {
                    db.messageError("Lỗi! Số Lượng!", "Phải là một chữ số");
                    txtSLHD.Clear();
                    txtSLHD.Focus();
                    return;
                }
                if (isInt <= 0)
                {
                    db.messageError("Lỗi! Số Lượng!", "Số Lượng Phải Lớn Hơn 0");
                    txtSLHD.Clear();
                    txtSLHD.Focus();
                    return;
                }
            }
        }
    }
}
