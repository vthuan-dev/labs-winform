Create Database QLSV;
Use QLSV;

Create Login mylogin with password='mylogin', CHECK_POLICY = OFF;
Execute sp_changedbowner mylogin;

Create Table SinhVien(
	MaSV char(6) not null primary key,
	TenSV nvarchar(50) not null,
	Phai bit,
	Lop nvarchar(20)
);

INSERT INTO SinhVien (MaSV, TenSV, Phai, Lop) VALUES
	('B18001', N'Nguyễn Văn A', 1, N'K12A'),
	('B18002', N'Trần Thị B', 0, N'K12B'),
	('B18003', N'Phạm Minh C', 1, N'K12C'),
	('B18004', N'Lê Thị D', 0, N'K12D'),
	('B18005', N'Nguyễn Văn E', 1, N'K12E'),
	('B18006', N'Trần Văn F', 1, N'K12F'),
	('B18007', N'Phạm Thị G', 0, N'K12G'),
	('B18008', N'Lê Văn H', 1, N'K12H'),
	('B18009', N'Nguyễn Thị I', 0, N'K12I'),
	('B18010', N'Trần Minh J', 1, N'K12J');
--Delete From SinhVien;