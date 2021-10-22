USE [SoftUni]

--Problem 2
SELECT * FROM [Departments]

GO

--Problem 3
SELECT [Name] FROM [Departments]

GO

--Problem 4
SELECT [FirstName], [LastName], [Salary] FROM Employees

GO

--Problem 5
SELECT [FirstName], [MiddleName], [LastName] FROM Employees

GO

--Problem 6
SELECT CONCAT(FirstName, '.', LastName, '@', 'softuni.bg') AS [Full Email Address] 
	FROM Employees

GO

--Problem 7
SELECT DISTINCT [Salary] FROM [Employees]

GO

--Problem 8
SELECT * FROM [Employees]
WHERE [JobTitle] = 'Sales Representative'

GO

--Problem 9
SELECT [FirstName], [LastName], [JobTitle] FROM [Employees]
WHERE [Salary] BETWEEN 20000 AND 30000

GO

--Problem 10
SELECT CONCAT([FirstName], ' ', [MiddleName], ' ', [LastName])
   AS [Full Name] 
 FROM [Employees]
WHERE [Salary] IN (25000, 14000, 12500, 23600)

GO

--Problem 11
SELECT [FirstName], [LastName] FROM [Employees]
WHERE [ManagerID] IS NULL

GO

--Problem 12
  SELECT [FirstName], [LastName], [Salary] FROM [Employees]
   WHERE [Salary] > 50000
ORDER BY [Salary] DESC

GO

--Problem  13
SELECT TOP(5) [FirstName], [LastName] 
		 FROM [Employees]
     ORDER BY [Salary] DESC

GO

--Problem 14
SELECT [FirstName], [LastName] FROM Employees
 WHERE [DepartmentID] <> 4

 GO

--Problem 15
SELECT * FROM [Employees]
     ORDER BY [Salary] DESC, [FirstName], [LastName] DESC, [MiddleName]

GO

--Problem 16
CREATE VIEW [V_EmployeesSalaries] AS (
     SELECT [FirstName], [LastName], [Salary]
	   FROM [Employees])

GO

--Problem 17
CREATE VIEW [V_EmployeeNameJobTitle] AS (
	SELECT CONCAT([FirstName], ' ', [MiddleName], ' ', LastName) AS [Full Name],
			[JobTitle] AS [Job Title]
	   FROM [Employees])

GO

--Problem 18
SELECT DISTINCT [JobTitle] FROM [Employees]

GO

--Problem 19
SELECT TOP(10) * FROM [Projects]
ORDER BY [StartDate], [Name]

GO

--Problem 20
SELECT TOP(7) [FirstName], [LastName], [HireDate] FROM [Employees]
	 ORDER BY [HireDate] DESC

GO

--Problem 21
UPDATE [Employees]
   SET [Salary] += [Salary] * 0.12
 WHERE [DepartmentID] IN (1, 2, 4, 11)

SELECT [Salary] FROM [Employees]

GO

--
USE [Geography]

--Problem 22
SELECT [PeakName] FROM [Peaks]
ORDER BY [PeakName]

GO

--Problem 23
SELECT TOP(30) [CountryName], [Population] FROM [Countries]
		 WHERE [ContinentCode] = 'EU'
		 ORDER BY [Population] DESC, [CountryName]

GO

--Problem 24
  SELECT [CountryName], [CountryCode],
		 CASE
			WHEN [CurrencyCode] = 'EUR' THEN 'Euro'
			ELSE 'Not Euro'
		 END AS [Currency]
	FROM [Countries]	
ORDER BY [CountryName]

GO


--
USE [Diablo]

--Problem 25
SELECT [Name] FROM [Characters]
ORDER BY [Name]

GO