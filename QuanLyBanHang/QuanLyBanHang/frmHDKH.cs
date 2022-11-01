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
    public partial class frmHDKH : Form
    {
        DB db = new DB();
        DataTable dtHoaDon = new DataTable();
        DataTable dtNhanVien = new DataTable();
        DataTable dtKhachHang = new DataTable();
        DataTable dtFindKhachHang = new DataTable();
        DataTable dtFindNhanVien = new DataTable();
        SqlDataAdapter daHoaDon = null;
        SqlDataAdapter daNhanVien = null;
        SqlDataAdapter daKhachHang = null;
        SqlDataAdapter daFindKhachHang = null;
        SqlDataAdapter daFindNhanVien = null;

        public frmHDKH()
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
                getDataFindKH(dtKhachHang);
            }
            catch(Exception a)
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
            cbKhachHang.DataSource = dt;
            cbKhachHang.DisplayMember = "TenCty";
            cbKhachHang.ValueMember = "MaKH";
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
        
        public void LoadHoaDon()
        {
            try
            {
                LoadKhachHang();
                LoadNhanVien();
                daHoaDon = new SqlDataAdapter("select*from HoaDon", db.getConnection());
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);
                dgvHoaDon.DataSource = dtHoaDon;
                txtTongSo.Text = dgvHoaDon.RowCount.ToString();
            }
            catch(Exception a)
            {
                db.messageError("HOADON", a.Message.ToString());
            }
        }
        public void LoadHoaDon(string makh)
        {
            try
            {
                LoadKhachHang(makh);
                LoadNhanVien();
                daHoaDon = new SqlDataAdapter("select*from HoaDon where MaKH=N'"+makh+"'", db.getConnection());
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

        private void frmHDKH_Load(object sender, EventArgs e)
        {
            LoadHoaDon();
            txtTongSo.Enabled = false;
        }
        private void dgvHoaDon_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void frmHDKH_FormClosing(object sender, FormClosingEventArgs e)
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
            db.closeConnection();
        }
        
        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadHoaDon();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string makh = cbKhachHang.SelectedValue.ToString();
            LoadHoaDon(makh);
        }
        
        private void txtTongSo_TextChanged(object sender, EventArgs e)
        {
            string makh = txtTongSo.Text.ToString().Trim();
            if(makh != "")
            {
                int isInt;
                bool check = int.TryParse(makh, out isInt);
                if (check)
                {
                    //db.messageError("","Bạn Phải Nhập vào 1 chữ số!!!");
                }
            }
        }

        
    }
}
