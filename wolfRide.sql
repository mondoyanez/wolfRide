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
	UserType VarChar(8)
);

CREATE TABLE RideStatus (
	RideStatusID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	RideStatus VARCHAR(256)
);

CREATE TABLE PaymentStatus (
	PaymentStatusID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	PaymentStatus VARCHAR(256)
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

	Rider INT FOREIGN KEY REFERENCES [USER](UserID),
	Driver INT FOREIGN KEY REFERENCES [USER](UserID),
	RideStatus INT FOREIGN KEY REFERENCES RideStatus(RideStatusID),
	PaymentStatus INT FOREIGN KEY REFERENCES PaymentStatus(PaymentStatusID)
);

INSERT INTO Credentials
VALUES ('Mondoyanez', 'Password!'), ('Peteparker', 'FriendlyNeighborhood'), ('RBicchieri', 'batminger'),
('AnnetteWhitney','warcamp'), ('NoachFay','smartSoccer'), ('OthmanWiegand','masterSure'), ('FearghasHagen','piperFervent'),
('HengBlue','rindingKeep'),('KwadwoHerbert','historyYellow'),('AoalsteinnYeung','steelBlock');

INSERT INTO UserType
VALUES ('Rider'), ('Driver'), ('Admin');

INSERT INTO RideStatus
VALUES ('Awaiting pickup'), ('In Progress'), ('Completed');

INSERT INTO PaymentStatus
VALUES ('Awaiting Payment'),('Paid in Full');

INSERT INTO [State]
VALUES ('OR');

INSERT INTO Locale(City, StateID)
VALUES ('McMinnville', 1), ('Newberg', 1), ('Portland', 1), ('Monmouth', 1), ('Salem', 1), ('Woodburn', 1), ('Tualatin', 1), ('Eugene', 1), ('Lake Oswego', 1), ('Oregon City', 1);

INSERT INTO Zip
VALUES (97128), (97132), (97035), (97361), (97301), (97071), (97062), (97401), (97034), (97045);

INSERT INTO MakeModel
VALUES ('Tesla', 'Model S'), ('Ford', 'Taurus'), ('BMW','3 Series'), ('Chevrolet','Malibu'), ('Mercedes-Benz','CLA 250 4MATIC COUPE');

INSERT INTO Vehicle
VALUES ('647-LKC', 2), ('281-OJE', 4), ('903-KVM', 5), ('124-ETM', 1), ('361-OZP', 3), ('201-NNI', 4), ('579-ALC', 2), ('685-RDX', 3), ('458-JJW', 1), ('662-HSM', 5);

SELECT * FROM Credentials;
SELECT * FROM UserType;
SELECT * FROM RideStatus;
SELECT * FROM PaymentStatus;
SELECT * FROM [State];
SELECT * FROM Locale;
SELECT * FROM Zip;
SELECT * FROM MakeModel;
SELECT * FROM Vehicle;

DROP TABLE [Credentials], [Address], Locale, MakeModel, PaymentStatus, Ride, RideStatus, [User], UserType, Vehicle, Zip, [State];