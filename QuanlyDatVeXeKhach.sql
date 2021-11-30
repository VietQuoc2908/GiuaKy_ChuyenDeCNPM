CREATE DATABASE QuanLyBanVeXeKhach
GO
USE QuanLyBanVeXeKhach
GO

---Table
--Khách hàng
CREATE TABLE HanhKhach
(
	soDienThoai INT PRIMARY KEY,
	CMND INT NOT NULL,
	hoTen NVARCHAR(50) NOT NULL,
	gioiTinh NVARCHAR(10),
	diaChi NVARCHAR(100),
	email VARCHAR(50),
)
GO
--Tài khoản
CREATE TABLE TaiKhoan
(
	tenDangNhap VARCHAR(20) PRIMARY KEY,
	matKhau VARCHAR(20) NOT NULL,
	loaiTaiKhoan INT NOT NULL,	
	soDienThoai INT
)
GO

-- Bến Xe
CREATE TABLE BenXe
(
	maBen VARCHAR(10) PRIMARY KEY,
	tenBen NVARCHAR(50) NOT NULL,
	diaChi NVARCHAR(50) NOT NULL
)
GO

CREATE TABLE NhanVien
(
	maNV VARCHAR(10) PRIMARY KEY,
	CMND INT NOT NULL,
	hoTen NVARCHAR(50) NOT NULL,
	gioiTinh NVARCHAR(10),
	diaChi NVARCHAR(100),
	email VARCHAR(50),
)
GO



CREATE TABLE HopDongNV
(
	maBen VARCHAR(10),
	maNV VARCHAR(10),
	ngayVaoLam DATE,
	Luong FLOAT,
	PRIMARY KEY (maBen,maNV),
	FOREIGN KEY (maBen) REFERENCES dbo.BenXe(maBen),
	FOREIGN KEY (maNV) REFERENCES dbo.NhanVien(maNV)
)

-- Xe
CREATE TABLE Xe
(
	bienSo VARCHAR(10) PRIMARY KEY,
	taiXe NVARCHAR(50) NOT NULL,
	sdtTaiXe INT,
	tenXe NVARCHAR(50) NOT NULL,
)
GO

CREATE TABLE ThoiGianHoatDong
(
	bienSo VARCHAR(10),
	maBen VARCHAR(10),
	ngayKyHopDong DATETIME,
	loaiXe NVARCHAR(50),
	chietKhau FLOAT,
	PRIMARY KEY (bienSo, maBen),
	FOREIGN KEY (maBen) REFERENCES dbo.BenXe(maBen),
	FOREIGN KEY (bienSo) REFERENCES dbo.Xe(bienSo)
)
GO


--Chuyến đi
CREATE TABLE ChuyenDi
(
	maCD INT IDENTITY(102,1) PRIMARY KEY,
	gioDi VARCHAR(5),
	ngayDi DATE NOT NULL,
	diemDi NVARCHAR(20) ,
	diemDen NVARCHAR(20) ,
	giaVe FLOAT NOT NULL,
)
GO



CREATE TABLE ThongTinVeXe
(
	bienSo VARCHAR(10),
	maCD INT,
	soLuongVe INT,
	PRIMARY KEY (bienSo, maCD),
	FOREIGN KEY (bienSo) REFERENCES dbo.Xe(bienSo),
	FOREIGN KEY (maCD) REFERENCES dbo.ChuyenDi(maCD)
)
--Danh sách khách hàng đặt vé xe

CREATE TABLE DatVeXe
(
	soDienThoai INT,
	maCD INT,
	maGhe VARCHAR(3),
	thoiGianDat DATETIME NOT NULL,
	PRIMARY KEY( soDienThoai, maCD, maGhe),
	FOREIGN KEY (soDienThoai) REFERENCES dbo.HanhKhach(soDienThoai) ON UPDATE CASCADE,
	FOREIGN KEY (maCD) REFERENCES dbo.ChuyenDi(maCD) ON UPDATE CASCADE
)
GO
---STORE  PROC
--Thêm xe

CREATE PROC themXe 
(@bienSo VARCHAR(10),@taiXe NVARCHAR(50), @sdtTaiXe int, @tenXe NVARCHAR(50))
AS
BEGIN
	INSERT dbo.Xe ( bienSo, taiXe, sdtTaiXe, tenXe)
	VALUES  ( @bienSo, @taiXe, @sdtTaiXe, @tenXe)
END
GO


-- Thêm Bến Xe

CREATE PROC themBenXe 
(@maBen VARCHAR(10),@tenBen NVARCHAR(50), @diaChi NVARCHAR(50))
AS
BEGIN
	INSERT dbo.BenXe(maBen, tenBen, diaChi)
	VALUES  ( @maBen,@tenBen,@diaChi)
END
GO

-- thêm chi tiết thông tin xe

CREATE PROC themThoiGianHoatDong (@bienSo VARCHAR(10),@maBen VARCHAR(10), @ngayKyHopDong DATE,@loaiXe NVARCHAR(50), @chietKhau FLOAT)
AS
BEGIN
	INSERT dbo.ThoiGianHoatDong(bienSo, maBen, ngayKyHopDong,loaiXe,chietKhau)
	VALUES  ( @bienSo,@maBen,@ngayKyHopDong,@loaiXe,@chietKhau)
END
GO


--Thêm Hợp Đồng Nhân Viên
CREATE PROC themHopDongNV (@maBen varchar(10), @maNV varchar(10), @ngayVaoLam DATE, @luong FLOAT)
AS
BEGIN
	INSERT dbo.HopDongNV(maBen, maNV, ngayVaoLam, Luong)
	VALUES (@maBen, @maNV, @ngayVaoLam, @luong)
END
GO


--Thêm Nhân Viên
CREATE PROC themNV (@maNV varchar(10), @CMND int, @hoTen NVARCHAR(50), @gioiTinh NVARCHAR(10), @diaChi NVARCHAR(100), @email VARCHAR(50))
AS
BEGIN
	INSERT dbo.NhanVien(maNV, CMND, hoTen, gioiTinh, diaChi, email)
	VALUES (@maNV, @CMND, @hoTen, @gioiTinh, @diaChi, @email)
END
GO


--Thêm chuyến đi

CREATE PROC themChuyenDi 
(@gioDi VARCHAR(5), @ngayDi DATE, @diemDi NVARCHAR(20), @diemDen NVARCHAR(20), @giaVe FLOAT)
AS
BEGIN
	INSERT dbo.ChuyenDi(gioDi, ngayDi, diemDi, diemDen, giaVe)
	VALUES  (@gioDi, @ngayDi, @diemDi, @diemDen, @giaVe)
END
GO


--Thêm khách hàng
CREATE PROC themKH (@soDienThoai INT, @CMND int, @hoTen NVARCHAR(50), @gioiTinh NVARCHAR(10), @diaChi NVARCHAR(100), @email VARCHAR(50))
AS
BEGIN
	INSERT dbo.HanhKhach(soDienThoai, CMND, hoTen, gioiTinh, diaChi, email)
	VALUES (@soDienThoai, @CMND, @hoTen, @gioiTinh, @diaChi, @email)
END
GO


--Thêm vé xe
CREATE PROC themDatVeXe (@soDienThoai INT, @maCD INT, @maGhe VARCHAR(3), @thoiGianDat DATETIME)
AS
BEGIN
	INSERT DatVeXe(soDienThoai, maCD, maGhe, thoiGianDat )
	VALUES  (@soDienThoai, @maCD, @maGhe, @thoiGianDat)
END
GO

--thêm tài khoản

CREATE PROC themTaiKhoan (@tenDangNhap VARCHAR(20), @matKhau VARCHAR(20),@loaiTaiKhoan VARCHAR(20), @soDienThoai INT)
AS
BEGIN
	INSERT dbo.TaiKhoan(tenDangNhap, matKhau, loaiTaiKhoan,soDienThoai )
	VALUES  (@tenDangNhap, @matKhau, @loaiTaiKhoan, @soDienThoai)
END
GO

CREATE PROC themTTVeXe (@bienSo VARCHAR(20), @maCD int, @soLuongVe int)
AS
BEGIN
	INSERT dbo.ThongTinVeXe(bienSo, maCD, soLuongVe )
	VALUES  (@bienSo, @maCD, @soLuongVe)
END
GO


---Dữ liệu
--Xe
themXe '59F-61792', N'Lê Quốc Hoàng', 328893485, N'KIA'
GO
themXe '39F-81792', N'Trần Nam Thương', 123457890, N'Toyota'
GO
themXe '62M-53012', N'Nguyễn Quốc Vương', 102458079, N'Limouse'
GO
themXe '48K-10054', N'Vũ Hoàng Nam', 112589774, N'Limouse Phương Trang'
GO
themXe '66T-10054', N'Cao Bá Đạt', 857493050, N'KIA'
GO
themXe '62L-10054', N'Trần Văn Anh', 205793240, N'Limouse'
GO
themXe '74L-98754', N'Nguyễn Kim Thiện', 971528030, N'Toyota'
GO

--Chuyến đi
set dateformat mdy;
go
themChuyenDi '5h00', '12-30-2020' , N'Đồng Nai', 'LongAn', 180000
GO
themChuyenDi '6h00', '2-10-2021' , N'TP.HCM', 'Long An', 125000
GO
themChuyenDi '7h00', '2-20-2021' , N'Long An', N'Đồng Tháp', 125000
GO
themChuyenDi '8h00', '2-20-2021' , N'Đồng Tháp', N'Bảo Lộc', 250000 
GO
themChuyenDi '14h00', '2-10-2021' , N'Long An', N'Bảo Lộc', 100000
GO
themChuyenDi '14h00', '12-30-2020' , N'Bảo Lộc', N'Long An', 150000
GO
themChuyenDi '8h00', '2-10-2021' , N'Bảo Lộc', N'tp.HCM', 170000
GO
themChuyenDi '7h00', '1-18-2021' , N'Bảo Lộc', N'Đồng Nai', 180000
GO
themChuyenDi '6h00', '1-18-2021' , N'Bảo Lộc', N'Đồng Tháp', 250000 
GO
themChuyenDi '15h00', '1-18-2021' , N'Bảo Lộc', N'Đồng Tháp', 200000
GO

--Thông tin vé xe
themTTVeXe '39F-81792','102',15
GO

themTTVeXe '39F-81792','105',13
GO

themTTVeXe '48K-10054','107',14
GO

themTTVeXe '48K-10054','105',12
GO

themTTVeXe '59F-61792','103',15
GO

themTTVeXe '59F-61792','106',15
GO

themTTVeXe '62L-10054','104',12
GO

themTTVeXe '62L-10054','105',12
GO

themTTVeXe '62M-53012','108',12
GO

themTTVeXe '62M-53012','110',15
GO

themTTVeXe '66T-10054','109',12
GO

themTTVeXe '66T-10054','110',15
GO

themTTVeXe '74L-98754','106',15
GO

themTTVeXe '74L-98754','109',12
GO


--Khách hàng
themKH 918236031, 251123456, N'Phan Anh Khoa', 'Nam', 'tp.HCM', 'khoa.pa@gmail.com'
GO
themKH 123456789, 251123456, N'Hoàng Huy Nguyễn', 'Nam', 'tp.HCM', 'huy.nh@gmail.com'
GO
themKH 912839740, 251123456, N'Trịnh Hoàng Yến', N'Nữ', 'tp.HCM', 'yen.th@gmail.com'
GO
themKH 328893485, 251234501, N'Trần Hoàng Yến', N'Nữ', N'Đồng Nai', 'yen.th@gmail.com'
GO
themKH 985354980, 251234521, N'Đỗ Nguyên Thanh Tùng', N'Nam', N'Gò Vấp', 'tung.dnt@gmail.com'
GO
themKH 1662788541, 251123456, N'Trần Kim Phượng', N'Nữ', 'LA', 'phuong.tk@gmail.com'
GO
themKH 1217784103, 278591258, N'Dương Trần Tử Minh', N'Nam', N'Quận 7', 'minh.dtt@gmail.com'
GO
themKH 912839743, 251234599, N'Lê Thu Trang', N'Nữ', N'Đà Lạt', 'trang.lt@gmail.com'
GO
themKH 985657082, 251234579, N'Đỗ Trọng Nghĩa', N'Nam', N'Phan Thiết', 'nghia.dt@gmail.com'
GO
themKH 897254831, 251234578, N'Trần Thị Hoài Thu', N'Nữ', N'Bảo Lộc', 'thu.tth@gmail.com'
GO

--Tài khoản nhân viên
INSERT INTO TaiKhoan VALUES ( 'my', '123', 1, 795802685),
							( 'thu', '123', 1, 387008764),
							('918236031','251123456',0,918236031)

GO

--Vé xe

dbo.themDatVeXe 918236031, 102, 'A01', '12-20-2020'
GO
dbo.themDatVeXe 912839740, 102, 'A02', '12-20-2020'
GO
dbo.themDatVeXe 123456789, 103, 'A07', '12-20-2020'
GO
dbo.themDatVeXe 918236031, 103, 'A12', '12-20-2020'
GO
dbo.themDatVeXe 912839740, 107, 'A01', '12-20-2020'
GO
dbo.themDatVeXe 985354980, 107, 'A05', '12-20-2020'
GO
dbo.themDatVeXe 985354980, 104, 'A06', '12-20-2020'
GO
dbo.themDatVeXe 912839743, 104, 'A10', '12-20-2020'
GO
dbo.themDatVeXe 985657082, 105, 'A11', '11-20-2020'
GO
dbo.themDatVeXe 985657082, 105, 'A12', '11-20-2020'
GO
dbo.themDatVeXe 985354980, 106, 'A03', '12-20-2020'
GO
dbo.themDatVeXe 328893485, 106, 'A04', '12-20-2020'
GO
dbo.themDatVeXe 897254831, 108, 'A08', '11-20-2020'
GO
dbo.themDatVeXe 1662788541, 109, 'A09', '11-20-2020'
GO


--Nhân viên
themNV 'NV03',245244418 , N'Dương Hồng Nga', N'Nữ', N'Bình Dương', 'ngadh@gmail.com'
GO

themNV 'NV04',340675279 , N'Nguyễn Kim Phương', N'Nữ', N'Đà Nẵng', 'phuongnk@gmail.com'
GO

themNV 'NV05',340943317 , N'Võ Thị Uyên', N'Nữ', N'TPHCM', 'uyenvt@gmail.com'
GO

themNV 'NV01',340692492 , N'Nguyễn Thành Minh', N'Nam', N'TPHCM', 'minhnt@gmail.com'
GO

themNV 'NV02',194566527 , N'Hoàng Vương Quốc', N'Nam', N'Tây Ninh', 'quochv@gmail.com'
GO


--Bến Xe
themBenXe 'BXLD', N'Bến xe Lộc Điền', N'113 Ngô Quyền, Phường 12, Quận 5, TPHCM'
GO


--Hợp đồng nhân viên	[maBen],[maNV],[ngayVaoLam],[Luong]
set dateformat mdy;
go
themHopDongNV 'BXLD', 'NV01', '2017-05-03', 6000000
GO

themHopDongNV 'BXLD', 'NV02', '2016-09-12', 5000000
GO

themHopDongNV 'BXLD', 'NV03', '2017-11-07', 5500000
GO

themHopDongNV 'BXLD', 'NV04', '2019-02-26', 6500000
GO

themHopDongNV 'BXLD', 'NV05', '2018-04-09', 5000000
GO

-------------------------------------các lệnh check, default---------------------

ALTER TABLE HopDongNV
ADD CONSTRAINT NV_Luong CHECK(Luong >= 2000000 )

ALTER TABLE HopDongNV
ADD CONSTRAINT HDNV_NgayVaoLam DEFAULT GETDATE() FOR ngayVaoLam

ALTER TABLE BenXe
ADD CONSTRAINT BenXe_TenBen UNIQUE(TenBen)

ALTER TABLE ChuyenDi
ADD CONSTRAINT CD_NgayDi DEFAULT GETDATE() FOR NgayDi

ALTER TABLE ChuyenDi
ADD CONSTRAINT CD_giaVe CHECK(giaVe >= 10000 )

ALTER TABLE DatVeXe
ADD CONSTRAINT DatVeXe_soDienThoai CHECK(soDienThoai >=100000000)

ALTER TABLE NHANVIEN
ADD CONSTRAINT NV_GIOITINHNV CHECK(gioiTinh = N'Nữ' OR gioiTinh= N'Nam' OR gioiTinh=N'Khác')

ALTER TABLE NHANVIEN
ADD CONSTRAINT NhanVien_email UNIQUE(email)

ALTER TABLE ThoiGianHoatDong
ADD CONSTRAINT tghd_Ngaykhd DEFAULT GETDATE() FOR ngayKyHopDong

ALTER TABLE ThongTinVeXe
ADD CONSTRAINT TT_VX CHECK(soLuongVe >0)

------------------------------trigger--------------------------------

--cập nhật lại  trong kho sau khi hủy hóa đơn
go

