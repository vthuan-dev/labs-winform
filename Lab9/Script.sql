Create Database QLKhachHang;
Use QLKhachHang;

Create Login mylogin with password='mylogin', CHECK_POLICY = OFF;
Execute sp_changedbowner mylogin;

Create Table KhachHang (
	MaKH int not null primary key,
	TenDN nvarchar(100) not null,
	MatKhau nvarchar(100) not null,
	HoTen nvarchar(100) not null,
	NgaySinh date,
	GioiTinh bit,
	Email nvarchar(100),
	ThuNhap int,
);

ALTER TABLE KhachHang
ADD CONSTRAINT CHK_KhachHang_Email
CHECK (Email LIKE '%_@__%.__%'); --Note: SQL Server do not support complicated reg_exp syntax

Alter Table KhachHang
Add Constraint CHK_KhachHang_ThuNhap
Check (ThuNhap >= 1000000 and ThuNhap <= 50000000);

INSERT INTO KhachHang (MaKH, TenDN, MatKhau, HoTen, NgaySinh, GioiTinh, Email, ThuNhap) VALUES
	(1, 'user1', 'password1', 'Nguyen Van A', '1990-01-01', 1, 'nguyenvana@example.com', 15000000),
	(2, 'user2', 'password2', 'Tran Thi B', '1985-05-05', 0, 'tranthib@example.com', 25000000),
	(3, 'user3', 'password3', 'Le Van C', '2000-03-15', 1, 'levanc@example.com', 5000000),
	(4, 'user4', 'password4', 'Pham Thi D', '1995-12-20', 0, 'phamthid@example.com', 30000000),
	(5, 'user5', 'password5', 'Nguyen Van E', '1988-07-30', 1, 'nguyenvane@example.com', 12000000),
	(6, 'user6', 'password6', 'Hoang Van F', '1992-11-11', 1, 'hoangvanf@example.com', 18000000),
	(7, 'user7', 'password7', 'Vu Thi G', '1980-02-28', 0, 'vuthig@example.com', 22000000),
	(8, 'user8', 'password8', 'Nguyen Van H', '1996-08-16', 1, 'nguyenvanh@example.com', 35000000),
	(9, 'user9', 'password9', 'Tran Van I', '1975-04-04', 1, 'tranvani@example.com', 40000000),
	(10, 'user10', 'password10', 'Pham Van J', '1983-09-09', 1, 'phamvanj@example.com', 20000000);