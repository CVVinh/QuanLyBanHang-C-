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
    public partial class frmKHTP : Form
    {
        DB db = new DB();
        DataTable dtKhachHang = new DataTable();
        DataTable dtThanhPho = new DataTable();
        DataTable dtFindThanhPho = new DataTable();
        SqlDataAdapter daKhachHang = null;
        SqlDataAdapter daThanhPho = null;
        SqlDataAdapter daFindThanhPho = null;

        public frmKHTP()
        {
            InitializeComponent();
        }
        private void dgvKhachHang_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        public void LoadThanhPho()
        {
            try
            {
                daThanhPho = new SqlDataAdapter("select*from ThanhPho", db.getConnection());
                dtThanhPho.Clear();
                daThanhPho.Fill(dtThanhPho);
                getDataComboxTable(dtThanhPho);
                getDataComboxFind(dtThanhPho);
            }
            catch(Exception a)
            {
                db.loadDataError("THANHPHO", a.Message.ToString());
            }
        }
        public void LoadThanhPho(String maTP)
        {
            try
            {
                daFindThanhPho = new SqlDataAdapter("select*from ThanhPho where ThanhPho=N'"+maTP+"'", db.getConnection());
                dtFindThanhPho.Clear();
                daFindThanhPho.Fill(dtFindThanhPho);
                getDataComboxTable(dtFindThanhPho);
            }
            catch (Exception a)
            {
                db.loadDataError("THANHPHO", a.Message.ToString());
            }
        }
        public void getDataComboxTable(DataTable dtTp)
        {
            (dgvKhachHang.Columns["ThanhPho"] as DataGridViewComboBoxColumn).DataSource = dtTp;
            (dgvKhachHang.Columns["ThanhPho"] as DataGridViewComboBoxColumn).DisplayMember = "TenThanhPho";
            (dgvKhachHang.Columns["ThanhPho"] as DataGridViewComboBoxColumn).ValueMember = "ThanhPho";
        }
        public void getDataComboxFind(DataTable dtTp)
        {
            cbThanhPho.DataSource = dtTp;
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
                txtTongSo.Text = dgvKhachHang.RowCount.ToString();
            }
            catch (Exception a)
            {
                db.loadDataError("KHACHHANG", a.Message.ToString());
            }
        }
        public void LoadKhachHang(string maTP)
        {
            try
            {
                LoadThanhPho(maTP);
                daKhachHang = new SqlDataAdapter("select*from KhachHang where ThanhPho=N'"+maTP+"'", db.getConnection());
                dtKhachHang.Clear();
                daKhachHang.Fill(dtKhachHang);
                dgvKhachHang.DataSource = dtKhachHang;
                txtTongSo.Text = dgvKhachHang.RowCount.ToString();
            }
            catch (Exception a)
            {
                db.loadDataError("KHACHHANG", a.Message.ToString());
            }
        }

        private void frmKHTP_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
            txtTongSo.Enabled = false;
        }

        private void frmKHTP_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtKhachHang.Dispose();
            dtKhachHang = null;
            dtThanhPho.Dispose();
            dtThanhPho = null;
            db.closeConnection();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string maTP = cbThanhPho.SelectedValue.ToString();
            LoadKhachHang(maTP);
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadKhachHang();
        }
    }
}
