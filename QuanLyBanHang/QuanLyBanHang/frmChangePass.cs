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
    public partial class frmChangePass : Form
    {
        DB db = new DB();
        SqlCommand cmd = new SqlCommand();

        public frmChangePass()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string tenDN = txtTenDangNhap.Text.ToString().Trim();
            string mkOld = txtOldMK.Text.ToString().Trim();
            string mkNew = txtMatKhau.Text.ToString().Trim();
            string mkAgain = txtAgainMK.Text.ToString().Trim();
            if (tenDN == "")
            {
                db.messageError("Lỗi! Nhập Tên Người Dùng!", "Bạn chưa nhập Tên Người Dùng!");
                txtTenDangNhap.Clear();
                txtTenDangNhap.Focus();
                return;
            }
            if (mkOld == "")
            {
                db.messageError("Lỗi! Nhập Mật Khẩu Cũ!", "Bạn chưa nhập mật khẩu cũ !!!");
                txtOldMK.Clear();
                txtOldMK.Focus();
                return;
            }
            if (mkNew == "")
            {
                db.messageError("Lỗi! Nhập Mật Khẩu Mới!", "Bạn chưa nhập mật khẩu Mới !!!");
                txtMatKhau.Clear();
                txtMatKhau.Focus();
                return;
            }
            if (mkAgain == "")
            {
                db.messageError("Lỗi! Nhập Lại Mật Khẩu Mới!", "Bạn chưa nhập Lại mật khẩu Mới !!!");
                txtAgainMK.Clear();
                txtAgainMK.Focus();
                return;
            }
            db.getConnection().Open();
            cmd.Connection = db.getConnection();
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.CommandText = System.String.Concat("select*from DangNhap where MaNV=N'" + frmChinh.getMaNV() + "'");
                cmd.CommandType = CommandType.Text;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (mkOld.CompareTo(reader.GetString(2))!=0)
                            {
                                db.messageError("Lỗi! Mật Khẩu Cũ!", "Mật Khẩu Cũ Không Đúng!");
                                txtOldMK.Clear();
                                txtOldMK.Focus();
                                db.getConnection().Close();
                                return;
                            }
                        }
                    }
                }
            }
            catch (SqlException a)
            {
                db.messageError("Lỗi! Truy Vấn Bảng Mật Khẩu !!!", a.Message.ToString());
            }
            try
            {
                cmd.CommandText = System.String.Concat("update DangNhap set TenDangNhap=N'" + tenDN + "', MatKhau=N'" + mkNew + "' where MaNV=N'" + frmChinh.getMaNV() + "'");
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                db.messageSeccessful("Cập Nhật Mật Khẩu Thành Công!!!");
            }
            catch(SqlException a)
            {
                db.messageError("Lỗi! Cập Nhật Mật Khẩu !!!", a.Message.ToString());
            }
            db.getConnection().Close();
            this.Close();
        }      

        private void txtMatKhau_Leave(object sender, EventArgs e)
        {
            string mkOld = txtOldMK.Text.ToString().Trim();
            string mkNew = txtMatKhau.Text.ToString().Trim();
            if (mkNew.Equals("")) { return; }
            if (mkNew.CompareTo(mkOld) == 0)
            {
                db.messageError("Lỗi! Mật Khẩu Mới!", "Bạn đã sử dụng mật khẩu này rồi!!!\nVui lòng thay mật khẩu mới.");
                txtMatKhau.Clear();
                txtMatKhau.Focus();
                return;
            }
        }

        private void txtAgainMK_Leave(object sender, EventArgs e)
        {
            string mkNew = txtMatKhau.Text.ToString().Trim();
            string mkAgain = txtAgainMK.Text.ToString().Trim();
            if (mkAgain.Equals("")) { return; }
            if (mkAgain.CompareTo(mkNew) != 0)
            {
                db.messageError("Lỗi! Nhập Lại Mật Khẩu Mới!", "Mật Khẩu Nhập Lại Không Khớp với Mật Khẩu Mới.");
                txtAgainMK.Clear();
                txtAgainMK.Focus();
                return;
            }
        }

    }
}
