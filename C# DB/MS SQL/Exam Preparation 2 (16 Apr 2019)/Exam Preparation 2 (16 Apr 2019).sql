CREATE DATABASE Airport

USE Airport

GO

--Problem 1
CREATE TABLE Planes (
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	Seats INT NOT NULL,
	[Range] INT NOT NULL 
)

CREATE TABLE Flights(
	Id INT PRIMARY KEY IDENTITY,
	DepartureTime DATETIME,
	ArrivalTime DATETIME,
	Origin VARCHAR(50) NOT NULL,
	Destination VARCHAR(50) NOT NULL,
	PlaneId INT FOREIGN KEY REFERENCES Planes(Id) NOT NULL
)

CREATE TABLE Passengers(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Age INT NOT NULL,
	[Address] VARCHAR(30) NOT NULL,
	PassportId CHAR(11) NOT NULL
)


CREATE TABLE LuggageTypes(
	Id INT PRIMARY KEY IDENTITY,
	[Type] VARCHAR(30) NOT NULL
)

CREATE TABLE Luggages(
	Id INT PRIMARY KEY IDENTITY,
	LuggageTypeId INT FOREIGN KEY REFERENCES  LuggageTypes(Id) NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
)

CREATE TABLE Tickets(
	Id INT PRIMARY KEY IDENTITY, 
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
	FlightId INT FOREIGN KEY REFERENCES Flights(Id) NOT NULL,
	LuggageId INT FOREIGN KEY REFERENCES Luggages(Id) NOT NULL,
	Price DECIMAL(10, 2) NOT NULL
)

GO

--Problem 2
INSERT INTO Planes([Name], Seats, [Range]) VALUES
('Airbus 336', 112, 5132),
('Airbus 330', 432, 5325),
('Boeing 369', 231, 2355),
('Stelt 297', 254, 2143),
('Boeing 338', 165, 5111),
('Airbus 558', 387, 1342),
('Boeing 128', 345, 5541)

INSERT INTO LuggageTypes([Type]) VALUES
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')

GO

--Problem 3
UPDATE Tickets
SET Price = Price * 1.13
WHERE FlightId 
IN 
(
	SELECT 
	 Id
	FROM Flights 
	WHERE Destination = 'Carlsbad'
)

GO

--Problem 4
DELETE FROM Tickets
WHERE FlightId 
IN
(
	SELECT Id 
	FROM Flights 
	WHERE Destination = 'Ayn Halagim'
)

DELETE 
FROM Flights 
WHERE Destination = 'Ayn Halagim'

GO

--Problem 5
SELECT
	*
FROM Planes
WHERE [Name] LIKE '%tr%' 
ORDER BY Id, [Name], Seats, [Range]

GO

--Problem 6
SELECT 
	f.Id,
	SUM(Price) AS Price
FROM Flights AS f
JOIN Tickets AS t
	ON f.Id = t.FlightId
GROUP BY f.Id
ORDER BY Price DESC

GO

--Problem 7
SELECT
	CONCAT(p.FirstName, ' ', p.LastName) AS [Full Name],
	f.Origin,
	f.Destination
FROM Passengers AS p
JOIN Tickets AS t
	ON p.Id = t.PassengerId
JOIN Flights AS f
	ON t.FlightId = f.Id
ORDER BY [Full Name], Origin, Destination

GO

--Problem 8
SELECT
	p.FirstName,
	p.LastName,
	p.Age
FROM Passengers AS p
LEFT JOIN Tickets AS t
	ON p.Id = t.PassengerId
WHERE t.Id IS NULL
ORDER BY Age DESC, FirstName, LastName

GO

--Problem 9
SELECT
	CONCAT(p.FirstName, ' ', p.LastName) AS [Full Name],
	pl.[Name] AS [Plane Name],
	CONCAT(f.Origin, ' - ', f.Destination) AS Trip,
	lt.[Type] AS [Luggage Type]
FROM Passengers AS p
LEFT JOIN Tickets AS t
	ON p.Id = t.PassengerId
LEFT JOIN Flights AS f
	ON t.FlightId = f.Id
JOIN Planes AS pl
	ON f.PlaneId = pl.Id
LEFT JOIN Luggages AS l
	ON t.LuggageId = l.Id
LEFT JOIN LuggageTypes AS lt
	ON l.LuggageTypeId = lt.Id
WHERE t.Id IS NOT NULL
ORDER BY [Full Name], [Plane Name], f.Origin, f.Destination

GO

--Problem 10
SELECT 
	p.[Name],
	p.Seats,
	COUNT(PassengerId) AS [Passengers Count]
FROM Tickets AS t
RIGHT JOIN Flights AS f
	ON t.FlightId = f.Id
RIGHT JOIN Planes AS p
	ON f.PlaneId = p.Id
GROUP BY p.[Name], p.Seats 
ORDER BY [Passengers Count] DESC, p.[Name], p.Seats

GO

--Problem 11
CREATE FUNCTION udf_CalculateTickets(@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT)
RETURNS NVARCHAR(100)
AS
BEGIN
	IF @peopleCount <= 0
	BEGIN
		RETURN 'Invalid people count!'
	END

	IF (SELECT COUNT(*) FROM Flights WHERE Destination = @destination AND Origin = @origin) = 0
	BEGIN
		RETURN 'Invalid flight!'
	END

	DECLARE @TotalPrice DECIMAL(20, 2) = @peopleCount * 
	(
			SELECT TOP(1)
				t.Price
			FROM Tickets AS t
			JOIN Flights AS f
				ON f.Id = t.FlightId
				WHERE f.Origin = @origin AND f.Destination = @destination
	)

	RETURN CONCAT('Total price ', @TotalPrice)
END

GO

--Problem 12
CREATE PROC usp_CancelFlights
AS
BEGIN
	UPDATE Flights
	SET DepartureTime = NULL, ArrivalTime = NULL
	WHERE ArrivalTime > DepartureTime
END

GO