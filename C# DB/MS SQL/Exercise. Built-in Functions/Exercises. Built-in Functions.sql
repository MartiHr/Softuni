--Problem 1
SELECT FirstName, LastName FROM Employees
WHERE LEFT(FirstName, 2) = 'Sa'

GO

--Problem 2
SELECT FirstName, LastName FROM Employees
WHERE LastName LIKE '%ei%'

--Problem 3
SELECT FirstName FROM Employees
WHERE DepartmentID IN (3, 10) AND DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005 

GO

--Problem 4
SELECT FirstName, LastName FROM Employees
WHERE CHARINDEX('engineer', JobTitle) = 0

GO

--Problem 5
SELECT [Name] FROM Towns
WHERE LEN([Name]) IN (5, 6)
ORDER BY [Name]

GO

--Problem 6
SELECT * FROM Towns
WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name] 

GO

--Problem 7
SELECT * FROM Towns
WHERE LEFT([Name], 1) NOT IN ('R', 'B', 'D')
ORDER BY [Name] 

GO

--Problem 8
CREATE VIEW V_EmployeesHiredAfter2000 AS(
SELECT FirstName, LastName FROM Employees
 WHERE DATEPART(YEAR, HireDate) > 2000
 )

GO

--Problem 9
SELECT FirstName, LastName FROM Employees
WHERE LEN(LastName) = 5

GO

--Problem 10
SELECT EmployeeID, FirstName, LastName, Salary,
	   DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

GO

--Problem 11
SELECT *
   FROM (
			SELECT EmployeeID, FirstName, LastName, Salary,
				   DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
			FROM Employees
			WHERE Salary BETWEEN 10000 AND 50000
		)  
   AS [RankingTable]
WHERE [Rank] = 2
ORDER BY Salary DESC

GO

--Problem 12
SELECT CountryName, IsoCode FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

GO

--Problem 13
SELECT p.PeakName, 
	   r.RiverName,
	   LOWER(CONCAT(LEFT(p.PeakName, LEN(p.PeakName) - 1), r.RiverName)) AS Mix
FROM Peaks AS p, 
	 Rivers AS r
WHERE LOWER(RIGHT(p.PeakName, 1)) = LOWER(LEFT(r.RiverName, 1))
ORDER BY Mix

GO

--Problem 14
SELECT TOP(50) [Name],
	   FORMAT([Start], 'yyyy-MM-dd') AS [Start]
FROM Games
WHERE DATEPART(YEAR, [Start]) IN (2011, 2012)
ORDER BY [Start], [Name]

GO

--Problem 15
SELECT Username,
	SUBSTRING(Email, CHARINDEX('@', Email, 1) + 1, LEN(Email) - CHARINDEX('@', Email, 1)) AS [Email Provider]
FROM Users
ORDER BY [Email Provider], Username

GO

--Problem 16
SELECT Username, IpAddress FROM Users
WHERE IpAddress LIKE '___.1_%._%.___'
ORDER BY Username 

GO

--Problem 17
SELECT
	[Name] AS Game,   
	CASE 
		WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
		WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
		ELSE 'Evening'
	END AS [Part of the Day],
	CASE 
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration >= 4 AND Duration <= 6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		ELSE 'Extra Long'
	END AS [Duration]
FROM Games
ORDER BY Game, Duration, [Part of the Day]

GO

--Problem 18
SELECT ProductName, OrderDate,
		DATEADD(DAY, 3, OrderDate) AS [Pay Due],
		DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
FROM Orders

GO