USE FlightDb
GO

CREATE TABLE Pilots (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(30) NOT NULL,
    Surname NVARCHAR(30) NOT NULL
)
GO

CREATE TABLE Cities (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(30) NOT NULL,
    DistanceFromCurrentCity INT NOT NULL
)
GO

CREATE TABLE FlightTypes (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [Type] NVARCHAR(30) NOT NULL
)
GO

CREATE TABLE Schedules (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    StartDateTime DATETIME NOT NULL,
    [CityId] INT FOREIGN KEY REFERENCES Cities(Id) ON DELETE CASCADE NOT NULL,
    [PilotId] INT FOREIGN KEY REFERENCES Pilots(Id) ON DELETE CASCADE NOT NULL
)
GO

CREATE TABLE Airplanes (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(30) NOT NULL,
    PassengerCount INT NOT NULL,
    [ScheduleId] INT FOREIGN KEY REFERENCES Schedules(Id) ON DELETE CASCADE NOT NULL
)
GO

        CREATE TABLE Tickets (
            Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
            [ScheduleId] INT FOREIGN KEY REFERENCES Schedules(Id) ON DELETE CASCADE NOT NULL,
            [FlightTypeId] INT FOREIGN KEY REFERENCES FlightTypes(Id) ON DELETE CASCADE NOT NULL
        )
GO
-- Insert data into Pilots
INSERT INTO Pilots ([Name], Surname) VALUES
('John', 'Doe'),
('Jane', 'Smith'),
('Michael', 'Johnson'),
('Emily', 'Davis'),
('Robert', 'Brown'),
('Linda', 'Wilson'),
('James', 'Taylor'),
('Mary', 'Anderson'),
('William', 'Thomas');
GO
-- Insert data into Cities
INSERT INTO Cities ([Name], DistanceFromCurrentCity) VALUES
('New York', 0),
('Los Angeles', 2451),
('Chicago', 790),
('Houston', 1625),
('Phoenix', 2236),
('Philadelphia', 95),
('San Antonio', 1452),
('San Diego', 2394),
('Dallas', 1316);
GO
-- Insert data into FlightTypes
INSERT INTO FlightTypes ([Type]) VALUES
('Economy'),
('Business'),
('First Class'),
('Premium Economy'),
('Basic Economy'),
('Standard'),
('Comfort'),
('Luxury'),
('Economy Plus');
GO
-- Insert data into Schedules
INSERT INTO Schedules (StartDateTime, [CityId], [PilotId]) VALUES
('2024-08-10 08:00:00', 1, 1),
('2024-08-10 10:00:00', 2, 2),
('2024-08-10 12:00:00', 3, 3),
('2024-08-11 09:00:00', 4, 4),
('2024-08-11 11:00:00', 5, 5),
('2024-08-12 07:00:00', 6, 6),
('2024-08-12 13:00:00', 7, 7),
('2024-08-13 15:00:00', 8, 8),
('2024-08-13 17:00:00', 9, 9);
GO
-- Insert data into Airplanes
INSERT INTO Airplanes ([Name], PassengerCount, [ScheduleId]) VALUES
('Boeing 737', 150, 1),
('Airbus A320', 180, 2),
('Boeing 787', 250, 3),
('Airbus A330', 280, 4),
('Boeing 747', 400, 5),
('Airbus A340', 350, 6),
('Boeing 777', 300, 7),
('Airbus A350', 290, 8),
('Boeing 767', 220, 9);
GO
-- Insert data into Tickets
INSERT INTO Tickets ([ScheduleId], [FlightTypeId]) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 8),
(9, 9);

GO
USE FlightDb
GO
CREATE  PROCEDURE GetTicketById
	@ticket_id INT
	AS
	BEGIN
	
	SELECT * FROM Tickets
	WHERE Tickets.Id=@ticket_id
	
	END