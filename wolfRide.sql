USE wolfRide;

IF DB_ID('wolfRide') IS NOT NULL
DROP DATABASE wolfRide;
GO

CREATE DATABASE wolfRide;
GO

USE wolfRide;

CREATE TABLE [Credentials] (
	UserName VARCHAR(256) PRIMARY KEY,
	[Password] VARCHAR(512) NOT NULL
);

CREATE TABLE UserType (
	UserTypeID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	UserType VarChar(64)
);

CREATE TABLE RideStatus (
	RideStatusID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	RideStatus VARCHAR(256)
);

CREATE TABLE MakeModel (
	MakeModelID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Make VARCHAR(256),
	Model VARCHAR(256)
);

CREATE TABLE Vehicle (
	VehicleID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	LicensePlate VARCHAR(256),

	MakeModelID INT FOREIGN KEY REFERENCES MakeModel(MakeModelID)
);

CREATE TABLE [State] (
	StateID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[State] VARCHAR(2)
);

CREATE TABLE Locale (
	LocaleID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	City VARCHAR(256),
	
	StateID INT FOREIGN KEY REFERENCES [STATE](StateID)
);

CREATE TABLE Zip (
	ZipID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	ZipCode INT
);

CREATE TABLE [Address] (
	AddressID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Line1 VARCHAR(256),
	Line2 VARCHAR(256),
	LocaleID INT FOREIGN KEY REFERENCES Locale(LocaleID),
	ZipID INT FOREIGN KEY REFERENCES Zip(ZipID)
);

CREATE TABLE [User] (
	UserID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	FullName VARCHAR(256),
	PhoneNumber VarChar(12),
	Email VarChar(256),
	Balance MONEY,

	UserTypeID INT FOREIGN KEY REFERENCES UserType(UserTypeID),
	AddressID INT FOREIGN KEY REFERENCES [Address](AddressID),
	CredentialsID VARCHAR(256) FOREIGN KEY REFERENCES Credentials(UserName)
);

CREATE TABLE Ride (
	RideID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	NumOfPassengers INT,
	EstimatedTimeOfArrival TIME,
	PickupTime TIME,
	Destination VARCHAR(256),

	Rider INT FOREIGN KEY REFERENCES [User](UserID),
	Driver INT FOREIGN KEY REFERENCES [User](UserID),
	VehicleID INT FOREIGN KEY REFERENCES [Vehicle](VehicleID),
	RideStatus INT FOREIGN KEY REFERENCES RideStatus(RideStatusID)
);

INSERT INTO Credentials
VALUES ('mondoyanez', 'password'), ('Peteparker', 'FriendlyNeighborhood'), ('RBicchieri', 'batminger'),
('AnnetteWhitney','warcamp'), ('NoachFay','smartSoccer'), ('OthmanWiegand','masterSure'), ('FearghasHagen','piperFervent'),
('HengBlue','rindingKeep'),('KwadwoHerbert','historyYellow'),('AoalsteinnYeung','steelBlock');

INSERT INTO UserType
VALUES ('Rider'), ('Driver'), ('User/Driver'), ('Admin'), ('User/Admin'), ('Driver/Admin'), ('User/Driver/Admin');

INSERT INTO RideStatus
VALUES ('Awaiting pickup'), ('In Progress'), ('Completed');

INSERT INTO [State]
VALUES ('OR');

INSERT INTO Locale(City, StateID)
VALUES ('McMinnville', 1), ('Newberg', 1), ('Portland', 1), ('Monmouth', 1), ('Salem', 1), ('Woodburn', 1), ('Tualatin', 1), ('Eugene', 1), ('Lake Oswego', 1), ('Oregon City', 1);

INSERT INTO Zip
VALUES (97128), (97132), (97202), (97361), (97301), (97071), (97062), (97401), (97034), (97045);

INSERT INTO MakeModel
VALUES ('NOT ', 'KNOWN'), ('Tesla', 'Model S'), ('Ford', 'Taurus'), ('BMW','3 Series'), ('Chevrolet','Malibu'), ('Mercedes-Benz','CLA 250 4MATIC COUPE');

INSERT INTO Vehicle(MakeModelID)
VALUES(1);

INSERT INTO Vehicle
VALUES ('647-LKC', 3), ('281-OJE', 5), ('903-KVM', 6), ('124-ETM', 2), ('361-OZP', 4), ('201-NNI', 5), ('579-ALC', 3), ('685-RDX', 4), ('458-JJW', 2), ('662-HSM', 6);

INSERT INTO Address(Line1, Line2, LocaleID, ZipID)
VALUES ('230 NW 19th St', '', 1, 1), ('520 E Michelle Ct', '', 2, 2), ('3608 SE Center St', '', 3, 3), ('110 Craven St S', '', 4, 4), ('3327 Rockingham Ct NE', '', 5 ,5),
('858 Ostrom Dr', '', 6, 6), ('7119 SW Sagert St', 'Unit 104', 7, 7), ('1478 Pearl St', '', 8, 8), ('668 McVey Ave', 'Unit 31', 9, 9), ('705 9th St', '', 10, 10);

INSERT INTO [User](FullName)
VALUES ('UNKNOWN')

INSERT INTO [User]
VALUES ('Armando Yanez', '847-364-4431', 'armandoyanez@yahoo.com', 200, 7, 1, 'mondoyanez'),
('Peter Parker', '753-278-8064', 'peterparker@gmail.com', 100, 2, 2, 'Peteparker'),
('Richard Bicchieri', '906-681-7333', 'richBicchieri@msn.com', 92, 3, 3, 'RBicchieri'),
('Annette Whitney', '486-494-4958', 'annWhitney@yahoo.com', 122, 1, 4, 'AnnetteWhitney'),
('Noach Fay', '726-847-4723', 'nFay@yahoo.com', 100, 1, 5, 'NoachFay'),
('Othman Wiegand', '855-796-8426', 'OthmanWiegand@gmail.com', 120, 1, 6, 'OthmanWiegand'),
('Fearghas Hagen', '800-870-6253', 'FearghasHagen@yahoo.com', 72, 1, 7, 'FearghasHagen'),
('Heng Blue', '859-394-5230', 'HengBlue@msn.com', 96, 3, 8, 'HengBlue'),
('Kwadwo Herbert', '497-504-5577', 'KwadwoHerbert@yahoo.com', 106, 1, 9, 'KwadwoHerbert'),
('Aoalsteinn Yeung', '865-449-8345', 'AoalsteinnYeung@gmail.com', 112, 1, 10, 'AoalsteinnYeung');

--------------------------------------------------------------------------------------------------------------------------------------------------
-- Debugging / Testing
--------------------------------------------------------------------------------------------------------------------------------------------------


/*
--Testing

SELECT * FROM Credentials;
SELECT * FROM [State];
SELECT * FROM Locale;
SELECT * FROM Zip;
SELECT * FROM [Address];
SELECT * FROM [User];

SELECT * FROM [Address]
WHERE Line1 = '230 NW 19th St' AND Line2 = '';

DELETE FROM Credentials WHERE UserName = 'mondoyanez';
DELETE FROM [State] WHERE [State] = 'NY';
DELETE FROM Locale WHERE City = 'Manhatten';
DELETE FROM Zip WHERE ZipCode = 10001;
DELETE FROM [Address] WHERE Line1 = '2389 NE Lafayette Ave';
DELETE FROM [User] WHERE FullName = 'Armando Yanez';
*/


INSERT INTO Ride
VALUES (2, DATEADD(MINUTE, 30, GETDATE()), DATEADD(MINUTE, 15, GETDATE()), 'Western Oregon University- Math Center', 1, 11, 11, 1);

INSERT INTO Ride(NumOfPassengers, EstimatedTimeOfArrival, PickupTime, Destination, Rider, RideStatus)
VALUES (2, DATEADD(MINUTE, 30, GETDATE()), DATEADD(MINUTE, 15, GETDATE()), 'Western Oregon University- Math Center', 4, 1);

UPDATE Ride
SET Driver = 5, VehicleID = 4
WHERE RideID = 5;

UPDATE Ride
SET RideStatus = 2
WHERE RideID = 5;

SELECT * FROM [State];
SELECT * FROM Locale;
SELECT * FROM Zip;
SELECT * FROM MakeModel;
SELECT * FROM Vehicle;
SELECT * FROM Credentials;
SELECT * FROM [User];
SELECT * FROM Ride;
SELECT * FROM UserType;
SELECT * FROM [Address];
SELECT * FROM RideStatus;

DELETE FROM Ride WHERE Rider = 1;

SELECT U.FullName AS 'Driver', M.Make + ' ' + M.Model AS 'Car', PickupTime, EstimatedTimeOfArrival, Destination  FROM Ride AS R
INNER JOIN [User] AS U ON R.Driver = U.UserID
INNER JOIN [User] AS U2 ON R.Rider = U2.UserID
INNER JOIN Vehicle AS V ON R.VehicleID = V.VehicleID
INNER JOIN MakeModel AS M ON V.MakeModelID = M.MakeModelID
WHERE R.RideStatus <> 3 AND U2.CredentialsID = 'mondoyanez'

SELECT U.FullName AS 'Rider', R.NumOfPassengers AS '# of Passengers', Destination FROM Ride AS R
INNER JOIN [User] AS U ON R.Rider = U.UserID
WHERE RideStatus = 1;

SELECT U.FullName AS 'Rider', PickupTime, EstimatedTimeOfArrival, Destination  FROM Ride AS R
INNER JOIN [User] AS U ON R.Rider = U.UserID
--U.CredentialsID = @credentialID

SELECT *  FROM Ride AS R
INNER JOIN [User] AS U1 ON R.Rider = U1.UserID
INNER JOIN [User] AS U2 ON R.Driver = U2.UserID
WHERE U2.UserID = 2
--U.CredentialsID = @credentialID

SELECT Balance FROM [User]
WHERE CredentialsID = 'mondoyanez';

UPDATE [User]
SET Balance = 0
WHERE FullName = 'Armando Yanez' AND CredentialsID = 'mondoyanez';

UPDATE Ride
SET RideStatus = 2
WHERE RideID = 3;

DROP TABLE [Credentials], [Address], Locale, MakeModel, Ride, [User], UserType, Vehicle, Zip, [State], RideStatus;
