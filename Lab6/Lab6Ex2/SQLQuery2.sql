Create database QLCB;
Use QLCB;

Create Table CanBo(
	MaCB int Primary Key,
	TenCB nvarchar(100) Not Null,
	ChucVuCB int Not Null,
	SoGioGiang int Not Null,
	DonGia money Not Null,
	CONSTRAINT FK_ChucVuCB FOREIGN KEY (ChucVuCB) REFERENCES ChucVu(MaCV)
)	

Create Table ChucVu(
	MaCV int Primary Key,
	TenCV nvarchar(100) Not Null
)

delete from ChucVu where MaCV = 2;
insert into ChucVu values (1, N'Gi?ng viên'), (2, N'Tr? gi?ng');