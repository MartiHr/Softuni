CREATE DATABASE WMS

GO

USE WMS

GO

--Problem 1
CREATE TABLE Clients(
	ClientId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Phone CHAR(12) CHECK (LEN(Phone) = 12) NOT NULL
)


CREATE TABLE Mechanics(
	MechanicId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	[Address] VARCHAR(255) NOT NULL
)


CREATE TABLE Models (
	ModelId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL
)


CREATE TABLE Jobs(
	JobId INT PRIMARY KEY IDENTITY,
	ModelId INT FOREIGN KEY REFERENCES Models(ModelId) NOT NULL,
	[Status] VARCHAR(11) CHECK([Status] IN ('Pending', 'In Progress', 'Finished')) DEFAULT 'Pending' NOT NULL,
	ClientId INT FOREIGN KEY REFERENCES Clients(ClientId) NOT NULL,
	MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId),
	IssueDate DATE NOT NULL,
	FinishDate DATE 
)


CREATE TABLE Orders(
	OrderId INT PRIMARY KEY IDENTITY,
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
	IssueDate DATE,
	Delivered BIT DEFAULT 0 NOT NULL
)


CREATE TABLE Vendors(
	VendorId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL
)


CREATE TABLE Parts(
	PartId INT PRIMARY KEY IDENTITY,
	SerialNumber VARCHAR(50) UNIQUE NOT NULL,
	[Description] VARCHAR(255),
	Price DECIMAL(6, 2) CHECK(PRICE > 0) NOT NULL,
	VendorId INT FOREIGN KEY REFERENCES Vendors(VendorId) NOT NULL,
	StockQty INT CHECK(StockQty >= 0) DEFAULT 0 NOT NULL
)


CREATE TABLE OrderParts(
	OrderId INT FOREIGN KEY REFERENCES Orders(OrderId),
	PartId INT FOREIGN KEY REFERENCES Parts(PartId),
	Quantity INT CHECK(Quantity > 0) DEFAULT 1 NOT NULL,
	PRIMARY KEY (OrderId, PartId)
)


CREATE TABLE PartsNeeded(
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId),
	PartId INT FOREIGN KEY REFERENCES Parts(PartId),
	Quantity INT CHECK(Quantity > 0) DEFAULT 1 NOT NULL,
	PRIMARY KEY (JobId, PartId)
)

GO

--Problem 2
INSERT INTO Clients(FirstName, LastName, Phone) VALUES
('Teri', 'Ennaco', '570-889-5187'),
('Merlyn', 'Lawler', '201-588-7810'),
('Georgene', 'Montezuma', '925-615-5185'),
('Jettie', 'Mconnell', '908-802-3564'),
('Lemuel', 'Latzke', '631-748-6479'),
('Melodie', 'Knipp', '805-690-1682'),
('Candida', 'Corbley', '908-275-8357')

INSERT INTO Parts(SerialNumber, [Description], Price, VendorId) VALUES
('WP8182119', 'Door Boot Seal', 117.86, 2),
('W10780048', 'Suspension Rod', 42.81, 1),
('W10841140', 'Silicone Adhesive', 6.77, 4),
('WPY055980', 'High Temperature Adhesive', 13.94, 3)

GO

--Problem 3
UPDATE Jobs
SET MechanicId = 3, [Status] = 'In Progress'
WHERE Status = 'Pending'

GO

--Problem 4
DELETE FROM OrderParts
WHERE OrderId = 19

DELETE FROM Orders
WHERE OrderId = 19

GO

--Problem 5
SELECT 
	CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
	j.[Status],
	j.IssueDate
FROM Mechanics AS m
JOIN Jobs AS j
	ON m.MechanicId = j.MechanicId
ORDER BY m.MechanicId, j.IssueDate, j.JobId

GO

--Problem 6
SELECT 
	CONCAT(c.FirstName, ' ', c.LastName) AS Client, 
	DATEDIFF(DAY, j.IssueDate, '2017-04-24') AS [Days going],
	j.[Status] 
FROM Clients AS c
LEFT JOIN Jobs AS j
	ON	c.ClientId = j.ClientId
WHERE j.[Status] <> 'Finished'

GO

--Problem 7
SELECT 
	CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
	AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS [Average Days]
FROM Mechanics AS m
LEFT JOIN Jobs AS j
	ON m.MechanicId = j.MechanicId
GROUP BY m.MechanicId, FirstName, m.LastName
ORDER BY m.MechanicId

GO

--Problem 8
SELECT 
	CONCAT(FirstName, ' ', LastName) AS Available
FROM 
Mechanics 
WHERE MechanicId 
NOT IN (
			SELECT 
				m.MechanicId
			FROM 
			Mechanics AS m
			JOIN Jobs AS j
				ON  j.MechanicId = m.MechanicId
			WHERE j.[Status] <> 'Finished'
				GROUP BY m.MechanicId
	   )

GO

--Problem 9
SELECT 
	JobId,
	ISNULL(SUM(RowPrice), 0) AS Total
	FROM
	(
		SELECT 
			j.JobId,
			op.Quantity * Price AS RowPrice
		FROM Jobs AS j
		LEFT JOIN Orders AS o
			ON j.JobId = o.JobId
		LEFT JOIN OrderParts AS op
			ON o.OrderId = op.OrderId
		LEFT JOIN Parts AS p
			ON op.PartId = p.PartId
		WHERE j.[Status] = 'Finished'
	) AS JobIdWithTotalPrice
GROUP BY JobId 
ORDER BY Total DESC, JobId

GO

--Problem 10
SELECT 
	PartId,
	[Description],
	[Required],
	[In Stock],
	Ordered
	FROM
	(
		SELECT 
			pn.PartId,
			p.[Description],
			pn.Quantity AS [Required],
			p.StockQty AS [In Stock],
			ISNULL(op.Quantity, 0) AS Ordered
		FROM Jobs AS j 
		LEFT JOIN PartsNeeded AS pn
			ON j.JobId = pn.JobId
		LEFT JOIN Parts AS p
			ON pn.PartId = p.PartId
		LEFT JOIN Orders AS o
			ON j.JobId = o.JobId
		LEFT JOIN OrderParts AS op
			ON o.OrderId = op.OrderId
		WHERE j.[Status] <> 'Finished' 
		AND (o.Delivered IS NULL OR o.Delivered = 0)
	) AS SubQuery
WHERE [In Stock] + Ordered < [Required] 

GO

--Problem 11
CREATE PROC usp_PlaceOrder @jobID INT, @partSerialNumber VARCHAR(50), @quantity INT
AS
BEGIN 
	IF 
END





GO

--Problem 12
CREATE FUNCTION udf_GetCost (@jobId INT)
RETURNS DECIMAL(6, 2)
AS
BEGIN
	RETURN 
	(
		SELECT 
			SUM(RowPrice)
			FROM
			(
				SELECT 
					j.JobId,
					ISNULL(Quantity * Price, 0) AS RowPrice
				FROM Jobs AS j
				LEFT JOIN Orders AS o
					ON j.JobId = o.JobId
				LEFT JOIN OrderParts AS op
					ON o.OrderId = op.OrderId
				LEFT JOIN Parts AS p
					ON op.PartId = p.PartId
				GROUP BY j.JobId, Quantity * Price
			) AS TotalPrice
		WHERE JobId = @jobId
	) 
END

GO

SELECT dbo.udf_GetCost(1)


