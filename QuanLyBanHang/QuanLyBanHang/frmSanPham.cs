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
    public partial class frmSanPham : Form
    {
        DB db = new DB();
        DataTable dt = new DataTable();
        SqlDataAdapter da = null;
        SqlCommand cmd = new SqlCommand();
        bool Them;

        public frmSanPham()
        {
            InitializeComponent();
        }
        public void LoadSanPham()
        {
            try
            {
                da = new SqlDataAdapter("select*from SanPham", db.getConnection());
                dt.Clear();
                da.Fill(dt);
                dgvSanPham.DataSource = dt;
            }catch(Exception a)
            {
                db.loadDataError("SANPHAM",a.Message.ToString());
            }
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            LoadSanPham();
            gbSanPham.Enabled = false;
            btnHuyBo.Enabled = false;
            btnLuu.Enabled = false;
            btnReLoad.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnTroVe.Enabled = true;
        }

        private void frmSanPham_FormClosing(object sender, FormClosingEventArgs e)
        {
            dt.Dispose();
            dt = null;
            db.closeConnection();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadSanPham();
        }
       
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            txtMaSP.ResetText();
            txtTenSP.ResetText();
            txtDonViTinh.ResetText();
            txtDonGia.ResetText();
            txtHinhAnh.Clear();
            pbSanPham.Image = null;
            gbSanPham.Enabled = false;
            btnHuyBo.Enabled = false;
            btnLuu.Enabled = false;
            btnReLoad.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnTroVe.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            txtMaSP.ResetText();
            txtMaSP.Enabled = true;
            txtMaSP.Focus();
            txtTenSP.ResetText();
            txtDonViTinh.ResetText();
            txtDonGia.ResetText();
            txtHinhAnh.Clear();
            pbSanPham.Image = null;
            gbSanPham.Enabled = true;
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
                try
                {
                    cmd.Connection = db.getConnection();
                    int r = dgvSanPham.CurrentCell.RowIndex;
                    string maSP = dgvSanPham.Rows[r].Cells[0].Value.ToString();
                    cmd.CommandText = System.String.Concat("delete from SanPham where masp=N'" + maSP + "'");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    LoadSanPham();
                    db.deleteSeccessful();
                }catch(SqlException a)
                {
                    db.deleteError(a.Message.ToString());
                }
            }
            db.getConnection().Close();
            gbSanPham.Enabled = false;
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
            int r = dgvSanPham.CurrentCell.RowIndex;
            txtMaSP.Text = dgvSanPham.Rows[r].Cells[0].Value.ToString();
            txtMaSP.Enabled = false;
            txtTenSP.Text = dgvSanPham.Rows[r].Cells[1].Value.ToString();
            txtDonViTinh.Text = dgvSanPham.Rows[r].Cells[2].Value.ToString();
            txtDonGia.Text = dgvSanPham.Rows[r].Cells[3].Value.ToString();
            txtHinhAnh.Text = dgvSanPham.Rows[r].Cells[4].Value.ToString();
            if (txtHinhAnh.Text.ToString() != "")
            {
                pbSanPham.Image = Image.FromFile(txtHinhAnh.Text.ToString());
            }
            else { pbSanPham.Image = null; }
            txtTenSP.Focus();

            gbSanPham.Enabled = true;
            btnHuyBo.Enabled = true;
            btnLuu.Enabled = true;
            btnReLoad.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnTroVe.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maSP = txtMaSP.Text.ToString().Trim();
            string tenSP = txtTenSP.Text.ToString().Trim();
            string donViTinh = txtDonViTinh.Text.ToString().Trim();
            string donGia = txtDonGia.Text.ToString().Trim();
            string hinh = txtHinhAnh.Text.ToString().Trim();
            if (maSP == "")
            {
                db.messageError("Mã Sản Phẩm không được rỗng !!!", "");
                txtMaSP.Focus();
                return;
            }
            if (tenSP == "")
            {
                db.messageError("Bạn chưa nhập Tên SP !!!", "");
                txtTenSP.Focus();
                return;
            }
            if (donViTinh == "")
            {
                db.messageError("Bạn chưa nhập Đơn Vị Tính !!!", "");
                txtDonViTinh.Focus();
                return;
            }
            if (donGia == "")
            {
                db.messageError("Bạn chưa nhập Đơn Giá !!!", "");
                txtDonGia.Focus();
                return;
            }
            cmd.Connection = db.getConnection();
            cmd.CommandType = CommandType.Text;
            db.getConnection().Open();
            if (Them)
            {
                try
                {
                    cmd.CommandText = System.String.Concat("insert into SanPham values(N'"+maSP+"', N'"+tenSP+"', N'"+donViTinh+"', N'"+donGia+"', N'"+hinh+"') ");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    db.addSeccessful();
                }
                catch (SqlException a)
                {
                    db.addError(a.Message.ToString());
                }
            }else if (!Them)
            {
                try
                {
                    cmd.CommandText = System.String.Concat("update SanPham set TenSP=N'"+tenSP+"', DonViTinh=N'"+donViTinh+"', DonGia=N'"+donGia+"', Hinh=N'"+hinh+"' where MaSP=N'"+maSP+"'");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    db.updateSeccessful();
                }catch(SqlException a)
                {
                    db.updateError(a.Message.ToString());
                }
            }

            db.getConnection().Close();
            LoadSanPham();
            gbSanPham.Enabled = false;
            btnHuyBo.Enabled = false;
            btnLuu.Enabled = false;
            btnReLoad.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnTroVe.Enabled = true;

        }

        private void btnOpenAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlOpen = new OpenFileDialog();
            dlOpen.Filter = "Image Files(*.BMP,*.JPG,*.GIF)|*.BMP,*.JPG,*.GIF| All files(*.*)|*.*";
            dlOpen.Title = "Chọn một hình ảnh";
            if (dlOpen.ShowDialog() == DialogResult.OK)
            {
                pbSanPham.Image = Image.FromFile(dlOpen.FileName);
                txtHinhAnh.Text = dlOpen.FileName;
            }
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            string dongia = txtDonGia.Text.ToString();
            if (dongia != "")
            {
                float isFloat;
                bool check = float.TryParse(dongia, out isFloat);
                if (!check)
                {
                    db.messageError("Lỗi! Đơn Giá!", "Bạn phải nhập vào một con số.");
                    txtDonGia.Clear();
                    txtDonGia.Focus();
                    return;
                }
            }
        }

    }
}
