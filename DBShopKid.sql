USE [SHOPKID]
GO
/****** Object:  UserDefinedFunction [dbo].[AUTO_IDKH]    Script Date: 1/13/2021 11:15:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[AUTO_IDKH]()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID CHAR(5)
	IF (SELECT COUNT(MAKH) FROM KHACHHANG) = 0
		SET @ID = '0'
	ELSE

		SELECT @ID = MAX(RIGHT(MAKH, 3)) FROM KHACHHANG
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID <9 THEN 'KH00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >=9  and @ID <99 THEN 'KH0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >=99  and @ID <=999 THEN 'KH' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)

			
		END
	RETURN @ID
END
GO
/****** Object:  UserDefinedFunction [dbo].[AUTO_IDKho]    Script Date: 1/13/2021 11:15:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[AUTO_IDKho]()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID CHAR(5)
	IF (SELECT COUNT(MaKho) FROM Kho) = 0
		SET @ID = '0'
	ELSE

		SELECT @ID = MAX(RIGHT(MaKho, 3)) FROM Kho
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID <9 THEN 'MK00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >=9  and @ID <99 THEN 'MK0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >=99  and @ID <=999 THEN 'MK' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)

			
		END
	RETURN @ID
END
GO
/****** Object:  UserDefinedFunction [dbo].[AUTO_SanPham]    Script Date: 1/13/2021 11:15:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[AUTO_SanPham]()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MaSP) FROM SanPham) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaSP, 3)) FROM SanPham
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'SP00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'SP0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END

GO
/****** Object:  Table [dbo].[ChiTietDonHang]    Script Date: 1/13/2021 11:15:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonHang](
	[MaDH] [int] NOT NULL,
	[MaSP] [char](5) NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [int] NULL,
 CONSTRAINT [PK_ChiTietDonHang] PRIMARY KEY CLUSTERED 
(
	[MaDH] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHD]    Script Date: 1/13/2021 11:15:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHD](
	[MaHD] [char](5) NOT NULL,
	[MaSP] [char](5) NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [bigint] NULL,
	[ThanhTien] [bigint] NULL,
 CONSTRAINT [PK_ChiTietHD_1] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuNhap]    Script Date: 1/13/2021 11:15:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuNhap](
	[MaPN] [char](5) NOT NULL,
	[MaSP] [char](5) NOT NULL,
	[SoLuongNhap] [int] NULL,
	[ThanhTien] [bigint] NULL,
 CONSTRAINT [PK_ChiTietPhieuNhap] PRIMARY KEY CLUSTERED 
(
	[MaPN] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 1/13/2021 11:15:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[MaCV] [char](5) NOT NULL,
	[TenCV] [nvarchar](50) NULL,
 CONSTRAINT [PK_ChucVu] PRIMARY KEY CLUSTERED 
(
	[MaCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DMform]    Script Date: 1/13/2021 11:15:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DMform](
	[IDform] [char](5) NOT NULL,
	[TenBtn] [varchar](50) NULL,
	[TenFrm] [nvarchar](50) NULL,
 CONSTRAINT [PK_DMform] PRIMARY KEY CLUSTERED 
(
	[IDform] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 1/13/2021 11:15:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[MaDH] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[NgayDatHang] [date] NULL,
	[NgayGiao] [date] NULL,
	[TinhTrangGiaoHang] [int] NULL,
	[DaThanhToan] [int] NULL,
	[PhuongThucThanhToan] [int] NULL,
 CONSTRAINT [PK_DonHang] PRIMARY KEY CLUSTERED 
(
	[MaDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 1/13/2021 11:15:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHD] [char](5) NOT NULL,
	[NgayLapHD] [date] NULL,
	[TrangThai] [bit] NULL,
	[TongTien] [bigint] NULL,
	[MaNV] [char](5) NULL,
	[MaKH] [char](5) NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 1/13/2021 11:15:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [char](5) NOT NULL,
	[TenKH] [nvarchar](50) NULL,
	[SDT] [nchar](12) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[GioiTinh] [nvarchar](50) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kho]    Script Date: 1/13/2021 11:15:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kho](
	[MaKho] [char](5) NOT NULL,
	[MaSP] [char](5) NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_Kho] PRIMARY KEY CLUSTERED 
(
	[MaKho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiSanPham]    Script Date: 1/13/2021 11:15:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSanPham](
	[MaLoai] [char](5) NOT NULL,
	[TenLoai] [nvarchar](200) NULL,
	[MaNhom] [char](5) NULL,
 CONSTRAINT [PK_LoaiSanPham] PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 1/13/2021 11:15:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNCC] [char](5) NOT NULL,
	[TenNCC] [nvarchar](max) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[SDT] [nchar](12) NULL,
 CONSTRAINT [PK_NhaCungCap] PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 1/13/2021 11:15:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [char](5) NOT NULL,
	[TenNV] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[SDT] [nchar](12) NULL,
	[SoCMND] [nchar](9) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[MaCV] [char](5) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nhom]    Script Date: 1/13/2021 11:15:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nhom](
	[MaNhom] [char](5) NOT NULL,
	[TenNhom] [nvarchar](max) NULL,
 CONSTRAINT [PK_NHOM] PRIMARY KEY CLUSTERED 
(
	[MaNhom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 1/13/2021 11:15:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[MaPN] [char](5) NOT NULL,
	[NgayNhap] [date] NULL,
	[TongTien] [bigint] NULL,
	[MaNV] [char](5) NULL,
	[MaNCC] [char](5) NULL,
 CONSTRAINT [PK_PhieuNhap] PRIMARY KEY CLUSTERED 
(
	[MaPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quyen]    Script Date: 1/13/2021 11:15:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quyen](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[IdFrm] [char](5) NULL,
 CONSTRAINT [PK_Quyen] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 1/13/2021 11:15:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSP] [char](5) NOT NULL,
	[TenSP] [nvarchar](max) NULL,
	[DonViTinh] [nvarchar](50) NULL,
	[GiaBan] [bigint] NULL,
	[GiaNhap] [bigint] NULL,
	[HinhAnh] [nvarchar](max) NULL,
	[MoTa] [nvarchar](max) NULL,
	[MaLoai] [char](5) NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 1/13/2021 11:15:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[UserName] [varchar](50) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[SoDienThoai] [varchar](50) NULL,
	[MatKhau] [nvarchar](50) NULL,
	[HoatDong] [int] NULL,
	[PhanQuyen] [int] NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserNhanVien]    Script Date: 1/13/2021 11:15:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserNhanVien](
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](max) NULL,
	[MaNV] [char](5) NULL,
 CONSTRAINT [PK_UserNhanVien] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaSP], [SoLuong], [DonGia]) VALUES (1, N'SP001', 4, 369000)
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaSP], [SoLuong], [DonGia]) VALUES (4, N'SP029', 1, 165000)
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaSP], [SoLuong], [DonGia]) VALUES (5, N'SP002', 2, 522000)
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaSP], [SoLuong], [DonGia]) VALUES (6, N'SP046', 1, 125000)
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaSP], [SoLuong], [DonGia]) VALUES (7, N'SP047', 1, 120000)
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaSP], [SoLuong], [DonGia]) VALUES (8, N'SP006', 1, 369000)
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaSP], [SoLuong], [DonGia]) VALUES (9, N'SP060', 5, 119000)
INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaSP], [SoLuong], [DonGia]) VALUES (10, N'SP060', 5, 119000)
GO
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD001', N'SP002', 10, 522000, 5220000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD001', N'SP003', 15, 275000, 4125000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD001', N'SP008', 14, 369000, 5166000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD002', N'SP002', 12, 522000, 6264000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD002', N'SP014', 13, 369000, 4797000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD002', N'SP016', 15, 369000, 5535000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD002', N'SP017', 20, 369000, 7380000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD003', N'SP014', 32, 369000, 11808000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD003', N'SP017', 20, 369000, 7380000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD003', N'SP020', 12, 130000, 1560000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD004', N'SP017', 10, 369000, 3690000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD004', N'SP021', 12, 100000, 1200000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD005', N'SP013', 16, 369000, 5904000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD005', N'SP018', 16, 369000, 5904000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD006', N'SP003', 2, 275000, 550000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD006', N'SP005', 4, 369000, 1476000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD006', N'SP011', 2, 369000, 738000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD007', N'SP012', 9, 369000, 3321000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD007', N'SP021', 3, 100000, 300000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD008', N'SP001', 7, 369000, 2583000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD008', N'SP020', 7, 130000, 910000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD009', N'SP021', 2, 100000, 200000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD009', N'SP022', 6, 110000, 660000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD010', N'SP012', 7, 369000, 2583000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD010', N'SP013', 7, 369000, 2583000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD011', N'SP013', 6, 369000, 2214000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD012', N'SP027', 15, 185000, 2775000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD012', N'SP030', 8, 83000, 664000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD013', N'SP026', 9, 109000, 981000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD013', N'SP030', 10, 83000, 830000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD014', N'SP027', 2, 185000, 370000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD014', N'SP033', 2, 185000, 370000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD015', N'SP021', 5, 100000, 500000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD015', N'SP029', 3, 165000, 495000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD016', N'SP042', 4, 110000, 440000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD016', N'SP047', 4, 120000, 480000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD017', N'SP041', 8, 110000, 880000)
INSERT [dbo].[ChiTietHD] ([MaHD], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD017', N'SP042', 5, 110000, 550000)
GO
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN001', N'SP001', 301, 108360000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN001', N'SP009', 400, 144000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN001', N'SP012', 300, 108000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN002', N'SP003', 17, 1700000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN002', N'SP010', 408, 146880000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN002', N'SP011', 550, 198000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN003', N'SP013', 399, 143640000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN003', N'SP014', 400, 144000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN003', N'SP015', 500, 180000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN003', N'SP016', 349, 125640000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN003', N'SP017', 400, 144000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN004', N'SP018', 400, 144000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN004', N'SP019', 500, 57500000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN004', N'SP020', 400, 50000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN004', N'SP021', 670, 60300000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN004', N'SP022', 433, 43300000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN005', N'SP023', 130, 13000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN005', N'SP024', 200, 22000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN005', N'SP025', 340, 40800000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN005', N'SP026', 540, 54000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN006', N'SP027', 333, 59940000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN006', N'SP028', 444, 35520000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN006', N'SP029', 222, 33300000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN006', N'SP030', 545, 43600000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN007', N'SP031', 160, 12800000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN008', N'SP032', 100, 16000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN008', N'SP033', 200, 36000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN009', N'SP035', 140, 25200000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN009', N'SP036', 300, 24000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN010', N'SP037', 399, 71820000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN010', N'SP038', 100, 8000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN010', N'SP039', 21, 1680000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN011', N'SP040', 150, 12000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN011', N'SP041', 100, 11000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN011', N'SP043', 45, 8100000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN012', N'SP046', 6, 720000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN012', N'SP058', 8, 680000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN012', N'SP059', 7, 3710000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN013', N'SP042', 200, 22000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN013', N'SP044', 150, 27000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN013', N'SP045', 333, 41625000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN015', N'SP034', 300, 24000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN016', N'SP046', 164, 19680000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN016', N'SP047', 200, 23000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN017', N'SP058', 182, 15470000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN017', N'SP059', 233, 123490000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN018', N'SP004', 255, 91800000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN018', N'SP005', 150, 54000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN019', N'SP037', 300, 54000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN019', N'SP038', 200, 16000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN019', N'SP039', 150, 12000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN020', N'SP008', 150, 54000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN020', N'SP043', 200, 36000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaPN], [MaSP], [SoLuongNhap], [ThanhTien]) VALUES (N'PN021', N'SP060', 40, 4000000)
GO
INSERT [dbo].[ChucVu] ([MaCV], [TenCV]) VALUES (N'CV001', N'Kế Toán')
INSERT [dbo].[ChucVu] ([MaCV], [TenCV]) VALUES (N'CV002', N'Nhân Viên Đứng Quầy')
INSERT [dbo].[ChucVu] ([MaCV], [TenCV]) VALUES (N'CV003', N'Nhân Viên Tư Vấn Khách Hàng')
INSERT [dbo].[ChucVu] ([MaCV], [TenCV]) VALUES (N'CV004', N'Giám Đốc')
INSERT [dbo].[ChucVu] ([MaCV], [TenCV]) VALUES (N'CV005', N'Phó Giám Đốc')
INSERT [dbo].[ChucVu] ([MaCV], [TenCV]) VALUES (N'CV006', N'Giữ Xe')
GO
INSERT [dbo].[DMform] ([IDform], [TenBtn], [TenFrm]) VALUES (N'Q001 ', N'btnSanPham', N'Danh mục sản phẩm')
INSERT [dbo].[DMform] ([IDform], [TenBtn], [TenFrm]) VALUES (N'Q002 ', N'btnLoaiSanPham', N'Danh mục loại sản phẩm')
INSERT [dbo].[DMform] ([IDform], [TenBtn], [TenFrm]) VALUES (N'Q003 ', N'btnNhaCungCap', N'Danh mục nhà cung cấp')
INSERT [dbo].[DMform] ([IDform], [TenBtn], [TenFrm]) VALUES (N'Q004 ', N'btnHoaDonNhapHang', N'Màn hình nhập hàng')
INSERT [dbo].[DMform] ([IDform], [TenBtn], [TenFrm]) VALUES (N'Q005 ', N'btnBanHang', N'Màn hình bán hàng')
INSERT [dbo].[DMform] ([IDform], [TenBtn], [TenFrm]) VALUES (N'Q006 ', N'btnKhachHang', N'Danh mục khách hàng')
INSERT [dbo].[DMform] ([IDform], [TenBtn], [TenFrm]) VALUES (N'Q007 ', N'btnPhanQuyen', N'Chức năng phân quyền')
INSERT [dbo].[DMform] ([IDform], [TenBtn], [TenFrm]) VALUES (N'Q008 ', N'btnTK', N'Chức năng quản lý tài khoản')
INSERT [dbo].[DMform] ([IDform], [TenBtn], [TenFrm]) VALUES (N'Q009 ', N'btnNhanVien', N'Chức năng quản lý nhân viên')
INSERT [dbo].[DMform] ([IDform], [TenBtn], [TenFrm]) VALUES (N'Q010 ', N'btnHoaDonBanHang', N'Màn hình hóa đơn bán hàng')
INSERT [dbo].[DMform] ([IDform], [TenBtn], [TenFrm]) VALUES (N'Q011 ', N'btnBaoCaoDT', N'Màn hình báo cáo doanh thu')
GO
SET IDENTITY_INSERT [dbo].[DonHang] ON 

INSERT [dbo].[DonHang] ([MaDH], [UserName], [NgayDatHang], [NgayGiao], [TinhTrangGiaoHang], [DaThanhToan], [PhuongThucThanhToan]) VALUES (1, N'khanh1999', CAST(N'2021-01-11' AS Date), CAST(N'2021-07-29' AS Date), 1, 1, 1)
INSERT [dbo].[DonHang] ([MaDH], [UserName], [NgayDatHang], [NgayGiao], [TinhTrangGiaoHang], [DaThanhToan], [PhuongThucThanhToan]) VALUES (4, N'khanh1999', CAST(N'2021-01-11' AS Date), CAST(N'2021-07-19' AS Date), 0, 0, 0)
INSERT [dbo].[DonHang] ([MaDH], [UserName], [NgayDatHang], [NgayGiao], [TinhTrangGiaoHang], [DaThanhToan], [PhuongThucThanhToan]) VALUES (5, N'khanh', CAST(N'2021-01-11' AS Date), CAST(N'2022-08-08' AS Date), 0, 0, 0)
INSERT [dbo].[DonHang] ([MaDH], [UserName], [NgayDatHang], [NgayGiao], [TinhTrangGiaoHang], [DaThanhToan], [PhuongThucThanhToan]) VALUES (6, N'khanh', CAST(N'2021-01-11' AS Date), CAST(N'2021-03-19' AS Date), 0, 0, 0)
INSERT [dbo].[DonHang] ([MaDH], [UserName], [NgayDatHang], [NgayGiao], [TinhTrangGiaoHang], [DaThanhToan], [PhuongThucThanhToan]) VALUES (7, N'khanh', CAST(N'2021-01-11' AS Date), CAST(N'2021-02-22' AS Date), 0, 0, 0)
INSERT [dbo].[DonHang] ([MaDH], [UserName], [NgayDatHang], [NgayGiao], [TinhTrangGiaoHang], [DaThanhToan], [PhuongThucThanhToan]) VALUES (8, N'khanh', CAST(N'2021-01-11' AS Date), CAST(N'2022-01-23' AS Date), 0, 0, 0)
INSERT [dbo].[DonHang] ([MaDH], [UserName], [NgayDatHang], [NgayGiao], [TinhTrangGiaoHang], [DaThanhToan], [PhuongThucThanhToan]) VALUES (9, N'khanh', CAST(N'2021-01-11' AS Date), CAST(N'2021-08-17' AS Date), 0, 0, 0)
INSERT [dbo].[DonHang] ([MaDH], [UserName], [NgayDatHang], [NgayGiao], [TinhTrangGiaoHang], [DaThanhToan], [PhuongThucThanhToan]) VALUES (10, N'khanh', CAST(N'2021-01-11' AS Date), CAST(N'2021-09-18' AS Date), 0, 0, 0)
SET IDENTITY_INSERT [dbo].[DonHang] OFF
GO
INSERT [dbo].[HoaDon] ([MaHD], [NgayLapHD], [TrangThai], [TongTien], [MaNV], [MaKH]) VALUES (N'HD001', CAST(N'2021-01-05' AS Date), 1, 14511000, N'NV001', N'KH006')
INSERT [dbo].[HoaDon] ([MaHD], [NgayLapHD], [TrangThai], [TongTien], [MaNV], [MaKH]) VALUES (N'HD002', CAST(N'2021-01-05' AS Date), 1, 23976000, N'NV001', N'KH001')
INSERT [dbo].[HoaDon] ([MaHD], [NgayLapHD], [TrangThai], [TongTien], [MaNV], [MaKH]) VALUES (N'HD003', CAST(N'2021-01-07' AS Date), 1, 20748000, N'NV001', N'KH002')
INSERT [dbo].[HoaDon] ([MaHD], [NgayLapHD], [TrangThai], [TongTien], [MaNV], [MaKH]) VALUES (N'HD004', CAST(N'2021-01-10' AS Date), 1, 4890000, N'NV001', N'KH003')
INSERT [dbo].[HoaDon] ([MaHD], [NgayLapHD], [TrangThai], [TongTien], [MaNV], [MaKH]) VALUES (N'HD005', CAST(N'2021-01-01' AS Date), 1, 11808000, N'NV001', N'KH004')
INSERT [dbo].[HoaDon] ([MaHD], [NgayLapHD], [TrangThai], [TongTien], [MaNV], [MaKH]) VALUES (N'HD006', CAST(N'2021-01-05' AS Date), 1, 2764000, N'NV001', N'KH006')
INSERT [dbo].[HoaDon] ([MaHD], [NgayLapHD], [TrangThai], [TongTien], [MaNV], [MaKH]) VALUES (N'HD007', CAST(N'2021-01-13' AS Date), 1, 3621000, N'NV001', N'KH011')
INSERT [dbo].[HoaDon] ([MaHD], [NgayLapHD], [TrangThai], [TongTien], [MaNV], [MaKH]) VALUES (N'HD008', CAST(N'2021-01-11' AS Date), 1, 3493000, N'NV001', N'KH010')
INSERT [dbo].[HoaDon] ([MaHD], [NgayLapHD], [TrangThai], [TongTien], [MaNV], [MaKH]) VALUES (N'HD009', CAST(N'2021-01-15' AS Date), 1, 860000, N'NV001', N'KH013')
INSERT [dbo].[HoaDon] ([MaHD], [NgayLapHD], [TrangThai], [TongTien], [MaNV], [MaKH]) VALUES (N'HD010', CAST(N'2021-01-16' AS Date), 1, 5166000, N'NV001', N'KH014')
INSERT [dbo].[HoaDon] ([MaHD], [NgayLapHD], [TrangThai], [TongTien], [MaNV], [MaKH]) VALUES (N'HD011', CAST(N'2021-01-10' AS Date), 1, 2214000, N'NV001', N'KH014')
INSERT [dbo].[HoaDon] ([MaHD], [NgayLapHD], [TrangThai], [TongTien], [MaNV], [MaKH]) VALUES (N'HD012', CAST(N'2021-01-14' AS Date), 1, 3439000, N'NV001', N'KH013')
INSERT [dbo].[HoaDon] ([MaHD], [NgayLapHD], [TrangThai], [TongTien], [MaNV], [MaKH]) VALUES (N'HD013', CAST(N'2021-01-19' AS Date), 1, 1811000, N'NV005', N'KH012')
INSERT [dbo].[HoaDon] ([MaHD], [NgayLapHD], [TrangThai], [TongTien], [MaNV], [MaKH]) VALUES (N'HD014', CAST(N'2021-01-10' AS Date), 1, 740000, N'NV005', N'KH014')
INSERT [dbo].[HoaDon] ([MaHD], [NgayLapHD], [TrangThai], [TongTien], [MaNV], [MaKH]) VALUES (N'HD015', CAST(N'2021-01-07' AS Date), 1, 995000, N'NV001', N'KH015')
INSERT [dbo].[HoaDon] ([MaHD], [NgayLapHD], [TrangThai], [TongTien], [MaNV], [MaKH]) VALUES (N'HD016', CAST(N'2021-01-09' AS Date), 1, 920000, N'NV001', N'KH012')
INSERT [dbo].[HoaDon] ([MaHD], [NgayLapHD], [TrangThai], [TongTien], [MaNV], [MaKH]) VALUES (N'HD017', CAST(N'2021-01-09' AS Date), 1, 1430000, N'NV019', N'KH008')
GO
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [DiaChi], [GioiTinh]) VALUES (N'KH001', N'Nguyễn Việt Anh', N'092872832   ', N'Q1-TPHCM', N'Nam')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [DiaChi], [GioiTinh]) VALUES (N'KH002', N'La Gia Bảo', N'088772122   ', N'Q6-TPHCM', N'Nam')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [DiaChi], [GioiTinh]) VALUES (N'KH003', N'Đặng Thị Ngọc Cẩm', N'098372612   ', N'Q3-TPHCM', N'Nữ')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [DiaChi], [GioiTinh]) VALUES (N'KH004', N'Lê Ngọc Băng Châu', N'076532342   ', N'Q4-TPHCM', N'Nữ')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [DiaChi], [GioiTinh]) VALUES (N'KH005', N'Trần Thị Kim Chi', N'065662344   ', N'Q7-TPHCM', N'Nữ')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [DiaChi], [GioiTinh]) VALUES (N'KH006', N'Trần Văn Chiến', N'088776766   ', N'Q8-TPHCM', N'Nam')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [DiaChi], [GioiTinh]) VALUES (N'KH007', N'Dương Tấn Cường', N'0887878788  ', N'Q.Tân Phú-TPHCM', N'Nam')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [DiaChi], [GioiTinh]) VALUES (N'KH008', N'Võ Nguyễn Hải Đăng', N'098236372   ', N'Q.Bình Chánh-TPHCM', N'Nam')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [DiaChi], [GioiTinh]) VALUES (N'KH009', N'Nguyễn Thị Anh Đào', N'023873743   ', N'Q2-TPHCM', N'Nữ')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [DiaChi], [GioiTinh]) VALUES (N'KH010', N'Lê Thị Kim Hằng', N'076866722   ', N'Q11-TPHCM', N'Nữ')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [DiaChi], [GioiTinh]) VALUES (N'KH011', N'Bùi Vỹ Khang', N'087678212   ', N'Q12-TPHCM', N'Nam')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [DiaChi], [GioiTinh]) VALUES (N'KH012', N'Hồ Anh Kiệt', N'076526234   ', N'Q12-TPHCM', N'Nữ')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [DiaChi], [GioiTinh]) VALUES (N'KH013', N'Trương Thùy Linh', N'077655454   ', N'Q10-TPHCM', N'Nữ')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [DiaChi], [GioiTinh]) VALUES (N'KH014', N'Trần Huỳnh Long', N'078765654   ', N'Q5-TPHCM', N'Nam')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [DiaChi], [GioiTinh]) VALUES (N'KH015', N'Cô Châu', N'32444345    ', N'', N'Nữ')
GO
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK001', N'SP001', 290)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK002', N'SP002', 82)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK003', N'SP003', 396)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK004', N'SP004', 260)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK005', N'SP005', 202)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK006', N'SP006', 99)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK007', N'SP007', 56)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK008', N'SP008', 192)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK009', N'SP009', 300)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK010', N'SP010', 408)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK011', N'SP011', 406)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK012', N'SP012', 283)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK013', N'SP013', 371)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK014', N'SP014', 355)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK015', N'SP015', 400)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK016', N'SP016', 385)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK017', N'SP017', 350)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK018', N'SP018', 417)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK019', N'SP019', 433)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK020', N'SP020', 414)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK021', N'SP021', 411)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK022', N'SP022', 427)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK023', N'SP023', 540)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK024', N'SP024', 540)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK025', N'SP025', 540)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK026', N'SP026', 531)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK027', N'SP027', 528)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK028', N'SP028', 545)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK029', N'SP029', 541)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK030', N'SP030', 527)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK031', N'SP031', 160)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK032', N'SP032', 200)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK033', N'SP033', 198)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK034', N'SP034', 300)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK035', N'SP035', 300)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK036', N'SP036', 300)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK037', N'SP037', 321)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK038', N'SP038', 221)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK039', N'SP039', 171)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK040', N'SP040', 150)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK041', N'SP041', 92)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK042', N'SP042', 191)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK043', N'SP043', 245)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK044', N'SP044', 150)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK045', N'SP045', 333)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK046', N'SP046', 169)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK047', N'SP047', 195)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK048', N'SP048', 0)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK049', N'SP049', 0)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK050', N'SP050', 0)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK051', N'SP051', 0)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK052', N'SP052', 0)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK053', N'SP053', 0)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK054', N'SP054', 0)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK055', N'SP055', 0)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK056', N'SP056', 0)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK057', N'SP057', 0)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK058', N'SP058', 189)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK059', N'SP059', 240)
INSERT [dbo].[Kho] ([MaKho], [MaSP], [SoLuong]) VALUES (N'MK060', N'SP060', 30)
GO
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MaNhom]) VALUES (N'LH001', N'Thế giới bình sữa', N'1    ')
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MaNhom]) VALUES (N'LH002', N'Dinh dưỡng đóng lọ', N'2    ')
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MaNhom]) VALUES (N'LH003', N'Khăn ướt vải', N'3    ')
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MaNhom]) VALUES (N'LH004', N'Núm ty', N'1    ')
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MaNhom]) VALUES (N'LH005', N'Phô mai, váng sữa', N'2    ')
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MaNhom]) VALUES (N'LH006', N'Khăn ướt bột giấy', N'3    ')
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MaNhom]) VALUES (N'LH007', N'Túi trữ sữa', N'1    ')
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MaNhom]) VALUES (N'LH008', N'Cọ, Giá úp', N'1    ')
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MaNhom]) VALUES (N'LH009', N'Ty ngậm', N'1    ')
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MaNhom]) VALUES (N'LH010', N'Thực phẩm chế biến', N'2    ')
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MaNhom]) VALUES (N'LH011', N'Thức ăn nghiền', N'2    ')
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MaNhom]) VALUES (N'LH012', N'Khăn giấy', N'3    ')
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MaNhom]) VALUES (N'LH013', N'Sữa cho mẹ', N'2    ')
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MaNhom]) VALUES (N'LH014', N'Máy phun, tiệt trùng', N'1    ')
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai], [MaNhom]) VALUES (N'LH015', N'Ngậm nếu', N'1    ')
GO
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SDT]) VALUES (N'NC001', N'IPI CORP', N'Lâm Đồng', N'0982625322  ')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SDT]) VALUES (N'NC002', N'Công Ty TNHH BeeMat', N'Q4-TPHCM', N'190008273   ')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SDT]) VALUES (N'NC003', N'Công Ty TNHH Thuong Mại và Dịch Vụ B2C', N'Q6-TPHCM', N'1900276354  ')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SDT]) VALUES (N'NC004', N'Galaxy International Joint Stock Company', N'Q6-TPHCM', N'190999999   ')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SDT]) VALUES (N'NC005', N'Công Ty TNHH Camprotech', N'Q5-TPHCM', N'1900725362  ')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SDT]) VALUES (N'NC006', N'SAT - ABB Authorized Value Provider', N'Q7-TPHCM', N'0876766123  ')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SDT]) VALUES (N'NC007', N'Phan Gia Export Import Production Trading Company Limited', N'Q8-TPHCM', N'0978672332  ')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SDT]) VALUES (N'NC008', N'GKTECH Company', N'Q.Bình Thạnh - TPHCM', N'0909092826  ')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SDT]) VALUES (N'NC009', N'DH CNTP', N'TPHCM', N'098743332   ')
GO
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [SDT], [SoCMND], [DiaChi], [MaCV]) VALUES (N'NV001', N'Lê Đăng Trường', CAST(N'1999-06-09' AS Date), N'Nam', N'083772829   ', N'033738383', N'TP. Hồ Chí Minh', N'CV004')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [SDT], [SoCMND], [DiaChi], [MaCV]) VALUES (N'NV002', N'Đinh Ngọc Tú', CAST(N'1990-11-15' AS Date), N'Nữ', N'092727372   ', N'221122321', N'Hà Nội', N'CV002')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [SDT], [SoCMND], [DiaChi], [MaCV]) VALUES (N'NV003', N'Mai Thị Tuyết Nhi', CAST(N'1993-06-18' AS Date), N'Nữ', N'086433311   ', N'232111111', N'Q1 - TPHCM', N'CV002')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [SDT], [SoCMND], [DiaChi], [MaCV]) VALUES (N'NV004', N'Hoàng Thị Lan Anh', CAST(N'2004-06-10' AS Date), N'Nữ', N'099331121   ', N'655644333', N'Q. Phú Nhuận - TPHCM', N'CV005')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [SDT], [SoCMND], [DiaChi], [MaCV]) VALUES (N'NV005', N'Huỳnh Thị Cảnh Vi', CAST(N'1995-05-16' AS Date), N'Nữ', N'075333322   ', N'3234544  ', N'Lâm Hà-Lâm Đồng', N'CV002')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [SDT], [SoCMND], [DiaChi], [MaCV]) VALUES (N'NV006', N'Huỳnh Văn Cường', CAST(N'2002-07-13' AS Date), N'Nam', N'0164029569  ', N'32342112 ', N'Bình Định', N'CV005')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [SDT], [SoCMND], [DiaChi], [MaCV]) VALUES (N'NV007', N'Bùi Long Tuyên', CAST(N'1993-05-04' AS Date), N'Nam', N'0123484509  ', N'45643323 ', N'Bình Định', N'CV002')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [SDT], [SoCMND], [DiaChi], [MaCV]) VALUES (N'NV008', N'Nguyễn Xuân Hội', CAST(N'1992-08-20' AS Date), N'Nam', N'0165765903  ', N'64443334 ', N'Xuân Lộc-Đồng Nai', N'CV003')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [SDT], [SoCMND], [DiaChi], [MaCV]) VALUES (N'NV009', N'Nguyến Văn Tuyên', CAST(N'2020-12-12' AS Date), N'Nam', N'0124896892  ', N'65443332 ', N'Bình Phước', N'CV005')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [SDT], [SoCMND], [DiaChi], [MaCV]) VALUES (N'NV010', N'Trương Quang Tuấn', CAST(N'2020-12-12' AS Date), N'Nam', N'0168530039  ', N'54332322 ', N'Lâm Hà-Lâm Đồng', N'CV003')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [SDT], [SoCMND], [DiaChi], [MaCV]) VALUES (N'NV011', N'Huỳnh Thị Ngọc Vy', CAST(N'1999-07-16' AS Date), N'Nữ', N'0168530039  ', N'23337765 ', N'Lâm Hà-Lâm Đồng', N'CV002')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [SDT], [SoCMND], [DiaChi], [MaCV]) VALUES (N'NV012', N'Phạm Minh Tiến', CAST(N'1996-08-09' AS Date), N'Nam', N'0168532889  ', N'32321212 ', N'Đăk Lắk', N'CV002')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [SDT], [SoCMND], [DiaChi], [MaCV]) VALUES (N'NV013', N'Nguyễn Phước Quỳnh Như', CAST(N'1998-12-18' AS Date), N'Nữ', N'093938223   ', N'56543433 ', N'Q3 - TPHCM', N'CV001')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [SDT], [SoCMND], [DiaChi], [MaCV]) VALUES (N'NV014', N'Nguyễn Thị Châu Anh', CAST(N'2020-12-12' AS Date), N'Nữ', N'038337212   ', N'54332322 ', N'Q4 - TPHCM', N'CV002')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [SDT], [SoCMND], [DiaChi], [MaCV]) VALUES (N'NV015', N'Nguyễn Thị Kim Anh', CAST(N'1997-06-17' AS Date), N'Nữ', N'076554343   ', N'654433233', N'Q5 - TPHCM', N'CV003')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [SDT], [SoCMND], [DiaChi], [MaCV]) VALUES (N'NV016', N'Nguyễn Thị Mỹ Anh', CAST(N'2000-07-18' AS Date), N'Nữ', N'089934832   ', N'564433343', N'Q11 - TPHCM', N'CV004')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [SDT], [SoCMND], [DiaChi], [MaCV]) VALUES (N'NV017', N'Nguyễn Thị Ngọc Loan', CAST(N'1985-07-22' AS Date), N'Nữ', N'063532234   ', N'655443323', N'Q12 - TPHCM', N'CV001')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [SDT], [SoCMND], [DiaChi], [MaCV]) VALUES (N'NV018', N'Trương Phúc Kim Phương', CAST(N'1994-07-13' AS Date), N'Nữ', N'097665444   ', N'97754343 ', N'Q2 - TPHCM', N'CV001')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [SDT], [SoCMND], [DiaChi], [MaCV]) VALUES (N'NV019', N'Đinh Văn Sơn', CAST(N'1990-04-17' AS Date), N'Nữ', N'066554434   ', N'43323487 ', N'Q5 - TPHCM', N'CV004')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [SDT], [SoCMND], [DiaChi], [MaCV]) VALUES (N'NV020', N'Dương Thị Bích Đào', CAST(N'2000-11-09' AS Date), N'Nam', N'087382822   ', N'98767655 ', N'Q7 - TPCHM', N'CV002')
GO
INSERT [dbo].[Nhom] ([MaNhom], [TenNhom]) VALUES (N'1    ', N'BÌNH SỮA')
INSERT [dbo].[Nhom] ([MaNhom], [TenNhom]) VALUES (N'2    ', N'DINH DƯỠNG')
INSERT [dbo].[Nhom] ([MaNhom], [TenNhom]) VALUES (N'3    ', N'KHĂN')
GO
INSERT [dbo].[PhieuNhap] ([MaPN], [NgayNhap], [TongTien], [MaNV], [MaNCC]) VALUES (N'PN001', CAST(N'2020-12-16' AS Date), 360360000, N'NV001', N'NC001')
INSERT [dbo].[PhieuNhap] ([MaPN], [NgayNhap], [TongTien], [MaNV], [MaNCC]) VALUES (N'PN002', CAST(N'2020-12-30' AS Date), 346580000, N'NV001', N'NC004')
INSERT [dbo].[PhieuNhap] ([MaPN], [NgayNhap], [TongTien], [MaNV], [MaNCC]) VALUES (N'PN003', CAST(N'2020-12-30' AS Date), 737280000, N'NV001', N'NC002')
INSERT [dbo].[PhieuNhap] ([MaPN], [NgayNhap], [TongTien], [MaNV], [MaNCC]) VALUES (N'PN004', CAST(N'2020-12-23' AS Date), 355100000, N'NV001', N'NC003')
INSERT [dbo].[PhieuNhap] ([MaPN], [NgayNhap], [TongTien], [MaNV], [MaNCC]) VALUES (N'PN005', CAST(N'2021-01-07' AS Date), 129800000, N'NV001', N'NC008')
INSERT [dbo].[PhieuNhap] ([MaPN], [NgayNhap], [TongTien], [MaNV], [MaNCC]) VALUES (N'PN006', CAST(N'2021-01-13' AS Date), 172360000, N'NV001', N'NC007')
INSERT [dbo].[PhieuNhap] ([MaPN], [NgayNhap], [TongTien], [MaNV], [MaNCC]) VALUES (N'PN007', CAST(N'2021-01-15' AS Date), 12800000, N'NV001', N'NC006')
INSERT [dbo].[PhieuNhap] ([MaPN], [NgayNhap], [TongTien], [MaNV], [MaNCC]) VALUES (N'PN008', CAST(N'2021-01-07' AS Date), 52000000, N'NV001', N'NC004')
INSERT [dbo].[PhieuNhap] ([MaPN], [NgayNhap], [TongTien], [MaNV], [MaNCC]) VALUES (N'PN009', CAST(N'2021-01-05' AS Date), 49200000, N'NV005', N'NC005')
INSERT [dbo].[PhieuNhap] ([MaPN], [NgayNhap], [TongTien], [MaNV], [MaNCC]) VALUES (N'PN010', CAST(N'2021-01-05' AS Date), 81500000, N'NV001', N'NC003')
INSERT [dbo].[PhieuNhap] ([MaPN], [NgayNhap], [TongTien], [MaNV], [MaNCC]) VALUES (N'PN011', CAST(N'2021-01-05' AS Date), 31100000, N'NV001', N'NC003')
INSERT [dbo].[PhieuNhap] ([MaPN], [NgayNhap], [TongTien], [MaNV], [MaNCC]) VALUES (N'PN012', CAST(N'2021-01-05' AS Date), 5110000, N'NV001', N'NC003')
INSERT [dbo].[PhieuNhap] ([MaPN], [NgayNhap], [TongTien], [MaNV], [MaNCC]) VALUES (N'PN013', CAST(N'2021-01-05' AS Date), 90625000, N'NV001', N'NC006')
INSERT [dbo].[PhieuNhap] ([MaPN], [NgayNhap], [TongTien], [MaNV], [MaNCC]) VALUES (N'PN015', CAST(N'2021-01-07' AS Date), 24000000, N'NV001', N'NC004')
INSERT [dbo].[PhieuNhap] ([MaPN], [NgayNhap], [TongTien], [MaNV], [MaNCC]) VALUES (N'PN016', CAST(N'2021-01-07' AS Date), 42680000, N'NV001', N'NC006')
INSERT [dbo].[PhieuNhap] ([MaPN], [NgayNhap], [TongTien], [MaNV], [MaNCC]) VALUES (N'PN017', CAST(N'2021-01-07' AS Date), 138960000, N'NV001', N'NC004')
INSERT [dbo].[PhieuNhap] ([MaPN], [NgayNhap], [TongTien], [MaNV], [MaNCC]) VALUES (N'PN018', CAST(N'2021-01-07' AS Date), 145800000, N'NV001', N'NC001')
INSERT [dbo].[PhieuNhap] ([MaPN], [NgayNhap], [TongTien], [MaNV], [MaNCC]) VALUES (N'PN019', CAST(N'2021-01-07' AS Date), 82000000, N'NV001', N'NC002')
INSERT [dbo].[PhieuNhap] ([MaPN], [NgayNhap], [TongTien], [MaNV], [MaNCC]) VALUES (N'PN020', CAST(N'2021-01-09' AS Date), 90000000, N'NV001', N'NC006')
INSERT [dbo].[PhieuNhap] ([MaPN], [NgayNhap], [TongTien], [MaNV], [MaNCC]) VALUES (N'PN021', CAST(N'2021-01-11' AS Date), 4000000, N'NV019', N'NC006')
GO
SET IDENTITY_INSERT [dbo].[Quyen] ON 

INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (114, N'admin', N'Q001 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (115, N'admin', N'Q002 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (116, N'admin', N'Q003 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (118, N'admin', N'Q005 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (119, N'admin', N'Q006 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (120, N'admin', N'Q007 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (122, N'admin', N'Q009 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (123, N'nhi', N'Q001 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (124, N'nhi', N'Q002 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (125, N'nhi', N'Q003 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (126, N'nhi', N'Q005 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (130, N'admin', N'Q008 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (131, N'vi', N'Q001 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (133, N'admin', N'Q004 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (139, N'vi', N'Q010 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (140, N'vi', N'Q009 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (142, N'vi', N'Q006 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (144, N'vi', N'Q005 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (1133, N'admin', N'Q011 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (1134, N'admin', N'Q010 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (1135, N'vi', N'Q011 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (1137, N'vi', N'Q004 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (1138, N'vi', N'Q003 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (1139, N'vi', N'Q002 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (1140, N'tuyen', N'Q001 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (1141, N'tuyen', N'Q001 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (1142, N'son', N'Q001 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (1143, N'son', N'Q002 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (1144, N'son', N'Q003 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (1145, N'son', N'Q004 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (1146, N'son', N'Q005 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (1147, N'son', N'Q006 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (1148, N'son', N'Q009 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (1149, N'son', N'Q010 ')
INSERT [dbo].[Quyen] ([Id], [UserName], [IdFrm]) VALUES (1150, N'son', N'Q011 ')
SET IDENTITY_INSERT [dbo].[Quyen] OFF
GO
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP001', N'Bình sữa Pigeon nhựa PPSU cổ rộng 240ml', N'Cái', 369000, 360000, N'sp1.png', N'Chất liệu nhựa Polyphenylsulfone
Núm ti silicone siêu mềm
. Thân bình sữa có vạch đo thể tích rõ ràng thuận tiện khi pha sữa.', N'LH001')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP002', N'Bình sữa Philips Avent Natural nhựa PP BPA Free cổ rộng mô phỏng tự nhiên 260ml (SCF693/13)', N'Cái', 522000, 400000, N'sp2.png', N'Sản phẩm cao cấp, dung tích: 260ml. Chất liệu silicone & nhựa PP an toàn. Thiết kế bền đẹp, vạch đo thể tích rõ ràng.', N'LH001')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP003', N'Bình sữa Pigeon nhựa PPSU cổ rộng 160ml
', N'Cái', 275000, 100000, N'sp3.png', N'Sản phẩm cao cấp, dung tích: 260ml. Chất liệu silicone & nhựa PP an toàn. Thiết kế bền đẹp, vạch đo thể tích rõ ràng.', N'LH001')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP004', N'Bình sữa Wesser nhựa PPSU cổ hẹp 140ml', N'Cái', 369000, 360000, N'sp4.png', N'Sản phẩm cao cấp, dung tích: 260ml. Chất liệu silicone & nhựa PP an toàn. Thiết kế bền đẹp, vạch đo thể tích rõ ràng.', N'LH001')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP005', N'Bình sữa Wesser nhựa PPSU cổ hẹp 60ml', N'Cái', 369000, 360000, N'sp5.png', N'Sản phẩm cao cấp, dung tích: 260ml. Chất liệu silicone & nhựa PP an toàn. Thiết kế bền đẹp, vạch đo thể tích rõ ràng.', N'LH001')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP006', N'Bình sữa Wesser nhựa PPSU cổ hẹp 250ml', N'Cái', 369000, 360000, N'sp6.png', N'Sản phẩm cao cấp, dung tích: 260ml. Chất liệu silicone & nhựa PP an toàn. Thiết kế bền đẹp, vạch đo thể tích rõ ràng.', N'LH001')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP007', N'Bình sữa Wesser nhựa PPSU có tay cầm cổ rộng 260ml', N'Cái', 369000, 360000, N'sp7.png', N'Sản phẩm cao cấp, dung tích: 260ml. Chất liệu silicone & nhựa PP an toàn. Thiết kế bền đẹp, vạch đo thể tích rõ ràng.', N'LH001')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP008', N'Bình sữa Philips Avent Natural nhựa PP BPA Free cổ rộng mô phỏng tự nhiên 125ml (SCF690/13)', N'Cái', 369000, 360000, N'sp8.png', N'Sản phẩm cao cấp, dung tích: 260ml. Chất liệu silicone & nhựa PP an toàn. Thiết kế bền đẹp, vạch đo thể tích rõ ràng.', N'LH001')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP009', N'Bình sữa Pigeon Streamline nhựa PP BPA Free cổ hẹp 250ml', N'Cái', 369000, 360000, N'sp9.png', N'Sản phẩm cao cấp, dung tích: 260ml. Chất liệu silicone & nhựa PP an toàn. Thiết kế bền đẹp, vạch đo thể tích rõ ràng.', N'LH001')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP010', N'Bình sữa Wesser nhựa PPSU có tay cầm cổ rộng 180ml', N'Cái', 369000, 360000, N'sp10.png', N'Sản phẩm cao cấp, dung tích: 260ml. Chất liệu silicone & nhựa PP an toàn. Thiết kế bền đẹp, vạch đo thể tích rõ ràng.', N'LH001')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP011', N'Combo 2 Bình sữa Pigeon Streamline gồm 1 bình sữa 250ml', N'Cái', 369000, 360000, N'sp11.png', N'Sản phẩm cao cấp, dung tích: 260ml. Chất liệu silicone & nhựa PP an toàn. Thiết kế bền đẹp, vạch đo thể tích rõ ràng.', N'LH001')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP012', N'Bình sữa Pigeon Streamline nhựa PP BPA Free cổ hẹp 150ml', N'Cái', 369000, 360000, N'sp12.png', N'Sản phẩm cao cấp, dung tích: 260ml. Chất liệu silicone & nhựa PP an toàn. Thiết kế bền đẹp, vạch đo thể tích rõ ràng.', N'LH001')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP013', N'Bình sữa Pigeon nhựa PPSU cổ hẹp 160ml', N'Cái', 369000, 360000, N'sp13.png', N'Sản phẩm cao cấp, dung tích: 260ml. Chất liệu silicone & nhựa PP an toàn. Thiết kế bền đẹp, vạch đo thể tích rõ ràng.', N'LH001')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP014', N'Bình sữa Pigeon nhựa PP Plus BPA Free cổ rộng 240ml', N'Cái', 369000, 360000, N'sp14.png', N'Sản phẩm cao cấp, dung tích: 260ml. Chất liệu silicone & nhựa PP an toàn. Thiết kế bền đẹp, vạch đo thể tích rõ ràng.', N'LH001')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP015', N'Combo 1 Bình sữa cổ thường nhựa PP Dr Brown gồm 1 bình sữa USA', N'Cái', 369000, 360000, N'sp15.png', N'Sản phẩm cao cấp, dung tích: 260ml. Chất liệu silicone & nhựa PP an toàn. Thiết kế bền đẹp, vạch đo thể tích rõ ràng.', N'LH001')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP016', N'Bình sữa Pigeon nhựa PPSU cổ hẹp 240ml', N'Cái', 369000, 360000, N'sp16.png', N'Sản phẩm cao cấp, dung tích: 260ml. Chất liệu silicone & nhựa PP an toàn. Thiết kế bền đẹp, vạch đo thể tích rõ ràng.', N'LH001')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP017', N'Bình sữa Pigeon nhựa PP Plus BPA Free cổ rộng 160ml', N'Cái', 369000, 360000, N'sp17.png', N'Sản phẩm cao cấp, dung tích: 260ml. Chất liệu silicone & nhựa PP an toàn. Thiết kế bền đẹp, vạch đo thể tích rõ ràng.', N'LH001')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP018', N'Combo 2 Bình sữa Pigeon nhựa PP Plus cổ rộng gồm 1 bình sữa 240ml', N'Cái', 369000, 360000, N'sp18.png', N'Sản phẩm cao cấp, dung tích: 260ml. Chất liệu silicone & nhựa PP an toàn. Thiết kế bền đẹp, vạch đo thể tích rõ ràng.', N'LH001')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP019', N'Bình sữa Pigeon nhựa PP BPA Free cổ hẹp bé gái 120ml', N'Cái', 120000, 115000, N'sp19.png', N'Sản phẩm cao cấp, dung tích: 260ml. Chất liệu silicone & nhựa PP an toàn. Thiết kế bền đẹp, vạch đo thể tích rõ ràng.', N'LH001')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP020', N'Bình sữa Pigeon nhựa PP BPA Free cổ hẹp vuông 240ml', N'Cái', 130000, 125000, N'sp20.png', N'Sản phẩm cao cấp, dung tích: 260ml. Chất liệu silicone & nhựa PP an toàn. Thiết kế bền đẹp, vạch đo thể tích rõ ràng.', N'LH001')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP021', N'Bình sữa Pigeon nhựa PP BPA Free cổ hẹp bé gái 240ml', N'Cái', 100000, 90000, N'sp21.png', N'Sản phẩm cao cấp, dung tích: 260ml. Chất liệu silicone & nhựa PP an toàn. Thiết kế bền đẹp, vạch đo thể tích rõ ràng.', N'LH001')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP022', N'Bình sữa Pigeon nhựa PP Plus BPA Free cổ rộng 160ml', N'Cái', 110000, 100000, N'sp22.png', N'Sản phẩm cao cấp, dung tích: 260ml. Chất liệu silicone & nhựa PP an toàn. Thiết kế bền đẹp, vạch đo thể tích rõ ràng.', N'LH001')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP023', N'Combo 2 Bình sữa Pigeon nhựa PP Plus cổ rộng gồm 1 bình sữa 240ml..
', N'Cái', 110000, 100000, N'sp23.png', N'Sản phẩm cao cấp, dung tích: 260ml. Chất liệu silicone & nhựa PP an toàn. Thiết kế bền đẹp, vạch đo thể tích rõ ràng.', N'LH001')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP024', N'Bình sữa Dr Brown''s Options nhựa PP BPA Free cổ hẹp 120ml
', N'Cái', 115000, 110000, N'sp24.png', N'Sản phẩm cao cấp, dung tích: 260ml. Chất liệu silicone & nhựa PP an toàn. Thiết kế bền đẹp, vạch đo thể tích rõ ràng.', N'LH001')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP025', N'Bình sữa Pigeon nhựa PP BPA Free cổ hẹp bé gái 120ml', N'Cái', 125000, 120000, N'sp25.png', N'Sản phẩm cao cấp, dung tích: 260ml. Chất liệu silicone & nhựa PP an toàn. Thiết kế bền đẹp, vạch đo thể tích rõ ràng.', N'LH001')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP026', N'Bình sữa Pigeon nhựa PP BPA Free cổ hẹp vuông 120ml', N'Cái', 109000, 100000, N'sp26.png', N'Xuất xứ Hàn Quốc. Chất liệu platinum silicone cao cấp. Sử dụng cho bé từ 6M+', N'LH004')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP027', N'Núm ty Philips Avent mô phỏng tự nhiên (SCF658/23, 9M+)', N'Cái', 185000, 180000, N'sp27.png', N'Xuất xứ Hàn Quốc. Chất liệu platinum silicone cao cấp. Sử dụng cho bé từ 6M+', N'LH004')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP028', N'Ty thay bình sữa Pigeon silicone siêu mềm size L', N'Cái', 88000, 80000, N'sp28.png', N'Xuất xứ Hàn Quốc. Chất liệu platinum silicone cao cấp. Sử dụng cho bé từ 6M+', N'LH004')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP029', N'Ty thay bình sữa Pigeon silicone siêu mềm plus size L', N'Cái', 165000, 150000, N'sp29.png', N'Xuất xứ Hàn Quốc. Chất liệu platinum silicone cao cấp. Sử dụng cho bé từ 6M+', N'LH004')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP030', N'Vỉ 2 núm ty Wesser silicone cổ hẹp size +', N'Cái', 83000, 80000, N'sp30.png', N'Xuất xứ Hàn Quốc. Chất liệu platinum silicone cao cấp. Sử dụng cho bé từ 6M+', N'LH004')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP031', N'Vỉ 2 núm ty Wesser silicone cổ hẹp size L', N'Cái', 83000, 80000, N'sp31.png', N'Xuất xứ Hàn Quốc. Chất liệu platinum silicone cao cấp. Sử dụng cho bé từ 6M+', N'LH004')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP032', N'Ty thay bình sữa Pigeon silicone siêu mềm plus (size M, 3-6M)', N'Cái', 165000, 160000, N'sp32.png', N'Xuất xứ Hàn Quốc. Chất liệu platinum silicone cao cấp. Sử dụng cho bé từ 6M+', N'LH004')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP033', N'Vỉ 2 núm ty silicone Philips Avent mô phỏng tự nhiên (SCF653/23, 3-6M)', N'Cái', 185000, 180000, N'sp33.png', N'Xuất xứ Hàn Quốc. Chất liệu platinum silicone cao cấp. Sử dụng cho bé từ 6M+', N'LH004')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP034', N'Vỉ 2 núm ty Wesser silicone cổ hẹp size M', N'Cái', 83000, 80000, N'sp34.png', N'Xuất xứ Hàn Quốc. Chất liệu platinum silicone cao cấp. Sử dụng cho bé từ 6M+', N'LH004')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP035', N'Vỉ 2 núm ty silicone Philips Avent mô phỏng tự nhiên (SCF654/23, 6M+)', N'Cái', 185000, 180000, N'sp35.png', N'Xuất xứ Hàn Quốc. Chất liệu platinum silicone cao cấp. Sử dụng cho bé từ 6M+', N'LH004')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP036', N'Ty thay bình sữa silicone siêu mềm Pigeon Y, 2 cái', N'Cái', 88000, 80000, N'sp36.png', N'Xuất xứ Hàn Quốc. Chất liệu platinum silicone cao cấp. Sử dụng cho bé từ 6M+', N'LH004')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP037', N'Vỉ 2 núm ty silicone Philips Avent mô phỏng tự nhiên (SCF652/23, 1-3M)', N'Cái', 185000, 180000, N'sp37.png', N'Xuất xứ Hàn Quốc. Chất liệu platinum silicone cao cấp. Sử dụng cho bé từ 6M+', N'LH004')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP038', N'Ty thay bình sữa Pigeon silicone siêu mềm size S, 2 cái', N'Cái', 88000, 80000, N'sp38.png', N'Xuất xứ Hàn Quốc. Chất liệu platinum silicone cao cấp. Sử dụng cho bé từ 6M+', N'LH004')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP039', N'Ty thay bình sữa silicone siêu mềm Pigeon M', N'Cái', 88000, 80000, N'sp39.png', N'Xuất xứ Hàn Quốc. Chất liệu platinum silicone cao cấp. Sử dụng cho bé từ 6M+', N'LH004')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP040', N'Bình sữa Kuku nhựa PPSU cổ rộng 140ml (KU5833)', N'Cái', 88000, 80000, N'sp40.png', N'Sản phẩm cao cấp, dung tích: 260ml. Chất liệu silicone & nhựa PP an toàn. Thiết kế bền đẹp, vạch đo thể tích rõ ràng.', N'LH001')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP041', N'Bình sữa Kuku nhựa PPSU cổ rộng 140ml (KU5833)', N'Cái', 110000, 110000, N'sp41.png', N'Sản phẩm cao cấp, dung tích: 260ml. Chất liệu silicone & nhựa PP an toàn. Thiết kế bền đẹp, vạch đo thể tích rõ ràng.', N'LH001')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP042', N'Bình sữa Kuku nhựa PPSU cổ rộng 140ml (KU5833)', N'Cái', 110000, 110000, N'sp42.png', N'Sản phẩm cao cấp, dung tích: 260ml. Chất liệu silicone & nhựa PP an toàn. Thiết kế bền đẹp, vạch đo thể tích rõ ràng.', N'LH001')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP043', N'Ty thay bình sữa Pigeon silicone siêu mềm size S, 2 cái', N'Cái', 180000, 180000, N'sp43.png', N'Xuất xứ Hàn Quốc. Chất liệu platinum silicone cao cấp. Sử dụng cho bé từ 6M+', N'LH004')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP044', N'Ty thay bình sữa Pigeon silicone siêu mềm size S, 2 cái', N'Cái', 185000, 180000, N'sp44.png', N'Xuất xứ Hàn Quốc. Chất liệu platinum silicone cao cấp. Sử dụng cho bé từ 6M+', N'LH004')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP045', N'Combo 2 Túi trữ sữa Perfection 200ml (30 túi/hộp)', N'Cái', 130000, 125000, N'sp45.png', N'Cảm ứng nhiệt. Không chứa BPA. Khả năng chịu nhiệt: 110 oC ~ 200oC.', N'LH007')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP046', N'Túi trữ sữa Pur (50 túi)', N'Cái', 125000, 120000, N'sp46.png', N'Cảm ứng nhiệt. Không chứa BPA. Khả năng chịu nhiệt: 110 oC ~ 200oC.', N'LH007')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP047', N'Combo 2 Túi trữ sữa Perfection 200ml (30 túi/hộp)
', N'Cái', 120000, 115000, N'sp47.png', N'Cảm ứng nhiệt. Không chứa BPA. Khả năng chịu nhiệt: 110 oC ~ 200oC.', N'LH007')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP048', N'Túi trữ sữa Perfection 200ml (30 túi/hộp)', N'Cái', 99000, 90000, N'sp48.png', N'Cảm ứng nhiệt. Không chứa BPA. Khả năng chịu nhiệt: 110 oC ~ 200oC.', N'LH007')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP049', N'Túi trữ sữa Gluck Baby 3D Double Zip 250ml', N'Cái', 100000, 95000, N'sp49.png', N'Cảm ứng nhiệt. Không chứa BPA. Khả năng chịu nhiệt: 110 oC ~ 200oC.', N'LH007')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP050', N'Túi trữ sữa Gluck Baby 3D Double Zip 250ml', N'Cái', 100000, 95000, N'sp50.png', N'Cảm ứng nhiệt. Không chứa BPA. Khả năng chịu nhiệt: 110 oC ~ 200oC.', N'LH007')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP051', N'Túi trữ sữa Gluck Baby 3D Double Zip 260ml', N'Cái', 100000, 95000, N'sp51.png', N'Cảm ứng nhiệt. Không chứa BPA. Khả năng chịu nhiệt: 110 oC ~ 200oC.', N'LH007')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP052', N'Túi trữ sữa Gluck Baby 3D Double Zip 250ml', N'Cái', 100000, 95000, N'sp52.png', N'Cảm ứng nhiệt. Không chứa BPA. Khả năng chịu nhiệt: 110 oC ~ 200oC.', N'LH007')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP053', N'Túi trữ sữa Gluck Baby 3D Double Zip 250ml', N'Cái', 100000, 95000, N'sp53.png', N'Cảm ứng nhiệt. Không chứa BPA. Khả năng chịu nhiệt: 110 oC ~ 200oC.', N'LH007')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP054', N'Túi trữ sữa Gluck Baby 3D Double Zip 250ml', N'Cái', 100000, 95000, N'sp54.png', N'Cảm ứng nhiệt. Không chứa BPA. Khả năng chịu nhiệt: 110 oC ~ 200oC.Cảm ứng nhiệt. Không chứa BPA. Khả năng chịu nhiệt: 110 oC ~ 200oC.', N'LH007')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP055', N'Túi trữ sữa Gluck Baby 3D Double Zip 250ml', N'Cái', 100000, 95000, N'sp55.png', N'Cảm ứng nhiệt. Không chứa BPA. Khả năng chịu nhiệt: 110 oC ~ 200oC.', N'LH007')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP056', N'Túi trữ sữa Gluck Baby 3D Double Zip 250ml', N'Cái', 100000, 95000, N'sp56.png', N'Cảm ứng nhiệt. Không chứa BPA. Khả năng chịu nhiệt: 110 oC ~ 200oC.', N'LH007')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP057', N'Túi trữ sữa Gluck Baby 3D Double Zip 250ml', N'Cái', 100000, 95000, N'sp57.png', N'Cảm ứng nhiệt. Không chứa BPA. Khả năng chịu nhiệt: 110 oC ~ 200oC.', N'LH007')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP058', N'Hộp 50 túi đựng sữa Sunmum 250ml kèm 5 zipper 18x23cm', N'Cái', 90000, 85000, N'sp58.png', N'Cảm ứng nhiệt. Không chứa BPA. Khả năng chịu nhiệt: 110 oC ~ 200oC.', N'LH007')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP059', N'Túi Trữ Sữa Cảm Ứng Nhiệt Mother-K Hàn Quốc KM13012 - 90 Cái', N'Cái', 549000, 530000, N'sp59.png', N'Cảm ứng nhiệt. Không chứa BPA. Khả năng chịu nhiệt: 110 oC ~ 200oC.', N'LH007')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DonViTinh], [GiaBan], [GiaNhap], [HinhAnh], [MoTa], [MaLoai]) VALUES (N'SP060', N'Túi Trữ Sữa Mum''s Care Có Cảm Ứng Nhiệt 210ml (60 Túi/Hộp)', N'Cái', 119000, 100000, N'sp60.png', N'Cảm ứng nhiệt. Không chứa BPA. Khả năng chịu nhiệt: 110 oC ~ 200oC.', N'LH007')
GO
INSERT [dbo].[TaiKhoan] ([UserName], [HoTen], [DiaChi], [SoDienThoai], [MatKhau], [HoatDong], [PhanQuyen]) VALUES (N'chau', N'Dao Minh Chau', N'TPHCM', N'09887266', N'123', 1, 0)
INSERT [dbo].[TaiKhoan] ([UserName], [HoTen], [DiaChi], [SoDienThoai], [MatKhau], [HoatDong], [PhanQuyen]) VALUES (N'khanh', N'Huynh Ngoc Khanh', N'Binh Dinh', N'08889372', N'123', 1, 1)
INSERT [dbo].[TaiKhoan] ([UserName], [HoTen], [DiaChi], [SoDienThoai], [MatKhau], [HoatDong], [PhanQuyen]) VALUES (N'khanh1999', N'Huynh Ngoc Khanh', N'Go Vap', N'095857462', N'123', 1, 0)
INSERT [dbo].[TaiKhoan] ([UserName], [HoTen], [DiaChi], [SoDienThoai], [MatKhau], [HoatDong], [PhanQuyen]) VALUES (N'khanhhuynh', N'Khanh Huynh', N'Go Vap', N'09382636', N'123', 1, 0)
INSERT [dbo].[TaiKhoan] ([UserName], [HoTen], [DiaChi], [SoDienThoai], [MatKhau], [HoatDong], [PhanQuyen]) VALUES (N'khanhngoc', N'Huynh Ngoc Khanh', N'Tuy Phuoc', N'09827636', N'123', 1, 0)
GO
INSERT [dbo].[UserNhanVien] ([UserName], [Password], [MaNV]) VALUES (N'admin', N'8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', N'NV001')
INSERT [dbo].[UserNhanVien] ([UserName], [Password], [MaNV]) VALUES (N'anh', N'841f587994c53ef3b916e073cbaed99a5e5032959f62be2e4d96baf7334c2007', N'NV004')
INSERT [dbo].[UserNhanVien] ([UserName], [Password], [MaNV]) VALUES (N'anhhh', N'841f587994c53ef3b916e073cbaed99a5e5032959f62be2e4d96baf7334c2007', N'NV014')
INSERT [dbo].[UserNhanVien] ([UserName], [Password], [MaNV]) VALUES (N'cuong', N'841f587994c53ef3b916e073cbaed99a5e5032959f62be2e4d96baf7334c2007', N'NV006')
INSERT [dbo].[UserNhanVien] ([UserName], [Password], [MaNV]) VALUES (N'dao', N'841f587994c53ef3b916e073cbaed99a5e5032959f62be2e4d96baf7334c2007', N'NV020')
INSERT [dbo].[UserNhanVien] ([UserName], [Password], [MaNV]) VALUES (N'hoi', N'841f587994c53ef3b916e073cbaed99a5e5032959f62be2e4d96baf7334c2007', N'NV008')
INSERT [dbo].[UserNhanVien] ([UserName], [Password], [MaNV]) VALUES (N'nhi', N'841f587994c53ef3b916e073cbaed99a5e5032959f62be2e4d96baf7334c2007', N'NV003')
INSERT [dbo].[UserNhanVien] ([UserName], [Password], [MaNV]) VALUES (N'nhu', N'841f587994c53ef3b916e073cbaed99a5e5032959f62be2e4d96baf7334c2007', N'NV013')
INSERT [dbo].[UserNhanVien] ([UserName], [Password], [MaNV]) VALUES (N'son', N'841f587994c53ef3b916e073cbaed99a5e5032959f62be2e4d96baf7334c2007', N'NV019')
INSERT [dbo].[UserNhanVien] ([UserName], [Password], [MaNV]) VALUES (N'tien', N'841f587994c53ef3b916e073cbaed99a5e5032959f62be2e4d96baf7334c2007', N'NV012')
INSERT [dbo].[UserNhanVien] ([UserName], [Password], [MaNV]) VALUES (N'tuyen', N'841f587994c53ef3b916e073cbaed99a5e5032959f62be2e4d96baf7334c2007', N'NV007')
INSERT [dbo].[UserNhanVien] ([UserName], [Password], [MaNV]) VALUES (N'vi', N'841f587994c53ef3b916e073cbaed99a5e5032959f62be2e4d96baf7334c2007', N'NV005')
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonHang_DonHang] FOREIGN KEY([MaDH])
REFERENCES [dbo].[DonHang] ([MaDH])
GO
ALTER TABLE [dbo].[ChiTietDonHang] CHECK CONSTRAINT [FK_ChiTietDonHang_DonHang]
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonHang_SanPham] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[ChiTietDonHang] CHECK CONSTRAINT [FK_ChiTietDonHang_SanPham]
GO
ALTER TABLE [dbo].[ChiTietHD]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHD_HoaDon] FOREIGN KEY([MaHD])
REFERENCES [dbo].[HoaDon] ([MaHD])
GO
ALTER TABLE [dbo].[ChiTietHD] CHECK CONSTRAINT [FK_ChiTietHD_HoaDon]
GO
ALTER TABLE [dbo].[ChiTietHD]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHD_SanPham] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[ChiTietHD] CHECK CONSTRAINT [FK_ChiTietHD_SanPham]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuNhap_PhieuNhap] FOREIGN KEY([MaPN])
REFERENCES [dbo].[PhieuNhap] ([MaPN])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK_ChiTietPhieuNhap_PhieuNhap]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuNhap_SanPham] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK_ChiTietPhieuNhap_SanPham]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_TaiKhoan] FOREIGN KEY([UserName])
REFERENCES [dbo].[TaiKhoan] ([UserName])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_TaiKhoan]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien]
GO
ALTER TABLE [dbo].[Kho]  WITH CHECK ADD  CONSTRAINT [FK_Kho_SanPham] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[Kho] CHECK CONSTRAINT [FK_Kho_SanPham]
GO
ALTER TABLE [dbo].[LoaiSanPham]  WITH CHECK ADD  CONSTRAINT [FK_LoaiSanPham_NHOM] FOREIGN KEY([MaNhom])
REFERENCES [dbo].[Nhom] ([MaNhom])
GO
ALTER TABLE [dbo].[LoaiSanPham] CHECK CONSTRAINT [FK_LoaiSanPham_NHOM]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_ChucVu] FOREIGN KEY([MaCV])
REFERENCES [dbo].[ChucVu] ([MaCV])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_ChucVu]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NhaCungCap] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NhaCungCap] ([MaNCC])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NhaCungCap]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NhanVien]
GO
ALTER TABLE [dbo].[Quyen]  WITH CHECK ADD  CONSTRAINT [FK_Quyen_DMform1] FOREIGN KEY([IdFrm])
REFERENCES [dbo].[DMform] ([IDform])
GO
ALTER TABLE [dbo].[Quyen] CHECK CONSTRAINT [FK_Quyen_DMform1]
GO
ALTER TABLE [dbo].[Quyen]  WITH CHECK ADD  CONSTRAINT [FK_Quyen_UserNhanVien] FOREIGN KEY([UserName])
REFERENCES [dbo].[UserNhanVien] ([UserName])
GO
ALTER TABLE [dbo].[Quyen] CHECK CONSTRAINT [FK_Quyen_UserNhanVien]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_LoaiSanPham] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[LoaiSanPham] ([MaLoai])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_LoaiSanPham]
GO
ALTER TABLE [dbo].[UserNhanVien]  WITH CHECK ADD  CONSTRAINT [FK_UserNhanVien_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[UserNhanVien] CHECK CONSTRAINT [FK_UserNhanVien_NhanVien]
GO
/****** Object:  Trigger [dbo].[trg_DatHang]    Script Date: 1/13/2021 11:15:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_DatHang] ON [dbo].[ChiTietHD] AFTER INSERT AS 
BEGIN
	UPDATE Kho
	SET SoLuong = Kho.SoLuong - (
		SELECT SoLuong
		FROM inserted
		WHERE MaSP = Kho.MaSP
	)
	FROM Kho
	JOIN inserted ON Kho.MaSP = inserted.MaSP
END
GO
ALTER TABLE [dbo].[ChiTietHD] ENABLE TRIGGER [trg_DatHang]
GO
/****** Object:  Trigger [dbo].[them1KHnew]    Script Date: 1/13/2021 11:15:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger [dbo].[them1KHnew]	on [dbo].[KhachHang] after insert as
	begin
			declare @makh varchar(5);
		
			
			select @makh=dbo.AUTO_IDKH()

			update  KhachHang set MaKH=@makh where MaKH=''
		
			
		END

GO
ALTER TABLE [dbo].[KhachHang] ENABLE TRIGGER [them1KHnew]
GO
/****** Object:  Trigger [dbo].[them1Kho]    Script Date: 1/13/2021 11:15:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[them1Kho]	on [dbo].[Kho] after insert as
	begin
			declare @makh char(5);
		
			
			select @makh=dbo.AUTO_IDKho()

			update  Kho set MaKho=@makh where MaKho=''
		
			
		END
GO
ALTER TABLE [dbo].[Kho] ENABLE TRIGGER [them1Kho]
GO
/****** Object:  Trigger [dbo].[them1masp]    Script Date: 1/13/2021 11:15:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[them1masp]	on [dbo].[SanPham] after insert as
	begin
			declare @mapt varchar(5);
		
			
			select @mapt=dbo.AUTO_SanPham();

			update  SanPham set  MaSP=@mapt where MaSP=''
		
			
		END
GO
ALTER TABLE [dbo].[SanPham] ENABLE TRIGGER [them1masp]
GO
/****** Object:  Trigger [dbo].[themkhohangmoi]    Script Date: 1/13/2021 11:15:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[themkhohangmoi]	on [dbo].[SanPham] after insert as
	begin
			declare @mahh varchar(50);
			declare @soluong int;
			select @mahh=i.MaSP  from inserted i;
			select @soluong=0;

			insert into Kho (MaKho,MaSP,SoLuong) values('',@mahh,@soluong)
		END
GO
ALTER TABLE [dbo].[SanPham] ENABLE TRIGGER [themkhohangmoi]
GO
