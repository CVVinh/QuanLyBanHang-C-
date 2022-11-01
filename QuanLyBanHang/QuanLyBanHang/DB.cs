using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    class DB
    {
        // chuoi ket noi
        public static String strConnectionString = "Data Source=DESKTOP-DSGAHCU; Initial Catalog = QuanLyBanHang; Integrated Security = True";
        

        // doi tuong ket noi
        public static SqlConnection conn ;
        // doi tuong dua du lieu vao DataTable dt
        public SqlDataAdapter da = null;
        // doi tuong hien thi du lieu len Form
        public DataTable dt;
        
        public DB()
        {
            conn = new SqlConnection(strConnectionString);
        }
        public DB(String nameCSDL)
        {
            String connCSDL = "Data Source=DESKTOP-DSGAHCU;Initial Catalog="+ nameCSDL + "; Integrated Security = True";
            conn = new SqlConnection(connCSDL);
        }
        // mo noi ket
        public SqlConnection getConnection()
        {
            return conn;
        }
        // dong noi ket
        public void closeConnection()
        {
            conn.Close();
        }
        
        // thoat ung dung
        public void closeApp()
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát ứng dụng?", "Xác Nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
                Application.Exit();
        }
        public void messageError(string message, string error)
        {
            MessageBox.Show(message+" - "+ error, "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void loadDataError(string bangLoi, string error)
        {
            MessageBox.Show("Lỗi! không lấy được nội dung trong bảng "+ bangLoi + " !!! - " + error, "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void addError(string error)
        {
            MessageBox.Show("Lỗi! không Thêm được bảng ghi !!! - " + error, "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void updateError(string error)
        {
            MessageBox.Show("Lỗi! không Cập Nhật được bảng ghi !!! - " + error, "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void deleteError(string error)
        {
            MessageBox.Show("Lỗi! không xóa được bảng ghi !!! - " + error, "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void messageSeccessful(String message)
        {
            MessageBox.Show(message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void addSeccessful()
        {
            MessageBox.Show("Thêm Bảng ghi thành công !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void updateSeccessful()
        {
            MessageBox.Show("Cập Nhật Bảng ghi thành công !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void deleteSeccessful()
        {
            MessageBox.Show("Đã xóa thành công !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public bool confirmDelete()
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa !!!", "Xác Nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            return (DialogResult.OK == result);
        }
        public bool confirmString(string str)
        {
            DialogResult result = MessageBox.Show(str, "Xác Nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            return (DialogResult.OK == result);
        }

    }
}
