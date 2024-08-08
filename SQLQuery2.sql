USE FlightDb

GO
-- Delete data from Tickets
DELETE FROM Tickets;
GO
-- Delete data from Airplanes
DELETE FROM Airplanes;
GO
-- Delete data from Schedules
DELETE FROM Schedules;
GO
-- Delete data from FlightTypes
DELETE FROM FlightTypes;
GO
-- Delete data from Cities
DELETE FROM Cities;
GO
-- Delete data from Pilots
DELETE FROM Pilots;
GO

-- Truncate tables to remove all data
TRUNCATE TABLE Tickets;
GO

TRUNCATE TABLE Airplanes;
GO

TRUNCATE TABLE Schedules;
GO

TRUNCATE TABLE FlightTypes;
GO

TRUNCATE TABLE Cities;
GO

TRUNCATE TABLE Pilots;
GO



-- Insert data into Pilots
INSERT INTO Pilots ([Name], Surname) VALUES
('John', 'Doe'),
('Jane', 'Smith'),
('Emily', 'Johnson'),
('Michael', 'Brown'),
('Sarah', 'Davis'),
('David', 'Wilson'),
('Laura', 'Martinez'),
('James', 'Garcia'),
('Linda', 'Anderson'),
('Robert', 'Thomas');
GO
-- Insert data into Cities
INSERT INTO Cities ([Name], DistanceFromCurrentCity) VALUES
('New York', 0),
('Los Angeles', 2451),
('Chicago', 1138),
('Houston', 1611),
('Phoenix', 2152),
('Philadelphia', 150),
('San Antonio', 1866),
('San Diego', 2454),
('Dallas', 1824),
('San Jose', 2545);
GO
-- Insert data into FlightTypes
INSERT INTO FlightTypes ([Type]) VALUES
('Economy'),
('Business'),
('First Class'),
('Premium Economy'),
('Charter'),
('Private'),
('Economy Plus'),
('Standard'),
('Luxury'),
('Budget');
GO

INSERT INTO Schedules (StartDateTime, CityId, PilotId) VALUES
('2024-08-01 08:00:00', 10, 10),
('2024-08-01 10:00:00', 10, 11),
('2024-08-01 12:00:00', 10, 12),
('2024-08-01 08:00:00', 11, 13),
('2024-08-01 10:00:00', 11, 14),
('2024-08-01 12:00:00', 11, 15),
('2024-08-01 08:00:00', 12, 16),
('2024-08-01 10:00:00', 12, 17),
('2024-08-01 12:00:00', 12, 18),
('2024-08-02 12:00:00', 13, 19),
('2024-08-02 14:00:00', 13, 10),
('2024-08-02 16:00:00', 13, 11),
('2024-08-02 18:00:00', 14, 12),
('2024-08-02 20:00:00', 14, 13),
('2024-08-03 08:00:00', 14, 14),
('2024-08-03 10:00:00', 15, 15),
('2024-08-03 12:00:00', 15, 16),
('2024-08-03 14:00:00', 15, 17),
('2024-08-03 16:00:00', 16, 18),
('2024-08-03 18:00:00', 16, 19),
('2024-08-03 20:00:00', 16, 10),
('2024-08-04 08:00:00', 17, 11),
('2024-08-04 10:00:00', 17, 12),
('2024-08-04 12:00:00', 17, 13),
('2024-08-04 14:00:00', 18, 14),
('2024-08-04 16:00:00', 18,15),
('2024-08-04 18:00:00', 18, 16),
('2024-08-04 18:00:00', 19, 17),
('2024-08-04 18:00:00', 19, 18),
('2024-08-04 18:00:00', 19, 19);

GO
INSERT INTO Airplanes ([Name], PassengerCount, ScheduleId) VALUES
('Boeing 737', 150, 13),
('Airbus A320', 180, 14),
('Boeing 787', 250, 15),
('Airbus A380', 500, 16),
('Boeing 747', 400, 17),
('Airbus A330', 250, 18),
('Boeing 767', 200, 19),
('Airbus A321', 220, 20),
('Boeing 757', 180, 21),
('Airbus A319', 150, 22),
('Boeing 737', 150, 23),
('Airbus A320', 180, 24),
('Boeing 787', 250, 25),
('Airbus A380', 500, 26),
('Boeing 747', 400, 27),
('Airbus A330', 250, 28),
('Boeing 767', 200, 29),
('Airbus A321', 220, 30),
('Boeing 757', 180, 31),
('Airbus A319', 150, 32),
('Boeing 737', 150, 33),
('Airbus A320', 180, 34),
('Boeing 787', 250, 35),
('Airbus A380', 500, 36),
('Boeing 747', 400, 37),
('Airbus A330', 250, 38),
('Boeing 767', 200, 39),
('Airbus A321', 220, 40),
('Boeing 757', 180, 41),
('Airbus A319', 150, 42);

Go
INSERT INTO Tickets (ScheduleId, FlightTypeId) VALUES
(13, 10),
(14, 11),
(15, 12),
(16, 13),
(17, 14),
(18, 15),
(19, 16),
(20, 17),
(21, 18),
(22, 19),
(23, 10),
(24, 11),
(25, 12),
(26, 13),
(27, 14),
(28, 15),
(29, 16),
(30, 17),
(31, 18),
(32, 19),
(33, 10),
(34, 11),
(35, 12),
(36, 13),
(37, 14),
(38, 15),
(39, 16),
(40, 17),
(41, 18),
(42, 19);