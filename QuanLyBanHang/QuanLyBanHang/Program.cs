using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmThanhPho());
            //Application.Run(new frmKhachHang());
            //Application.Run(new frmNhanVien());
            //Application.Run(new frmChangePass());
            //Application.Run(new frmLogin());
            //Application.Run(new frmReportKH());
            //Application.Run(new frmReportNV());
            //Application.Run(new frmReportSP());
            //Application.Run(new frmReportHD());
            //Application.Run(new frmReportCTHD());
            //Application.Run(new frmHelp());
            Application.Run(new frmChinh());
        }
    }
}
