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
    public partial class frmThanhPho : Form
    {
        DB db = new DB();
        SqlDataAdapter da = null;
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();
        bool them;

        public frmThanhPho()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            try
            {
                da = new SqlDataAdapter("select*from thanhpho", db.getConnection());
                dt.Clear();
                da.Fill(dt);
                dgvThanhpho.DataSource = dt;
                txtMaThanhPho.ResetText();
                txtTenThanhPho.ResetText();
                pnlThamhPho.Enabled = false;
                btnHuyBo.Enabled = false;
                btnLuu.Enabled = false;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnReLoad.Enabled = true;
            }catch(SqlException a)
            {
                db.loadDataError("THANHPHO",a.Message.ToString());
            }
        }

        private void frmThanhPho_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmThanhPho_FormClosing(object sender, FormClosingEventArgs e)
        {
            dt.Dispose();
            dt = null;
            db.closeConnection();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            txtMaThanhPho.Enabled = true;
            pnlThamhPho.Enabled = true;
            btnHuyBo.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnReLoad.Enabled = false;
            txtMaThanhPho.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            them = false;
            int r = dgvThanhpho.CurrentCell.RowIndex;
            this.txtMaThanhPho.Text = dgvThanhpho.Rows[r].Cells[0].Value.ToString();
            txtTenThanhPho.Text = dgvThanhpho.Rows[r].Cells[1].Value.ToString();
            txtTenThanhPho.Focus();
            txtMaThanhPho.Enabled = false;
            pnlThamhPho.Enabled = true;
            btnHuyBo.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnReLoad.Enabled = false;
            txtTenThanhPho.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(db.confirmDelete())
            {
                db.getConnection().Open();
                try
                {
                    int r = dgvThanhpho.CurrentCell.RowIndex;
                    string maThanhPho = dgvThanhpho.Rows[r].Cells[0].Value.ToString();
                    cmd.Connection = db.getConnection();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = System.String.Concat("delete from thanhpho where thanhpho=N'" + maThanhPho + "'");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    LoadData();
                    db.deleteSeccessful();
                }
                catch (SqlException a)
                {
                    db.deleteError(a.Message.ToString());
                }
                db.getConnection().Close();
                btnLuu.Enabled = false;
                btnHuyBo.Enabled = false;

                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnReLoad.Enabled = true;
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            txtMaThanhPho.ResetText();
            txtTenThanhPho.ResetText();
            pnlThamhPho.Enabled = false;
            btnHuyBo.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnReLoad.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maTP = txtMaThanhPho.Text.ToString();
            string tenTP = txtTenThanhPho.Text.ToString();
            if (maTP == "")
            {
                db.messageError("Mã Thành Phố không được rỗng !!!", "");
                txtMaThanhPho.Focus();
                return;
            }
            if (tenTP == "")
            {
                db.messageError("Bạn chưa nhập Tên Thành Phố !!!", "");
                txtTenThanhPho.Focus();
                return;
            }
            cmd.Connection = db.getConnection();
            cmd.CommandType = CommandType.Text;
            db.getConnection().Open();
            if (them)
            {
                try
                {
                    cmd.CommandText = System.String.Concat("Insert into thanhpho values(N'" + maTP + "', N'" + tenTP + "')");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();                    
                    db.addSeccessful();
                }
                catch (SqlException a)
                {
                    db.addError(a.Message.ToString());
                }
            }
            if (!them)
            {
                try
                {
                    int r = dgvThanhpho.CurrentCell.RowIndex;
                    string maThanhPho = dgvThanhpho.Rows[r].Cells[0].Value.ToString();
                    cmd.CommandText = System.String.Concat("Update thanhpho set tenthanhpho=N'" + tenTP + "' where thanhpho=N'" + maThanhPho + "'");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    db.updateSeccessful();
                }
                catch (SqlException a)
                {
                    db.updateError(a.Message.ToString());
                }
            }
            LoadData();
            db.getConnection().Close();
            pnlThamhPho.Enabled = false;
            btnHuyBo.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnReLoad.Enabled = true;
        }

        private void txtMaThanhPho_TextChanged(object sender, EventArgs e)
        {
            string maTP = txtMaThanhPho.Text.ToString();
            if (maTP != "")
            {
                int isInt;
                bool check = int.TryParse(maTP, out isInt);
                if (!check)
                {
                    db.messageError("Mã Thành Phố !!!", "Bạn phải nhập vào một con số");
                    txtMaThanhPho.Clear();
                    txtMaThanhPho.Focus();
                    return;
                }
            }
        }
    }
}
