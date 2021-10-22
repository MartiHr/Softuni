USE Gringotts

-- Problem 1
SELECT COUNT(*) FROM WizzardDeposits

GO

--Problem 2
SELECT MAX(MagicWandSize) AS LongestMagicWand FROM WizzardDeposits

GO

--Problem 3
SELECT
	DepositGroup,
	MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits
GROUP BY DepositGroup

GO

--Problem 4
SELECT TOP (2)
	DepositGroup
	FROM
	(
		SELECT
			DepositGroup,
			AVG(MagicWandSize) AS AverageWandSize
		FROM WizzardDeposits
		GROUP BY DepositGroup
	) AS DepositGroupSubQuery
ORDER BY AverageWandSize

GO

--Problem 5
SELECT
	DepositGroup,
	SUM(DepositAmount) AS TotalSUm
FROM WizzardDeposits
GROUP BY DepositGroup

GO

--Problem 6
SELECT
	DepositGroup,
	SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
HAVING MagicWandCreator = 'Ollivander family'

GO

--Problem 7
SELECT
	*
	FROM
	(
		SELECT
			DepositGroup,
			SUM(DepositAmount) AS TotalSum
		FROM WizzardDeposits
		GROUP BY DepositGroup, MagicWandCreator
		HAVING MagicWandCreator = 'Ollivander family'
	) AS DepositGroupSubquery
WHERE TotalSum < 150000
ORDER BY TotalSum DESC

GO

--Problem 8
SELECT 
	DepositGroup,
	MagicWandCreator,
	MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator

GO

--Problem 9
SELECT
	AgeGroup,
	COUNT(*) AS WizardCount
	FROM
	(
		SELECT 
			CASE
				WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
				WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
				WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
				WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
				WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
				WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
				ELSE '[61+]'
			END AS AgeGroup
		FROM WizzardDeposits
	) AS AgeSubquery
GROUP BY AgeGroup

GO

--Problem 10
SELECT 
	FirstLetter
	FROM
	(
		SELECT 
			LEFT(FirstName, 1) AS FirstLetter 
		FROM WizzardDeposits
		WHERE DepositGroup = 'Troll Chest'
	) AS LettersSubquery
GROUP BY FirstLetter

GO

--Problem 11
SELECT 
	DepositGroup,
	IsDepositExpired,
	AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '1985-01-01'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired 

GO

--Problem 12
SELECT 
	SUM([Difference]) AS SumDifference
	FROM
	(
		SELECT 
			FirstName AS [Host Wizard],
			DepositAmount AS [Host Wizard Deposit],
			LEAD(FirstName) OVER(ORDER BY Id) AS [Guest Wizard],
			LEAD(DepositAmount) OVER(ORDER BY Id) AS [Guest Wizard Deposit],
			DepositAmount - LEAD(DepositAmount) OVER(ORDER BY Id) AS [Difference]
		FROM WizzardDeposits
	) AS DifferenceSubQuery

GO
-------

USE SoftUni

--Problem 13
SELECT 
	e.DepartmentID,
	SUM(e.Salary) AS TotalSalary
FROM Employees AS e
GROUP BY e.DepartmentID
ORDER BY e.DepartmentID

GO

--Problem 14
SELECT
	DepartmentID,
	MIN(Salary) AS MinimumSalary
FROM Employees
WHERE DepartmentID IN (2, 5, 7) AND HireDate > '2000-01-01'
GROUP BY DepartmentID

GO

--Problem 15
SELECT *
INTO EmployeesWithSalaryHigherThan30000
FROM Employees
WHERE Salary > 30000

DELETE FROM EmployeesWithSalaryHigherThan30000
WHERE ManagerID = 42

UPDATE EmployeesWithSalaryHigherThan30000
SET Salary += 5000
WHERE DepartmentID = 1

SELECT 
	DepartmentID,
	AVG(Salary) AS AverageSalary
FROM EmployeesWithSalaryHigherThan30000
GROUP BY DepartmentID

GO

--Problem 16
SELECT
	*
	FROM
	(
		SELECT 
			DepartmentID,
			MAX(Salary) AS MaxSalary
		FROM Employees
		GROUP BY DepartmentID
	) AS DepartmentsWithSalaries
WHERE MaxSalary NOT BETWEEN 30000 AND 70000

GO

--Problem 17
SELECT COUNT(*) AS [Count]
FROM Employees
WHERE ManagerID IS NULL

GO

--Problem 18
SELECT 
	DISTINCT DepartmentID,
	Salary AS ThirdHighestSalary
	FROM
	(
		SELECT 
			*,
			DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryRank
		FROM Employees
	) AS RankedSalaries
WHERE SalaryRank = 3

GO

--Problem 19
SELECT TOP (10)
	FirstName,
	LastName,
	DepartmentID
FROM Employees AS em
WHERE Salary > 
			 (
				SELECT AVG(Salary) 
				FROM Employees AS e
				WHERE e.DepartmentID = em.DepartmentID
				GROUP BY DepartmentID
			 )
ORDER BY DepartmentID


GO