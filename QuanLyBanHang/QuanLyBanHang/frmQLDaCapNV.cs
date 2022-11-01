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
    public partial class frmQLDaCapNV : Form
    {
        DB db = new DB();
        DataTable dtNhanVien = new DataTable();
        DataTable dtFindNhanVien = new DataTable();
        DataTable dtFindHDNhanVien = new DataTable();
        DataTable dtKhachHang = new DataTable();
        DataTable dtSanPham = new DataTable();
        DataTable dtHoaDon = new DataTable();
        DataTable dtFindHoaDon = new DataTable();
        DataTable dtCTHoaDon = new DataTable();
        SqlDataAdapter daNhanVien = null;
        SqlDataAdapter daKhachHang = null;
        SqlDataAdapter daFindNhanVien = null;
        SqlDataAdapter daFindHDNhanVien = null;
        SqlDataAdapter daSanPham = null;
        SqlDataAdapter daHoaDon = null;
        SqlDataAdapter daFindHoaDon = null;
        SqlDataAdapter daCTHoaDon = null;

        public frmQLDaCapNV()
        {
            InitializeComponent();
        }
        public void getDataFindNV(DataTable dt)
        {
            cbNhanVien.DataSource = dt;
            cbNhanVien.DisplayMember = "HoTen";
            cbNhanVien.ValueMember = "MaNV";
        }
        public void LoadNhanVien()
        {
            try
            {
                daNhanVien = new SqlDataAdapter("select MaNV, Ho+' '+Ten as HoTen, Nu, NgayNV, DiaChi, DienThoai from NhanVien", db.getConnection());
                dtNhanVien.Clear();
                daNhanVien.Fill(dtNhanVien);
                dgvNhanVien.DataSource = dtNhanVien;
                getDataFindNV(dtNhanVien);
                txtTongSoNV.Text = dgvNhanVien.RowCount.ToString();
            }
            catch(Exception a)
            {
                db.loadDataError("NHANVIEN", a.Message.ToString());
            }
        }
        // load NV theo MaNV
        public void LoadNhanVien(string manv)
        {
            try
            {
                daFindNhanVien = new SqlDataAdapter("select MaNV, Ho+' '+Ten as HoTen, Nu, NgayNV, DiaChi, DienThoai from NhanVien where MaNV=N'" + manv +"'", db.getConnection());
                dtFindNhanVien.Clear();
                daFindNhanVien.Fill(dtFindNhanVien);
                dgvNhanVien.DataSource = dtFindNhanVien;
                txtTongSoNV.Text = dgvNhanVien.RowCount.ToString();
            }
            catch (Exception a)
            {
                db.loadDataError("NHANVIEN(str:manv)", a.Message.ToString());
            }
        }
        // load NV theo Ten NV
        public void LoadTenNhanVien(string manv)
        {
            try
            {
                daFindNhanVien = new SqlDataAdapter("select MaNV, Ho+' '+Ten as HoTen, Nu, NgayNV, DiaChi, DienThoai from NhanVien where Ten like '%" + manv + "%' or Ho like '%"+manv+"%'", db.getConnection());
                dtFindNhanVien.Clear();
                daFindNhanVien.Fill(dtFindNhanVien);
                dgvNhanVien.DataSource = dtFindNhanVien;
                txtTongSoNV.Text = dgvNhanVien.RowCount.ToString();
            }
            catch (Exception a)
            {
                db.loadDataError("NHANVIEN(str:manv)", a.Message.ToString());
            }
        }
        public void getDataComboBoxNV(DataTable dt)
        {
            (dgvHoaDon.Columns["MaNV"] as DataGridViewComboBoxColumn).DataSource = dt;
            (dgvHoaDon.Columns["MaNV"] as DataGridViewComboBoxColumn).DisplayMember = "HoTen";
            (dgvHoaDon.Columns["MaNV"] as DataGridViewComboBoxColumn).ValueMember = "MaNV";
        }
        public void LoadMaNhanVien(string manv)
        {
            try
            {
                daFindHDNhanVien = new SqlDataAdapter("select MaNV, Ho+' '+Ten as HoTen from NhanVien where MaNV=N'" + manv + "'", db.getConnection());
                dtFindHDNhanVien.Clear();
                daFindHDNhanVien.Fill(dtFindHDNhanVien);
                getDataComboBoxNV(dtFindHDNhanVien);
            }
            catch (Exception a)
            {
                db.loadDataError("NHANVIEN-LoadMaNV-(str:manv)", a.Message.ToString());
            }
        }
        public void getDataComboBoxKH(DataTable dt)
        {
            (dgvHoaDon.Columns["MaKHHD"] as DataGridViewComboBoxColumn).DataSource = dt;
            (dgvHoaDon.Columns["MaKHHD"] as DataGridViewComboBoxColumn).DisplayMember = "TenCty";
            (dgvHoaDon.Columns["MaKHHD"] as DataGridViewComboBoxColumn).ValueMember = "MaKH";
        }
        public void LoadKhachHang()
        {
            try
            {
                daKhachHang = new SqlDataAdapter("select*from KhachHang", db.getConnection());
                dtKhachHang.Clear();
                daKhachHang.Fill(dtKhachHang);
                getDataComboBoxKH(dtKhachHang);
            }
            catch (SqlException a)
            {
                db.loadDataError("KHACHHANG", a.Message.ToString());
            }
        }
        public void LoadHoaDon(string manv)
        {
            try
            {
                LoadMaNhanVien(manv);
                LoadKhachHang();
                daHoaDon = new SqlDataAdapter("select*from HoaDon where MaNV=N'" + manv + "'", db.getConnection());
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);
                dgvHoaDon.DataSource = dtHoaDon;
                txtTongSoHD.Text = dgvHoaDon.RowCount.ToString();
            }
            catch (SqlException a)
            {
                db.loadDataError("HOADON", a.Message.ToString());
            }
        }
        public void LoadMaHoaDon(string mahd)
        {
            try
            {
                daFindHoaDon = new SqlDataAdapter("select*from HoaDon where MaHD=N'" + mahd + "'", db.getConnection());
                dtFindHoaDon.Clear();
                daFindHoaDon.Fill(dtFindHoaDon);
                getDataComboBoxHD(dtFindHoaDon);
            }
            catch (SqlException a)
            {
                db.loadDataError("HOADON", a.Message.ToString());
            }
        }
        public void getDataComboBoxHD(DataTable dt)
        {
            (dgvChiTietHD.Columns["MaCTHD"] as DataGridViewComboBoxColumn).DataSource = dt;
            (dgvChiTietHD.Columns["MaCTHD"] as DataGridViewComboBoxColumn).DisplayMember = "MaHD";
            (dgvChiTietHD.Columns["MaCTHD"] as DataGridViewComboBoxColumn).ValueMember = "MaHD";
        }
        public void LoadSanPham()
        {
            try
            {
                daSanPham = new SqlDataAdapter("select*from SanPham", db.getConnection());
                dtSanPham.Clear();
                daSanPham.Fill(dtSanPham);
                getDataComboBoxSP(dtSanPham);
            }
            catch (SqlException a)
            {
                db.loadDataError("SANPHAM", a.Message.ToString());
            }
        }
        public void getDataComboBoxSP(DataTable dt)
        {
            (dgvChiTietHD.Columns["MaSP"] as DataGridViewComboBoxColumn).DataSource = dt;
            (dgvChiTietHD.Columns["MaSP"] as DataGridViewComboBoxColumn).DisplayMember = "TenSP";
            (dgvChiTietHD.Columns["MaSP"] as DataGridViewComboBoxColumn).ValueMember = "MaSP";
        }
        public void LoadChiTietHD(string mahd)
        {
            try
            {
                LoadMaHoaDon(mahd);
                LoadSanPham();
                daCTHoaDon = new SqlDataAdapter("select*from ChiTietHoaDon where MaHD=N'" + mahd + "'", db.getConnection());
                dtCTHoaDon.Clear();
                daCTHoaDon.Fill(dtCTHoaDon);
                dgvChiTietHD.DataSource = dtCTHoaDon;
                txtTongSoCTHD.Text = dgvChiTietHD.RowCount.ToString();
            }
            catch (SqlException a)
            {
                db.loadDataError("CHITIETHOADON", a.Message.ToString());
            }
        }

        private void frmQLDaCapNV_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
        }

        private void frmQLDaCapNV_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtKhachHang.Dispose();
            dtNhanVien.Dispose();
            dtFindNhanVien.Dispose();
            dtFindHDNhanVien.Dispose();
            dtHoaDon.Dispose();
            dtFindHoaDon.Dispose();
            dtCTHoaDon.Dispose();
            dtSanPham.Dispose();
            dtKhachHang = null;
            dtNhanVien = null;
            dtFindNhanVien = null;
            dtFindHDNhanVien = null;
            dtHoaDon = null;
            dtFindHoaDon = null;
            dtCTHoaDon = null;
            dtSanPham = null;
            db.closeConnection();
        }
        private void dgvNhanVien_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dgvHoaDon_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dgvChiTietHD_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadNhanVien();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            string manv = cbNhanVien.SelectedValue.ToString();
            LoadNhanVien(manv);
        }

        private void cbNhanVien_TextChanged(object sender, EventArgs e)
        {
            string tennv = cbNhanVien.Text.ToString();
            LoadTenNhanVien(tennv);
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvNhanVien.CurrentCell.RowIndex;
            string manv = dgvNhanVien.Rows[r].Cells[0].Value.ToString();
            LoadHoaDon(manv);
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvHoaDon.CurrentCell.RowIndex;
            string mahd = dgvHoaDon.Rows[r].Cells[0].Value.ToString();
            LoadChiTietHD(mahd);
        }

        
    }
}
