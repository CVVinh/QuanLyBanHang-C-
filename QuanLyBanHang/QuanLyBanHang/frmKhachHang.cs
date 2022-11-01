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
    
    public partial class frmKhachHang : Form
    {
        DB db = new DB();
        SqlDataAdapter da = null;
        DataTable dtKhachHang = new DataTable();
        DataTable dtThanhPho = new DataTable();
        SqlCommand cmd = new SqlCommand();
        bool Them;

        public frmKhachHang()
        {
            InitializeComponent();
        }
        private void LoadKhachHang()
        {
            try
            {
                da = new SqlDataAdapter("select*from khachhang", db.getConnection());
                dtKhachHang.Clear();
                da.Fill(dtKhachHang);
                dgvKhachHang.DataSource = dtKhachHang;
                //dgvKhachHang.RowCount(); // đếm số dòng
            }
            catch (SqlException a)
            {
                db.loadDataError("KHACHHANG",a.Message.ToString());
            }
        }
        private void LoadThanhPho()
        {
            try
            {
                da = new SqlDataAdapter("select*from thanhpho", db.getConnection());
                dtThanhPho.Clear();
                da.Fill(dtThanhPho);
                (dgvKhachHang.Columns["ThanhPho"] as DataGridViewComboBoxColumn).DataSource = dtThanhPho;
                (dgvKhachHang.Columns["ThanhPho"] as DataGridViewComboBoxColumn).DisplayMember = "TenThanhPho";
                (dgvKhachHang.Columns["ThanhPho"] as DataGridViewComboBoxColumn).ValueMember = "ThanhPho";
                cbThanhPho.DataSource = dtThanhPho;
                cbThanhPho.DisplayMember = "TenThanhPho";
                cbThanhPho.ValueMember = "ThanhPho";
            }
            catch (SqlException a)
            {
                db.loadDataError("THANHPHO", a.Message.ToString());
            }
        }
        
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadThanhPho();
            LoadKhachHang();
            pnlKhachHang.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void frmKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // giai phong tai nguyen
                dtKhachHang.Dispose();
                dtKhachHang = null;
                dtThanhPho.Dispose();
                dtThanhPho = null;
                // dong noi ket
                db.closeConnection();
            }
            catch (SqlException a)
            {
                MessageBox.Show("Loi! dong noi ket - " + a.Message.ToString());
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadThanhPho();
            LoadKhachHang();
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
                    // lay thu tu record hien hanh
                    int r = dgvKhachHang.CurrentCell.RowIndex;
                    // lay MaKH cua record
                    String strMaKH = dgvKhachHang.Rows[r].Cells[0].Value.ToString();
                    // viet cau truy van SQL
                    cmd.CommandText = System.String.Concat("delete from Khachhang where makh = N'" + strMaKH + "'");
                    cmd.CommandType = CommandType.Text;
                    // thuc hien truy van
                    cmd.ExecuteNonQuery();
                    LoadThanhPho();
                    LoadKhachHang();
                    db.deleteSeccessful();
                }
                catch (SqlException a)
                {
                    db.deleteError(a.Message.ToString());
                }
                db.getConnection().Close();

                btnLuu.Enabled = false;
                btnHuy.Enabled = false;

                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnThoat.Enabled = true;
                btnReload.Enabled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            txtMaKH.Clear();
            txtMaKH.Enabled = true;
            txtTenCty.Clear();
            txtDchi.Clear();
            txtDienThoai.Clear();
            txtMaKH.Focus();
            
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnThoat.Enabled = false;
            btnReload.Enabled = false;

            pnlKhachHang.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnThoat.Enabled = false;
            btnReload.Enabled = false;
            txtMaKH.Enabled = false;

            pnlKhachHang.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            int r = dgvKhachHang.CurrentCell.RowIndex;
            txtMaKH.Text = dgvKhachHang.Rows[r].Cells[0].Value.ToString();
            txtTenCty.Text = dgvKhachHang.Rows[r].Cells[1].Value.ToString();
            txtDchi.Text = dgvKhachHang.Rows[r].Cells[2].Value.ToString();
            cbThanhPho.SelectedValue = dgvKhachHang.Rows[r].Cells[3].Value.ToString();
            txtDienThoai.Text = dgvKhachHang.Rows[r].Cells[4].Value.ToString();

            txtTenCty.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text.ToString();
            string tenCty = txtTenCty.Text.ToString();
            string dchi = txtDchi.Text.ToString();
            string sdt = txtDienThoai.Text.ToString();
            if (maKH == "")
            {
                db.messageError("Mã Khách Hàng không được rỗng !!!", "");
                txtMaKH.Focus();
                return;
            }
            if (tenCty == "")
            {
                db.messageError("Bạn chưa nhập Tên Công Ty !!!", "");
                txtTenCty.Focus();
                return;
            }
            if (dchi == "")
            {
                db.messageError("Bạn chưa nhập Địa Chỉ !!!", "");
                txtDchi.Focus();
                return;
            }
            if (sdt == "")
            {
                db.messageError("Bạn chưa nhập Số Điện Thoại !!!", "");
                txtDienThoai.Focus();
                return;
            }
            cmd.Connection = db.getConnection();
            cmd.CommandType = CommandType.Text;
            db.getConnection().Open();
            if (Them)
            {
                try
                {
                    cmd.CommandText = System.String.Concat("insert into khachhang values (N'"+txtMaKH.Text.ToString()+"'"
                        +", N'"+txtTenCty.Text.ToString()+"'"
                        +", N'"+txtDchi.Text.ToString()+"'"
                        +", N'"+cbThanhPho.SelectedValue.ToString()+"'"
                        +", N'"+txtDienThoai.Text.ToString()+"')");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    db.addSeccessful();
                }
                catch(SqlException a)
                {
                    db.addError(a.Message.ToString());
                }
            }else if (!Them)
            {
                try
                {
                    int r = dgvKhachHang.CurrentCell.RowIndex;
                    String strMaKH = dgvKhachHang.Rows[r].Cells[0].Value.ToString();
                    cmd.CommandText = System.String.Concat("update khachhang set tencty=N'" + txtTenCty.Text.ToString() + "', diachi=N'" + txtDchi.Text.ToString() + "', thanhpho=N'" + cbThanhPho.SelectedValue.ToString() + "', dienthoai=N'" + txtDienThoai.Text.ToString() + "' where makh=N'"+strMaKH+"'");
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
            LoadKhachHang();
            LoadThanhPho();
            pnlKhachHang.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThoat.Enabled = true;
            btnReload.Enabled = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaKH.Clear();
            txtTenCty.Clear();
            txtDchi.Clear();
            txtDienThoai.Clear();
            pnlKhachHang.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThoat.Enabled = true;
            btnReload.Enabled = true;

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("Hello you");
        }
    }
}
