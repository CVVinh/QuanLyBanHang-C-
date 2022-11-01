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
    public partial class frmChiTietHD : Form
    {
        DB db = new DB();
        DataTable dtChiTietHD = new DataTable();
        DataTable dtHoaDon = new DataTable();
        DataTable dtSanPham = new DataTable();
        SqlDataAdapter daChiTietHD = null;
        SqlDataAdapter daHoaDon = null;
        SqlDataAdapter daSanPham = null;
        SqlCommand cmd = new SqlCommand();
        bool Them;

        public frmChiTietHD()
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
                (dgvChiTietHD.Columns["MaHD"] as DataGridViewComboBoxColumn).DataSource = dtHoaDon;
                (dgvChiTietHD.Columns["MaHD"] as DataGridViewComboBoxColumn).DisplayMember = "MaHD";
                (dgvChiTietHD.Columns["MaHD"] as DataGridViewComboBoxColumn).ValueMember = "MaHD";
                cbMaHD.DataSource = dtHoaDon;
                cbMaHD.DisplayMember = "MaHD";
                cbMaHD.ValueMember = "MaHD";
            }catch(Exception a)
            {
                db.messageError("HOADON", a.Message.ToString());
            }
        }
        public void LoadSanPham()
        {
            try
            {
                daSanPham = new SqlDataAdapter("select*from SanPham", db.getConnection());
                dtSanPham.Clear();
                daSanPham.Fill(dtSanPham);
                (dgvChiTietHD.Columns["MaSP"] as DataGridViewComboBoxColumn).DataSource = dtSanPham;
                (dgvChiTietHD.Columns["MaSP"] as DataGridViewComboBoxColumn).DisplayMember = "TenSP";
                (dgvChiTietHD.Columns["MaSP"] as DataGridViewComboBoxColumn).ValueMember = "MaSP";
                cbMaSP.DataSource = dtSanPham;
                cbMaSP.DisplayMember = "TenSP";
                cbMaSP.ValueMember = "MaSP";
            }catch(Exception a)
            {
                db.messageError("SANPHAM", a.Message.ToString());
            }
        }
        public void LoadChiTietHD()
        {
            try
            {
                LoadHoaDon();
                LoadSanPham();
                daChiTietHD = new SqlDataAdapter("select*from ChiTietHoaDon", db.getConnection());
                dtChiTietHD.Clear();
                daChiTietHD.Fill(dtChiTietHD);
                dgvChiTietHD.DataSource = dtChiTietHD;
            }catch(Exception a)
            {
                db.messageError("CHITIETSP", a.Message.ToString());
            }
        }

        private void frmChiTietHD_Load(object sender, EventArgs e)
        {
            LoadChiTietHD();
            gbChiTietHD.Enabled = false;
            btnHuyBo.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnReLoad.Enabled = true;
            btnTroVe.Enabled = true;
        }

        private void frmChiTietHD_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtChiTietHD.Dispose();
            dtChiTietHD = null;
            dtHoaDon.Dispose();
            dtHoaDon = null;
            dtSanPham.Dispose();
            dtSanPham = null;
            db.closeConnection();
        }

        private void dgvChiTietHD_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadChiTietHD();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            txtSoLuong.Clear();
            txtSoLuong.Focus();
            cbMaHD.Enabled = true;
            cbMaSP.Enabled = true;

            gbChiTietHD.Enabled = true;
            btnHuyBo.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnReLoad.Enabled = false;
            btnTroVe.Enabled = false;
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            txtSoLuong.Clear();
            gbChiTietHD.Enabled = false;
            btnHuyBo.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnReLoad.Enabled = true;
            btnTroVe.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;
            int r = dgvChiTietHD.CurrentCell.RowIndex;
            cbMaHD.SelectedValue = dgvChiTietHD.Rows[r].Cells[0].Value;
            cbMaHD.Enabled = false;
            cbMaSP.SelectedValue = dgvChiTietHD.Rows[r].Cells[1].Value;
            cbMaSP.Enabled = false;
            txtSoLuong.Text = dgvChiTietHD.Rows[r].Cells[2].Value.ToString();
            txtSoLuong.Focus();
            gbChiTietHD.Enabled = true;
            btnHuyBo.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnReLoad.Enabled = false;
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
                    int r = dgvChiTietHD.CurrentCell.RowIndex;
                    cmd.CommandText = System.String.Concat("delete from ChiTietHoaDon where MaHD=N'"+cbMaHD.SelectedValue.ToString()+"' and  MaSP=N'"+cbMaSP.SelectedValue.ToString()+"'");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    LoadChiTietHD();
                    db.deleteSeccessful();
                }catch(SqlException a)
                {
                    db.deleteError(a.Message.ToString());
                }
                db.getConnection().Close();
                gbChiTietHD.Enabled = false;
                btnHuyBo.Enabled = false;
                btnLuu.Enabled = false;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnReLoad.Enabled = true;
                btnTroVe.Enabled = true;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string soluong = txtSoLuong.Text.ToString().Trim();
            string maHD = cbMaHD.SelectedValue.ToString();
            string maSP = cbMaSP.SelectedValue.ToString();
            if (soluong == "")
            {
                db.messageError("Bạn chưa nhập số lượng !!!","");
                txtSoLuong.Focus();
                return;
            }
            db.getConnection().Open();
            cmd.Connection = db.getConnection();
            cmd.CommandType = CommandType.Text;
            if (Them)
            {
                try
                {
                    cmd.CommandText = System.String.Concat("insert into ChiTietHoaDon values(N'"+maHD+"', N'"+maSP+"', N'"+soluong+"')");
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
                    cmd.CommandText = System.String.Concat("update ChiTietHoaDon set  SoLuong=N'"+soluong+"' where MaHD=N'"+maHD+"' and MaSP=N'"+maSP+"'");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    db.updateSeccessful();
                }
                catch (SqlException a)
                {
                    db.updateError(a.Message.ToString());
                }
            }
            db.getConnection().Close();
            LoadChiTietHD();
            gbChiTietHD.Enabled = false;
            btnHuyBo.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnReLoad.Enabled = true;
            btnTroVe.Enabled = true;
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            string soluong = txtSoLuong.Text.ToString().Trim();
            if (soluong != "")
            {
                int isInt;
                bool check = int.TryParse(soluong, out isInt);
                if (check!=true)
                {
                    db.messageError("Lỗi! Số Lượng!", "Phải là một chữ số");
                    txtSoLuong.Clear();
                    txtSoLuong.Focus();
                    return;
                }
                if (isInt <= 0)
                {
                    db.messageError("Lỗi! Số Lượng!", "Số Lượng Phải Lớn Hơn 0");
                    txtSoLuong.Clear();
                    txtSoLuong.Focus();
                    return;
                }
            }
        }
    }
}
