USE SoftUni

--Problem 1
SELECT TOP (5)
	e.EmployeeID,
	e.JobTitle,
	e.AddressID,
	a.AddressText
FROM Employees AS e
LEFT JOIN Addresses AS a
ON e.AddressID = a.AddressID
ORDER BY e.AddressID

GO

--Problem 2
SELECT TOP (50)
	e.FirstName,
	e.LastName, 
	t.[Name],
	a.AddressText
FROM Employees AS e
LEFT JOIN Addresses AS a 
ON e.AddressID = a.AddressID
LEFT JOIN Towns AS t 
ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName

GO

--Problem 3
SELECT 
	e.EmployeeID,
	e.FirstName,
	e.LastName,
	d.[Name] AS DepartmentName
FROM Employees AS e
LEFT JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID

GO

--Problem 4
SELECT TOP (5)
	e.EmployeeID,
	e.FirstName,
	e.Salary,
	d.[Name] AS DepartmentName
FROM Employees AS e
LEFT JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID 

GO

--Problem 5
SELECT TOP (3)
	e.EmployeeID,
	e.FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID

GO

--Problem 6
SELECT 
	e.FirstName,
	e.LastName,
	e.HireDate,
	d.[Name] AS DeptName
FROM Employees AS e
LEFT JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1999-01-01' 
AND d.[Name] IN ('Sales', 'Finance')
ORDER BY e.HireDate 

GO

--Problem 7
SELECT TOP (5)
	e.EmployeeID,
	e.FirstName,
	p.[Name] AS ProjectName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep 
	ON e.EmployeeID = ep.EmployeeID
LEFT JOIN Projects AS p 
	ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

GO

--Problem 8
SELECT
	e.EmployeeID,
	e.FirstName,
	CASE	
		WHEN YEAR(p.StartDate) >= 2005 THEN NULL
		ELSE p.[Name]
	END AS [ProjectName]
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep 
	ON e.EmployeeID = ep.EmployeeID
LEFT JOIN Projects AS p 
	ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24
ORDER BY e.EmployeeID

GO

--Problem 9
SELECT 
	e.EmployeeID,
	e.FirstName,
	e.ManagerID,
	m.FirstName AS ManagerName
FROM Employees AS e
LEFT JOIN Employees AS m
	ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID IN (3, 7)
ORDER BY e.EmployeeID

GO

--Problem 10
SELECT TOP (50)
	e.EmployeeID,
	CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
	CONCAT(m.FirstName, ' ', m.LastName) AS ManagerName,
	d.[Name] AS DepartmentName
FROM Employees AS e
LEFT JOIN Employees as m
	ON e.ManagerID = m.EmployeeID
LEFT JOIN Departments as d
	ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

GO

--Problem 11
SELECT MIN(AvgSalarySubQuery.AverageSalary) AS MinAvgSalary
	FROM
	(
		SELECT e.DepartmentID,
			AVG(e.Salary) AS AverageSalary
		FROM Employees AS e
		GROUP BY e.[DepartmentID]
	) AS AvgSalarySubQuery

GO
----

USE Geography

--Problem 12
SELECT 
	c.CountryCode,
	m.MountainRange,
	p.PeakName,
	p.Elevation
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc
	ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m
	ON mc.MountainId = m.Id
LEFT JOIN Peaks as p
	ON p.MountainId = m.Id 
WHERE c.CountryCode = 'BG' AND p.Elevation > 2835 
ORDER BY p.Elevation DESC

GO

--Problem 13
SELECT 
	c.CountryCode,
	COUNT(m.Id) AS MountainRanges
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc
	ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains as m
	ON mc.MountainId = m.Id
WHERE c.CountryCode IN ('US', 'BG', 'RU')
GROUP BY c.CountryCode

GO

--Problem 14
SELECT TOP (5)
	c.CountryName,
	r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr
	ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r
	ON cr.RiverId = r.Id
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName 

GO

--Problem 15
SELECT 
	ContinentCode,
	CurrencyCode,
	CurrencyCount AS CurrencyUsage
	FROM
	(
		SELECT 
			*,
			DENSE_RANK() OVER(PARTITION BY [ContinentCode] ORDER BY CurrencyCount DESC) AS CurrencyRank
			FROM
				(
					SELECT 
						c.ContinentCode,
						c.CurrencyCode,
						COUNT(c.CurrencyCode) AS CurrencyCount
					FROM Countries AS c
					LEFT JOIN Currencies AS cu
						ON c.CurrencyCode = cu.CurrencyCode
					GROUP BY c.ContinentCode, c.CurrencyCode
				) AS CurrencyCountSubQuery
		WHERE CurrencyCountSubQuery.CurrencyCount > 1
	) AS RankedCurrencySubQuery
WHERE CurrencyRank = 1
ORDER BY ContinentCode

GO

--Problem 16
SELECT COUNT(*) AS [Count]
FROM Countries AS c 
LEFT JOIN MountainsCountries AS mc
	ON c.CountryCode = mc.CountryCode
WHERE MountainId IS NULL

GO

--Problem 17
SELECT TOP (5) *
	FROM
	(
		SELECT 
			CountryName,
			MAX(p.Elevation) AS HighestPeakElevation,
			MAX(r.[Length]) AS LongestRiverLength
		FROM Countries AS c
		LEFT JOIN MountainsCountries AS mc
			ON c.CountryCode = mc.CountryCode
		LEFT JOIN Mountains AS m 
			ON mc.MountainId = m.Id
		LEFT JOIN Peaks AS p
			ON p.MountainId = m.Id
		LEFT JOIN CountriesRivers AS cr
			ON c.CountryCode = cr.CountryCode
		LEFT JOIN Rivers AS r
			ON r.Id = cr.RiverId
		GROUP BY c.CountryName
	) AS CountrySubQuery
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC

GO

--Problem 18
SELECT TOP (5)
	CountryName AS Country,
    ISNULL(PeakName, '(no highest peak)') AS [Highest Peak Name],
    ISNULL(Elevation, 0) AS [Highest Peak Elevation],
    ISNULL(MountainRange, '(no mountain)') AS [Mountain]
FROM
	(
		SELECT 
			c.CountryName,
			p.PeakName,
			p.Elevation,
			m.MountainRange,
			DENSE_RANK() OVER(PARTITION BY c.[CountryName] ORDER BY p.[Elevation] DESC) AS [PeakRank]
		FROM Countries AS c
		LEFT JOIN MountainsCountries AS mc
			ON c.CountryCode = mc.CountryCode
		LEFT JOIN Mountains AS m
			ON mc.MountainId = m.Id
		LEFT JOIN Peaks AS p
		ON m.Id = p.MountainId
	) AS PeaksRankingSubQuery
WHERE [PeakRank] = 1
ORDER BY [Country], [Highest Peak Name]
