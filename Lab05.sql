--LAB 5 
--BAI 1

USE master;
GO
ALTER DATABASE QL_HANGHOA SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE QL_HANGHOA;
GO



-- 1. Xóa CSDL cũ nếu tồn tại và tạo CSDL mới
DROP DATABASE IF EXISTS QL_HANGHOA;
CREATE DATABASE QL_HANGHOA;
GO

USE QL_HANGHOA;
GO

-- 2. Tạo bảng DAILY
CREATE TABLE DAILY (
    STT_DL INT PRIMARY KEY,
    TEN_DL NVARCHAR(20),
    DCHI_DL NVARCHAR(20)
);

-- 3. Tạo bảng HANGHOA
CREATE TABLE HANGHOA (
    MA_HANG NVARCHAR(3) PRIMARY KEY,
    TEN_HG NVARCHAR(20)
);

ALTER TABLE HANGHOA
ADD MA_HANG INT IDENTITY(1,1) PRIMARY KEY;

-- 4. Tạo bảng MUA
CREATE TABLE MUA (
    MA_HANG NVARCHAR(3),
    STT_DL INT,
    NGAY_MUA SMALLDATETIME DEFAULT GETDATE(),
    SOLG_MUA INT CHECK (SOLG_MUA > 0),
    TRIGIA_MUA FLOAT CHECK (TRIGIA_MUA > 0),
    PRIMARY KEY (MA_HANG, STT_DL, NGAY_MUA),
    CONSTRAINT FK_MUA_HANGHOA FOREIGN KEY (MA_HANG) REFERENCES HANGHOA(MA_HANG) ON UPDATE CASCADE ON DELETE CASCADE,
    CONSTRAINT FK_MUA_DAILY FOREIGN KEY (STT_DL) REFERENCES DAILY(STT_DL) ON UPDATE CASCADE ON DELETE CASCADE,
    CONSTRAINT CHK_NGAY_MUA CHECK (NGAY_MUA <= GETDATE())
);

-- 5. Tạo bảng BAN
CREATE TABLE BAN (
    MA_HANG NVARCHAR(3),
    STT_DL INT,
    NGAY_BAN SMALLDATETIME DEFAULT GETDATE(),
    SOLG_BAN INT CHECK (SOLG_BAN > 0),
    TRIGIA_BAN FLOAT CHECK (TRIGIA_BAN > 0),
    PRIMARY KEY (MA_HANG, STT_DL, NGAY_BAN),
    CONSTRAINT FK_BAN_HANGHOA FOREIGN KEY (MA_HANG) REFERENCES HANGHOA(MA_HANG) ON UPDATE CASCADE ON DELETE CASCADE,
    CONSTRAINT FK_BAN_DAILY FOREIGN KEY (STT_DL) REFERENCES DAILY(STT_DL) ON UPDATE CASCADE ON DELETE CASCADE,
    CONSTRAINT CHK_NGAY_BAN CHECK (NGAY_BAN <= GETDATE())
);


--câu 2


USE QL_HANGHOA;
GO

-- 1. Thêm cột SODT vào bảng DAILY
ALTER TABLE DAILY
ADD SODT CHAR(11);
GO

-- 2. Thêm 2 cột DVT và NCC vào bảng HANGHOA
ALTER TABLE HANGHOA
ADD DVT CHAR(12), NCC CHAR(30);
GO

-- 3. Tạo bảng LOAI_HG
CREATE TABLE LOAI_HG (
    MA_LOAI CHAR(2) PRIMARY KEY,
    TEN_LOAI CHAR(50)
);
GO

-- 4. Thêm cột MA_LOAI vào bảng HANGHOA
ALTER TABLE HANGHOA
ADD MA_LOAI CHAR(2);
GO

ALTER TABLE HANGHOA
ALTER COLUMN MA_LOAI CHAR(3);


-- 5. Tạo khóa ngoại tham chiếu giữa HANGHOA(MA_LOAI) và LOAI_HG(MA_LOAI)
ALTER TABLE HANGHOA
ADD CONSTRAINT FK_HANGHOA_LOAI_HG FOREIGN KEY (MA_LOAI) REFERENCES LOAI_HG(MA_LOAI)
ON UPDATE CASCADE
ON DELETE CASCADE;
GO


--Câu 3
--

/*
1. Tại sao cần nhập dữ liệu cho 2 bảng DAILY và HANGHOA trước khi nhập dữ liệu cho bảng MUA và bảng BAN?

Nguyên lý khóa ngoại: Các bảng MUA và BAN có khóa ngoại tham chiếu đến bảng DAILY và bảng HANGHOA. 
Điều này có nghĩa là mỗi giá trị trong cột STT_DL của bảng MUA phải tồn tại trong bảng DAILY, và mỗi giá trị
trong cột MA_HANG của bảng MUA phải tồn tại trong bảng HANGHOA.
Nguyên tắc nhập dữ liệu: Vì vậy, khi bạn nhập dữ liệu vào bảng MUA hoặc BAN, các giá trị của STT_DL và MA_HANG 
phải có trước trong các bảng DAILY và HANGHOA để tránh lỗi vi phạm khóa ngoại. Nếu bạn nhập vào bảng MUA hoặc BAN mà không 
có dữ liệu tương ứng trong các bảng DAILY và HANGHOA, SQL Server sẽ báo lỗi.

2. Nhập dữ liệu vào bảng MUA trước khi nhập dữ liệu vào 2 bảng DAILY và HANGHOA

Khi chúng ta thử nhập dữ liệu vào bảng MUA mà không có dữ liệu ở bảng DAILY và HANGHOA 
(ví dụ: mã hàng hoặc số thứ tự đại lý chưa có trong các bảng này), bạn sẽ nhận được thông báo lỗi từ SQL Server:

## FOREIGN KEY constraint "FK_MUA_HANGHOA" failed.->> như này 

Đây là lỗi do vi phạm ràng buộc khóa ngoại. Lý do là bảng MUA không thể tham chiếu đến các giá trị không tồn 
tại trong bảng HANGHOA và DAILY.

Ý nghĩa của CASCADE UPDATE: Ràng buộc CASCADE UPDATE có tác dụng tự động cập nhật các giá trị liên quan 
trong bảng con khi giá trị trong bảng cha (bảng có khóa chính) bị thay đổi. Ví dụ, nếu bạn thay đổi mã hàng trong bảng HANGHOA,
các bản ghi tương ứng trong bảng MUA sẽ tự động được cập nhật để giữ tính toàn vẹn.

3. Nhập dữ liệu vào bảng DAILY và HANGHOA trước rồi nhập dữ liệu vào bảng MUA và BAN

Khi bạn nhập dữ liệu vào bảng DAILY và HANGHOA trước, bạn có thể nhập dữ
liệu vào bảng MUA và BAN mà không gặp lỗi, miễn là dữ liệu bạn nhập vào bảng MUA và BAN 
tham chiếu đúng tới các giá trị trong bảng DAILY và HANGHOA.



*/

INSERT INTO DAILY (STT_DL, TEN_DL, DCHI_DL)
VALUES (1, 'Đại lý A', 'Địa chỉ A');


INSERT INTO HANGHOA (MA_HANG, TEN_HG, DVT, NCC, MA_LOAI)
VALUES ('001', 'Hàng hóa 1', 'kg', 'Nhà cung cấp 1', 'L0');


INSERT INTO MUA (MA_HANG, STT_DL, SOLG_MUA, TRIGIA_MUA)
VALUES ('001', 1, 100, 1000);

INSERT INTO BAN (MA_HANG, STT_DL, SOLG_BAN, TRIGIA_BAN)
VALUES ('001', 1, 50, 500);


select * from HANGHOA;
EXEC sp_help 'HANGHOA';


SELECT * FROM HANGHOA WHERE MA_HANG = '001';




SELECT * FROM HANGHOA WHERE MA_HANG = '001';



select * from HANGHOA;
select * from DAILY;
select * from BAN;
select * from MUA;


/*
Sửa mã hàng trong bảng HANGHOA và quan sát kết quả: Khi bạn thay đổi mã hàng trong bảng HANGHOA
(ví dụ: từ '001' thành '002'), nhờ vào ràng buộc
CASCADE UPDATE, dữ liệu tương ứng trong bảng MUA và bảng BAN sẽ được cập nhật tự động.

*/

UPDATE HANGHOA SET MA_HANG = '002' WHERE MA_HANG = '001';

 -- Sau khi thực hiện câu lệnh này, các bản ghi tương ứng trong bảng MUA và BAN cũng sẽ thay đổi mã hàng từ '001' thành '002'.

 /*
 Cascade Delete là một tính năng trong cơ sở dữ liệu quan hệ,
 đặc biệt trong các ràng buộc khóa ngoại (Foreign Key Constraints), cho phép tự động xóa các bản
 ghi trong bảng con khi bản ghi trong bảng cha bị xóa. Việc này giúp duy trì tính toàn vẹn tham chiếu
 (referential integrity) giữa các bảng trong cơ sở dữ liệu.

Lợi ích của Cascade Delete:
Giảm thiểu lỗi khi xóa dữ liệu:

Khi bạn xóa một bản ghi trong bảng cha, hệ thống tự động xóa các bản ghi tương ứng 
trong bảng con mà không cần phải thực hiện các thao tác xóa thủ công.
Điều này giúp tránh các lỗi mà người dùng có thể gặp phải khi quên xóa dữ liệu phụ thuộc trong
bảng con trước khi xóa bản ghi chính.
Duy trì tính toàn vẹn dữ liệu:

Cascade Delete giúp bảo vệ dữ liệu khỏi tình trạng dữ liệu mồ côi (orphaned data).
Khi bản ghi trong bảng cha bị xóa, các bản ghi trong bảng con không còn tham chiếu đến bản ghi bị 
xóa và do đó không gây ra lỗi tham chiếu.
Điều này đảm bảo rằng không có các bản ghi không hợp lệ tồn tại trong cơ sở dữ liệu sau khi xóa bản ghi cha.
Tiết kiệm thời gian và công sức:

Nếu bảng con có nhiều bản ghi phụ thuộc vào bảng cha, việc sử dụng Cascade Delete giúp tiết kiệm 
thời gian vì không cần phải thực hiện nhiều lệnh xóa riêng biệt.
Chỉ cần xóa một bản ghi trong bảng cha và tất cả các bản ghi liên quan trong bảng con sẽ tự động bị xóa.
Dễ dàng quản lý dữ liệu:

Đối với các hệ thống có dữ liệu phức tạp và liên kết chặt chẽ giữa các bảng, Cascade Delete
giúp quản lý các mối quan hệ giữa các bảng dễ dàng hơn, vì người dùng không cần phải xử lý thủ công các mối quan hệ phụ thuộc.
 */

 -- Bài 4: Lập trình T-SQL
 -- 

 --1. Tạo bảng product:
--Câu lệnh tạo bảng product sẽ có cấu trúc như sau:
 
 CREATE TABLE product (
    prod_nr INT NOT NULL PRIMARY KEY,
    name VARCHAR(30) NOT NULL,
    price MONEY NOT NULL,
    type VARCHAR(30) NOT NULL
);

-- 2. Thêm dữ liệu vào bảng product:
INSERT INTO product (prod_nr, name, price, type) VALUES (4, 'ColorTv', 700, 'electronic');
INSERT INTO product (prod_nr, name, price, type) VALUES (5, 'Fan', 350, 'electronic');
INSERT INTO product (prod_nr, name, price, type) VALUES (6, 'Heater', 200, 'electronic');
INSERT INTO product (prod_nr, name, price, type) VALUES (7, 'Webcam', 60, 'Computer');

-- 3. Truy vấn bảng product để quan sát dữ liệu:


SELECT * FROM product;
	
	-- 4. Tính trị giá trung bình của mỗi sản phẩm và hiển thị thông qua biến:

DECLARE @avg_price MONEY;

-- Tính trị giá trung bình
SELECT @avg_price = AVG(price) FROM product;

-- Hiển thị trị giá trung bình
PRINT 'Trị giá trung bình của các sản phẩm là: ' + CAST(@avg_price AS VARCHAR);



-- 5. Kiểm tra và tăng giá sản phẩm nếu trị giá trung bình nhỏ hơn 500:

DECLARE @avg_price MONEY;
DECLARE @count INT;

-- Tính trị giá trung bình ban đầu
SELECT @avg_price = AVG(price) FROM product;

-- Kiểm tra và thực hiện công việc tăng giá nếu cần
WHILE @avg_price < 500
BEGIN
    -- Tăng giá của mỗi sản phẩm lên 5%
    UPDATE product
    SET price = price * 1.05;

    -- Tính lại trị giá trung bình
    SELECT @avg_price = AVG(price) FROM product;

    -- Đếm số lượng sản phẩm
    SELECT @count = COUNT(*) FROM product;

    -- Hiển thị bảng giá chi tiết của mỗi sản phẩm nếu trị giá trung bình >= 500
    IF @avg_price >= 500
    BEGIN
        PRINT 'Trị giá trung bình của các sản phẩm là: ' + CAST(@avg_price AS VARCHAR);
        SELECT * FROM product;
        BREAK;
    END
END;


--1. Thủ tục tính số lượng tồn của 1 mặt hàng của 1 đại lý cụ thể
--Thủ tục này tính tổng số lượng mua và bán của một mặt hàng tại một đại lý, 
--sau đó tính số lượng tồn bằng cách lấy tổng mua trừ tổng bán.



CREATE PROCEDURE TonKho
    @STT_DL INT, 
    @Ma_Hang NVARCHAR(3),
    @TongMua INT OUTPUT, 
    @TongBan INT OUTPUT, 
    @Ton INT OUTPUT
AS
BEGIN
    -- Tính tổng số lượng mua
    SELECT @TongMua = SUM(SOLG_MUA)
    FROM MUA
    WHERE STT_DL = @STT_DL AND MA_HANG = @Ma_Hang;

    -- Kiểm tra nếu không có dữ liệu mua. nếu không có dữ liệu mua thì set nó bằng0
    IF @TongMua IS NULL
        SET @TongMua = 0;

    -- Tính tổng số lượng bán
    SELECT @TongBan = SUM(SOLG_BAN)
    FROM BAN
    WHERE STT_DL = @STT_DL AND MA_HANG = @Ma_Hang;

    -- Kiểm tra nếu không có dữ liệu bán
    IF @TongBan IS NULL
        SET @TongBan = 0;

    -- Tính tồn kho
    SET @Ton = @TongMua - @TongBan;
END;

-- và gọi thủ tục để thực thi: 
DECLARE @Mua INT, @Ban INT, @Ton INT;
EXEC TonKho 2, '001', @Mua OUTPUT, @Ban OUTPUT, @Ton OUTPUT;
PRINT 'Tổng mua: ' + CAST(@Mua AS VARCHAR(20)) +
      '. Tổng bán: ' + CAST(@Ban AS VARCHAR(20)) +
      '. Tồn: ' + CAST(@Ton AS VARCHAR(20));

-- BAI 5


--  (stored procedures) cho các yêu cầu trong Bài 5:

/*
1. Thủ tục tính số lượng tồn của 1 mặt hàng của 1 đại lý cụ thể
Thủ tục này tính tổng số lượng mua và bán của một mặt hàng tại một
đại lý, sau đó tính số lượng tồn bằng cách lấy tổng mua trừ tổng bán.
*/

sql
Copy
Edit
CREATE PROCEDURE TonKho
    @STT_DL INT, 
    @Ma_Hang NVARCHAR(3),
    @TongMua INT OUTPUT, 
    @TongBan INT OUTPUT, 
    @Ton INT OUTPUT
AS
BEGIN
    -- Tính tổng số lượng mua
    SELECT @TongMua = SUM(SOLG_MUA)
    FROM MUA
    WHERE STT_DL = @STT_DL AND MA_HANG = @Ma_Hang;

    -- Kiểm tra nếu không có dữ liệu mua
    IF @TongMua IS NULL
        SET @TongMua = 0;

    -- Tính tổng số lượng bán
    SELECT @TongBan = SUM(SOLG_BAN)
    FROM BAN
    WHERE STT_DL = @STT_DL AND MA_HANG = @Ma_Hang;

    -- Kiểm tra nếu không có dữ liệu bán
    IF @TongBan IS NULL
        SET @TongBan = 0;

    -- Tính tồn kho
    SET @Ton = @TongMua - @TongBan;
END;
Gọi thủ tục thực thi:

sql
Copy
Edit
DECLARE @Mua INT, @Ban INT, @Ton INT;
EXEC TonKho 2, '002', @Mua OUTPUT, @Ban OUTPUT, @Ton OUTPUT;
PRINT 'Tổng mua: ' + CAST(@Mua AS VARCHAR(20)) +
      '. Tổng bán: ' + CAST(@Ban AS VARCHAR(20)) +
      '. Tồn: ' + CAST(@Ton AS VARCHAR(20));
/*
2. Thủ tục bán 1 mặt hàng của một đại lý cụ thể với số lượng và đơn giá bán cho trước
Thủ tục này kiểm tra xem đại lý có đủ số lượng hàng hóa để 
bán không và nếu đủ thì thực hiện ghi dữ liệu vào bảng BAN.*/

CREATE PROCEDURE BanHang
    @STT_DL INT, 
    @Ma_Hang NVARCHAR(3), 
    @SoLgBan INT, 
    @DonGia INT
AS
BEGIN
    DECLARE @TongMua INT, @TongBan INT;

    -- Tính tổng số lượng mua
    SELECT @TongMua = SUM(SOLG_MUA)
    FROM MUA
    WHERE STT_DL = @STT_DL AND MA_HANG = @Ma_Hang;

    -- Kiểm tra nếu không có dữ liệu mua
    IF @TongMua IS NULL
    BEGIN
        PRINT 'Mặt hàng ' + @Ma_Hang + ' không có ở đại lý';
        RETURN;
    END

    -- Tính tổng số lượng bán
    SELECT @TongBan = SUM(SOLG_BAN)
    FROM BAN
    WHERE STT_DL = @STT_DL AND MA_HANG = @Ma_Hang;

    -- Nếu không có dữ liệu bán, set giá trị bằng 0
    IF @TongBan IS NULL
        SET @TongBan = 0;

    -- Kiểm tra nếu số lượng mua >= số lượng bán + số lượng bán mới
    IF @TongMua >= @TongBan + @SoLgBan
    BEGIN
        -- Thực hiện bán
        INSERT INTO BAN (MA_HANG, STT_DL, NGAY_BAN, SOLG_BAN, TRIGIA_BAN)
        VALUES (@Ma_Hang, @STT_DL, GETDATE(), @SoLgBan, @DonGia);
    END
    ELSE
    BEGIN
        PRINT 'Không đủ hàng để bán';
    END
END;


--gọi thủ tục thực thi
EXEC BanHang 2, '001', 160, 12;

-- 3. Thủ tục tính tồn kho của mỗi mặt hàng của một đại lý cụ thể

CREATE PROCEDURE TinhTonKhoCuaDaiLy
    @STT_DL INT
AS
BEGIN
    SELECT 
        M.MA_HANG, 
        H.TEN_HG,
        ISNULL(SUM(M.SOLG_MUA), 0) - ISNULL(SUM(B.SOLG_BAN), 0) AS TON_KHO
    FROM 
        MUA M
    LEFT JOIN 
        BAN B ON M.MA_HANG = B.MA_HANG AND M.STT_DL = B.STT_DL
    JOIN 
        HANGHOA H ON M.MA_HANG = H.MA_HANG
    WHERE 
        M.STT_DL = @STT_DL
    GROUP BY 
        M.MA_HANG, H.TEN_HG;
END;


-- Gọi thủ tục thực thi

EXEC TinhTonKhoCuaDaiLy 1;


-- 4. Thủ tục tính tồn kho của mỗi mặt hàng của mỗi đại lý
CREATE PROCEDURE TinhTonKhoCuaMoiDaiLy
AS
BEGIN
    SELECT 
        M.STT_DL, 
        M.MA_HANG, 
        H.TEN_HG,
        ISNULL(SUM(M.SOLG_MUA), 0) - ISNULL(SUM(B.SOLG_BAN), 0) AS TON_KHO
    FROM 
        MUA M
    LEFT JOIN 
        BAN B ON M.MA_HANG = B.MA_HANG AND M.STT_DL = B.STT_DL
    JOIN 
        HANGHOA H ON M.MA_HANG = H.MA_HANG
    GROUP BY 
        M.STT_DL, M.MA_HANG, H.TEN_HG;
END;


-- Goi procedure :
EXEC TinhTonKhoCuaMoiDaiLy;


-- 5. Thủ tục xóa hàng hóa cùng các thông tin liên quan tới hàng hóa này ở bảng BAN và MUA

CREATE PROCEDURE XoaHangHoa
    @Ma_Hang NVARCHAR(3)
AS
BEGIN
    -- Xóa dữ liệu liên quan ở bảng BAN
    DELETE FROM BAN WHERE MA_HANG = @Ma_Hang;

    -- Xóa dữ liệu liên quan ở bảng MUA
    DELETE FROM MUA WHERE MA_HANG = @Ma_Hang;

    -- Xóa dữ liệu ở bảng HANGHOA
    DELETE FROM HANGHOA WHERE MA_HANG = @Ma_Hang;
END;


-- Goi procedure:
EXEC XoaHangHoa '002';


--Bai 6 // Store Procedure 

USE Northwind; -- Hoặc tên cơ sở dữ liệu của bạn
GO

SELECT name FROM sys.databases;


--	1. Thủ tục "insert_nhanvien" để thêm một mẩu tin nhân viên vào bảng nhanvien:

CREATE TABLE nhanvien
(
    manv INT NOT NULL PRIMARY KEY,
    hoten VARCHAR(30) NOT NULL,
    diachi VARCHAR(30) NOT NULL
);

CREATE PROCEDURE insert_nhanvien
    @manv INT,
    @hoten VARCHAR(30),
    @diachi VARCHAR(30)
AS
BEGIN
    INSERT INTO nhanvien (manv, hoten, diachi)
    VALUES (@manv, @hoten, @diachi);
END;



/*
2. Thêm một mẩu tin nhân viên với nội dung sau:
manv = 1
hoten = 'Nguyen Van Thanh'
diachi = '01 Ly Tu Trong, NK– TPCT'
*/

-- Thực thi thủ tục để thêm nhân viên
EXEC insert_nhanvien 1, 'Nguyen Van Thanh', '01 Ly Tu Trong, NK– TPCT';

-- Hiển thị bảng nhanvien để kiểm tra
SELECT * FROM nhanvien;


-- 3. Thủ tục cập nhật địa chỉ của nhân viên

CREATE PROCEDURE capnhat_diachi
    @manv INT,
    @diachi VARCHAR(30)
AS
BEGIN
    UPDATE nhanvien
    SET diachi = @diachi
    WHERE manv = @manv;
END;

-- 4. Cập nhật địa chỉ của nhân viên có manv = 1 và địa chỉ mới là ‘10 Ly Tu Trong, Q. NK – TPCT’


-- Thực thi thủ tục để cập nhật địa chỉ
EXEC capnhat_diachi 1, '10 Ly Tu Trong, Q. NK – TPCT';

-- Hiển thị bảng nhanvien để kiểm tra kết quả
SELECT * FROM nhanvien;


 -- Bài 7: Store Procedure - CSDL Northwind

 -- 1. Viết thủ tục/hàm tính tiền hóa đơn với Input là ORDERID và Output là trị giá hóa đơn.
--Cách 1: Sử dụng Thủ tục (Stored Procedure)
IF OBJECT_ID('CalulateMoney_Order', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE CalulateMoney_Order;
END;
GO

CREATE PROCEDURE CalulateMoney_Order @Order_ID CHAR(5)
AS
BEGIN
    SELECT SUM(UnitPrice * Quantity - UnitPrice * Quantity * Discount) AS Total_Price
    FROM [Order Details]  -- Bao quanh tên bảng có dấu cách
    WHERE OrderId = @Order_ID;
END;
GO


--thuc thi
EXEC CalulateMoney_Order '10249';



SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Order Details';


-- Bài 8: Lập trình
-- 1. Tạo bảng Account chứa thông tin về tài khoản của 1 người với mã số tài khoản là
-- khóa chính (int); ngoài ra còn có tên tài khoản (varchar(30))
CREATE TABLE Account (
    account_number INT PRIMARY KEY,
    account_name VARCHAR(30)
);

/*
2. Viết hàm kiểm tra số tài khoản theo nguyên tắc "chia dư 11" (modulo 11 check):
Chúng ta sẽ tạo một hàm kiểm tra số tài khoản có hợp lệ hay không. 
Hàm này sẽ tính toán tổng theo công thức:
(9∗9+8∗7+7∗2+6∗4+5∗2+4∗8+3∗5+2∗7+1∗7)mod11=0
*/

IF OBJECT_ID('dbo.CheckModulo11', 'FN') IS NOT NULL
    DROP FUNCTION dbo.CheckModulo11;
GO

CREATE FUNCTION dbo.CheckModulo11 (@account_number INT)
RETURNS BIT
AS
BEGIN
    DECLARE @sum INT = 0;
    DECLARE @i INT = 9;
    DECLARE @digit INT;
	s
    -- Lặp qua từng chữ số của số tài khoản
    WHILE @account_number > 0
    BEGIN
        SET @digit = @account_number % 10;          -- Lấy chữ số cuối
        SET @sum = @sum + (@digit * @i);             -- Tính tổng
        SET @account_number = @account_number / 10;    -- Bỏ chữ số cuối
        SET @i = @i - 1;
    END;

    -- Kiểm tra xem tổng chia dư 11 có bằng 0 không
    IF (@sum % 11) = 0
    BEGIN
        RETURN 1;  -- Hợp lệ
    END
    ELSE
    BEGIN
        RETURN 0;  -- Không hợp lệ
    END;
END;
GO


--excute 
SELECT dbo.CheckModulo11(972428577) AS IsValid;  -- Kỳ vọng trả về 1 (hợp lệ)


-- 3. Định nghĩa ràng buộc toàn vẹn với CHECK CONSTRAINT
ALTER TABLE Account
ADD CONSTRAINT chk_account_number CHECK (dbo.CheckModulo11(account_number) = 1);


-- 4. Thử nghiệm

-- Thêm tài khoản hợp lệ
INSERT INTO Account (account_number, account_name)
VALUES (972428577, 'Nguyen Van A');  -- Thành công

-- Thêm tài khoản không hợp lệ
INSERT INTO Account (account_number, account_name)
VALUES (123456789, 'Nguyen Thi B');  -- Lỗi, vì không thỏa mãn điều kiện modulo 11

-- Kiểm tra xem ràng buộc CHECK có tồn tại không
SELECT * 
FROM INFORMATION_SCHEMA.CHECK_CONSTRAINTS
WHERE CONSTRAINT_NAME = 'chk_account_number';


-- Kiểm tra hàm với một số tài khoản
SELECT dbo.CheckModulo11(123456789);  -- Kỳ vọng trả về 0 vì không hợp lệ
SELECT dbo.CheckModulo11(972428577);  -- Kỳ vọng trả về 1 vì hợp lệ

