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
using System.Data.Common;

namespace QuanLyBanHang
{
    public partial class frmUpdateNV : Form
    {
        DB db = new DB();
        SqlCommand cmd = new SqlCommand();

        public frmUpdateNV()
        {
            InitializeComponent();
        }

        private void frmUpdateNV_Load(object sender, EventArgs e)
        {
            cmd.Connection = db.getConnection();
            cmd.CommandType = CommandType.Text;
            db.getConnection().Open();
            try
            {
                cmd.CommandText = System.String.Concat("select*from NhanVien where MaNV=N'" + frmChinh.getMaNV() + "'");
                cmd.CommandType = CommandType.Text;
                using(DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            txtMaNV.Text = reader.GetString(0);
                            txtHoLot.Text = reader.GetString(1);
                            txtTen.Text = reader.GetString(2);
                            int gender = reader.GetInt32(3);
                            if (gender == 0)
                            {
                                chbNu.Checked = true;
                            }
                            else { chbNu.Checked = false; }

                            txtNgayNV.Text = reader.GetDateTime(4).ToLongDateString();
                            txtDiaChi.Text = reader.GetString(5);
                            txtDienThoai.Text = reader.GetString(6);
                            int intImage = reader.GetOrdinal("Hinh");
                            var anh = reader.GetValue(7).ToString();
                            if (!reader.IsDBNull(intImage) && anh != "")
                            {
                                txtHinhAnh.Text = anh;
                                pbNhanVien.Image = Image.FromFile(anh);
                            }
                            else { pbNhanVien.Image = null; }

                            txtHoLot.Focus();
                        }
                    }
                }
            }catch(SqlException a)
            {
                db.loadDataError("NHANVIEN", a.Message.ToString());
            }
            db.getConnection().Close();
        }

        private void frmUpdateNV_FormClosing(object sender, FormClosingEventArgs e)
        {
            db.closeConnection();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string hoLot = txtHoLot.Text.ToString().Trim();
            string ten = txtTen.Text.ToString().Trim();
            string ngayNV = txtNgayNV.Value.ToString().Trim();
            string dchi = txtDiaChi.Text.ToString().Trim();
            string sdt = txtDienThoai.Text.ToString().Trim();
            string hinh = txtHinhAnh.Text.ToString().Trim();
            
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

            int gioiTinh = 1;
            if (chbNu.Checked == true) gioiTinh = 0;
            cmd.Connection = db.getConnection();
            cmd.CommandType = CommandType.Text;
            db.getConnection().Open();
            try
            {
                cmd.CommandText = System.String.Concat("update NhanVien set ho=N'" + hoLot + "', ten=N'" + ten + "', Nu=" + gioiTinh + ", ngayNV=N'" + ngayNV + "', diachi=N'" + dchi + "', dienthoai=N'" + sdt + "', Hinh=N'" + hinh + "' where maNV=N'" + frmChinh.getMaNV() + "'");
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                db.updateSeccessful();
                db.getConnection().Close();
                this.Close();
            }
            catch (SqlException a)
            {
                db.addError(a.Message.ToString());
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtHinhAnh.Clear();
            pbNhanVien.Image = null;
        }
    }
}
