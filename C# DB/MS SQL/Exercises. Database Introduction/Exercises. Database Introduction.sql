CREATE DATABASE [Minions]

USE [Minions]

--CREATE TABLE [Minions](
--	[Id] INT NOT NULL,
--	[Name] NVARCHAR(50) NOT NULL, 
--	[Age] INT
--)

ALTER TABLE [MINIONS]
ADD CONSTRAINT PK_MinionsId PRIMARY KEY (Id)

DROP TABLE [Minions]

CREATE TABLE [Towns](
	[Id] INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
)

--Problem 3
ALTER TABLE [Minions]
ADD [TownId] INT

ALTER TABLE [Minions]
ADD CONSTRAINT [FK_MinionsTownId] FOREIGN KEY ([TownId]) REFERENCES [Towns]([Id])

--Problem 4
INSERT INTO [Towns]([Id], [Name]) VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO [Minions]([Id], [Name], [Age], [TownId]) VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

--Problem 5
TRUNCATE TABLE [Minions] 

--Problem 6
DROP TABLE [Minions]
DROP TABLE [Towns]

--Problem 7
CREATE TABLE [People](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX) CHECK (DATALENGTH(Picture) <= 2 * 1024 * 1024),
	[Height] DECIMAL(10, 2),
	[Weight] DECIMAL(10, 2),
	[Gender] CHAR CHECK(Gender = 'm' OR Gender = 'f') NOT NULL,
	[Birthdate] DATETIME2 NOT NULL,
	[Biography] NVARCHAR(MAX)
)

INSERT INTO [People]([Name], [Gender], [Birthdate]) VALUES
('Pesho', 'm', '12.30.2000'),
('Gosho', 'm', '12.30.2002'),
('Tosho', 'm', '12.30.2003'),
('Pesho', 'f', '12.30.2005'),
('Elizabeth', 'f', '12.30.2006')

--Problem 8
CREATE TABLE [Users](
	[Id] BIGINT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX),
	CHECK (DATALENGTH([ProfilePicture]) <= 900000),
	[LastLoginTime] DATETIME2,
	[IsDeleted] BIT NOT NULL
)

INSERT INTO [Users]([Username], [Password], [IsDeleted]) VALUES
('das', 'xzv', 1),
('gdf', '34', 0),
('cvb', 'wer', 1),
('eqw', 'eqw', 0),
('jgh', 'ad', 1)

--Problem 9
ALTER TABLE [Users]
DROP CONSTRAINT [PK__Users__3214EC07375878FF]

ALTER TABLE [Users]
ADD CONSTRAINT [PK_UsersCompositeIdUsername] PRIMARY KEY([Id], [Username])


--Problem 10
ALTER TABLE [Users]
ADD CHECK (LEN([Password]) >= 5)

--Problem 11
ALTER TABLE [Users]
ADD CONSTRAINT [DF_LastLoginTime] DEFAULT GETDATE() FOR [LastLoginTime]

--Problem 12
ALTER TABLE [Users]
DROP CONSTRAINT [PK_UsersCompositeIdUsername]

ALTER TABLE [Users]
ADD CONSTRAINT [PK_UsersId] PRIMARY KEY([Id])

ALTER TABLE [Users]
ADD CONSTRAINT [CHK__UsersLength] CHECK (LEN([Username]) >= 3)

--Probelm 13
CREATE DATABASE Movies

CREATE TABLE Directors(
	[Id] INT PRIMARY KEY IDENTITY,
	[DirectorName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(200)
)

CREATE TABLE Genres(
	[Id] INT PRIMARY KEY IDENTITY,
	[GenreName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(200)
)

CREATE TABLE Categories(
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(200)
)

CREATE TABLE Movies(
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(50) NOT NULL,
	[DirectorId] INT NOT NULL,
	[CopyrightYear] INT NOT NULL,
	[Length] TIME,
	[GenreId] INT NOT NULL,
	[CategoryId] INT NOT NULL,
	[Rating] INT,
	[Notes] NVARCHAR(200)
)

INSERT INTO [Directors](DirectorName) VALUES
('Gosho'),
('Posho'),
('Mosho'),
('Tosho'),
('Losho')

INSERT INTO [Genres](GenreName) VALUES
('Fantasy'),
('Comedy'),
('Action'),
('Thriller'),
('Action-Comedy')

INSERT INTO [Categories](CategoryName) VALUES
('Cartoon'),
('Adult'),
('Men'),
('Women'),
('Universal')

INSERT INTO [Movies](Title, DirectorId, CopyrightYear, GenreId, CategoryId) VALUES
('A', 1, 2000, 1, 1),
('B', 2, 2001, 2, 2),
('C', 3, 2002, 3, 3),
('D', 4, 2003, 4, 4),
('E', 5, 2004, 5, 5)

--Problem 14
CREATE DATABASE CarRental

CREATE TABLE Categories(
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(50) NOT NULL,
	[WeeklyRate] INT,
	[MonthlyRate] INT,
	[WeekendRate] INT
)

INSERT INTO Categories(CategoryName) VALUES
('Motor'),
('Car'),
('Truck')


CREATE TABLE Cars(
	[Id] INT PRIMARY KEY IDENTITY,
	[PlateNumber] NVARCHAR(50) NOT NULL,
	[Manufacturer] NVARCHAR(50) NOT NULL,
	[Model] NVARCHAR(50) NOT NULL,
	[CarYear] INT NOT NULL,
	[CategoryId] INT NOT NULL,
	[Doors] INT NOT NULL,
	[Picture] VARBINARY(MAX),
	[Condition] NVARCHAR(50),
	[Available] BIT NOT NULL
)

INSERT INTO Cars([PlateNumber], [Manufacturer], [Model], [CarYear], [CategoryId], [Doors], [Available]) VALUES
('DSADA', 'Opel', 'Astra', 2002, 1, 5, 0),
('EQWEQW', 'Opel', 'Astra', 2002, 1, 5, 0),
('NMN<M', 'Opel', 'Astra', 2002, 1, 5, 0)

CREATE TABLE Employees(
	[Id] INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(200) 
)

INSERT INTO Employees(FirstName, LastName, Title) VALUES
('Gosh', 'Petkov', 'Chief'),
('Stamo', 'Petkov', 'Chief'),
('Mitko', 'Petkov', 'Chief')

CREATE TABLE Customers(
	[Id] INT PRIMARY KEY IDENTITY,
	DriverLicenceNumber INT,
	FullName NVARCHAR(50) NOT NULL,
	[Address] NVARCHAR(50) NOT NULL,
	City NVARCHAR(50) NOT NULL,
	ZIPCode INT NOT NULL,
	Notes NVARCHAR(200) 
)

INSERT INTO Customers(FullName, [Address], City, ZIPCode) VALUES
('Gosh Petkov', 'PB 1', 'Kyustendil', 2500),
('Stamo Petkov', 'PB 1','Kyustendil', 2500),
('Mitko Petkov', 'PB 1','Kyustendil', 2500)

CREATE TABLE RentalOrders(
	[Id] INT PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	TankLevel FLOAT, 
	KilometrageStart INT,
	KilometrageEnd INT,
	TotalKilometrage INT,
	StartDate DATETIME2,
	EndDate DATETIME2,
	TotalDays INT, 
	RateApplied INT,
	TaxRate INT,
	OrderStatus BIT NOT NULL,
	Notes NVARCHAR(50)
)

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, OrderStatus) VALUES
(1, 1, 1, 0),
(2, 2, 2, 1),
(3, 3, 3, 1)

--Problem 15
CREATE DATABASE Hotel

CREATE TABLE Employees(
	[Id] INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(200) 
)

INSERT INTO Employees(FirstName, LastName, Title) VALUES
('Gosh', 'Petkov', 'Chief'),
('Stamo', 'Petkov', 'Chief'),
('Mitko', 'Petkov', 'Chief')


CREATE TABLE Customers(
	AccountNumber INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	PhoneNumber INT,
	EmergencyName NVARCHAR(50) NOT NULL,
	EmergencyNumber INT NOT NULL,
	Notes NVARCHAR(200) 
)

INSERT INTO Customers(FirstName, LastName, EmergencyName, EmergencyNumber) VALUES
('Gosh', 'Petkov', 'GP', 1122),
('Stamo', 'Petkov', 'SP', 2233 ),
('Mitko', 'Petkov', 'MP', 3344)


CREATE TABLE RoomStatus(
	RoomStatus BIT NOT NULL,
	Notes NVARCHAR(50)
)

INSERT INTO RoomStatus(RoomStatus) VALUES
(0),
(0),
(1)


CREATE TABLE RoomTypes(
	RoomType NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(50)
)

INSERT INTO RoomTypes(RoomType) VALUES
('Small'),
('Medium'),
('Big')

CREATE TABLE BedTypes(
	BedType NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(50)
)

INSERT INTO BedTypes(BedType) VALUES
('Soft'),
('Medium'),
('Hard')


CREATE TABLE Rooms(
	RoomNumber INT NOT NULL, 
	RoomType NVARCHAR(50), 
	BedType NVARCHAR(50), 
	Rate INT, 
	RoomStatus BIT NOT NULL, 
	Notes NVARCHAR(50)
)

INSERT INTO Rooms(RoomNumber, RoomStatus) VALUES
(1, 0),
(2, 1),
(3, 0)


CREATE TABLE Payments(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL, 
	PaymentDate DATETIME2, 
	AccountNumber INT, 
	FirstDateOccupied DATETIME2, 
	LastDateOccupied DATETIME2,
	TotalDays INT NOT NULL, 
	AmountCharged INT, 
	TaxRate INT, 
	TaxAmount INT, 
	PaymentTotal INT NOT NULL, 
	Notes NVARCHAR(50)
)

INSERT INTO Payments(EmployeeId, TotalDays, PaymentTotal) VALUES
(1, 3, 100),
(2, 7, 200),
(3, 10, 400)


CREATE TABLE Occupancies(
	Id INT PRIMARY KEY IDENTITY, 
	EmployeeId INT NOT NULL,
	DateOccupied DATETIME2, 
	AccountNumber INT,
	RoomNumber INT NOT NULL,
	RateApplied INT, 
	PhoneCharge INT,
	Notes NVARCHAR(50)
)

INSERT INTO Occupancies(EmployeeId, RoomNumber) VALUES
(1, 1),
(2, 2),
(3, 3)

--Problem 16 - similar to the previous two problems

--Problem 17 - 
--Backup the database SoftUni from the previous tasks
--into a file named “softuni-backup.bak”. Delete your database
--from SQL Server Management Studio. Then restore the database from the created backup.

--Problem 18 - Basic insert operations

--Problem 19
SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

--Problem 20
SELECT * FROM Towns
ORDER BY [Name]

SELECT * FROM Departments
ORDER BY [Name]

SELECT * FROM Employees
ORDER BY Salary DESC 

--Problem 21
SELECT [Name] FROM Towns
ORDER BY [Name]

SELECT [Name] FROM Departments
ORDER BY [Name]

SELECT [FirstName], [LastName], [JobTitle], [Salary] FROM Employees
ORDER BY Salary DESC 

--Problem 22
UPDATE Employees
SET Salary += Salary * 0.1

SELECT Salary FROM Employees

--Problem 23
UPDATE Payments
SET TaxRate -= TaxRate * 0.03

SELECT TaxRate FROM Payments

--Problem 24
TRUNCATE TABLE Occupancies