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
    public partial class frmHDSP : Form
    {
        DB db = new DB();
        DataTable dtHoaDon = new DataTable();
        DataTable dtNhanVien = new DataTable();
        DataTable dtKhachHang = new DataTable();
        DataTable dtSanPham = new DataTable();
        DataTable dtFindKhachHang = new DataTable();
        DataTable dtFindNhanVien = new DataTable();
        DataTable dtFindSanPham = new DataTable();
        SqlDataAdapter daHoaDon = null;
        SqlDataAdapter daNhanVien = null;
        SqlDataAdapter daKhachHang = null;
        SqlDataAdapter daSanPham = null;
        SqlDataAdapter daFindKhachHang = null;
        SqlDataAdapter daFindNhanVien = null;
        SqlDataAdapter daFindSanPham = null;

        public frmHDSP()
        {
            InitializeComponent();
        }
        public void LoadKhachHang()
        {
            try
            {
                daKhachHang = new SqlDataAdapter("select*from KhachHang", db.getConnection());
                dtKhachHang.Clear();
                daKhachHang.Fill(dtKhachHang);
                getDataComboBoxKH(dtKhachHang);
                //getDataFindKH(dtKhachHang);
            }
            catch (Exception a)
            {
                db.loadDataError("KHACHHANG", a.Message.ToString());
            }
        }
        public void LoadKhachHang(string makh)
        {
            try
            {
                daFindKhachHang = new SqlDataAdapter("select*from KhachHang where MaKH=N'" + makh + "'", db.getConnection());
                dtFindKhachHang.Clear();
                daFindKhachHang.Fill(dtFindKhachHang);
            }
            catch (Exception a)
            {
                db.loadDataError("KHACHHANG", a.Message.ToString());
            }
        }
        public void getDataComboBoxKH(DataTable dt)
        {
            (dgvHoaDon.Columns["MaKH"] as DataGridViewComboBoxColumn).DataSource = dt;
            (dgvHoaDon.Columns["MaKH"] as DataGridViewComboBoxColumn).DisplayMember = "TenCty";
            (dgvHoaDon.Columns["MaKH"] as DataGridViewComboBoxColumn).ValueMember = "MaKH";
        }
        public void getDataFindKH(DataTable dt)
        {
            //cbKhachHang.DataSource = dt;
            //cbKhachHang.DisplayMember = "TenCty";
            //cbKhachHang.ValueMember = "MaKH";
        }
        public void LoadNhanVien()
        {
            try
            {
                daNhanVien = new SqlDataAdapter("select MaNV, Ho+' '+Ten as HoTen from NhanVien", db.getConnection());
                dtNhanVien.Clear();
                daNhanVien.Fill(dtNhanVien);
                getDataComboBoxNV(dtNhanVien);
                //getDataFindNV(dtNhanVien);
            }
            catch (Exception a)
            {
                db.loadDataError("NHANVIEN", a.Message.ToString());
            }
        }
        public void LoadNhanVien(string manv)
        {
            try
            {
                daFindNhanVien = new SqlDataAdapter("select MaNV, Ho+' '+Ten as HoTen from NhanVien where MaNV=N'" + manv + "'", db.getConnection());
                dtFindNhanVien.Clear();
                daFindNhanVien.Fill(dtFindNhanVien);
                getDataComboBoxNV(dtFindNhanVien);
            }
            catch (Exception a)
            {
                db.loadDataError("NHANVIEN", a.Message.ToString());
            }
        }
        public void getDataComboBoxNV(DataTable dt)
        {
            (dgvHoaDon.Columns["MaNV"] as DataGridViewComboBoxColumn).DataSource = dt;
            (dgvHoaDon.Columns["MaNV"] as DataGridViewComboBoxColumn).DisplayMember = "HoTen";
            (dgvHoaDon.Columns["MaNV"] as DataGridViewComboBoxColumn).ValueMember = "MaNV";
        }
        public void getDataFindNV(DataTable dt)
        {
            //cbNhanVien.DataSource = dt;
            //cbNhanVien.DisplayMember = "HoTen";
            //cbNhanVien.ValueMember = "MaNV";
        }
        public void LoadSanPham()
        {
            try
            {
                daSanPham = new SqlDataAdapter("select*from SanPham", db.getConnection());
                dtSanPham.Clear();
                daSanPham.Fill(dtSanPham);
                getDataComboBoxSP(dtSanPham);
                getDataFindSP(dtSanPham);
            }
            catch(Exception a)
            {
                db.loadDataError("SANPHAM", a.Message.ToString());
            }
        }
        public void LoadSanPham(string masp)
        {
            try
            {
                daFindSanPham = new SqlDataAdapter("select*from SanPham where MaSP=N'" + masp+"'", db.getConnection());
                dtFindSanPham.Clear();
                daFindSanPham.Fill(dtFindSanPham);
                getDataComboBoxSP(dtFindSanPham);
            }
            catch (Exception a)
            {
                db.loadDataError("SANPHAM", a.Message.ToString());
            }
        }
        public void getDataComboBoxSP(DataTable dt)
        {
            (dgvHoaDon.Columns["MaSP"] as DataGridViewComboBoxColumn).DataSource = dt;
            (dgvHoaDon.Columns["MaSP"] as DataGridViewComboBoxColumn).DisplayMember = "TenSP";
            (dgvHoaDon.Columns["MaSP"] as DataGridViewComboBoxColumn).ValueMember = "MaSP";
        }
        public void getDataFindSP(DataTable dt)
        {
            cbSanPham.DataSource = dt;
            cbSanPham.DisplayMember = "TenSP";
            cbSanPham.ValueMember = "MaSP";
        }
        public void LoadHoaDon()
        {
            try
            {
                LoadKhachHang();
                LoadNhanVien();
                LoadSanPham();
                daHoaDon = new SqlDataAdapter("select hd.*, sp.MaSP from HoaDon hd join ChiTietHoaDon cthd on cthd.MaHD=hd.MaHD join SanPham sp on sp.MaSP=cthd.MaSP", db.getConnection());
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);
                dgvHoaDon.DataSource = dtHoaDon;
                txtTongSo.Text = dgvHoaDon.RowCount.ToString();
            }
            catch (Exception a)
            {
                db.messageError("HOADON", a.Message.ToString());
            }
        }
        public void LoadHoaDon(string masp)
        {
            try
            {
                LoadKhachHang();
                LoadNhanVien();
                LoadSanPham(masp);
                daHoaDon = new SqlDataAdapter("select hd.*, sp.MaSP from HoaDon hd join ChiTietHoaDon cthd on cthd.MaHD=hd.MaHD join SanPham sp on sp.MaSP=cthd.MaSP where sp.MaSP=N'" + masp + "'", db.getConnection());
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);
                dgvHoaDon.DataSource = dtHoaDon;
                txtTongSo.Text = dgvHoaDon.RowCount.ToString();
            }
            catch (Exception a)
            {
                db.messageError("HOADON", a.Message.ToString());
            }
        }

        private void frmHDSP_Load(object sender, EventArgs e)
        {
            LoadHoaDon();
            txtTongSo.Enabled = false;
        }

        private void frmHDSP_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtKhachHang.Dispose();
            dtKhachHang = null;
            dtFindKhachHang.Dispose();
            dtFindKhachHang = null;
            dtHoaDon.Dispose();
            dtHoaDon = null;
            dtNhanVien.Dispose();
            dtNhanVien = null;
            dtFindNhanVien.Dispose();
            dtFindNhanVien = null;
            dtSanPham.Dispose();
            dtSanPham = null;
            dtFindSanPham.Dispose();
            dtFindSanPham = null;
            db.closeConnection();
        }

        private void dgvHoaDon_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadHoaDon();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string masp = cbSanPham.SelectedValue.ToString();
            LoadHoaDon(masp);
        }
    }
}
