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
    public partial class frmQLDaCapKH : Form
    {
        DB db = new DB();
        DataTable dtKhachHang = new DataTable();
        DataTable dtFindKhachHang = new DataTable();
        DataTable dtThanhPho = new DataTable();
        DataTable dtFindThanhPho = new DataTable();
        DataTable dtNhanVien = new DataTable();
        DataTable dtSanPham = new DataTable();
        DataTable dtHoaDon = new DataTable();
        DataTable dtFindHoaDon = new DataTable();
        DataTable dtCTHoaDon = new DataTable();
        SqlDataAdapter daKhachHang = null;
        SqlDataAdapter daFindKhachHang = null;
        SqlDataAdapter daThanhPho = null;
        SqlDataAdapter daFindThanhPho = null;
        SqlDataAdapter daNhanVien = null;
        SqlDataAdapter daSanPham = null;
        SqlDataAdapter daHoaDon = null;
        SqlDataAdapter daFindHoaDon = null;
        SqlDataAdapter daCTHoaDon = null;

        public frmQLDaCapKH()
        {
            InitializeComponent();
        }
        public void LoadThanhPho()
        {
            try
            {
                daThanhPho = new SqlDataAdapter("select*from ThanhPho", db.getConnection());
                dtThanhPho.Clear();
                daThanhPho.Fill(dtThanhPho);
                getDataComboBoxTP(dtThanhPho);
                getDataFindTP(dtThanhPho);
            }
            catch(SqlException a)
            {
                db.loadDataError("THANHPHO", a.Message.ToString());
            }
        }
        public void LoadThanhPho(string matp)
        {
            try
            {
                daFindThanhPho = new SqlDataAdapter("select*from ThanhPho where ThanhPho=N'" + matp+"'", db.getConnection());
                dtFindThanhPho.Clear();
                daFindThanhPho.Fill(dtFindThanhPho);
                getDataComboBoxTP(dtFindThanhPho);
            }
            catch (SqlException a)
            {
                db.loadDataError("THANHPHO", a.Message.ToString());
            }
        }
        public void getDataComboBoxTP(DataTable dt)
        {
            (dgvKhachHang.Columns["ThanhPho"] as DataGridViewComboBoxColumn).DataSource = dt;
            (dgvKhachHang.Columns["ThanhPho"] as DataGridViewComboBoxColumn).DisplayMember = "TenThanhPho";
            (dgvKhachHang.Columns["ThanhPho"] as DataGridViewComboBoxColumn).ValueMember = "ThanhPho";
        }
        public void getDataFindTP(DataTable dt)
        {
            cbThanhPho.DataSource = dt;
            cbThanhPho.DisplayMember = "TenThanhPho";
            cbThanhPho.ValueMember = "ThanhPho";
        }
        public void LoadKhachHang()
        {
            try
            {
                LoadThanhPho();
                daKhachHang = new SqlDataAdapter("select*from KhachHang", db.getConnection());
                dtKhachHang.Clear();
                daKhachHang.Fill(dtKhachHang);
                dgvKhachHang.DataSource = dtKhachHang;
                txtTongSoKH.Text = dgvKhachHang.RowCount.ToString();
            }
            catch (SqlException a)
            {
                db.loadDataError("KHACHHANG", a.Message.ToString());
            }
        }
        public void LoadKhachHang(string matp)
        {
            try
            {
                LoadThanhPho(matp);
                daKhachHang = new SqlDataAdapter("select*from KhachHang where ThanhPho=N'"+matp+"'", db.getConnection());
                dtKhachHang.Clear();
                daKhachHang.Fill(dtKhachHang);
                dgvKhachHang.DataSource = dtKhachHang;
                txtTongSoKH.Text = dgvKhachHang.RowCount.ToString();
            }
            catch (SqlException a)
            {
                db.loadDataError("KHACHHANG", a.Message.ToString());
            }
        }
        // load dl cho bang HoaDon
        public void LoadMaKhachHang(string makh)
        {
            try
            {
                daFindKhachHang = new SqlDataAdapter("select*from KhachHang where MaKH=N'" + makh + "'", db.getConnection());
                dtFindKhachHang.Clear();
                daFindKhachHang.Fill(dtFindKhachHang);
                getDataComboBoxKH(dtFindKhachHang);
            }
            catch (SqlException a)
            {
                db.loadDataError("KHACHHANG", a.Message.ToString());
            }
        }
        public void getDataComboBoxKH(DataTable dt)
        {
            (dgvHoaDon.Columns["MaKHHD"] as DataGridViewComboBoxColumn).DataSource = dt;
            (dgvHoaDon.Columns["MaKHHD"] as DataGridViewComboBoxColumn).DisplayMember = "TenCty";
            (dgvHoaDon.Columns["MaKHHD"] as DataGridViewComboBoxColumn).ValueMember = "MaKH";
        }
        public void LoadNhanVien()
        {
            try
            {
                daNhanVien = new SqlDataAdapter("select MaNV, Ho+' '+Ten as HoTen from NhanVien", db.getConnection());
                dtNhanVien.Clear();
                daNhanVien.Fill(dtNhanVien);
                getDataComboBoxNV(dtNhanVien);
            }
            catch (SqlException a)
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
        public void LoadHoaDon(string makh)
        {
            try
            {
                LoadMaKhachHang(makh);
                LoadNhanVien();
                daHoaDon = new SqlDataAdapter("select*from HoaDon where MaKH=N'"+makh+"'", db.getConnection());
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
                daCTHoaDon = new SqlDataAdapter("select*from ChiTietHoaDon where MaHD=N'"+mahd+"'", db.getConnection());
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

        private void frmQLDaCapKH_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
        }

        private void frmQLDaCapKH_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtKhachHang.Dispose();
            dtFindKhachHang.Dispose();
            dtThanhPho.Dispose();
            dtFindThanhPho.Dispose();
            dtNhanVien.Dispose();
            dtHoaDon.Dispose();
            dtFindHoaDon.Dispose();
            dtCTHoaDon.Dispose();
            dtSanPham.Dispose();
            dtKhachHang = null;
            dtFindKhachHang = null;
            dtThanhPho = null;
            dtFindThanhPho = null;
            dtNhanVien = null;
            dtHoaDon = null;
            dtFindHoaDon = null;
            dtCTHoaDon = null;
            dtSanPham = null;
            db.closeConnection();
        }

        private void dgvKhachHang_DataError(object sender, DataGridViewDataErrorEventArgs e)
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
            LoadKhachHang();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string matp = cbThanhPho.SelectedValue.ToString();
            LoadKhachHang(matp);
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvKhachHang.CurrentCell.RowIndex;
            string makh = dgvKhachHang.Rows[r].Cells[0].Value.ToString();
            LoadHoaDon(makh);
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvHoaDon.CurrentCell.RowIndex;
            string mahd = dgvHoaDon.Rows[r].Cells[0].Value.ToString();
            LoadChiTietHD(mahd);
        }
        private void dgvChiTietHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
