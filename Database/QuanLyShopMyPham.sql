USE [master]
GO
/****** Object:  Database [QL_ShopMyPham]    Script Date: 7/15/2021 8:08:46 PM ******/
CREATE DATABASE [QL_ShopMyPham]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QL_ShopMyPham', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QL_ShopMyPham.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QL_ShopMyPham_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QL_ShopMyPham_log.ldf' , SIZE = 784KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QL_ShopMyPham] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QL_ShopMyPham].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QL_ShopMyPham] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QL_ShopMyPham] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QL_ShopMyPham] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QL_ShopMyPham] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QL_ShopMyPham] SET ARITHABORT OFF 
GO
ALTER DATABASE [QL_ShopMyPham] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QL_ShopMyPham] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QL_ShopMyPham] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QL_ShopMyPham] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QL_ShopMyPham] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QL_ShopMyPham] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QL_ShopMyPham] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QL_ShopMyPham] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QL_ShopMyPham] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QL_ShopMyPham] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QL_ShopMyPham] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QL_ShopMyPham] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QL_ShopMyPham] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QL_ShopMyPham] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QL_ShopMyPham] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QL_ShopMyPham] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QL_ShopMyPham] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QL_ShopMyPham] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QL_ShopMyPham] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QL_ShopMyPham] SET  MULTI_USER 
GO
ALTER DATABASE [QL_ShopMyPham] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QL_ShopMyPham] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QL_ShopMyPham] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QL_ShopMyPham] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QL_ShopMyPham]
GO
/****** Object:  UserDefinedFunction [dbo].[MAHD_TUDONGTANG]    Script Date: 7/15/2021 8:08:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[MAHD_TUDONGTANG](@MAHOADON CHAR(5),@TIENTO CHAR(2),@SIZE INT)
	RETURNS CHAR(5)
		AS
			BEGIN 
			IF(@MAHOADON = '')
				SET @MAHOADON = @TIENTO + REPLICATE(0,@SIZE - LEN(@TIENTO))
				DECLARE @NUM_MAHOADON1 INT , @MAHOADON1 CHAR(5)
				SET @MAHOADON = LTRIM(RTRIM(@MAHOADON))
				SET @NUM_MAHOADON1 = REPLACE(@MAHOADON,@TIENTO,'') + 1
				SET @SIZE = @SIZE - LEN(@TIENTO)	
				SET @MAHOADON1 = @TIENTO + REPLICATE(0,@SIZE - LEN(@TIENTO))
				SET @MAHOADON1 = @TIENTO + RIGHT(REPLICATE(0,@SIZE) + CONVERT(VARCHAR(MAX), @NUM_MAHOADON1),@SIZE)
				RETURN @MAHOADON1
			END
			

GO
/****** Object:  UserDefinedFunction [dbo].[MAKH_TUDONGTANG]    Script Date: 7/15/2021 8:08:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[MAKH_TUDONGTANG](@MAKHACHHANG CHAR(5),@TIENTO CHAR(2),@SIZE INT)
	RETURNS CHAR(5)
		AS
			BEGIN 
			IF(@MAKHACHHANG = '')
				SET @MAKHACHHANG = @TIENTO + REPLICATE(0,@SIZE - LEN(@TIENTO))
				DECLARE @NUM_MAKHACHHANG1 INT , @MAKHACHHANG1 CHAR(5)
				SET @MAKHACHHANG = LTRIM(RTRIM(@MAKHACHHANG))
				SET @NUM_MAKHACHHANG1 = REPLACE(@MAKHACHHANG,@TIENTO,'') + 1
				SET @SIZE = @SIZE - LEN(@TIENTO)	
				SET @MAKHACHHANG1 = @TIENTO + REPLICATE(0,@SIZE - LEN(@TIENTO))
				SET @MAKHACHHANG1 = @TIENTO + RIGHT(REPLICATE(0,@SIZE) + CONVERT(VARCHAR(MAX), @NUM_MAKHACHHANG1),@SIZE)
				RETURN @MAKHACHHANG1
			END
			

GO
/****** Object:  Table [dbo].[CT_HoaDon]    Script Date: 7/15/2021 8:08:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CT_HoaDon](
	[MaHoaDon] [char](5) NOT NULL,
	[MaSanPham] [char](5) NOT NULL,
	[SoLuongBan] [int] NULL,
	[DonGiaBan] [float] NULL,
	[ThanhTienBan] [float] NULL,
 CONSTRAINT [PK_CTHD] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC,
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CT_PhieuNhap]    Script Date: 7/15/2021 8:08:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CT_PhieuNhap](
	[MaPhieuNhap] [char](5) NOT NULL,
	[MaSanPham] [char](5) NOT NULL,
	[SoLuongNhap] [int] NULL,
	[DonGiaNhap] [float] NULL,
	[ThanhTienNhap] [float] NULL,
 CONSTRAINT [PK_CTPN] PRIMARY KEY CLUSTERED 
(
	[MaPhieuNhap] ASC,
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 7/15/2021 8:08:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHoaDon] [char](5) NOT NULL,
	[MaNhanVien] [char](5) NULL,
	[MaKhachHang] [char](5) NULL,
	[NgayLap] [datetime] NULL,
	[TongTien] [float] NULL,
	[GhiChu] [nvarchar](max) NULL,
 CONSTRAINT [PK_HD] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 7/15/2021 8:08:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [char](5) NOT NULL,
	[TenKhachHang] [nvarchar](max) NULL,
	[NgaySinh] [date] NULL,
	[SoDienThoai] [varchar](11) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[Email] [varchar](max) NULL,
	[MatKhau] [varchar](max) NULL,
 CONSTRAINT [PK_KH] PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LoaiHang]    Script Date: 7/15/2021 8:08:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LoaiHang](
	[MaLoai] [char](5) NOT NULL,
	[TenLoai] [nvarchar](max) NULL,
 CONSTRAINT [PK_LH] PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LoaiNhanVien]    Script Date: 7/15/2021 8:08:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LoaiNhanVien](
	[MaLoaiNhanVien] [char](5) NOT NULL,
	[TenLoaiNhanVien] [nvarchar](max) NULL,
 CONSTRAINT [PK_LOAINV] PRIMARY KEY CLUSTERED 
(
	[MaLoaiNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ManHinh]    Script Date: 7/15/2021 8:08:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ManHinh](
	[MaManHinh] [char](5) NOT NULL,
	[TenManHinh] [nvarchar](max) NULL,
 CONSTRAINT [PK_MHINH] PRIMARY KEY CLUSTERED 
(
	[MaManHinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 7/15/2021 8:08:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNhaCungCap] [char](5) NOT NULL,
	[TenNhaCungCap] [nvarchar](max) NULL,
	[SDT] [varchar](11) NULL,
	[DiaChi] [nvarchar](max) NULL,
 CONSTRAINT [PK_NCC] PRIMARY KEY CLUSTERED 
(
	[MaNhaCungCap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 7/15/2021 8:08:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [char](5) NOT NULL,
	[TenNhanVien] [nvarchar](max) NULL,
	[MaLoaiNhanVien] [char](5) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [nvarchar](4) NULL,
	[SoDienThoai] [varchar](11) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[ChungMinhThu] [varchar](15) NULL,
	[HinhAnh] [varchar](max) NULL,
	[MatKhau] [varchar](20) NULL,
 CONSTRAINT [PK_NV] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhanQuyen]    Script Date: 7/15/2021 8:08:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhanQuyen](
	[MaLoaiNhanVien] [char](5) NOT NULL,
	[MaManHinh] [char](5) NOT NULL,
	[CoQuyen] [bit] NULL,
 CONSTRAINT [PK_PQ] PRIMARY KEY CLUSTERED 
(
	[MaLoaiNhanVien] ASC,
	[MaManHinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 7/15/2021 8:08:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[MaPhieuNhap] [char](5) NOT NULL,
	[MaNhanVien] [char](5) NULL,
	[MaNhaCungCap] [char](5) NULL,
	[NgayNhap] [datetime] NULL,
	[TongTien] [float] NULL,
	[GhiCHu] [nvarchar](max) NULL,
 CONSTRAINT [PK_PN] PRIMARY KEY CLUSTERED 
(
	[MaPhieuNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 7/15/2021 8:08:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSanPham] [char](5) NOT NULL,
	[TenSanPham] [nvarchar](max) NULL,
	[GiaBan] [float] NULL,
	[GiaNhap] [float] NULL,
	[GiamGia] [float] NULL,
	[MoTa] [nvarchar](max) NULL,
	[MaLoai] [char](5) NULL,
	[MaThuongHieu] [char](5) NULL,
	[DonViTinh] [nvarchar](10) NULL,
	[SoLuongTon] [int] NULL,
	[HinhAnh] [varchar](max) NULL,
	[HinhAnhChiTiet] [varchar](max) NULL,
 CONSTRAINT [PK_MH] PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ThuongHieu]    Script Date: 7/15/2021 8:08:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ThuongHieu](
	[MaThuongHieu] [char](5) NOT NULL,
	[TenThuongHieu] [nvarchar](max) NULL,
 CONSTRAINT [PK_TH] PRIMARY KEY CLUSTERED 
(
	[MaThuongHieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[CT_HoaDon] ([MaHoaDon], [MaSanPham], [SoLuongBan], [DonGiaBan], [ThanhTienBan]) VALUES (N'HD001', N'MH001', 1, 119000, 119000)
INSERT [dbo].[CT_HoaDon] ([MaHoaDon], [MaSanPham], [SoLuongBan], [DonGiaBan], [ThanhTienBan]) VALUES (N'HD002', N'MH001', 1, 119000, 119000)
INSERT [dbo].[CT_HoaDon] ([MaHoaDon], [MaSanPham], [SoLuongBan], [DonGiaBan], [ThanhTienBan]) VALUES (N'HD003', N'MH001', 1, 119000, 119000)
INSERT [dbo].[CT_HoaDon] ([MaHoaDon], [MaSanPham], [SoLuongBan], [DonGiaBan], [ThanhTienBan]) VALUES (N'HD004', N'MH001', 1, 119000, 119000)
INSERT [dbo].[CT_HoaDon] ([MaHoaDon], [MaSanPham], [SoLuongBan], [DonGiaBan], [ThanhTienBan]) VALUES (N'HD005', N'MH002', 2, 400000, 800000)
INSERT [dbo].[CT_HoaDon] ([MaHoaDon], [MaSanPham], [SoLuongBan], [DonGiaBan], [ThanhTienBan]) VALUES (N'HD007', N'MH002', 1, 400000, 400000)
INSERT [dbo].[CT_HoaDon] ([MaHoaDon], [MaSanPham], [SoLuongBan], [DonGiaBan], [ThanhTienBan]) VALUES (N'HD007', N'MH003', 1, 220000, 220000)
INSERT [dbo].[CT_HoaDon] ([MaHoaDon], [MaSanPham], [SoLuongBan], [DonGiaBan], [ThanhTienBan]) VALUES (N'HD008', N'MH003', 1, 199000, 199000)
INSERT [dbo].[CT_HoaDon] ([MaHoaDon], [MaSanPham], [SoLuongBan], [DonGiaBan], [ThanhTienBan]) VALUES (N'HD008', N'MH004', 1, 189000, 189000)
INSERT [dbo].[CT_HoaDon] ([MaHoaDon], [MaSanPham], [SoLuongBan], [DonGiaBan], [ThanhTienBan]) VALUES (N'HD009', N'MH002', 1, 290000, 290000)
INSERT [dbo].[CT_HoaDon] ([MaHoaDon], [MaSanPham], [SoLuongBan], [DonGiaBan], [ThanhTienBan]) VALUES (N'HD009', N'MH003', 1, 199000, 199000)
INSERT [dbo].[CT_HoaDon] ([MaHoaDon], [MaSanPham], [SoLuongBan], [DonGiaBan], [ThanhTienBan]) VALUES (N'HD010', N'MH001', 1, 119000, 119000)
INSERT [dbo].[CT_HoaDon] ([MaHoaDon], [MaSanPham], [SoLuongBan], [DonGiaBan], [ThanhTienBan]) VALUES (N'HD010', N'MH002', 1, 290000, 290000)
INSERT [dbo].[CT_HoaDon] ([MaHoaDon], [MaSanPham], [SoLuongBan], [DonGiaBan], [ThanhTienBan]) VALUES (N'HD010', N'MH005', 1, 139000, 139000)
INSERT [dbo].[CT_HoaDon] ([MaHoaDon], [MaSanPham], [SoLuongBan], [DonGiaBan], [ThanhTienBan]) VALUES (N'HD011', N'MH005', 2, 139000, 278000)
INSERT [dbo].[CT_HoaDon] ([MaHoaDon], [MaSanPham], [SoLuongBan], [DonGiaBan], [ThanhTienBan]) VALUES (N'HD012', N'MH001', 4, 119000, 476000)
INSERT [dbo].[CT_HoaDon] ([MaHoaDon], [MaSanPham], [SoLuongBan], [DonGiaBan], [ThanhTienBan]) VALUES (N'HD013', N'MH006', 2, 139000, 278000)
INSERT [dbo].[CT_HoaDon] ([MaHoaDon], [MaSanPham], [SoLuongBan], [DonGiaBan], [ThanhTienBan]) VALUES (N'HD014', N'MH002', 6, 290000, 1740000)
INSERT [dbo].[CT_HoaDon] ([MaHoaDon], [MaSanPham], [SoLuongBan], [DonGiaBan], [ThanhTienBan]) VALUES (N'HD014', N'MH003', 1, 199000, 199000)
INSERT [dbo].[CT_HoaDon] ([MaHoaDon], [MaSanPham], [SoLuongBan], [DonGiaBan], [ThanhTienBan]) VALUES (N'HD015', N'MH001', 1, 119000, 119000)
INSERT [dbo].[CT_PhieuNhap] ([MaPhieuNhap], [MaSanPham], [SoLuongNhap], [DonGiaNhap], [ThanhTienNhap]) VALUES (N'PN001', N'MH001', 1, 200000, 200000)
INSERT [dbo].[CT_PhieuNhap] ([MaPhieuNhap], [MaSanPham], [SoLuongNhap], [DonGiaNhap], [ThanhTienNhap]) VALUES (N'PN002', N'MH001', 2, 200000, 400000)
INSERT [dbo].[CT_PhieuNhap] ([MaPhieuNhap], [MaSanPham], [SoLuongNhap], [DonGiaNhap], [ThanhTienNhap]) VALUES (N'PN002', N'MH002', 2, 150000, 300000)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [NgayLap], [TongTien], [GhiChu]) VALUES (N'HD001', N'NV001', N'KH001', CAST(N'2021-07-11 19:40:58.560' AS DateTime), 119000, N'')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [NgayLap], [TongTien], [GhiChu]) VALUES (N'HD002', N'NV001', N'KH001', CAST(N'2021-07-11 19:43:07.247' AS DateTime), 119000, N'')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [NgayLap], [TongTien], [GhiChu]) VALUES (N'HD003', N'NV001', N'KH001', CAST(N'2021-07-11 19:52:24.097' AS DateTime), 119000, N'')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [NgayLap], [TongTien], [GhiChu]) VALUES (N'HD004', N'NV001', N'KH001', CAST(N'2021-07-11 19:53:57.417' AS DateTime), 119000, N'')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [NgayLap], [TongTien], [GhiChu]) VALUES (N'HD005', N'NV001', N'KH003', CAST(N'2021-07-12 18:18:12.257' AS DateTime), 0, N'')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [NgayLap], [TongTien], [GhiChu]) VALUES (N'HD006', N'NV001', N'KH003', CAST(N'2021-07-12 18:34:23.713' AS DateTime), 0, N'')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [NgayLap], [TongTien], [GhiChu]) VALUES (N'HD007', N'NV001', N'KH003', CAST(N'2021-07-12 18:44:27.463' AS DateTime), 0, N'')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [NgayLap], [TongTien], [GhiChu]) VALUES (N'HD008', N'NV001', N'KH003', CAST(N'2021-07-12 19:24:15.483' AS DateTime), 388000, N'')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [NgayLap], [TongTien], [GhiChu]) VALUES (N'HD009', N'NV001', N'KH003', CAST(N'2021-07-12 19:30:05.743' AS DateTime), 489000, N'')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [NgayLap], [TongTien], [GhiChu]) VALUES (N'HD010', N'NV001', N'KH001', CAST(N'2021-07-13 08:28:26.840' AS DateTime), 548000, N'')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [NgayLap], [TongTien], [GhiChu]) VALUES (N'HD011', N'NV001', N'KH004', CAST(N'2021-07-13 14:06:09.387' AS DateTime), 278000, N'')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [NgayLap], [TongTien], [GhiChu]) VALUES (N'HD012', N'NV001', N'KH001', CAST(N'2021-07-13 14:11:09.603' AS DateTime), 476000, N'')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [NgayLap], [TongTien], [GhiChu]) VALUES (N'HD013', N'NV001', N'KH005', CAST(N'2021-07-13 19:00:28.220' AS DateTime), 278000, N'')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [NgayLap], [TongTien], [GhiChu]) VALUES (N'HD014', N'NV001', N'KH005', CAST(N'2021-07-13 19:05:38.000' AS DateTime), 1939000, N'')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [NgayLap], [TongTien], [GhiChu]) VALUES (N'HD015', N'NV001', N'KH005', CAST(N'2021-07-15 20:06:18.587' AS DateTime), 0, N'')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [NgaySinh], [SoDienThoai], [DiaChi], [Email], [MatKhau]) VALUES (N'KH001', N'Nguyễn Thị Thùy Dương', CAST(N'1999-01-24' AS Date), N'0582442079', N'Mỹ Tho - Tiền Giang', N'thuyduong99@gmail.com', N'123456')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [NgaySinh], [SoDienThoai], [DiaChi], [Email], [MatKhau]) VALUES (N'KH002', N'Nguyễn Tuấn Vũ', CAST(N'2000-05-19' AS Date), N'0943918204', N'115/46 Lê Trọng Tấn, Tân Phú, TP HCM', N'tuanvu2k@gmail.com', N'abc')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [NgaySinh], [SoDienThoai], [DiaChi], [Email], [MatKhau]) VALUES (N'KH003', N'Nguyễn Chí Hùng', CAST(N'2021-07-15' AS Date), N'012345678', N'Tây Ninh', N'hung@gmail.com', N'123')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [NgaySinh], [SoDienThoai], [DiaChi], [Email], [MatKhau]) VALUES (N'KH004', N'Nguyễn Chí Hùng', CAST(N'2011-02-02' AS Date), N'1234567890', N'Tây Ninh', N'hung1@gmail.com', N'123456')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [NgaySinh], [SoDienThoai], [DiaChi], [Email], [MatKhau]) VALUES (N'KH005', N'Nguyễn Đình Mạnh', CAST(N'2004-10-19' AS Date), N'0772586579', N'Đăk Nông', N'dinhmanh@gmail.com', N'123456')
INSERT [dbo].[LoaiHang] ([MaLoai], [TenLoai]) VALUES (N'ML001', N'Son môi')
INSERT [dbo].[LoaiHang] ([MaLoai], [TenLoai]) VALUES (N'ML002', N'Phấn mắt')
INSERT [dbo].[LoaiHang] ([MaLoai], [TenLoai]) VALUES (N'ML003', N'Chì kẻ mắt')
INSERT [dbo].[LoaiHang] ([MaLoai], [TenLoai]) VALUES (N'ML005', N'Kem dưỡng')
INSERT [dbo].[LoaiHang] ([MaLoai], [TenLoai]) VALUES (N'ML006', N'Sữa rửa mặt')
INSERT [dbo].[LoaiHang] ([MaLoai], [TenLoai]) VALUES (N'ML007', N'Serum')
INSERT [dbo].[LoaiHang] ([MaLoai], [TenLoai]) VALUES (N'ML008', N'Nước hoa nam')
INSERT [dbo].[LoaiHang] ([MaLoai], [TenLoai]) VALUES (N'ML009', N'Nước hoa nữ')
INSERT [dbo].[LoaiNhanVien] ([MaLoaiNhanVien], [TenLoaiNhanVien]) VALUES (N'LNV01', N'Nhân viên kho')
INSERT [dbo].[LoaiNhanVien] ([MaLoaiNhanVien], [TenLoaiNhanVien]) VALUES (N'LNV02', N'Nhân viên bán hàng')
INSERT [dbo].[LoaiNhanVien] ([MaLoaiNhanVien], [TenLoaiNhanVien]) VALUES (N'LNV03', N'Quản lý')
INSERT [dbo].[ManHinh] ([MaManHinh], [TenManHinh]) VALUES (N'SF001', N'Nhóm Người Dùng')
INSERT [dbo].[ManHinh] ([MaManHinh], [TenManHinh]) VALUES (N'SF002', N'Màn Hình')
INSERT [dbo].[ManHinh] ([MaManHinh], [TenManHinh]) VALUES (N'SF003', N'Phân Quyền')
INSERT [dbo].[ManHinh] ([MaManHinh], [TenManHinh]) VALUES (N'SF004', N'Đổi Mật Khẩu')
INSERT [dbo].[ManHinh] ([MaManHinh], [TenManHinh]) VALUES (N'SF005', N'Bán Hàng')
INSERT [dbo].[ManHinh] ([MaManHinh], [TenManHinh]) VALUES (N'SF006', N'Nhập Hàng')
INSERT [dbo].[ManHinh] ([MaManHinh], [TenManHinh]) VALUES (N'SF007', N'Quản Lý Sản Phẩm')
INSERT [dbo].[ManHinh] ([MaManHinh], [TenManHinh]) VALUES (N'SF008', N'Quản Lý Nhân Viên')
INSERT [dbo].[ManHinh] ([MaManHinh], [TenManHinh]) VALUES (N'SF009', N'Quản Lý Khách Hàng')
INSERT [dbo].[ManHinh] ([MaManHinh], [TenManHinh]) VALUES (N'SF010', N'Quản Lý Nhà Cung Cấp')
INSERT [dbo].[ManHinh] ([MaManHinh], [TenManHinh]) VALUES (N'SF011', N'Quản Lý Loại Sản Phẩm')
INSERT [dbo].[ManHinh] ([MaManHinh], [TenManHinh]) VALUES (N'SF012', N'Quản Lý Thương Hiệu')
INSERT [dbo].[ManHinh] ([MaManHinh], [TenManHinh]) VALUES (N'SF013', N'Doanh Thu')
INSERT [dbo].[ManHinh] ([MaManHinh], [TenManHinh]) VALUES (N'SF014', N'Chi Tiết Hóa Đơn')
INSERT [dbo].[ManHinh] ([MaManHinh], [TenManHinh]) VALUES (N'SF015', N'Chi Tiết Phiếu Nhập')
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [SDT], [DiaChi]) VALUES (N'NCC01', N'Công Ty TNHH TM DV Mỹ Phẩm Bắc Trang', N'0946698350', N'20 Trần Cao Vân, P. Đa Kao, Q. 1,Tp. Hồ Chí Minh (TPHCM)')
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [SDT], [DiaChi]) VALUES (N'NCC02', N'Rubi.vn - Công Ty TNHH Rubi Việt Nam', N'0913851853', N'42 Đường số 4, P. 11, Q. Gò Vấp,Tp. Hồ Chí Minh (TPHCM)')
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [SDT], [DiaChi]) VALUES (N'NCC03', N'Công Ty TNHH Mỹ Phẩm EV Princess', N'02838355005', N'35 Đường 3/2, P. 11, Q. 10,Tp. Hồ Chí Minh (TPHCM)')
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [SDT], [DiaChi]) VALUES (N'NCC04', N'Công Ty TNHH Thương Mại A & P.L.U.S', N'0902667038', N'Phòng WT1-3.OT01, Tầng 4, Tháp 1, Cao ốc Wilton Tower 71/3 Nguyễn Văn Thương, F.25, Q. Bình Thạnh,Tp. Hồ Chí Minh (TPHCM)')
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [SDT], [DiaChi]) VALUES (N'NCC05', N'Công Ty TNHH MTV Camiko', N'0934145544', N'Số 47 Đường số 1, P. Tân Thành, Q. Tân Phú,Tp. Hồ Chí Minh (TPHCM)')
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [SDT], [DiaChi]) VALUES (N'NCC06', N'Công Ty TNHH Thương Mại Và Đầu Tư V.B.C.L', N'02473080808', N'Tầng 10, Tòa nhà MD Complex Tower, Khu đô thị Mỹ Đình I, P. Cầu Diễn, Q. Nam Từ Liêm,Hà Nội')
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [SDT], [DiaChi]) VALUES (N'NCC07', N'Chi Nhánh Tp. Hồ Chí Minh - Công Ty CP Thương Mại Và Xuất Nhập Khẩu Aladin', N'02839208568', N'63B Trần Đình Xu, P. Cầu Kho, Q. 1,Tp. Hồ Chí Minh (TPHCM)')
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [SDT], [DiaChi]) VALUES (N'NCC08', N'Mỹ Phẩm Của Tui', N'0762311118', N'Số 447, Minh Phụng, P. 10, Q. 11,Tp. Hồ Chí Minh (TPHCM)')
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [SDT], [DiaChi]) VALUES (N'NCC09', N'Công Ty TNHH TM & XNK Beautyful Girl', N'0965616170', N'Số 62, Đường 2, KP. Bình Dương 2, An Bình, Dĩ An,Bình Dương')
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [SDT], [DiaChi]) VALUES (N'NCC10', N'Công Ty TNHH TM Quốc Tế Trường Phát', N'02873096369', N'Số 78 /12 Cộng Hòa, P. 4, Q. Tân Bình,Tp. Hồ Chí Minh (TPHCM)')
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [SDT], [DiaChi]) VALUES (N'NCC11', N'Công Ty TNHH MTV KIMHANA', N'02822203789', N'Số 101, Đường Thảo Điền, P. Thảo Điền, Q. 2,Tp. Hồ Chí Minh (TPHCM)')
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [SDT], [DiaChi]) VALUES (N'NCC12', N'COCO SHOP - Công Ty TNHH TM Và Đầu Tư XNK Việt Nam', N'0988888290', N'Số 80 Chùa Bộc, P. Trung Liệt, Q. Đống Đa,Hà Nội')
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [SDT], [DiaChi]) VALUES (N'NCC13', N'Công Ty TNHH Long Nam', N'0799886668', N'18A BT3 Bán đảo Linh Đàm, Khu Đô Thị Mới Bắc Linh Đàm, P. Hoàng Liệt, Q. Hoàng Mai,Hà Nội')
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [SDT], [DiaChi]) VALUES (N'NCC15', N'Cửa Hàng Mỹ Phẩm Nhật Bản Sakura', N'0707900900', N'15/3/22 Đường Số 20, Bình Hưng Hòa A, Bình Tân,Tp. Hồ Chí Minh (TPHCM)')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [MaLoaiNhanVien], [NgaySinh], [GioiTinh], [SoDienThoai], [DiaChi], [ChungMinhThu], [HinhAnh], [MatKhau]) VALUES (N'NV001', N'Nguyễn Trọng Hiếu', N'LNV03', CAST(N'2000-04-16' AS Date), N'Nam', N'0369910547', N'Đăk Nông', N'245387159', N'nv1.jpg', N'1234567')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [MaLoaiNhanVien], [NgaySinh], [GioiTinh], [SoDienThoai], [DiaChi], [ChungMinhThu], [HinhAnh], [MatKhau]) VALUES (N'NV002', N'Huỳnh Hữu Thắng', N'LNV02', CAST(N'2000-10-03' AS Date), N'Nam', N'0943918205', N'Đồng Tháp', N'326514587', N'nv2.jpg', N'123456')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [MaLoaiNhanVien], [NgaySinh], [GioiTinh], [SoDienThoai], [DiaChi], [ChungMinhThu], [HinhAnh], [MatKhau]) VALUES (N'NV003', N'Trần Mỹ Dung', N'LNV01', CAST(N'1987-10-14' AS Date), N'Nữ', N'0912348231', N'Hà Nội', N'096165678', N'nv3.jpg', N'123456')
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV01', N'SF001', 0)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV01', N'SF002', 0)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV01', N'SF003', 0)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV01', N'SF004', 1)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV01', N'SF005', 0)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV01', N'SF006', 1)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV01', N'SF007', 1)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV01', N'SF008', 0)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV01', N'SF009', 0)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV01', N'SF010', 1)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV01', N'SF011', 1)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV01', N'SF012', 1)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV01', N'SF013', 0)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV01', N'SF014', 0)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV01', N'SF015', 1)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV02', N'SF001', 0)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV02', N'SF002', 0)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV02', N'SF003', 0)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV02', N'SF004', 1)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV02', N'SF005', 1)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV02', N'SF006', 0)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV02', N'SF007', 1)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV02', N'SF008', 0)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV02', N'SF009', 1)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV02', N'SF010', 0)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV02', N'SF011', 1)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV02', N'SF012', 1)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV02', N'SF013', 1)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV02', N'SF014', 1)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV02', N'SF015', 0)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV03', N'SF001', 1)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV03', N'SF002', 1)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV03', N'SF003', 1)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV03', N'SF004', 1)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV03', N'SF005', 1)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV03', N'SF006', 1)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV03', N'SF007', 1)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV03', N'SF008', 1)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV03', N'SF009', 1)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV03', N'SF010', 1)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV03', N'SF011', 1)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV03', N'SF012', 1)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV03', N'SF013', 1)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV03', N'SF014', 1)
INSERT [dbo].[PhanQuyen] ([MaLoaiNhanVien], [MaManHinh], [CoQuyen]) VALUES (N'LNV03', N'SF015', 1)
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNhanVien], [MaNhaCungCap], [NgayNhap], [TongTien], [GhiCHu]) VALUES (N'PN001', N'NV001', N'NCC01', CAST(N'2021-07-11 19:44:17.050' AS DateTime), 200000, N'')
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNhanVien], [MaNhaCungCap], [NgayNhap], [TongTien], [GhiCHu]) VALUES (N'PN002', N'NV001', N'NCC01', CAST(N'2021-07-13 08:29:17.400' AS DateTime), 700000, N'')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [GiaBan], [GiaNhap], [GiamGia], [MoTa], [MaLoai], [MaThuongHieu], [DonViTinh], [SoLuongTon], [HinhAnh], [HinhAnhChiTiet]) VALUES (N'MH001', N'Son Thỏi Lì Chất Siêu Mịn, Thiết Kế Siêu Xịn G9Skin First V-Fit Lipstick', 250000, 200000, 119000, N'Son thỏi lì với thiết kế vẻ ngoài sang trọng cùng bảng màu quyến rũ, rạng rỡ lôi cuốn cho bạn vẻ đẹp tinh tế, thời thượng thu hút mọi ánh nhìn ', N'ML001', N'TH003', N'Thỏi', 6, N'song91.jpg', N'song92.jpg')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [GiaBan], [GiaNhap], [GiamGia], [MoTa], [MaLoai], [MaThuongHieu], [DonViTinh], [SoLuongTon], [HinhAnh], [HinhAnhChiTiet]) VALUES (N'MH002', N'Bảng Phấn Mắt 4 Màu Black Rouge Crystal Heart Lock Shadow', 400000, 150000, 290000, N'Kết cấu chất phấn mềm và mịn giúp phấn không bị vón cục hay bay nhanh, duy trì lớp trang điểm trong nhiều giờ.', N'ML002', N'TH002', N'Cái', 16, N'matbr1.jpg', N'matbr2.jpg')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [GiaBan], [GiaNhap], [GiamGia], [MoTa], [MaLoai], [MaThuongHieu], [DonViTinh], [SoLuongTon], [HinhAnh], [HinhAnhChiTiet]) VALUES (N'MH003', N'Sữa Rửa Mặt Dạng Gel Chiết Xuất Lá Hoa Anh Đào Innisfree Jeju Cherry Blossom Jam Cleanser 150g', 220000, 145000, 199000, N'Sữa Rửa Mặt Dạng Gel Chiết Xuất Lá Hoa Anh Đào Innisfree Jeju Cherry Blossom Jam Cleanser có tính axit yếu, phù hợp với mọi loại da. Với thành chính chiết xuất từ Lá hoa anh đào Hoàng Gia tại đảo Jeju. ', N'ML006', N'TH002', N'Lọ', 11, N'sakura1.jpg', N'sakura2.jpg')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [GiaBan], [GiaNhap], [GiamGia], [MoTa], [MaLoai], [MaThuongHieu], [DonViTinh], [SoLuongTon], [HinhAnh], [HinhAnhChiTiet]) VALUES (N'MH004', N'Kem Dưỡng Trắng, Nâng Tông Tức Thì Black Rouge Pink Tone Up Cream 45ml', 360000, 170000, 189000, N'Có chức năng như 1 sản phẩm makeup giúp nâng tông da trắng hồng một cách tự nhiên.', N'ML005', N'TH004', N'Tuýp', 11, N'nangtonebr1.jpg', N'nangtonebr2.jpg')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [GiaBan], [GiaNhap], [GiamGia], [MoTa], [MaLoai], [MaThuongHieu], [DonViTinh], [SoLuongTon], [HinhAnh], [HinhAnhChiTiet]) VALUES (N'MH005', N'Son Kem Lì, Mịn Mượt Môi Black Rouge Air Fit Velvet Tint Version 7', 299000, 100000, 139000, N'Bộ sưu tập Velvert Crown nằm trong version 7 của phiên bản Air Fit Velvet Tint quen thuộc, mang sức hút mạnh mẽ từ vẻ đẹp của nữ hoàng, sự lôi cuốn đến từ vẻ tinh tế, thu hút tựa như đang bước chân vào vương quốc mộng mơ, quyến rũ', N'ML001', N'TH004', N'Thỏi', 10, N'sonbr5.jpg', N'sonbr6.jpg')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [GiaBan], [GiaNhap], [GiamGia], [MoTa], [MaLoai], [MaThuongHieu], [DonViTinh], [SoLuongTon], [HinhAnh], [HinhAnhChiTiet]) VALUES (N'MH006', N'Son Kem Lì Siêu Nhẹ Môi, Lên Màu Chuẩn Black Rouge Cotton Lip Color', 299000, 100000, 139000, N'Black Rouge Cotton Lip Color là dòng son với chất son mềm mại hoàn hảo đúng như tên gọi của nó, với thiết kế vỏ ngoài mang tông đỏ quyến rũ cùng chất son mịn mượt như nhung và bảng màu đa dạng, mang nét trẻ trung thời thượng, cuốn hút mọi ánh nhìn ', N'ML001', N'TH004', N'Thỏi', 11, N'sonbr1.jpg', N'sonbr2.jpg')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [GiaBan], [GiaNhap], [GiamGia], [MoTa], [MaLoai], [MaThuongHieu], [DonViTinh], [SoLuongTon], [HinhAnh], [HinhAnhChiTiet]) VALUES (N'MH007', N'[Phiên Bản Flower Color] Son Kem Lì, Mịn Môi Black Rouge Cream Matt Rouge Version', 299000, 100000, 129000, N'Dòng son kem lì Black Rouge Cream Matt Rouge trở lại với một phiên bản đặc biệt version 3 trong mùa hè này, với những gam màu mới mẻ được lấy cảm hứng từ những cánh hoa nở rộ trong ngày nắng đẹp, những tông màu tươi mới cùng thiết kế xinh xắn mang đến cho bạn một gương mặt khả ái xinh xắn với nụ cười tươi rạng rỡ trên môi  ', N'ML001', N'TH004', N'Thỏi', 11, N'sonbr3.jpg', N'sonbr4.jpg')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [GiaBan], [GiaNhap], [GiamGia], [MoTa], [MaLoai], [MaThuongHieu], [DonViTinh], [SoLuongTon], [HinhAnh], [HinhAnhChiTiet]) VALUES (N'MH008', N'Bảng phấn mắt 4 ô Merzy The Heritage Shadow Palette', 400000, 150000, 290000, N'Kết cấu chất phấn mềm và mịn giúp phấn không bị vón cục hay bay nhanh, duy trì lớp trang điểm trong nhiều giờ.', N'ML002', N'TH005', N'Cái', 20, N'phanmerzy1.jpg', N'phanmerzy2.jpg')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [GiaBan], [GiaNhap], [GiamGia], [MoTa], [MaLoai], [MaThuongHieu], [DonViTinh], [SoLuongTon], [HinhAnh], [HinhAnhChiTiet]) VALUES (N'MH009', N'Phấn Mắt Đơn Bám Màu Tốt Merzy The First Eye Shadow ', 400000, 150000, 290000, N'Kết cấu chất phấn mềm và mịn giúp phấn không bị vón cục hay bay nhanh, duy trì lớp trang điểm trong nhiều giờ.', N'ML002', N'TH005', N'Cái', 20, N'phanmerzy3.jpg', N'phanmerzy4.jpg')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [GiaBan], [GiaNhap], [GiamGia], [MoTa], [MaLoai], [MaThuongHieu], [DonViTinh], [SoLuongTon], [HinhAnh], [HinhAnhChiTiet]) VALUES (N'MH010', N'[The Heritage Colection] Bút Kẻ Mắt Nước Chống Trôi Hiệu Quả Cho Đôi Mắt Sắc Nét Merzy The Heritage Pen Eyeliner ', 209000, 100000, 119000, N'Bút kẻ mắt nước Merzy The Heritage Pen Eyeliner dễ dàng hoàn thiện đường kẻ mắt chỉ với một lần kẻ cùng khả năng chống thấm nước mạnh mẽ cho đôi mắt thêm phần sắc nét huyền bí và cuốn hút', N'ML003', N'TH005', N'Cái', 20, N'kemat1.jpg', N'kemat2.jpg')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [GiaBan], [GiaNhap], [GiamGia], [MoTa], [MaLoai], [MaThuongHieu], [DonViTinh], [SoLuongTon], [HinhAnh], [HinhAnhChiTiet]) VALUES (N'MH011', N'Kẻ Mắt Dạ Chống Trôi Nét Siêu Mảnh Innisfree Powerproof Brush Liner ', 209000, 100000, 109000, N'Bút kẻ mắt nước Innisfree Powerproof Brush Liner là bút kẻ mắt nước sắc nét có chức năng không trôi, tạo đường vẽ mềm mại mang đến đôi mắt quyến rũ cho bạn.', N'ML003', N'TH002', N'Cái', 20, N'kemat3.jpg', N'kemat4.jpg')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [GiaBan], [GiaNhap], [GiamGia], [MoTa], [MaLoai], [MaThuongHieu], [DonViTinh], [SoLuongTon], [HinhAnh], [HinhAnhChiTiet]) VALUES (N'MH012', N'Kem Dưỡng Cấp nước, Phục Hồi Da Mụn Hạt Trà Xanh Innisfree Green Tea Seed Cream 50ml', 580000, 370000, 379000, N'Chiết xuất Hạt Trà Xanh chống oxy hóa, ngăn ngừa mụn, viêm.', N'ML005', N'TH002', N'Lọ', 11, N'kem1.jpg', N'kem2.jpg')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [GiaBan], [GiaNhap], [GiamGia], [MoTa], [MaLoai], [MaThuongHieu], [DonViTinh], [SoLuongTon], [HinhAnh], [HinhAnhChiTiet]) VALUES (N'MH013', N'Kem Dưỡng Cấp nước, Dưỡng Trắng Lá Hoa Anh Đào Innisfree Jeju Cherry Blossom Jam Cream 50ml', 580000, 370000, 379000, N'Chiết xuất lá hoa anh đào chống oxy hóa, ngăn ngừa mụn, viêm.', N'ML005', N'TH002', N'Lọ', 11, N'kem3.jpg', N'kem4.jpg')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [GiaBan], [GiaNhap], [GiamGia], [MoTa], [MaLoai], [MaThuongHieu], [DonViTinh], [SoLuongTon], [HinhAnh], [HinhAnhChiTiet]) VALUES (N'MH014', N'Kem Dưỡng Cấp nước, Dưỡng Trắng Hoa Lan Innisfree Jeju Orchid Jam Cream 50ml', 580000, 370000, 379000, N'Chiết xuất hoa lan chống oxy hóa, ngăn ngừa mụn, viêm.', N'ML005', N'TH002', N'Lọ', 11, N'kem5.jpg', N'kem6.jpg')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [GiaBan], [GiaNhap], [GiamGia], [MoTa], [MaLoai], [MaThuongHieu], [DonViTinh], [SoLuongTon], [HinhAnh], [HinhAnhChiTiet]) VALUES (N'MH015', N'Tinh Chất Dưỡng Ẩm Sâu, Phục Hồi Da Mụn Innisfree Green Tea Seed Serum 80ml', 580000, 400000, 550000, N'Chiết xuất hạt trà xanh chống oxy hóa, ngăn ngừa mụn, viêm.', N'ML007', N'TH002', N'Lọ', 11, N'serum3.jpg', N'serum4.jpg')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [GiaBan], [GiaNhap], [GiamGia], [MoTa], [MaLoai], [MaThuongHieu], [DonViTinh], [SoLuongTon], [HinhAnh], [HinhAnhChiTiet]) VALUES (N'MH016', N'Tinh Chất Dưỡng Ẩm Sâu, Phục Hồi Da Mụn Innisfree Pomegrante Serum 80ml', 580000, 400000, 550000, N'Chiết xuất lựu đỏ chống oxy hóa, ngăn ngừa mụn, viêm.', N'ML007', N'TH002', N'Lọ', 11, N'serum1.jpg', N'serum2.jpg')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [GiaBan], [GiaNhap], [GiamGia], [MoTa], [MaLoai], [MaThuongHieu], [DonViTinh], [SoLuongTon], [HinhAnh], [HinhAnhChiTiet]) VALUES (N'MH017', N'Nước hoa Nam Dior Sauvage Parfum 60ml', 4800000, 3000000, 3500000, N'Dior sauvage Parfum là phiên bản mới nhất trong bộ sưu tập nước hoa của nhà Dior trong dòng Sauvage, tiếp nối sự thành công của các phiên bản Sauvage EDT và Sauvage EDP. Một phiên bản mới được thiết kế đậm đà hơn nhưng vẫn giữ nguyên các ADN cốt lõi làm nên thương hiệu “Lady Killer” đình đám của Dior Sauvage. Chuyên gia Francois Demachy đã phát hành phiên bản Sauvage Parfume vào năm 2019, được lấy cảm hứng từ vùng thảo nguyên, thời điểm ánh trăng lên cao cùng bầu trời tối đen le lói ánh sáng của lửa trại.', N'ML008', N'TH006', N'Lọ', 11, N'sauvage1.jpg', N'sauvage2.jpg')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [GiaBan], [GiaNhap], [GiamGia], [MoTa], [MaLoai], [MaThuongHieu], [DonViTinh], [SoLuongTon], [HinhAnh], [HinhAnhChiTiet]) VALUES (N'MH018', N'Nước hoa Nam Dior Homme Intense 60ml', 4800000, 3000000, 3500000, N' Dior Homme Intense được ví như là một kẻ gây nghiện, gây nghiện với chính người dùng, và lây lan cái "nghiện" đó cho cả những người xung quanh. Một ngày mưa gió, lạnh lẽo, tỉnh giấc cùng bầu trời xám xịt đen sì ngoài kia, cách tốt nhất để làm hài lòng bản thân là xịt một shot Dior Homme Intense vào cơ thể và đi ngủ tiếp, như thể nó sẽ mang lại sự thư giãn tuyệt đối, bình yên vô điều kiện cho bất kỳ chàng trai nào.', N'ML008', N'TH006', N'Lọ', 11, N'ins1.jpg', N'ins2.jpg')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [GiaBan], [GiaNhap], [GiamGia], [MoTa], [MaLoai], [MaThuongHieu], [DonViTinh], [SoLuongTon], [HinhAnh], [HinhAnhChiTiet]) VALUES (N'MH019', N'Nước hoa Nữ Miss Dior Blooming Bouquet 60ml', 4800000, 3000000, 3500000, N' Dưới cái nắng dịu nhẹ, đôi khi bản thân lại nhớ đến cảm giác khi yêu “ Tựa như lần đầu “ . Nhẹ nhàng và chậm rãi tựa như Miss Dior Blooming Bouquet, đơn giản, đáng yêu mà ngây ngô. Một chai nước hoa vuông vức với cái nơ màu bạc trên đỉnh nhìn thật đáng yêu, như đang đứng giữa ranh giới của một cô bé và một quý cô, từng bước một mà trưởng thành.', N'ML009', N'TH006', N'Lọ', 11, N'miss1.jpg', N'miss2.jpg')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [GiaBan], [GiaNhap], [GiamGia], [MoTa], [MaLoai], [MaThuongHieu], [DonViTinh], [SoLuongTon], [HinhAnh], [HinhAnhChiTiet]) VALUES (N'MH020', N'Nước hoa Nữ Miss Dior Rose N Roses For Women 60ml', 4800000, 3000000, 3500000, N'Mùi hương của hoa hồng Damask ấm áp, sang trọng và vô cùng quyến rũ, khiến cho các quý cô sử dụng nó thêm phần lung linh hơn. Ở tầng cuối, xạ hương kết hợp với hương hoa hồng càng làm cho Rose N Roses For Women trở nên quyến rũ hơn thích hợp cho các chị em trẻ trung, tươi tắn sử dụng khi đi làm, đi chơi, đi café hay những buổi hẹn hò lãng mạn.', N'ML009', N'TH006', N'Lọ', 11, N'miss3.jpg', N'miss4.jpg')
INSERT [dbo].[ThuongHieu] ([MaThuongHieu], [TenThuongHieu]) VALUES (N'TH001', N'Missha')
INSERT [dbo].[ThuongHieu] ([MaThuongHieu], [TenThuongHieu]) VALUES (N'TH002', N'Innisfree')
INSERT [dbo].[ThuongHieu] ([MaThuongHieu], [TenThuongHieu]) VALUES (N'TH003', N'G9Skin')
INSERT [dbo].[ThuongHieu] ([MaThuongHieu], [TenThuongHieu]) VALUES (N'TH004', N'Blackrouge')
INSERT [dbo].[ThuongHieu] ([MaThuongHieu], [TenThuongHieu]) VALUES (N'TH005', N'Merzy')
INSERT [dbo].[ThuongHieu] ([MaThuongHieu], [TenThuongHieu]) VALUES (N'TH006', N'Dior')
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__KhachHan__0389B7BD896F1C94]    Script Date: 7/15/2021 8:08:46 PM ******/
ALTER TABLE [dbo].[KhachHang] ADD UNIQUE NONCLUSTERED 
(
	[SoDienThoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__NhanVien__0389B7BDB22A64BE]    Script Date: 7/15/2021 8:08:46 PM ******/
ALTER TABLE [dbo].[NhanVien] ADD UNIQUE NONCLUSTERED 
(
	[SoDienThoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__NhanVien__3D09A4FFD9D0A7C7]    Script Date: 7/15/2021 8:08:46 PM ******/
ALTER TABLE [dbo].[NhanVien] ADD UNIQUE NONCLUSTERED 
(
	[ChungMinhThu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CT_HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_CTHD_HD] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDon] ([MaHoaDon])
GO
ALTER TABLE [dbo].[CT_HoaDon] CHECK CONSTRAINT [FK_CTHD_HD]
GO
ALTER TABLE [dbo].[CT_HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_CTHD_MH] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[CT_HoaDon] CHECK CONSTRAINT [FK_CTHD_MH]
GO
ALTER TABLE [dbo].[CT_PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_CTPN_PN] FOREIGN KEY([MaPhieuNhap])
REFERENCES [dbo].[PhieuNhap] ([MaPhieuNhap])
GO
ALTER TABLE [dbo].[CT_PhieuNhap] CHECK CONSTRAINT [FK_CTPN_PN]
GO
ALTER TABLE [dbo].[CT_PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_CTPN_SP] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[CT_PhieuNhap] CHECK CONSTRAINT [FK_CTPN_SP]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HD_KH] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HD_KH]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HD_NV] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HD_NV]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NV_LNV] FOREIGN KEY([MaLoaiNhanVien])
REFERENCES [dbo].[LoaiNhanVien] ([MaLoaiNhanVien])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NV_LNV]
GO
ALTER TABLE [dbo].[PhanQuyen]  WITH CHECK ADD  CONSTRAINT [FK_PQ_LNV] FOREIGN KEY([MaLoaiNhanVien])
REFERENCES [dbo].[LoaiNhanVien] ([MaLoaiNhanVien])
GO
ALTER TABLE [dbo].[PhanQuyen] CHECK CONSTRAINT [FK_PQ_LNV]
GO
ALTER TABLE [dbo].[PhanQuyen]  WITH CHECK ADD  CONSTRAINT [FK_PQ_MH] FOREIGN KEY([MaManHinh])
REFERENCES [dbo].[ManHinh] ([MaManHinh])
GO
ALTER TABLE [dbo].[PhanQuyen] CHECK CONSTRAINT [FK_PQ_MH]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PN_NCC] FOREIGN KEY([MaNhaCungCap])
REFERENCES [dbo].[NhaCungCap] ([MaNhaCungCap])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PN_NCC]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PN_NV] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PN_NV]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_MH_LH] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[LoaiHang] ([MaLoai])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_MH_LH]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_MH_TH] FOREIGN KEY([MaThuongHieu])
REFERENCES [dbo].[ThuongHieu] ([MaThuongHieu])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_MH_TH]
GO
USE [master]
GO
ALTER DATABASE [QL_ShopMyPham] SET  READ_WRITE 
GO
