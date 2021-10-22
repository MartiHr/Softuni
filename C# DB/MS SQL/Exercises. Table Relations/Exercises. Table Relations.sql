CREATE DATABASE [TABLE RELATIONS DEMO]

USE [TABLE RELATIONS DEMO]

--Problem 1
CREATE TABLE Passports(
	PassportID INT PRIMARY KEY,
	PassportNumber VARCHAR(9)
)

CREATE TABLE Persons(
	PersonID INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50),
	Salary DECIMAL(9, 2),
	PassportID INT FOREIGN KEY REFERENCES Passports(PassportID) UNIQUE
)


INSERT INTO Passports(PassportID, PassportNumber) VALUES
	(101, 'N34FG21B'),
	(102,'N34FG21B'),
	(103, 'ZE657QP2')

INSERT INTO Persons(FirstName, Salary, PassportID) VALUES
	('Roberto', 43300.00, 102),
	('Tom', 56100.00, 103),
	('Yana', 60200.00, 101)		

--Problem 2
CREATE TABLE Manufacturers(
	ManufacturerID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(10),
	EstablishedOn DATE 
)

CREATE TABLE Models(
	ModelID INT PRIMARY KEY,
	[Name] NVARCHAR(10),
	ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers([Name], EstablishedOn) VALUES
('BMW', '07/03/1916'),
('Tesla', '01/01/2003'),
('Lada', '01/05/1966')

INSERT INTO Models(ModelID, [Name], ManufacturerID) VALUES
(101, 'X1', 1),
(102, 'i6', 1),
(103, 'Model S', 2),
(104, 'Model X', 2),
(105, 'Model 3', 2),
(106, 'Nova', 3)

GO

--Problem 3
CREATE TABLE Students(
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50)
)

INSERT INTO Students([Name]) VALUES
('Mila'),
('Toni'),
('Ron')

CREATE TABLE Exams(
	ExamID INT PRIMARY KEY,
	[Name] NVARCHAR(50)
)

INSERT INTO [Exams] VALUES
(101, 'SpringMVC'),
(102, 'Neo4j'),
(103, 'Oracle 11g')


CREATE TABLE StudentsExams(
	[StudentID] INT FOREIGN KEY REFERENCES Students(StudentID),
	[ExamID] INT FOREIGN KEY REFERENCES Exams(ExamID),
	PRIMARY KEY(StudentID, ExamID)
)

INSERT INTO StudentsExams(StudentID, ExamID) VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)

GO

--Problem 4
CREATE TABLE Teachers(
	TeacherID INT PRIMARY KEY,
	[Name] NVARCHAR(50),
	[ManagerID] INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers(TeacherID, [Name], ManagerID) VALUES
(101, 'John', NULL),
(102, 'Maya', 106),
(103, 'Silvia', 106),
(104, 'Ted', 105),
(105, 'Mark', 101),
(106, 'Greta', 101)


--Problem 5
CREATE DATABASE OnlineStore

CREATE TABLE Cities(
	CityID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50)
)

CREATE TABLE Customers(
	CustomerID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50),
	Birthday DATE,
	CityID INT FOREIGN KEY REFERENCES Cities(CityID)
)

CREATE TABLE Orders(
	OrderID INT PRIMARY KEY IDENTITY,
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE ItemTypes(
	ItemTypeID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50)
)

CREATE TABLE Items(
	ItemID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50),
	ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems(
	OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
	ItemID INT FOREIGN KEY REFERENCES  Items(ItemID),
	PRIMARY KEY (OrderID, ItemID)
)

GO

--Problem 6
CREATE DATABASE University

CREATE TABLE Majors(
	MajorID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50)
)

CREATE TABLE Students(
	[StudentID] INT PRIMARY KEY IDENTITY,
	StudentNumber INT,
	StudentName VARCHAR(50),
	MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Payments(
	PaymentID INT PRIMARY KEY IDENTITY,
	PaymentDate DATE,
	PaymentAmount INT,
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)

CREATE TABLE Subjects(
	SubjectID INT PRIMARY KEY IDENTITY,
	SubjectName VARCHAR(50)
)

CREATE TABLE Agenda(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID),
	PRIMARY KEY(StudentID, SubjectID)
)