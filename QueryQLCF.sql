create database checkQLCF
go
use checkQLCF
go

CREATE TABLE PersonTable
(
   PersonID INT IDENTITY PRIMARY KEY,
   Name NVARCHAR(100) NOT NULL ,
   Type NVARCHAR(1000) ,
   PhoneNumber NVARCHAR(15)
)
GO
CREATE TABLE Account
(
   UserName NVARCHAR(100) PRIMARY KEY,
   PassWord NVARCHAR(100),
   PersonID INT,
   FOREIGN KEY (PersonID)
   REFERENCES PersonTable (PersonID),
   TypeAcc INT,
)
go


CREATE TABLE Drink
(
   IDdrink INT IDENTITY PRIMARY KEY ,
   Name NVARCHAR(100) NOT NULL ,
   Price INT NOT NULL
)
DBCC CHECKIDENT( Drink, RESEED, 0);
go

CREATE TABLE Inventory 
(
   IDdrink INT primary key REFERENCES Drink (IDdrink),
   Name NVARCHAR (150),
   Amount INT
)
GO
DBCC CHECKIDENT( PersonTable, RESEED, 0);
INSERT INTO PersonTable (Name, Type,PhoneNumber) 
VALUES (N'Nguyễn Đình Hòa','Manager','0966'); 

INSERT INTO PersonTable (Name, Type,PhoneNumber) 
VALUES (N'Lê Thái Hưng','Manager','09153'); 

INSERT INTO PersonTable (Name, Type,PhoneNumber) 
VALUES (N'Trần Linh Tâm','Barista','076317'); 
INSERT INTO PersonTable (Name, Type,PhoneNumber) 
VALUES (N'Nguyễn Văn A','Decommissioning','0763'); 
INSERT INTO PersonTable
VALUES (N'Ngô Huyền Diệu','Barista','090')
GO

INSERT INTO Account(UserName,PassWord,PersonID,TypeAcc) 
VALUES ('lethaihung','n12345678',1,1); 
GO
INSERT INTO Account(UserName,PassWord,PersonID,TypeAcc) 
VALUES ('nguyenvana','1234',3,1); 
INSERT INTO Account
VALUES ('Ngô Huyền Diệu','1234',4,2)
GO
INSERT INTO Account (UserName,PassWord,PersonID,TypeAcc)
VALUES ('nguyendinhhoa','n12345678',0,1)
INSERT INTO Account (UserName,PassWord,PersonID,TypeAcc)
VALUES ('tranlinhtam','1234',2,2)


CREATE TABLE SaleReport
(
   idReport INT IDENTITY PRIMARY KEY,
   DaySaleReport DATE NOT NULL,
   CollectMoney int,
   SpendMoney int,
   TotalMoney int,
   TotalBill int,
)
insert into Drink
values 
	('Cafe den da',20000),
	('Cafe den nong',20000),
	('Cafe sua da',25000),
	('Cafe sua nong',25000),
	('Bac xiu',35000);
go

insert into Inventory
values 
	(0,'Cafe den da',100),
	(1,'Cafe den nong',100),
	(2,'Cafe sua da',100),
	(3,'Cafe sua nong',100),
	(4,'Bac xiu',100);
go

CREATE TABLE TableDrink
(
   id INT IDENTITY PRIMARY KEY,
   nameTable NVARCHAR(100) NOT NULL Default N'Bàn chưa có tên',
   statusTable NVARCHAR(100) NOT NULL DEFAULT N'Trống'  --TRỐNG / CÓ NGƯỜI 
)

INSERT INTO dbo.TableDrink(nameTable) VALUES (N'Bàn 1')
INSERT INTO dbo.TableDrink(nameTable) VALUES (N'Bàn 2')
INSERT INTO dbo.TableDrink(nameTable) VALUES (N'Bàn 3')
INSERT INTO dbo.TableDrink(nameTable) VALUES (N'Bàn 4')
INSERT INTO dbo.TableDrink(nameTable) VALUES (N'Bàn 5')
INSERT INTO dbo.TableDrink(nameTable) VALUES (N'Bàn 6')
INSERT INTO dbo.TableDrink(nameTable) VALUES (N'Bàn 7')
INSERT INTO dbo.TableDrink(nameTable) VALUES (N'Bàn 8')
INSERT INTO dbo.TableDrink(nameTable) VALUES (N'Bàn 9')
INSERT INTO dbo.TableDrink(nameTable) VALUES (N'Bàn 10')
INSERT INTO dbo.TableDrink(nameTable) VALUES (N'Bàn 11')
INSERT INTO dbo.TableDrink(nameTable) VALUES (N'Bàn 12')



CREATE TABLE Bill
(
   IDBill INT IDENTITY PRIMARY KEY,
   TableNumber INT not Null REFERENCES  TableDrink(id) ,
   DateCheck Date NOT NULL DEFAULT GETDATE(),
   StatusBill int default 0,
   discount int default 0,
   TotalPrice int default 0,
)
go

insert into Bill 
values
	(1,'11-9-2023',1,0,0),
	(2,'10-9-2023',1,0,0),
	(2,'11-9-2023',1,0,0);
go
insert into Bill 
values
	(1,'11-9-2023',0,0,0),
	(2,'10-9-2023',0,0,0),
	(2,'11-9-2023',0,0,0);
go

create table BillInfo
(
	IDBillInfo int identity primary key,
	IDBill int,
	IDdrink INT REFERENCES Drink(IDdrink),
	Drinkcount INT,
	statusBillInfo int default 0,
	BaristaServe NVARCHAR(150),
	CustomerName NVARCHAR(150),
	foreign key (IDBill) references Bill(IDBill)
)
go
insert BillInfo
values 
(2 , 1,2,0,N'Trần Linh Tâm','Nguyen Dinh Hoa'),
(6 , 1,2,0,N'Trần Linh Tâm','Nguyen Dinh Hoa')
go



create table Feedback
(
	IDBill int primary key,
	CustomerName nvarchar(50) ,
	Detail nvarchar(300)
)
go
----
CREATE PROC USP_InsertFeedback @IDBill INT , @CustomerName NVARCHAR(50), @Detail NVARCHAR(300)
AS
BEGIN 
   INSERT INTO dbo.Feedback VALUES (@IDBill,@CustomerName,@Detail)
END


--Tạo PROC lấy danh sách TableDrink
GO
CREATE PROC USP_GetTableList
AS 
BEGIN 
    SELECT * FROM dbo.TableDrink
END

-- Dinh hoa code--

create proc USP_GetDrinkByDrinkName
@DrinkName NVarChar(100)
as  
begin
	Select * from Drink where Name=@DrinkName
end
create proc USP_GetIdTableByName
@DrinkName NVarChar(100)
as  
begin
	Select IDdrink from Drink where Name=@DrinkName
end
go

create proc USP_GetBillListByDate
@DateCheck Date
as begin
select IDBill as [ID], TableDrink.nameTable as [Table],TotalPrice from Bill inner join TableDrink on Bill.TableNumber=TableDrink.id 
where Bill.StatusBill= 1 and  DateCheck=@DateCheck 
end

create proc USP_GetSalesReportListByDate
@DateCheck Date
as begin
select TotalBill as[Total Bill],CollectMoney as [Collected Money], SpendMoney as[Spend Money],TotalMoney as [ToTal Money] from SaleReport 
where DaySaleReport=@DateCheck
end

create proc USP_GetBillInfoByIDBill
@IDBill int
as 
begin
select Drink.Name as[Drink],Drink.Price,Drinkcount as[Amount],BaristaServe as[Barista Serve], BillInfo.CustomerName as [Customer Name]
from BillInfo inner join Drink on Drink.IDdrink=BillInfo.IDdrink inner join Bill on Bill.IDBill=BillInfo.IDBill inner join TableDrink on TableDrink.id=Bill.TableNumber 
Where Bill.IDBill=@IDBill
end
 
create proc USP_InsertSaleReport
@Day date, @CollectedMoney int, @SpendMoney int,@TotalMoney int,@TotalBill int
as 
begin
insert into SaleReport
values
	(@Day,@CollectedMoney,@SpendMoney,@TotalMoney,@TotalBill)
end 

create proc USP_UpdateSaleReport
@Day date,@CollectedMoney int, @TotalMoney int,@TotalBill int
as
begin
update SaleReport set CollectMoney=@CollectedMoney,TotalMoney=@TotalMoney,TotalBill=@TotalBill where DaySaleReport=@Day
end

create proc USP_GetTypeByUserName
@username NVARCHAR(100)
as
begin
	select TypeAcc from Account where UserName=@username
end
 
 CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END

 -- Le Hung code--
 CREATE PROC USP_STATUS @userName NVARCHAR(100) , @passWord NVARCHAR(100)
AS
BEGIN 
SELECT TypeAcc FROM Account Where UserName=@userName AND PassWord=@passWord
END


select * from Account
 CREATE PROC USP_Login
@userName nvarchar(100),@passWord nvarchar(100)
AS
BEGIN 
  SELECT *FROM dbo.Account WHERE UserName=@userName AND PassWord=@passWord
END


CREATE PROC USP_STATUS
@userName nvarchar(100),@passWord nvarchar(100)
AS
BEGIN 
  SELECT Account.TypeAcc FROM dbo.Account WHERE UserName=@userName AND PassWord=@passWord
END

create PROC USP_InsertBill 
@TableNumber INT ,@StatusBill INT
AS 
BEGIN 
  INSERT INTO Bill (TableNumber,StatusBill)
  Values (@TableNumber,@StatusBilL)
END
go

CREATE PROC USP_InsertBillInfo
@IDBill INT, @IDdrink INT, @DrinkCount INT, @CustomerName NVARCHAR(100)
AS
    BEGIN
        -- Chèn thông tin mới
        INSERT INTO dbo.BillInfo (IDBill, IDdrink, DrinkCount, CustomerName) VALUES (@IDBill, @IDdrink, @DrinkCount, @CustomerName)
    END


CREATE PROC USP_PersonLogin
@Name nvarchar(100),@Type nvarchar(100)
AS
BEGIN 
   INSERT INTO dbo.PersonTable(Name,Type) VALUES (@Name,@Type)
END

CREATE PROC USP_GetTableList
AS 
BEGIN 
    SELECT * FROM dbo.TableDrink
END

CREATE TRIGGER UTG_UpdateBillInfo
ON BillInfo FOR INSERT,UPDATE
AS
BEGIN
    DECLARE @idBill INT
	SELECT @idBill= IDBill FROM Inserted 

	DECLARE @idTable INT 
	SELECT @idTable = TableNumber FROM Bill WHERE IDBill = @idBill and StatusBill =0

	UPDATE TableDrink SET statusTable=N'Có người' WHERE id = @idTable
END

CREATE TRIGGER UTG_UpdateBill
ON Bill FOR Update 
AS
BEGIN 
     DECLARE @idBill INT 
     SELECT @idBill = IDBill FROM inserted

     DECLARE @idTable INT 
     SELECT @idTable = TableNumber FROM Bill WHERE IDBill = @idBill 

	 DECLARE @count int =0
	 SELECT @count = COUNT(*) FROM Bill WHERE TableNumber = @idTable and StatusBill =0
	 IF(@count = 0)
	   UPDATE TableDrink SET statusTable=N'Trống' WHERE id=@idTable
END

--test query--
