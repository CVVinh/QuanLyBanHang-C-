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
using System.Globalization;

namespace QuanLyBanHang
{
    public partial class frmHoaDon : Form
    {
        DB db = new DB();
        DataTable dtHoaDon = new DataTable();
        DataTable dtKhachhang = new DataTable();
        DataTable dtNhanVien = new DataTable();
        SqlDataAdapter daHoaDon = null;
        SqlDataAdapter daKhachHang = null;
        SqlDataAdapter daNhanVien = null;
        SqlCommand cmd = new SqlCommand();
        bool Them;

        public frmHoaDon()
        {
            InitializeComponent();
        }
        public void LoadHoaDon()
        {
            try
            {
                daHoaDon = new SqlDataAdapter("select*from HoaDon", db.getConnection());
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);
                dgvHoaDon.DataSource = dtHoaDon;
            }catch(Exception a)
            {
                db.loadDataError("HOADON",a.Message.ToString());
            }
        }
        public void LoadKhachHang()
        {
            try
            {
                daKhachHang = new SqlDataAdapter("select*from KhachHang", db.getConnection());
                dtKhachhang.Clear();
                daKhachHang.Fill(dtKhachhang);
                // dua du lieu len comboBox
                (dgvHoaDon.Columns["MaKH"] as DataGridViewComboBoxColumn).DataSource = dtKhachhang;
                (dgvHoaDon.Columns["MaKH"] as DataGridViewComboBoxColumn).DisplayMember = "TenCty";
                (dgvHoaDon.Columns["MaKH"] as DataGridViewComboBoxColumn).ValueMember = "MaKH";
                cbMaKH.DataSource = dtKhachhang;
                cbMaKH.DisplayMember = "TenCty";
                cbMaKH.ValueMember = "MaKH";
            }
            catch (Exception a)
            {
                db.loadDataError("KHACHHANG", a.Message.ToString());
            }
        }

        public void LoadNhanVien()
        {
            try
            {
                daNhanVien = new SqlDataAdapter("select MaNV, Ho+' '+Ten as HoTen from NhanVien", db.getConnection());
                dtNhanVien.Clear();
                daNhanVien.Fill(dtNhanVien);
                // dua du lieu len comboBox DataGridView
                (dgvHoaDon.Columns["MaNV"] as DataGridViewComboBoxColumn).DataSource = dtNhanVien;
                (dgvHoaDon.Columns["MaNV"] as DataGridViewComboBoxColumn).DisplayMember = "HoTen";
                (dgvHoaDon.Columns["MaNV"] as DataGridViewComboBoxColumn).ValueMember = "MaNV";
                cbMaNV.DataSource = dtNhanVien;
                cbMaNV.DisplayMember = "HoTen";
                cbMaNV.ValueMember = "MaNV";
            }
            catch (Exception a)
            {
                db.loadDataError("NHANVIEN", a.Message.ToString());
            }
        }       

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
            LoadNhanVien();
            LoadHoaDon();
            gbHoaDon.Enabled = false;
            btnHuyBo.Enabled = false;
            btnLuu.Enabled = false;
            btnReLoad.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnTroVe.Enabled = true;
        }

        private void frmHoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtHoaDon.Dispose();
            dtHoaDon = null;
            dtKhachhang.Dispose();
            dtKhachhang = null;
            dtNhanVien.Dispose();
            dtNhanVien = null;
            db.closeConnection();
        }

        private void dgvHoaDon_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadKhachHang();
            LoadNhanVien();
            LoadHoaDon();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            txtMaHD.Clear();
            txtMaHD.Focus();
            txtMaHD.Enabled = true;
            gbHoaDon.Enabled = true;
            btnHuyBo.Enabled = true;
            btnLuu.Enabled = true;
            btnReLoad.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnTroVe.Enabled = false;
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            gbHoaDon.Enabled = false;
            btnHuyBo.Enabled = false;
            btnLuu.Enabled = false;
            btnReLoad.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnTroVe.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;
            int r = dgvHoaDon.CurrentCell.RowIndex;
            txtMaHD.Text = dgvHoaDon.Rows[r].Cells[0].Value.ToString();
            txtMaHD.Enabled = false;
            cbMaKH.SelectedValue = dgvHoaDon.Rows[r].Cells[1].Value.ToString();
            cbMaNV.SelectedValue = dgvHoaDon.Rows[r].Cells[2].Value.ToString();
            //txtNgayLapHoaDon.Text = Convert.ToDateTime(dgvHoaDon.Rows[r].Cells[3].Value.ToString()).ToString("dd/MM/yyyy");
            txtNgayLapHoaDon.Text = dgvHoaDon.Rows[r].Cells[3].Value.ToString();
            txtNgayLapHoaDon.Focus();
            //txtNgayLapNhanHang.Text = Convert.ToDateTime(dgvHoaDon.Rows[r].Cells[4].Value.ToString()).ToString("dd/MM/yyyy");
            txtNgayLapNhanHang.Text = dgvHoaDon.Rows[r].Cells[4].Value.ToString();

            gbHoaDon.Enabled = true;
            btnHuyBo.Enabled = true;
            btnLuu.Enabled = true;
            btnReLoad.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnTroVe.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (db.confirmDelete())
            {
                db.getConnection().Open();
                cmd.Connection = db.getConnection();
                cmd.CommandType = CommandType.Text;
                try
                {
                    int r = dgvHoaDon.CurrentCell.RowIndex;
                    string maHD = dgvHoaDon.Rows[r].Cells[0].Value.ToString();
                    cmd.CommandText = System.String.Concat("delete from HoaDon where MaHD=N'"+maHD+"'");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    LoadKhachHang();
                    LoadNhanVien();
                    LoadHoaDon();
                    db.deleteSeccessful();
                }
                catch(SqlException a)
                {
                    db.deleteError(a.Message.ToString());
                }
                db.getConnection().Close();
                gbHoaDon.Enabled = false;
                btnHuyBo.Enabled = false;
                btnLuu.Enabled = false;
                btnReLoad.Enabled = true;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnTroVe.Enabled = true;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maHD = txtMaHD.Text.ToString().Trim();
            string strNgayLapHD = txtNgayLapHoaDon.Value.ToString().Trim();
            string strNgayNhanHang = txtNgayLapNhanHang.Value.ToString().Trim();
            if(maHD == "")
            {
                db.messageError("Mã Hóa Đơn Không Được Phép Rỗng !!!", "");
                txtMaHD.Focus();
                return;
            }
            if (strNgayLapHD == "")
            {
                db.messageError("Bạn chưa nhập Ngày Lập Hóa Đơn !!!", "");
                txtNgayLapHoaDon.Focus();
                return;
            }
            if (strNgayNhanHang == "")
            {
                db.messageError("Bạn chưa nhập Ngày Nhận Hóa Đơn !!!", "");
                txtNgayLapNhanHang.Focus();
                return;
            }
            //DateTime ngayLapHD = DateTime.ParseExact("24/01/2013", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //DateTime ngayNhanHang = DateTime.ParseExact(strNgayNhanHang, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //System.Globalization.CultureInfo cti = new System.Globalization.CultureInfo("vi-VN");
            //DateTime ngayLapHD = DateTime.Parse(strNgayLapHD, cti, DateTimeStyles.None);
            //DateTime ngayNhanHang = DateTime.Parse(strNgayNhanHang, cti, DateTimeStyles.None);
            DateTime ngayLapHD = Convert.ToDateTime(strNgayLapHD);
            DateTime ngayNhanHang = Convert.ToDateTime(strNgayNhanHang);

            db.getConnection().Open();
            cmd.Connection = db.getConnection();
            cmd.CommandType = CommandType.Text;
            if (Them)
            {
                try
                {
                    cmd.CommandText = System.String.Concat("insert into Hoadon values(N'"+maHD+"', N'"+cbMaKH.SelectedValue.ToString()+"', N'"+cbMaNV.SelectedValue.ToString()+"', N'"+ ngayLapHD + "', N'"+ ngayNhanHang + "')");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    db.addSeccessful();
                }catch(SqlException a)
                {
                    db.addError(a.Message.ToString());
                }
            }else if (!Them)
            {
                try
                {
                    cmd.CommandText = System.String.Concat("update HoaDon set MaKH=N'"+cbMaKH.SelectedValue.ToString()+"', MaNV=N'"+cbMaNV.SelectedValue.ToString()+"', NgayLapHD=N'"+ngayLapHD+"', NgayNhanHang=N'"+ngayNhanHang+"' where MaHD=N'"+maHD+"'");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    db.updateSeccessful();
                }catch(SqlException a)
                {
                    db.updateError(a.Message.ToString());
                }
            }
            db.getConnection().Close();
            LoadKhachHang();
            LoadNhanVien();
            LoadHoaDon();
            gbHoaDon.Enabled = false;
            btnHuyBo.Enabled = false;
            btnLuu.Enabled = false;
            btnReLoad.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnTroVe.Enabled = true;

        }

    }
}
