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

namespace QuanLyBanHang
{
    public partial class frmChinh : Form
    {
        DB db = new DB();
        public static String manv="";

        public frmChinh()
        {
            InitializeComponent();
        }
        // Lay ma nhan vien
        public static String getMaNV()
        {
            return manv;
        }
        // dat ma nhan vien
        public static void setMaNV(String maNV)
        {
            manv = maNV;
        }
        public void frmLogin(int intLogin)
        {
            Form frm = new frmLogin();
            frm.Text = intLogin.ToString();
            frm.ShowDialog();
        }
        public void XemDanhMuc(int indexDanhMuc)
        {
            Form frm = new frmXemDanhMuc();
            frm.Text = indexDanhMuc.ToString();
            frm.ShowDialog();
        }
        private void frmChinh_Load(object sender, EventArgs e)
        {
            frmLogin(1);
        }

        private void menuDN_Click(object sender, EventArgs e)
        {            
            frmLogin(1);
        }

        private void menuDX_Click(object sender, EventArgs e)
        {
            if (db.confirmString("Bạn Có Chắc Muốn Thoát Phiên Làm Việc !!!")) {
                manv = "";
            }
        }

        private void menuDMK_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmChangePass();
            frm.ShowDialog();
        }

        private void menuCNTT_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmUpdateNV();
            frm.ShowDialog();
        }

        private void menuCTK_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            frmLogin(2);
        }

        private void menuThoat_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            db.closeApp();
        }

        private void menuXDMTP_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            XemDanhMuc(1);
        }

        private void menuXDMKH_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            XemDanhMuc(2);
        }

        private void menuXDMNV_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            XemDanhMuc(3);
        }

        private void menuXDMSP_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            XemDanhMuc(4);
        }

        private void menuXDMHD_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            XemDanhMuc(5);
        }

        private void menuXDMCTHD_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            XemDanhMuc(6);
        }

        private void menuQLDMTP_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmThanhPho();
            frm.ShowDialog();
        }

        private void menuQLDMKH_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmKhachHang();
            frm.ShowDialog();
        }

        private void menuQLDMNV_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmNhanVien();
            frm.ShowDialog();
        }

        private void menuQLDMSP_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmSanPham();
            frm.ShowDialog();
        }

        private void menuQLDMHD_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmHoaDon();
            frm.ShowDialog();
        }

        private void menuQLDMCTHD_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmChiTietHD();
            frm.ShowDialog();
        }

        private void menuQLKHTTP_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmKHTP();
            frm.ShowDialog();
        }

        private void menuQLHDTKH_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmHDKH();
            frm.ShowDialog();
        }

        private void menuQLHDTNV_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmHDNV();
            frm.ShowDialog();
        }

        private void menuQLHDTSP_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmHDSP();
            frm.ShowDialog();
        }

        private void menuQLCTHDTHD_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmCTHDHD();
            frm.ShowDialog();
        }

        private void chiTiếtHóaĐơnTheoSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmCTHDSP();
            frm.ShowDialog();
        }

        private void menuQLDCTKH_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmQLDaCapKH();
            frm.ShowDialog();
        }

        private void menuQLDCTNV_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmQLDaCapNV();
            frm.ShowDialog();
        }

        // moi them chuc nang bao cao
        private void menuBCDMKH_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmReportKH();
            frm.ShowDialog();
        }

        private void menuBCDMNV_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmReportNV();
            frm.ShowDialog();
        }

        private void menuBCDMSP_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmReportSP();
            frm.ShowDialog();
        }

        private void menuBCDMHD_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmReportHD();
            frm.ShowDialog();
        }

        private void menuBCDMCTHD_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmReportCTHD();
            frm.ShowDialog();
        }

        private void menuHDSD_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmHelp();
            frm.ShowDialog();
        }


        // Menu Ribbon
        private void rbLogIn_Click(object sender, EventArgs e)
        {
            frmLogin(1);
        }

        private void rbLogOut_Click(object sender, EventArgs e)
        {
            if(db.confirmString("Bạn Có Chắc Muốn Thoát Phiên Làm Việc !!!"))
            {
                manv = "";
            }
        }

        private void rbEditKey_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmChangePass();
            frm.ShowDialog();
        }

        private void rbUpdateEmployee_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmUpdateNV();
            frm.ShowDialog();
        }

        private void rbAccountTranfer_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            frmLogin(2);
        }

        private void rbExit_Click(object sender, EventArgs e)
        {
            db.closeApp();
        }

        private void rbCity_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            XemDanhMuc(1);
        }

        private void rbCustomer_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            XemDanhMuc(2);
        }

        private void rbEmployee_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            XemDanhMuc(3);
        }

        private void rbProduct_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            XemDanhMuc(4);
        }

        private void rbReceipt_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            XemDanhMuc(5);
        }

        private void rbDetailReceipt_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            XemDanhMuc(6);
        }

        private void rbMunipulationCity_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmThanhPho();
            frm.ShowDialog();
        }

        private void rbManipulationCustomer_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmKhachHang();
            frm.ShowDialog();
        }

        private void rbManipulationEmployee_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmNhanVien();
            frm.ShowDialog();
        }

        private void rbManipulationProduct_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmSanPham();
            frm.ShowDialog();
        }

        private void rbManipulationReceipt_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmHoaDon();
            frm.ShowDialog();
        }

        private void rbManipulationDetailReceipt_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmChiTietHD();
            frm.ShowDialog();
        }

        private void rbFindCity_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmKHTP();
            frm.ShowDialog();
        }

        private void rbFindCustomer_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmHDKH();
            frm.ShowDialog();
        }

        private void rbFindEmployee_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmHDNV();
            frm.ShowDialog();
        }

        private void rbFindProduct_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmHDSP();
            frm.ShowDialog();
        }

        private void rbFindReceipt_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmCTHDHD();
            frm.ShowDialog();
        }

        private void rbFindDetailReceipt_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmCTHDSP();
            frm.ShowDialog();
        }

        private void rbFindGroupClients_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmQLDaCapKH();
            frm.ShowDialog();
        }

        private void rbFindGroupStaffs_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmQLDaCapNV();
            frm.ShowDialog();
        }     

        // moi them vao menu ribbon
        private void rbReportCustomer_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmReportKH();
            frm.ShowDialog();
        }

        private void rbReportEmployee_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmReportNV();
            frm.ShowDialog();
        }

        private void rbReportProduct_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmReportSP();
            frm.ShowDialog();
        }

        private void rbReportReceipt_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmReportHD();
            frm.ShowDialog();
        }

        private void rbReportDetailReceipt_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmReportCTHD();
            frm.ShowDialog();
        }
        
        private void rbHelp_Click(object sender, EventArgs e)
        {
            if (manv.Equals("")) frmLogin(1);
            Form frm = new frmHelp();
            frm.ShowDialog();
        }
    }
}
