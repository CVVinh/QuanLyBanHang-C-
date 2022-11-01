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
    public partial class frmNhanVien : Form
    {
        DB db = new DB();
        DataTable dt = new DataTable();
        SqlDataAdapter da = null;
        SqlCommand cmd = new SqlCommand();
        bool Them;

        public frmNhanVien()
        {
            InitializeComponent();
        }
        public void LoadNhanVien()
        {
            try
            {
                da = new SqlDataAdapter("select*from NhanVien", db.getConnection());
                dt.Clear();
                da.Fill(dt);
                dgvNhanVien.DataSource = dt;
            }catch(Exception a)
            {
                db.loadDataError("NHANVIEN", a.Message.ToString());
            }
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
            gbNhanVien.Enabled = false;
            btnHuyBo.Enabled = false;
            btnLuu.Enabled = false;
            btnReLoad.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnTroVe.Enabled = true;
        }
        private void frmNhanVien_FormClosing(object sender, FormClosingEventArgs e)
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
            LoadNhanVien();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true; 
            txtMaNV.Clear();
            txtMaNV.Enabled = true;
            txtMaNV.Focus();
            txtHoLot.Clear();
            txtTen.Clear();
            txtDiaChi.Clear();
            txtDienThoai.Clear();
            chbNu.Checked = false;
            txtHinhAnh.Clear();
            pbNhanVien.Image = null;
            gbNhanVien.Enabled = true;
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
            txtMaNV.Clear();
            txtHoLot.Clear();
            txtTen.Clear();
            txtDiaChi.Clear();
            txtDienThoai.Clear();
            txtHinhAnh.Clear();
            pbNhanVien.Image = null;
            chbNu.Checked = false;
            gbNhanVien.Enabled = false;
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
            txtMaNV.Enabled = false;
            int r = dgvNhanVien.CurrentCell.RowIndex;
            txtMaNV.Text = dgvNhanVien.Rows[r].Cells[0].Value.ToString().Trim();
            txtHoLot.Text = dgvNhanVien.Rows[r].Cells[1].Value.ToString().Trim();
            txtTen.Text = dgvNhanVien.Rows[r].Cells[2].Value.ToString().Trim();
            txtNgayNV.Text = dgvNhanVien.Rows[r].Cells[4].Value.ToString().Trim();
            txtDiaChi.Text = dgvNhanVien.Rows[r].Cells[5].Value.ToString().Trim();
            txtDienThoai.Text = dgvNhanVien.Rows[r].Cells[6].Value.ToString().Trim() ;
            txtHinhAnh.Text = dgvNhanVien.Rows[r].Cells[7].Value.ToString().Trim();
            if (txtHinhAnh.Text.ToString() != "")
            {
                pbNhanVien.Image = Image.FromFile(txtHinhAnh.Text.ToString());
            }
            else { pbNhanVien.Image = null; }
            chbNu.Checked = Convert.ToBoolean(dgvNhanVien.Rows[r].Cells[3].Value);
            txtHoLot.Focus();

            gbNhanVien.Enabled = true;
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
                    cmd.CommandType = CommandType.Text;
                    int r = dgvNhanVien.CurrentCell.RowIndex;
                    string maNV = dgvNhanVien.Rows[r].Cells[0].Value.ToString();
                    cmd.CommandText = System.String.Concat("delete from NhanVien where manv=N'" + maNV + "'");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    LoadNhanVien();
                    db.deleteSeccessful();
                }catch(SqlException a)
                {
                    db.deleteError(a.Message.ToString());
                }
                db.getConnection().Close();
                chbNu.Checked = false;
                gbNhanVien.Enabled = false;
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
            string maNV = txtMaNV.Text.ToString().Trim();
            string hoLot = txtHoLot.Text.ToString().Trim();
            string ten = txtTen.Text.ToString().Trim();
            string ngayNV = txtNgayNV.Value.ToString().Trim();
            string dchi = txtDiaChi.Text.ToString().Trim();
            string sdt = txtDienThoai.Text.ToString().Trim();
            string hinh = txtHinhAnh.Text.ToString().Trim();
            if(maNV == "")
            {
                db.messageError("Mã Nhân Viên Không Được Rỗng !!!", "");
                txtMaNV.Focus();
                return;
            }
            if (hoLot == "")
            {
                db.messageError("Bạn chưa nhập Họ của Nhân Viên !!!", "");
                txtHoLot.Focus();
                return;
            }
            if (ten == "")
            {
                db.messageError("Bạn chưa nhập Tên của Nhân Viên !!!", "");
                txtTen.Focus();
                return;
            }
            if (ngayNV == "")
            {
                db.messageError("Bạn chưa nhập Ngày Sinh !!!", "");
                txtNgayNV.Focus();
                return;
            }
            if (sdt == "")
            {
                db.messageError("Bạn chưa nhập Số Điện Thoại !!!", "");
                txtDienThoai.Focus();
                return;
            }
            if (dchi == "")
            {
                db.messageError("Bạn chưa nhập Địa Chỉ !!!", "");
                txtDiaChi.Focus();
                return;
            }
            
            int gioiTinh = 0;
            if (chbNu.Checked == true) gioiTinh = 1;
            cmd.Connection = db.getConnection();
            cmd.CommandType = CommandType.Text;
            db.getConnection().Open();
            if (Them)
            {
                try
                {
                    cmd.CommandText = System.String.Concat("insert into NhanVien(MaNV,Ho,Ten,Nu,NgayNV,DiaChi,DienThoai,Hinh) values(N'" + maNV + "', N'" + hoLot + "', N'" + ten + "', N'" + gioiTinh + "', N'" + ngayNV + "', N'" + dchi + "', N'" + sdt + "', N'"+hinh+"')");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    db.addSeccessful();
                }
                catch (SqlException a)
                {
                    db.addError(a.Message.ToString());
                }
            }
            else if(!Them)
            {
                try
                {
                    int r = dgvNhanVien.CurrentCell.RowIndex;
                    cmd.CommandText = System.String.Concat("update NhanVien set ho=N'" + hoLot + "', ten=N'" + ten + "', Nu=N'"+gioiTinh+"', ngayNV=N'"+ngayNV+"', diachi=N'"+dchi+"', dienthoai=N'"+sdt+"',Hinh=N'"+hinh+"' where maNV=N'"+maNV+"'");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    db.updateSeccessful();
                }
                catch (SqlException a)
                {
                    db.addError(a.Message.ToString());
                }
            }
            
            db.getConnection().Close();
            LoadNhanVien();
            gbNhanVien.Enabled = false;
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
            dlOpen.Filter = "Image Files(*.BMP,*.JPG,*PNG,*JPEG,*.GIF)|*.BMP,*.JPG, *PNG, *JPEG,*.GIF| All files(*.*)|*.*";
            dlOpen.Title = "Chọn một hình ảnh";
            if (dlOpen.ShowDialog() == DialogResult.OK)
            {
                pbNhanVien.Image = Image.FromFile(dlOpen.FileName);
                txtHinhAnh.Text = dlOpen.FileName;
            }
        }
    }
}
