CREATE DATABASE [Service]

USE [Service]

GO

--Problem 1
CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY, 
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
	[Name] VARCHAR(50),
	Birthdate DATETIME2,
	Age INT CHECK (Age BETWEEN 14 AND 110),
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(25),
	LastName VARCHAR(25),
	Birthdate DATETIME2,
	Age INT CHECK (AGE BETWEEN 18 AND 110),
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE [Status](
	Id INT PRIMARY KEY IDENTITY,
	[Label] VARCHAR(30) NOT NULL
)

CREATE TABLE Reports(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	StatusId INT FOREIGN KEY REFERENCES [Status](Id) NOT NULL,
	OpenDate DATETIME2 NOT NULL,
	CloseDate DATETIME2,
	[Description] VARCHAR(200) NOT NULL,
	UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

GO

--Problem 2
INSERT INTO Employees(FirstName, LastName, Birthdate, DepartmentId) VALUES
('Marlo', 'O''Malley', '1958-9-21', 1),
('Niki', 'Stanaghan', '1969-11-26', 4),
('Ayrton', 'Senna', '1960-03-21', 9),
('Ronnie', 'Peterson', '1944-02-14', 9),
('Giovanna', 'Amati', '1959-07-20', 5)


INSERT INTO Reports(CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId) VALUES
(1, 1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2),
(6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5),
(14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2),
(4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)

GO

--Problem 3
UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

GO

--Problem 4
DELETE FROM Reports
WHERE [StatusId] = 4

GO

--Problem 5
SELECT 
	[Description],
	FORMAT(OpenDate, 'dd-MM-yyyy') AS OpenDate
FROM Reports AS r
WHERE EmployeeId IS NULL
ORDER BY r.OpenDate, [Description]

GO

--Problem 6
SELECT 
	r.[Description],
	c.[Name] AS CategoryName
FROM Reports AS r
JOIN Categories AS c
	ON r.CategoryId = c.Id
WHERE CategoryId IS NOT NULL
ORDER BY r.[Description], c.[Name] 

GO

--Problem 7
SELECT TOP(5)
	c.[Name] AS CategoryName,
	COUNT(r.Id) AS ReportsNumber
FROM Categories AS c
	JOIN Reports AS r
ON	c.Id = r.CategoryId
GROUP BY c.[Name]
ORDER BY ReportsNumber DESC, CategoryName

GO

--Problem 8
SELECT 
	u.Username,
	c.[Name]
FROM Reports AS r
JOIN Categories AS c
	ON r.CategoryId = c.Id
JOIN Users AS u
	ON r.UserId = u.Id
WHERE DAY(r.OpenDate) = DAY(u.Birthdate) AND MONTH(r.OpenDate) = MONTH(u.Birthdate)
ORDER BY u.Username, c.[Name]

GO

--Problem 9
SELECT 
	CONCAT(e.FirstName, ' ', e.LastName) AS FullName,
	COUNT(UserID) AS [UsersCount]
FROM Employees AS e
LEFT JOIN Reports AS r
	ON r.EmployeeId = e.Id
GROUP BY CONCAT(e.FirstName, ' ', e.LastName)
ORDER BY COUNT(UserID) DESC, FullName

GO

--Problem 10
SELECT	
	CASE WHEN (e.FirstName IS NULL OR e.LastName IS NULL) THEN 'None' 
		ELSE CONCAT(e.FirstName , ' ', e.LastName)
	END AS Employee, 
	ISNULL(d.[Name], 'None') AS Department,
	ISNULL(c.[Name], 'None') AS Category,
	ISNULL(r.[Description], 'None')	AS [Description],
	ISNULL(FORMAT(r.OpenDate, 'dd.MM.yyyy'), 'None') AS OpenDate,
	ISNULL(s.[Label], 'None') AS [Status],
	ISNULL(u.[Name], 'None') AS [User]
FROM Reports AS r
LEFT JOIN Employees AS e
	ON r.EmployeeId = e.Id
LEFT JOIN Users AS u
	ON r.UserId = u.Id
LEFT JOIN Departments AS d
	ON e.DepartmentId = d.Id
LEFT JOIN [Status] AS s
	ON r.StatusId = s.Id
LEFT JOIN Categories AS c
	ON r.CategoryId = c.Id
ORDER BY e.FirstName DESC , e.LastName DESC, Department, c.[Name], r.[Description], r.OpenDate, s.[Label], u.[Name]

GO

--Problem 11
CREATE FUNCTION udf_HoursToComplete(@startDate DATETIME, @endDate DATETIME)
RETURNS INT
AS
BEGIN
	IF @startDate IS NULL OR @endDate IS NULL
	BEGIN
		RETURN 0
	END

	RETURN DATEDIFF(HOUR, @startDate, @endDate)
END

GO

--Problem 12
CREATE PROC usp_AssignEmployeeToReport(@employeeId INT, @reportId INT) 
AS 
BEGIN
	DECLARE @employeeDepartment INT = (
											SELECT 
												d.Id 
											FROM Employees AS e 
											LEFT JOIN Departments AS d
												ON e.DepartmentId = d.Id
											WHERE e.Id = @employeeId
										)
	
	DECLARE @reportCategoryDepartment INT = (
												SELECT 
													d.Id
												FROM Reports AS r
												LEFT JOIN Categories AS c
													ON r.CategoryId = c.Id
												LEFT JOIN Departments AS d
													ON c.DepartmentId = d.Id
												WHERE r.Id = @reportId
											)

	IF @employeeDepartment <> @reportCategoryDepartment
	BEGIN 
		THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1
		RETURN
	END

	UPDATE Reports
	SET EmployeeId = @employeeId
	WHERE Id = @reportId

	RETURN
END

GO