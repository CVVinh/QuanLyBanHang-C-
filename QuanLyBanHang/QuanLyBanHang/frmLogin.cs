using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyBanHang
{
    public partial class frmLogin : Form
    {
        DB db = new DB();
        int typeFrom;
        SqlCommand cmd = new SqlCommand();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            typeFrom = Convert.ToInt32(this.Text);
            switch (typeFrom)
            {
                case 1:
                    lbDangNhap.Text = "ĐĂNG NHẬP HỆ THỐNG";
                    this.Text = "ĐĂNG NHẬP HỆ THỐNG";
                    break;
                case 2:
                    lbDangNhap.Text = "CHUYỂN ĐỔI TÀI KHOẢN";
                    this.Text = "CHUYỂN ĐỔI TÀI KHOẢN";
                    break;
                default: break;
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.ToString().Trim();
            string matKhau = txtMatKhau.Text.ToString().Trim();
            if (tenDangNhap == "")
            {
                db.messageError("Lỗi! Tên Đăng Nhập !!!","Bạn chưa nhập Tên Đăng Nhập !!!");
                txtTenDangNhap.Focus();
                return;
            }
            if (matKhau == "")
            {
                db.messageError("Lỗi! Mật Khẩu !!!", "Bạn chưa nhập Mật Khẩu !!!");
                txtMatKhau.Focus();
                return;
            }
            db.getConnection().Open();
            try
            {
                cmd.Connection = db.getConnection();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = System.String.Concat("select*from DangNhap where TenDangNhap=N'"+tenDangNhap+"' and MatKhau=N'"+matKhau+"'");
                cmd.CommandType = CommandType.Text;

                // Thi hành truy vấn trả về SqlReader
                string result = Convert.ToString(cmd.ExecuteScalar());

                // Kiểm tra có kết quả trả về
                if (!result.Equals(""))
                {
                    frmChinh.setMaNV(result) ;
                    db.getConnection().Close();
                    this.Close();
                }
                else
                {
                    db.messageError("Lỗi! Đăng Nhập Hệ Thống !!!", "Không đúng tên người dùng/mật khẩu !!!");
                }
            }
            catch (SqlException a)
            {
                db.messageError("Lỗi! Đăng Nhập Hệ Thống !!!", a.Message.ToString()+"\n"+a.ToString());
            }
            db.getConnection().Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (typeFrom == 1)
                db.closeApp();
            else this.Close();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (new StackTrace().GetFrames().Any(x => x.GetMethod().Name == "Close")) {
                //MessageBox.Show("Closed by calling Close()");
            }
            else
            {
                //MessageBox.Show("Closed by X or Alt+F4");
                Application.Exit();
            }
                
        }

        
    }
}
