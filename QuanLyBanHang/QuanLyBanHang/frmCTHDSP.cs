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
    public partial class frmCTHDSP : Form
    {
        DB db = new DB();
        DataTable dtChiTietHD = new DataTable();
        DataTable dtSanPham = new DataTable();
        DataTable dtFindSanPham = new DataTable();
        SqlDataAdapter daChiTietHD = null;
        SqlDataAdapter daSanPham = null;
        SqlDataAdapter daFindSanPhamn = null;

        public frmCTHDSP()
        {
            InitializeComponent();
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
            catch (Exception a)
            {
                db.loadDataError("SANPHAM", a.Message.ToString());
            }
        }
        public void LoadSanPham(String masp)
        {
            try
            {
                daFindSanPhamn = new SqlDataAdapter("select*from SanPham where MaSP=N'" + masp + "'", db.getConnection());
                dtFindSanPham.Clear();
                daFindSanPhamn.Fill(dtFindSanPham);
                getDataComboBoxSP(dtFindSanPham);
            }
            catch (Exception a)
            {
                db.loadDataError("SANPHAM", a.Message.ToString());
            }
        }
        public void LoadChiTietHoaDon()
        {
            try
            {
                LoadSanPham();
                daChiTietHD = new SqlDataAdapter("select*from ChiTietHoaDon", db.getConnection());
                dtChiTietHD.Clear();
                daChiTietHD.Fill(dtChiTietHD);
                dgvHoaDon.DataSource = dtChiTietHD;
                txtTongSo.Text = dgvHoaDon.RowCount.ToString();
            }
            catch (Exception a)
            {
                db.loadDataError("CHITIETHOADON", a.Message.ToString());
            }
        }
        public void LoadChiTietHoaDon(string masp)
        {
            try
            {
                LoadSanPham(masp);
                daChiTietHD = new SqlDataAdapter("select*from ChiTietHoaDon where MaSP=N'" + masp + "'", db.getConnection());
                dtChiTietHD.Clear();
                daChiTietHD.Fill(dtChiTietHD);
                dgvHoaDon.DataSource = dtChiTietHD;
                txtTongSo.Text = dgvHoaDon.RowCount.ToString();
            }
            catch (Exception a)
            {
                db.loadDataError("CHITIETHOADON", a.Message.ToString());
            }
        }

        private void frmCTHDSP_Load(object sender, EventArgs e)
        {
            LoadChiTietHoaDon();
            txtTongSo.Enabled = false;
        }

        private void frmCTHDSP_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtChiTietHD.Dispose();
            dtChiTietHD = null;
            dtFindSanPham.Dispose();
            dtFindSanPham = null;
            dtSanPham.Dispose();
            dtSanPham = null;
            db.closeConnection();
        }

        private void dgvHoaDon_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        
        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadChiTietHoaDon();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string masp = cbSanPham.SelectedValue.ToString();
            LoadChiTietHoaDon(masp);
        }
        
    }
}
