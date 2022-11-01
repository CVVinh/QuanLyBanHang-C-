USE [master]
GO
/****** Object:  Database [QuanLyBanHang]    Script Date: 12/8/2021 3:51:18 AM ******/
CREATE DATABASE [QuanLyBanHang]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyBanHang', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\QuanLyBanHang.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLyBanHang_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\QuanLyBanHang_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [QuanLyBanHang] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyBanHang].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyBanHang] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QuanLyBanHang] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyBanHang] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyBanHang] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuanLyBanHang] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyBanHang] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyBanHang] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyBanHang] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyBanHang] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyBanHang] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyBanHang] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QuanLyBanHang', N'ON'
GO
ALTER DATABASE [QuanLyBanHang] SET QUERY_STORE = OFF
GO
USE [QuanLyBanHang]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 12/8/2021 3:51:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaHD] [nvarchar](10) NOT NULL,
	[MaSP] [nvarchar](6) NOT NULL,
	[SoLuong] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DangNhap]    Script Date: 12/8/2021 3:51:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DangNhap](
	[MaNV] [nvarchar](6) NOT NULL,
	[TenDangNhap] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_DangNhap] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 12/8/2021 3:51:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHD] [nvarchar](10) NOT NULL,
	[MaKH] [nvarchar](10) NULL,
	[MaNV] [nvarchar](6) NOT NULL,
	[NgayLapHD] [date] NOT NULL,
	[NgayNhanHang] [date] NULL,
 CONSTRAINT [PK__HoaDon__2725A6E024A492C3] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Khachhang]    Script Date: 12/8/2021 3:51:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Khachhang](
	[MaKH] [nvarchar](10) NOT NULL,
	[TenCty] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](100) NULL,
	[ThanhPho] [nvarchar](2) NOT NULL,
	[DienThoai] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 12/8/2021 3:51:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [nvarchar](6) NOT NULL,
	[Ho] [nvarchar](30) NOT NULL,
	[Ten] [nvarchar](12) NOT NULL,
	[Nu] [int] NOT NULL,
	[NgayNV] [date] NOT NULL,
	[DiaChi] [nvarchar](100) NULL,
	[DienThoai] [nvarchar](10) NULL,
	[Hinh] [nvarchar](max) NULL,
 CONSTRAINT [PK__NhanVien__2725D70AF5B4EC33] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 12/8/2021 3:51:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSP] [nvarchar](6) NOT NULL,
	[TenSP] [nvarchar](50) NOT NULL,
	[DonViTinh] [nvarchar](10) NULL,
	[DonGia] [float] NOT NULL,
	[Hinh] [nvarchar](max) NULL,
 CONSTRAINT [PK__SanPham__2725081C3CE2145B] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThanhPho]    Script Date: 12/8/2021 3:51:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThanhPho](
	[ThanhPho] [nvarchar](2) NOT NULL,
	[TenThanhPho] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ThanhPho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (N'00001', N'0006', 48)
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (N'00001', N'0007', 10)
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (N'00002', N'0001', 25)
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (N'00002', N'0002', 90)
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (N'00002', N'0003', 25)
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (N'00002', N'0004', 20)
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (N'00003', N'0007', 10)
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (N'00004', N'0006', 15)
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (N'00004', N'0007', 20)
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (N'00004', N'0008', 15)
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (N'00002', N'0009', 60)
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (N'00001', N'0001', 23)
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSP], [SoLuong]) VALUES (N'00001', N'0003', 23)
GO
INSERT [dbo].[DangNhap] ([MaNV], [TenDangNhap], [MatKhau]) VALUES (N'0001', N'nv1', N'nv1')
INSERT [dbo].[DangNhap] ([MaNV], [TenDangNhap], [MatKhau]) VALUES (N'0002', N'nv2', N'nv2')
INSERT [dbo].[DangNhap] ([MaNV], [TenDangNhap], [MatKhau]) VALUES (N'0003', N'nv3', N'nv3')
INSERT [dbo].[DangNhap] ([MaNV], [TenDangNhap], [MatKhau]) VALUES (N'0004', N'nv4', N'nv4')
INSERT [dbo].[DangNhap] ([MaNV], [TenDangNhap], [MatKhau]) VALUES (N'0005', N'nv5', N'nv5')
INSERT [dbo].[DangNhap] ([MaNV], [TenDangNhap], [MatKhau]) VALUES (N'0006', N'nv6', N'nv6')
INSERT [dbo].[DangNhap] ([MaNV], [TenDangNhap], [MatKhau]) VALUES (N'0007', N'nv7', N'nv7')
INSERT [dbo].[DangNhap] ([MaNV], [TenDangNhap], [MatKhau]) VALUES (N'0008', N'nv8', N'nv8')
INSERT [dbo].[DangNhap] ([MaNV], [TenDangNhap], [MatKhau]) VALUES (N'0009', N'nv9', N'nv9')
INSERT [dbo].[DangNhap] ([MaNV], [TenDangNhap], [MatKhau]) VALUES (N'0010', N'nv10', N'nv10')
INSERT [dbo].[DangNhap] ([MaNV], [TenDangNhap], [MatKhau]) VALUES (N'0011', N'nv11', N'nv11')
GO
INSERT [dbo].[HoaDon] ([MaHD], [MaKH], [MaNV], [NgayLapHD], [NgayNhanHang]) VALUES (N'00001', N'AGROMAS', N'0001', CAST(N'1999-06-28' AS Date), CAST(N'1999-07-10' AS Date))
INSERT [dbo].[HoaDon] ([MaHD], [MaKH], [MaNV], [NgayLapHD], [NgayNhanHang]) VALUES (N'00002', N'BUMEM', N'0002', CAST(N'1999-06-29' AS Date), CAST(N'1999-07-12' AS Date))
INSERT [dbo].[HoaDon] ([MaHD], [MaKH], [MaNV], [NgayLapHD], [NgayNhanHang]) VALUES (N'00003', N'ALSIMES', N'0001', CAST(N'1999-07-04' AS Date), CAST(N'1999-07-12' AS Date))
INSERT [dbo].[HoaDon] ([MaHD], [MaKH], [MaNV], [NgayLapHD], [NgayNhanHang]) VALUES (N'00004', N'AGROMAS', N'0004', CAST(N'1999-07-05' AS Date), CAST(N'1999-07-10' AS Date))
INSERT [dbo].[HoaDon] ([MaHD], [MaKH], [MaNV], [NgayLapHD], [NgayNhanHang]) VALUES (N'00005', N'COFIDEC', N'0003', CAST(N'1999-07-06' AS Date), CAST(N'1999-07-20' AS Date))
INSERT [dbo].[HoaDon] ([MaHD], [MaKH], [MaNV], [NgayLapHD], [NgayNhanHang]) VALUES (N'00006', N'ATC', N'0002', CAST(N'1999-07-08' AS Date), CAST(N'1999-07-21' AS Date))
INSERT [dbo].[HoaDon] ([MaHD], [MaKH], [MaNV], [NgayLapHD], [NgayNhanHang]) VALUES (N'00007', N'AGROMAS', N'0001', CAST(N'2000-01-01' AS Date), CAST(N'2000-02-01' AS Date))
INSERT [dbo].[HoaDon] ([MaHD], [MaKH], [MaNV], [NgayLapHD], [NgayNhanHang]) VALUES (N'00008', N'COFIDEC', N'0004', CAST(N'2010-10-10' AS Date), CAST(N'2010-10-10' AS Date))
INSERT [dbo].[HoaDon] ([MaHD], [MaKH], [MaNV], [NgayLapHD], [NgayNhanHang]) VALUES (N'00009', N'AGROMAS', N'0001', CAST(N'2021-11-14' AS Date), CAST(N'2021-11-15' AS Date))
GO
INSERT [dbo].[Khachhang] ([MaKH], [TenCty], [DiaChi], [ThanhPho], [DienThoai]) VALUES (N'AGROMAS', N'Cơ Điện Nông Nghiệp Q. 5', N'311 Hai Bà Trưng Q3', N'05', N'88970364')
INSERT [dbo].[Khachhang] ([MaKH], [TenCty], [DiaChi], [ThanhPho], [DienThoai]) VALUES (N'ALSIMES', N'Giày An Lạc', N'761 Trần Hưng Đạo P1', N'03', N'548456005')
INSERT [dbo].[Khachhang] ([MaKH], [TenCty], [DiaChi], [ThanhPho], [DienThoai]) VALUES (N'ASC', N'Du Lịch An Phú', N'233 Nguyễn Trãi P2', N'04', N'058812478')
INSERT [dbo].[Khachhang] ([MaKH], [TenCty], [DiaChi], [ThanhPho], [DienThoai]) VALUES (N'ASECO', N'Giầy May 3/2', N'811 Trần Hưng Đạo P1', N'01', N'48951320')
INSERT [dbo].[Khachhang] ([MaKH], [TenCty], [DiaChi], [ThanhPho], [DienThoai]) VALUES (N'ATC', N'Sản Xuất Hàng Mỹ Thuật', N'7 Trang Tử P14', N'04', N'588512230')
INSERT [dbo].[Khachhang] ([MaKH], [TenCty], [DiaChi], [ThanhPho], [DienThoai]) VALUES (N'BUMEM', N'Xây Dựng Bình Minh', N'155 Tô Hiến Thành', N'06', N'718547896')
INSERT [dbo].[Khachhang] ([MaKH], [TenCty], [DiaChi], [ThanhPho], [DienThoai]) VALUES (N'CEMACO', N'Hóa Chất Vật Liệu', N'282 Trần Hưng Đạo P11', N'06', N'0718450057')
INSERT [dbo].[Khachhang] ([MaKH], [TenCty], [DiaChi], [ThanhPho], [DienThoai]) VALUES (N'CINOTEC', N'Điện Toán Sài Gòn', N'43 Yết Kiêu P9', N'05', N'718931752')
INSERT [dbo].[Khachhang] ([MaKH], [TenCty], [DiaChi], [ThanhPho], [DienThoai]) VALUES (N'CODACO', N'Cơ Khí Dân Dụng', N'534 Lê Văn Sĩ P14', N'04', N'588647207')
INSERT [dbo].[Khachhang] ([MaKH], [TenCty], [DiaChi], [ThanhPho], [DienThoai]) VALUES (N'COFIDEC', N'Phát Triển Kinh Té Duyên Hải', N'94 Điện Biên Phủ', N'01', N'48453710')
INSERT [dbo].[Khachhang] ([MaKH], [TenCty], [DiaChi], [ThanhPho], [DienThoai]) VALUES (N'LIPPHACO', N'Liên Phát', N'200 Bến Chuong Duong', N'04', N'0588321047')
INSERT [dbo].[Khachhang] ([MaKH], [TenCty], [DiaChi], [ThanhPho], [DienThoai]) VALUES (N'LIPPHACO1', N'Xây Dựng 789', N'789 Hòa Bình Q5', N'05', N'0326581674')
INSERT [dbo].[Khachhang] ([MaKH], [TenCty], [DiaChi], [ThanhPho], [DienThoai]) VALUES (N'LIPPHACO2', N'Xây Dựng Thành Công', N'859 Lý Thường Kiệt Q.Thủ Đức', N'06', N'0897654232')
INSERT [dbo].[Khachhang] ([MaKH], [TenCty], [DiaChi], [ThanhPho], [DienThoai]) VALUES (N'LIPPHACO3', N'Cơ Điện Công Nghiệp Q. 5', N'102 Lý Tự Trọng Q9', N'02', N'0326587789')
GO
INSERT [dbo].[NhanVien] ([MaNV], [Ho], [Ten], [Nu], [NgayNV], [DiaChi], [DienThoai], [Hinh]) VALUES (N'0001', N'Lê Văn', N'Tám', 1, CAST(N'1995-10-15' AS Date), N'45 Trần Phú Q8', N'86452345', N'D:\baitapC++\PhatTrienUngDungWindow\ThucHanh\chuong6\anh\face.png')
INSERT [dbo].[NhanVien] ([MaNV], [Ho], [Ten], [Nu], [NgayNV], [DiaChi], [DienThoai], [Hinh]) VALUES (N'0002', N'Hà Vĩnh', N'Phát', 0, CAST(N'1991-07-12' AS Date), N'89 Đặng Khôi Q1', N'8352074', N'D:\baitapC++\PhatTrienUngDungWindow\ThucHanh\chuong6\anh\face.png')
INSERT [dbo].[NhanVien] ([MaNV], [Ho], [Ten], [Nu], [NgayNV], [DiaChi], [DienThoai], [Hinh]) VALUES (N'0003', N'Trần Tuyết', N'Oanh', 1, CAST(N'1991-02-27' AS Date), N'26 Lê Quí Đôn P6 Q3', N'8557798', NULL)
INSERT [dbo].[NhanVien] ([MaNV], [Ho], [Ten], [Nu], [NgayNV], [DiaChi], [DienThoai], [Hinh]) VALUES (N'0004', N'Nguyễn Kim', N'Ngọc', 1, CAST(N'1992-03-30' AS Date), N'178 Hậu Giang P6 Q6', N'8553278', NULL)
INSERT [dbo].[NhanVien] ([MaNV], [Ho], [Ten], [Nu], [NgayNV], [DiaChi], [DienThoai], [Hinh]) VALUES (N'0005', N'Trương Duy ', N'Hùng', 0, CAST(N'1992-09-13' AS Date), N'77 Trương Định P6 Q3', N'8940295', NULL)
INSERT [dbo].[NhanVien] ([MaNV], [Ho], [Ten], [Nu], [NgayNV], [DiaChi], [DienThoai], [Hinh]) VALUES (N'0006', N'Lương Bá ', N'Thắng', 0, CAST(N'1992-09-13' AS Date), N'92 Lê Thánh Tôn Q1', N'8940549', NULL)
INSERT [dbo].[NhanVien] ([MaNV], [Ho], [Ten], [Nu], [NgayNV], [DiaChi], [DienThoai], [Hinh]) VALUES (N'0007', N'Trần thị', N'Lan', 1, CAST(N'2000-10-20' AS Date), N'15 Nguyễn Trãi Q5', N'85656634', NULL)
INSERT [dbo].[NhanVien] ([MaNV], [Ho], [Ten], [Nu], [NgayNV], [DiaChi], [DienThoai], [Hinh]) VALUES (N'0008', N'Tạ thành', N'Tâm', 0, CAST(N'2005-10-12' AS Date), N'20 Võ thị Sáu Q3', N'85656666', NULL)
INSERT [dbo].[NhanVien] ([MaNV], [Ho], [Ten], [Nu], [NgayNV], [DiaChi], [DienThoai], [Hinh]) VALUES (N'0009', N'Ngô Thanh', N'Sơn', 0, CAST(N'2010-12-20' AS Date), N'122 Trần Phú Q5', N'85654166', NULL)
INSERT [dbo].[NhanVien] ([MaNV], [Ho], [Ten], [Nu], [NgayNV], [DiaChi], [DienThoai], [Hinh]) VALUES (N'0010', N'Lê thị', N'Thủy Chi', 1, CAST(N'2010-10-10' AS Date), N'25 Ngô Quyền Q10', N'97654123', NULL)
INSERT [dbo].[NhanVien] ([MaNV], [Ho], [Ten], [Nu], [NgayNV], [DiaChi], [DienThoai], [Hinh]) VALUES (N'0011', N'Lê thị', N'Nhật Anh', 0, CAST(N'2010-10-10' AS Date), N'77 Trương Định P6 Q5', N'85656666', N'D:\baitapC++\PhatTrienUngDungWindow\ThucHanh\chuong6\anh\face.png')
INSERT [dbo].[NhanVien] ([MaNV], [Ho], [Ten], [Nu], [NgayNV], [DiaChi], [DienThoai], [Hinh]) VALUES (N'0012', N'Lâm', N'Tâm Anh', 0, CAST(N'2000-12-08' AS Date), N'3/2, P.Xuân Khánh, Q. Ninh Kiều, TP. Cần Thơ', N'85654166', N'D:\baitapC++\PhatTrienUngDungWindow\ThucHanh\chuong6\anh\face.png')
INSERT [dbo].[NhanVien] ([MaNV], [Ho], [Ten], [Nu], [NgayNV], [DiaChi], [DienThoai], [Hinh]) VALUES (N'0013', N'Lâm', N'Tâm Như', 0, CAST(N'2000-02-15' AS Date), N'26, Đinh Tiên Hoàng', N'85654166', NULL)
INSERT [dbo].[NhanVien] ([MaNV], [Ho], [Ten], [Nu], [NgayNV], [DiaChi], [DienThoai], [Hinh]) VALUES (N'0014', N'Mỹ', N'Chi', 0, CAST(N'2021-12-08' AS Date), N'3/2, xuân khánh, ninh kiều, cần thơ', N'97654123', N'D:\baitapC++\PhatTrienUngDungWindow\ThucHanh\chuong6\anh\face.png')
GO
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [DonGia], [Hinh]) VALUES (N'0001', N'Bia 333', N'Thùng', 220000, NULL)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [DonGia], [Hinh]) VALUES (N'0002', N'Bia Tiger', N'Thùng', 310000, NULL)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [DonGia], [Hinh]) VALUES (N'0003', N'Bia Heineken', N'Thùng', 380000, NULL)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [DonGia], [Hinh]) VALUES (N'0004', N'Rượu Bình tây', N'Chai', 150000, NULL)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [DonGia], [Hinh]) VALUES (N'0005', N'Rượu Napoleon', N'Chai', 430500, NULL)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [DonGia], [Hinh]) VALUES (N'0006', N'Gia vị', N'Thùng', 400000, NULL)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [DonGia], [Hinh]) VALUES (N'0007', N'Bánh kem', N'Cái', 200000, NULL)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [DonGia], [Hinh]) VALUES (N'0008', N'Bơ', N'Kg', 280000, NULL)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [DonGia], [Hinh]) VALUES (N'0009', N'Bánh mì', N'Cái', 10000, NULL)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [DonGia], [Hinh]) VALUES (N'0010', N'Nem', N'Kg', 83790, NULL)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [DonGia], [Hinh]) VALUES (N'0011', N'Táo', N'Kg', 15000, NULL)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [DonGia], [Hinh]) VALUES (N'0012', N'Bánh Kinh Đô', N'Kg', 85000, N'D:\baitapC++\PhatTrienUngDungWindow\ThucHanh\chuong6\anh\bear.png')
GO
INSERT [dbo].[ThanhPho] ([ThanhPho], [TenThanhPho]) VALUES (N'01', N'Hà Nội')
INSERT [dbo].[ThanhPho] ([ThanhPho], [TenThanhPho]) VALUES (N'02', N'Hải Phòng')
INSERT [dbo].[ThanhPho] ([ThanhPho], [TenThanhPho]) VALUES (N'03', N'Huế')
INSERT [dbo].[ThanhPho] ([ThanhPho], [TenThanhPho]) VALUES (N'04', N'Nha Trang')
INSERT [dbo].[ThanhPho] ([ThanhPho], [TenThanhPho]) VALUES (N'05', N'TP HCM')
INSERT [dbo].[ThanhPho] ([ThanhPho], [TenThanhPho]) VALUES (N'06', N'Cần Thơ')
INSERT [dbo].[ThanhPho] ([ThanhPho], [TenThanhPho]) VALUES (N'07', N'Đà Nẵng')
INSERT [dbo].[ThanhPho] ([ThanhPho], [TenThanhPho]) VALUES (N'08', N'Vĩnh Long')
GO
ALTER TABLE [dbo].[HoaDon] ADD  CONSTRAINT [DF__HoaDon__NgayLapH__412EB0B6]  DEFAULT (getdate()) FOR [NgayLapHD]
GO
ALTER TABLE [dbo].[NhanVien] ADD  CONSTRAINT [DF__NhanVien__Nu__403A8C7D]  DEFAULT ((0)) FOR [Nu]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietHoa__MaHD__44FF419A] FOREIGN KEY([MaHD])
REFERENCES [dbo].[HoaDon] ([MaHD])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK__ChiTietHoa__MaHD__44FF419A]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietHoa__MaSP__45F365D3] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK__ChiTietHoa__MaSP__45F365D3]
GO
ALTER TABLE [dbo].[DangNhap]  WITH CHECK ADD  CONSTRAINT [FK_DangNhap_NhanVien1] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[DangNhap] CHECK CONSTRAINT [FK_DangNhap_NhanVien1]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK__HoaDon__MaKH__4316F928] FOREIGN KEY([MaKH])
REFERENCES [dbo].[Khachhang] ([MaKH])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK__HoaDon__MaKH__4316F928]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien]
GO
ALTER TABLE [dbo].[Khachhang]  WITH CHECK ADD FOREIGN KEY([ThanhPho])
REFERENCES [dbo].[ThanhPho] ([ThanhPho])
GO
/****** Object:  StoredProcedure [dbo].[SanPhamTheoNgay]    Script Date: 12/8/2021 3:51:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SanPhamTheoNgay](@TuNgay date, @DenNgay date)
as
begin
select sp.MaSP, sp.TenSP, sp.DonViTinh, sp.DonGia, count(*) SLHD, sum(ct.soluong) SLSP
from SanPham sp join ChiTietHoaDon ct on sp.MaSP=ct.MaSP join HoaDon hd on hd.MaHD=ct.MaHD
where hd.NgayLapHD between @TuNgay and @DenNgay
group by sp.MaSP, sp.TenSP, sp.DonViTinh, sp.DonGia
end;
GO
USE [master]
GO
ALTER DATABASE [QuanLyBanHang] SET  READ_WRITE 
GO
