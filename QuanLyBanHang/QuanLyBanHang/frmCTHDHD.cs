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
    public partial class frmCTHDHD : Form
    {
        DB db = new DB();
        DataTable dtChiTietHD = new DataTable();
        DataTable dtHoaDon = new DataTable();
        DataTable dtFindHoaDon = new DataTable();
        SqlDataAdapter daChiTietHD = null;
        SqlDataAdapter daHoaDon = null;
        SqlDataAdapter daFindHoaDon = null;

        public frmCTHDHD()
        {
            InitializeComponent();
        }
        public void getDataComboBoxHD(DataTable dt)
        {
            (dgvHoaDon.Columns["MaHD"] as DataGridViewComboBoxColumn).DataSource = dt;
            (dgvHoaDon.Columns["MaHD"] as DataGridViewComboBoxColumn).DisplayMember = "MaHD";
            (dgvHoaDon.Columns["MaHD"] as DataGridViewComboBoxColumn).ValueMember = "MaHD";
        }
        public void getDataFindHD(DataTable dt)
        {
            cbHoaDon.DataSource = dt;
            cbHoaDon.DisplayMember = "MaHD";
            cbHoaDon.ValueMember = "MaHD";
        }
        public void LoadHoaDon()
        {
            try
            {
                daHoaDon = new SqlDataAdapter("select*from HoaDon", db.getConnection());
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);
                getDataComboBoxHD(dtHoaDon);
                getDataFindHD(dtHoaDon);
            }
            catch(Exception a)
            {
                db.loadDataError("HOADON", a.Message.ToString());
            }
        }
        public void LoadHoaDon(String mahd)
        {
            try
            {
                daFindHoaDon = new SqlDataAdapter("select*from HoaDon where MaHD=N'"+mahd+"'", db.getConnection());
                dtFindHoaDon.Clear();
                daFindHoaDon.Fill(dtFindHoaDon);
                getDataComboBoxHD(dtFindHoaDon);
            }
            catch (Exception a)
            {
                db.loadDataError("HOADON", a.Message.ToString());
            }
        }
        public void LoadChiTietHoaDon()
        {
            try
            {
                LoadHoaDon();
                daChiTietHD = new SqlDataAdapter("select cthd.MaHD,cthd.SoLuong, sp.TenSP from ChiTietHoaDon cthd join SanPham sp on sp.MaSP=cthd.MaSP", db.getConnection());
                dtChiTietHD.Clear();
                daChiTietHD.Fill(dtChiTietHD);
                dgvHoaDon.DataSource = dtChiTietHD;
                txtTongSo.Text = dgvHoaDon.RowCount.ToString();
            }
            catch(Exception a)
            {
                db.loadDataError("CHITIETHOADON", a.Message.ToString());
            }
        }
        public void LoadChiTietHoaDon(string mahd)
        {
            try
            {
                LoadHoaDon(mahd);
                daChiTietHD = new SqlDataAdapter("select cthd.MaHD,cthd.SoLuong, sp.TenSP from ChiTietHoaDon cthd join SanPham sp on sp.MaSP=cthd.MaSP where MaHD=N'" + mahd+"'", db.getConnection());
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

        private void frmCTHDHD_Load(object sender, EventArgs e)
        {
            LoadChiTietHoaDon();
            txtTongSo.Enabled = false;
        }

        private void frmCTHDHD_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtChiTietHD.Dispose();
            dtChiTietHD = null;
            dtFindHoaDon.Dispose();
            dtFindHoaDon = null;
            dtHoaDon.Dispose();
            dtHoaDon = null;
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
            string mahd = cbHoaDon.SelectedValue.ToString().Trim();
            LoadChiTietHoaDon(mahd);
        }
        
    }
}
