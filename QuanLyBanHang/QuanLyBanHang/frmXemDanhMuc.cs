using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyBanHang
{
    public partial class frmXemDanhMuc : Form
    {
        DB db = new DB();
        SqlDataAdapter da = null;
        DataTable dt = new DataTable();
        string tenBang="";
        string cotHienThi = "*";
        SqlCommand cmd = new SqlCommand();
        
        public frmXemDanhMuc()
        {
            InitializeComponent();
        }
        public void loadData()
        {
            try
            {
                da = new SqlDataAdapter("select "+cotHienThi+" from "+tenBang, db.getConnection());
                dt.Clear();
                da.Fill(dt);
                dgvXemDanhMuc.DataSource = dt;
                dgvXemDanhMuc.AutoResizeColumns();
            }
            catch(Exception a)
            {
                db.loadDataError("Lỗi! Không lấy được nội dung trong bảng "+tenBang+" !!! - ", a.Message.ToString());
            }
        }
        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmXemDanhMuc_Load(object sender, EventArgs e)
        {
            int indexDM = Convert.ToInt32(this.Text);
            switch (indexDM)
            {
                case 1:
                    lbXemDanhMuc.Text = "Danh Mục Thành Phố";
                    this.Text = "Xem Danh Mục Thành Phố";
                    tenBang = "ThanhPho";
                    loadData();
                    break;
                case 2:
                    lbXemDanhMuc.Text = "Danh Mục Khách Hàng";
                    this.Text = "Xem Danh Mục Khách Hàng";
                    tenBang = "KhachHang";
                    loadData();
                    break;
                case 3:
                    lbXemDanhMuc.Text = "Danh Mục Nhân Viên";
                    this.Text = "Xem Danh Mục Nhân Viên";
                    tenBang = "NhanVien";
                    cotHienThi = "MaNV, Ho, Ten, Nu, NgayNV, DiaChi, DienThoai";
                    loadData();
                    break;
                case 4:
                    lbXemDanhMuc.Text = "Danh Mục Sản Phẩm";
                    this.Text = "Xem Danh Mục Sản Phẩm";
                    tenBang = "SanPham";
                    cotHienThi = "MaSP, TenSP, DonViTinh, DonGia";
                    loadData();
                    break;
                case 5:
                    lbXemDanhMuc.Text = "Danh Mục Hóa Đơn";
                    this.Text = "Xem Danh Mục Hóa Đơn";
                    tenBang = "HoaDon";
                    loadData();
                    break;
                case 6:
                    lbXemDanhMuc.Text = "Danh Mục Chi Tiết Hóa Đơn";
                    this.Text = "Xem Danh Mục Chi Tiết Hóa Đơn";
                    tenBang = "ChiTietHoaDon";
                    loadData();
                    break;
                default: break;
            }
        }
        private void frmXemDanhMuc_FormClosing(object sender, FormClosingEventArgs e)
        {
            dt.Dispose();
            dt = null;
            db.closeConnection();
        }

        private void dgvXemDanhMuc_DoubleClick(object sender, EventArgs e)
        {
            if (db.confirmDelete())
            {
                cmd.Connection = db.getConnection();
                cmd.CommandType = CommandType.Text;
                db.getConnection().Open();
                try
                {
                    string cotMa = dgvXemDanhMuc.Columns[0].HeaderText;
                    int r = dgvXemDanhMuc.CurrentCell.RowIndex;
                    string layMa = dgvXemDanhMuc.Rows[r].Cells[0].Value.ToString();
                    cmd.CommandText = System.String.Concat("delete from "+tenBang+" where "+cotMa+" = '"+layMa+"'");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    loadData();
                    db.deleteSeccessful();
                }catch(SqlException a)
                {
                    db.messageError("Lỗi! Delete từ bảng "+tenBang, a.Message.ToString());
                }
                db.getConnection().Close();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tenTim = txtTimKiem.Text.ToString().Trim();
            if (tenTim != "")
            {
                try
                {
                    string cotMa = dgvXemDanhMuc.Columns[1].HeaderText;
                    da = new SqlDataAdapter("select " + cotHienThi + " from " + tenBang + " where " + cotMa + " like '%" + tenTim + "%'", db.getConnection());
                    dt.Clear();
                    da.Fill(dt);
                    dgvXemDanhMuc.DataSource = dt;
                }
                catch (SqlException a)
                {
                    db.messageError("Lỗi! Truy Vấn dữ liệu từ bảng " + tenBang, a.Message.ToString());
                }
            }
            else loadData();
        }
    }
}
