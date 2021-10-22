USE SoftUni

GO

--Problem 1
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT 
		FirstName,
		LastName
	FROM Employees
	WHERE Salary > 35000
END

GO

--Problem 2
CREATE PROC usp_GetEmployeesSalaryAboveNumber @minSalary DECIMAL(18, 4)
AS
		SELECT 
		FirstName,
		LastName
	FROM Employees
	WHERE Salary >= @minSalary

GO

--Problem 3
CREATE PROC usp_GetTownsStartingWith @townName VARCHAR(50)
AS
	SELECT Name FROM Towns
	WHERE LEFT([Name], LEN(@townName)) = @townName

GO

--Problem 4
CREATE PROC usp_GetEmployeesFromTown @townName VARCHAR(50)
AS 
	SELECT 
		FirstName,
		LastName
	FROM Employees AS e
	LEFT JOIN Addresses AS a
		ON e.AddressID = a.AddressID
	LEFT JOIN Towns AS t
		ON a.TownID = t.TownID	
	WHERE t.[Name] =  @townName

GO

--Problem 5
CREATE FUNCTION ufn_GetSalaryLevel (@salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(10) 

	IF @salary < 30000
	BEGIN
		SET @salaryLevel = 'Low'
	END
	ELSE IF  @salary BETWEEN 30000 AND 50000
	BEGIN
		SET @salaryLevel = 'Average'
	END
	ELSE
	BEGIN
		SET @salaryLevel = 'High'
	END

	RETURN @salaryLevel
END

GO

--Problem 6
CREATE PROC usp_EmployeesBySalaryLevel @salaryLevel VARCHAR(10)
AS	
	SELECT 
		FirstName,
		LastName
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel
	
GO

--Problem 7
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(255), @word NVARCHAR(255))
RETURNS BIT
AS
BEGIN
	DECLARE @wordLength INT = LEN(@word)
	DECLARE @index INT = 1

	WHILE @index <= @wordLength
	BEGIN
		DECLARE @currentLetter CHAR(1) = SUBSTRING(@word, @index, 1)
		IF CHARINDEX(@currentLetter, @setOfLetters) = 0
		BEGIN
			RETURN 0
		END

		SET @index += 1
	END

	RETURN 1
END

GO

--Problem 8
CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
	--Firstly we need to delete all records from EmployeesProjects where EmployeeID is one of the lately deleted
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN 
		  (
			SELECT EmployeeID 
			FROM Employees
			WHERE DepartmentID = @departmentId
		  ) 

	--We need to set ManagerID to NULL of all Employees which have their Manager lately deleted
	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN
		  (
			SELECT EmployeeID 
			FROM Employees
			WHERE DepartmentID = @departmentId
		  )


	--We need to alter ManagerID column from Departments in order to be nullable because we need to set
    --ManagerID to NULL of all Departments that have their Manager lately deleted
	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT

	--We need to set ManagerID to NULL (no Manager) to all departments that have their Manager lately deleted
	UPDATE Departments
	SET ManagerID = NULL
	WHERE ManagerID IN
		  (
			SELECT EmployeeID 
			FROM Employees
			WHERE DepartmentID = @departmentId
		  )

	--We need to delete all employees from the lately deleted department
	DELETE FROM Employees
	WHERE DepartmentID = @departmentId

	--Lastly we delete wanted department
	DELETE FROM Departments
	WHERE DepartmentID = @departmentId


	SELECT COUNT(*)
      FROM [Employees]
     WHERE [DepartmentID] = @departmentId
END

GO

------

USE Bank

GO

--Problem 9
CREATE PROC usp_GetHoldersFullName
AS
BEGIN
	SELECT  
		CONCAT(FirstName, ' ', LastName) AS [Full Name]
	FROM AccountHolders
END

GO

--Problem 10
CREATE PROC usp_GetHoldersWithBalanceHigherThan @balanceThreshold MONEY
AS 
BEGIN
	SELECT 
		FirstName,
		LastName
	FROM AccountHolders AS ah
    JOIN Accounts AS a
		ON ah.Id = a.AccountHolderId
	GROUP BY FirstName, LastName
	HAVING SUM(Balance) > @balanceThreshold
	ORDER BY FirstName, LastName
END

GO

--Problem 11
CREATE FUNCTION ufn_CalculateFutureValue (@initialSum DECIMAL(12, 4), @yearlyInterestRate FLOAT, @numberOfYears INT)
RETURNS DECIMAL(12, 4)
AS
BEGIN
	RETURN ROUND(@initialSum * (POWER((1 + @yearlyInterestRate), @numberOfYears)), 4)
END

GO

--Problem 12
CREATE PROC usp_CalculateFutureValueForAccount @accountID INT, @interestRate FLOAT
AS
BEGIN
	SELECT 
		a.Id AS	[Account Id],
		ah.FirstName,
		ah.LastName,
		a.Balance,
		dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5) AS [Balance in 5 years]
	FROM AccountHolders AS ah
	JOIN Accounts AS a
		ON ah.Id = a.AccountHolderId
	WHERE a.Id = @accountID
END

GO

-----

USE Diablo

GO

--Problem 13
CREATE FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR(50))
RETURNS TABLE 
AS 
RETURN SELECT 
(
	SELECT 
		SUM(Cash) AS SumCash
		FROM
		(
			SELECT 
				Cash,
				ROW_NUMBER() OVER(PARTITION BY g.[Name] ORDER BY ug.Cash DESC) AS RowNumber
			FROM UsersGames AS ug
			JOIN Games AS g
				ON ug.GameId = g.Id
			WHERE g.[Name] = @gameName
		) AS CashWithRowNumber
	WHERE RowNumber % 2 <> 0
) AS SumCash

GO