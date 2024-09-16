USE QL_HocVien
GO

-- Bảng Học viên (SinhViens)
CREATE TABLE HocVien (
    MaHocVien VARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(255),
    NgaySinh DATE,
    GioiTinh NvarCHAR(3),
    DiaChi NVARCHAR(255),
    SoDienThoai CHAR(15),
    Email VARCHAR(255),
    NgayDangKy DATE,
    TrangThaiHocVien NVARCHAR(50),
   
);
GO

-- Bảng Khóa học (KhoaHocs)
CREATE TABLE KhoaHoc(
    MaKhoaHoc VARCHAR(10) PRIMARY KEY,
    TenKhoaHoc NVARCHAR(255),
    MoTa Nvarchar(255),
    HocPhi DECIMAL(10,2),
    ThoiGianHoc NVARCHAR(50),
    NgayBatDau DATE,
    NgayKetThuc DATE,
);
GO

-- Bảng Đăng ký học (DangKyHocs)
CREATE TABLE DangKyHoc (
    MaDangKy VARCHAR(10) PRIMARY KEY,
    MaHocVien VARCHAR(10),
    MaKhoaHoc VARCHAR(10),
    NgayDangKy DATE,
    FOREIGN KEY (MaHocVien) REFERENCES HocVien(MaHocVien),
    FOREIGN KEY (MaKhoaHoc) REFERENCES KhoaHoc(MaKhoaHoc)
);
GO

-- Bảng Điểm danh (DiemDanhs)
CREATE TABLE DiemDanh (
    MaDiemDanh VARCHAR(10) PRIMARY KEY,
    MaDangKy VARCHAR(10),
    NgayDiemDanh DATE,
    BuoiHoc NVARCHAR(50),
    TrangThai NVARCHAR(50),
    LyDoVangMat NVARCHAR(255),
    FOREIGN KEY (MaDangKy) REFERENCES DangKyHoc(MaDangKy)
);
GO

-- Bảng Giảng viên (GiangViens)
CREATE TABLE GiangVien (
    MaGiangVien VARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(255),
    GioiTinh NvarCHAR(3),
    DiaChi NVARCHAR(255),
    SoDienThoai CHAR(15),
    Email VARCHAR(255),
    TrinhDoHocVan NVARCHAR(255)
);
GO

-- Bảng Điểm (Diems)
CREATE TABLE Diem (
    MaDiem VARCHAR(10) PRIMARY KEY,
    MaHocVien VARCHAR(10),
    MaKhoaHoc VARCHAR(10),
    DiemTong DECIMAL(5,2),
    DiemLyThuyet DECIMAL(5,2),
    DiemThucHanh DECIMAL(5,2),
    XepLoai NVARCHAR(50),
    FOREIGN KEY (MaHocVien) REFERENCES HocVien(MaHocVien),
    FOREIGN KEY (MaKhoaHoc) REFERENCES KhoaHoc(MaKhoaHoc)
);
GO
-- Bảng Lớp (Lops)
CREATE TABLE Lop (
    MaLop VARCHAR(10) PRIMARY KEY,
    TenLop NVARCHAR(255),
    MaKhoaHoc VARCHAR(10),
    
    
);
GO



-- Bảng Thanh toán học phí (ThanhToanHocPhis)
CREATE TABLE ThanhToanHocPhi (
    MaThanhToan VARCHAR(10) PRIMARY KEY,
    MaDangKy VARCHAR(10),
    NgayThanhToan DATE,
    SoTien DECIMAL(10,2),
    PhuongThucThanhToan NVARCHAR(50),
    TrangThaiHocPhi NVARCHAR(50),
    FOREIGN KEY (MaDangKy) REFERENCES DangKyHoc(MaDangKy)
);
GO



-- Bảng Lịch học (LichHocs)
CREATE TABLE LichHoc (
    MaLichHoc VARCHAR(10) PRIMARY KEY,
    MaKhoaHoc VARCHAR(10),
    MaGiangVien VARCHAR(10),
	MaLop VARCHAR(10),
    NgayHoc DATE,
    GioBatDau TIME,
    GioKetThuc TIME,
    FOREIGN KEY (MaKhoaHoc) REFERENCES KhoaHoc(MaKhoaHoc),
    FOREIGN KEY (MaGiangVien) REFERENCES GiangVien(MaGiangVien),
	FOREIGN KEY (MaLop) REFERENCES Lop(MaLop)
);
GO





-------------------------------------dl cho các bảng
INSERT INTO HocVien (MaHocVien, HoTen, NgaySinh, GioiTinh, DiaChi, SoDienThoai, Email, NgayDangKy, TrangThaiHocVien)
VALUES 
    ('HV001', N'Nguyễn Văn Minh', '2000-01-01', N'Nam', N'Hà Nội', '123456789', 'nguyenvanminh@gmail.com', '2023-01-01', N'Đang học'),
    ('HV002', N'Nguyễn Thị Hòa', '1999-05-15', N'Nữ', N'Hồ Chí Minh', '987654321', 'nguyenthihoa@gmail.com', '2023-02-15', N'Nghỉ học'),
    ('HV003', N'Trần Văn Đảo', '2001-08-20', N'Nam', N'Đà Nẵng', '111222333', 'tranvandao@gmail.com', '2023-03-20', N'Đang học'),
    ('HV004', N'Lê Thị Thùy Dương', '1998-12-10', N'Nữ', N'Hải Phòng', '555666777', 'lethidd@gmail.com', '2023-04-10', N'Đang học'),
    ('HV005', N'Phạm Văn An', '2002-03-25', N'Nam', N'Cần Thơ', '999000111', 'phamvana@gmail.com', '2023-05-25', N'Nghỉ học');
GO

INSERT INTO KhoaHoc (MaKhoaHoc, TenKhoaHoc, MoTa, HocPhi, ThoiGianHoc, NgayBatDau, NgayKetThuc)
VALUES 
    ('KH001', N'Lập trình Java', N'Khóa học về lập trình Java cơ bản', 1500000.00, N'2 tháng', '2023-01-15', '2023-03-15'),
    ('KH002', N'Tiếng Anh cơ bản', N'Khóa học tiếng Anh cho người mới học', 1200000.00, N'3 tháng', '2023-02-10', '2023-05-10'),
    ('KH003', N'Marketing online', N'Khóa học về kỹ thuật marketing trực tuyến', 1800000.00, N'2.5 tháng', '2023-03-20', '2023-06-10'),
    ('KH004', N'Design đồ họa', N'Khóa học về thiết kế đồ họa', 2000000.00, N'3 tháng', '2023-04-05', '2023-07-05'),
    ('KH005', N'Quản trị dự án', N'Khóa học về quản lý dự án', 2200000.00, N'2 tháng', '2023-05-15', '2023-07-15');
Go


INSERT INTO DangKyHoc (MaDangKy, MaHocVien, MaKhoaHoc, NgayDangKy)
VALUES 
    ('DKH001', 'HV001', 'KH001', '2023-01-02'),
    ('DKH002', 'HV002', 'KH002', '2023-02-20'),
    ('DKH003', 'HV003', 'KH003', '2023-03-25'),
    ('DKH004', 'HV004', 'KH004', '2023-04-12'),
    ('DKH005', 'HV005', 'KH005', '2023-05-18');
GO





INSERT INTO GiangVien (MaGiangVien, HoTen, GioiTinh, DiaChi, SoDienThoai, Email, TrinhDoHocVan)
VALUES 
    ('GV001', N'Nguyễn Thị Giang', N'Nữ', N'Hà Nội', '123456789', 'giangnt@gmail.com', N'Tiến sĩ'),
    ('GV002', N'Phạm Văn Minh', N'Nam', N'Hồ Chí Minh', '987654321', 'minhpv@gmail.com', N'Thạc sĩ'),
    ('GV003', N'Lê Thị Hương', N'Nữ', N'Đà Nẵng', '111222333', 'huonglt@gmail.com', N'Tiến sĩ'),
    ('GV004', N'Trần Văn Hòa', N'Nam', N'Hải Phòng', '555666777', 'hoatv@gmail.com', N'Thạc sĩ'),
    ('GV005', N'Nguyễn Văn Tâm', N'Nam', N'Cần Thơ', '999000111', 'tamnv@gmail.com', N'Tiến sĩ');
Go

INSERT INTO Diem (MaDiem, MaHocVien, MaKhoaHoc,DiemLyThuyet, DiemThucHanh, DiemTong , XepLoai)
VALUES 
    ('D001', 'HV001', 'KH001', 8.5, 8.5, 8.5, N'Giỏi'),
    ('D002', 'HV002', 'KH002', 6.0, 5.5, 5.7, N'Trung bình'),
    ('D003', 'HV003', 'KH003', 9.5, 8.5, 9.0, N'Xuất sắc'),
    ('D004', 'HV004', 'KH004', 7.5, 10.0, 8.8, N'Khá'),
    ('D005', 'HV005', 'KH005', 5.5, 5.0, 5.3, N'Trung bình');
Go

INSERT INTO Lop (MaLop, TenLop, MaKhoaHoc)
VALUES 
    ('L001', N'Lớp Java A1', 'KH001' ),
    ('L002', N'Lớp Tiếng Anh B2', 'KH002'),
    ('L003', N'Lớp Marketing C3', 'KH003'),
    ('L004', N'Lớp Design D4', 'KH004'),
    ('L005', N'Lớp Quản trị dự án E5', 'KH005');
Go


INSERT INTO ThanhToanHocPhi (MaThanhToan, MaDangKy, NgayThanhToan, SoTien, PhuongThucThanhToan, TrangThaiHocPhi)
VALUES 
    ('TTHP001', 'DKH001', '2023-01-15', 1200000.00, N'Transfer', N'Đã thanh toán'),
    ('TTHP002', 'DKH002', '2023-03-01', 1000000.00, N'Cash', N'Đã thanh toán'),
    ('TTHP003', 'DKH003', '2023-04-10', 1500000.00, N'Credit Card', N'Chưa thanh toán'),
    ('TTHP004', 'DKH004', '2023-05-20', 2000000.00, N'Credit Card', N'Chưa thanh toán'),
    ('TTHP005', 'DKH005', '2023-06-05', 1800000.00, N'Transfer', N'Đã thanh toán');
Go

INSERT INTO LichHoc (MaLichHoc, MaKhoaHoc, MaGiangVien, MaLop, NgayHoc, GioBatDau, GioKetThuc)
VALUES 
    ('LH001', 'KH001', 'GV001','L001', '2023-01-20', '08:00:00', '10:00:00'),
    ('LH002', 'KH002', 'GV002','L002' ,'2023-02-25', '10:30:00', '12:30:00'),
    ('LH003', 'KH003', 'GV003','L003','2023-03-30', '13:30:00', '15:30:00'),
    ('LH004', 'KH004', 'GV004', 'L004' ,'2023-04-15', '16:00:00', '18:00:00'),
    ('LH005', 'KH005', 'GV005','L005' ,'2023-05-10', '08:30:00', '10:30:00');
Go
DROP TABLE IF EXISTS LichHoc;
DROP TABLE IF EXISTS ThanhToanHocPhi;
DROP TABLE IF EXISTS Lop;
DROP TABLE IF EXISTS Diem;
DROP TABLE IF EXISTS GiangVien;
DROP TABLE IF EXISTS DiemDanh;
DROP TABLE IF EXISTS DangKyHoc;
DROP TABLE IF EXISTS KhoaHoc;
DROP TABLE IF EXISTS HocVien;

CREATE table NHANVIEN
(
 TENTAIKHOAN VARCHAR(10) PRIMARY KEY,
 MATKHAU NVARCHAR(30),
 LOAITAIKHOAN int,
)
insert into (TENTAIKHOAN,MATKHAU,LOAITAIKHOAN)
values    
       ('admin1',N'123',1),
	   ('user1',N'123',0);



INSERT INTO LichHoc (MaLichHoc, MaKhoaHoc, MaGiangVien, MaLop, NgayHoc, GioBatDau, GioKetThuc, MaPhong)
VALUES 
    ('LH006', 'KH001', NULL,NULL, '2023-01-20', '08:00:00', '10:00:00', 'PH001'),
	('LH007', 'KH001', NULL,NULL, '2023-01-20', '08:00:00', '10:00:00', 'PH001'),
	('LH008', 'KH001', NULL,NULL, '2023-01-20', '08:00:00', '10:00:00', 'PH001');

	update LichHoc set MaGiangVien='GV001',MaLop ='L003',LoaiBuoiHoc=N'Thực Hành' where MaLichHoc='LH006'

	select hv.HoTen,kh.TenKhoaHoc, d.DiemLyThuyet, d.DiemThucHanh, d.DiemTong, d.XepLoai from Diem d, HocVien hv, KhoaHoc kh where hv.MaHocVien = d.MaHocVien and d.MaKhoaHoc = kh.MaKhoaHoc