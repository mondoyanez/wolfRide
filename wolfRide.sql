IF DB_ID('wolfRide') IS NOT NULL
DROP DATABASE wolfRide;
GO

CREATE DATABASE wolfRide;
GO

USE wolfRide;

CREATE TABLE Credentials (
	UserName VARCHAR(256) PRIMARY KEY,
	[Password] VARCHAR(512) NOT NULL
);

CREATE TABLE UserType (
	UserTypeID INT PRIMARY KEY,
	UserType VarChar(8)
);

CREATE TABLE RideStatus (
	RideStatusID INT PRIMARY KEY,
	RideStatus VARCHAR(256)
);

CREATE TABLE PaymentStatus (
	PaymentStatusID INT PRIMARY KEY,
	PaymentStatus VARCHAR(256)
);

CREATE TABLE MakeModel (
	MakeModelID INT PRIMARY KEY,
	Make VARCHAR(256),
	Model VARCHAR(256)
);

CREATE TABLE Vehicle (
	VehicleID INT PRIMARY KEY,
	LicensePlate VARCHAR(256),

	MakeModelID INT FOREIGN KEY REFERENCES MakeModel(MakeModelID)
);

CREATE TABLE Locale (
	LocaleID INT PRIMARY KEY,
	City VARCHAR(256),
	[STATE] VARCHAR(2)
);

CREATE TABLE Zip (
	ZipID INT PRIMARY KEY,
	ZipCode INT
);

CREATE TABLE [Address] (
	AddressID INT PRIMARY KEY,
	Line1 VARCHAR(256),
	Line2 VARCHAR(256),
	LocaleID INT FOREIGN KEY REFERENCES Locale(LocaleID),
	ZipID INT FOREIGN KEY REFERENCES Zip(ZipID)
);

CREATE TABLE [User] (
	UserID INT PRIMARY KEY,
	FullName VARCHAR(256),
	PhoneNumber VarChar(12),
	Email VarChar(256),
	Balance MONEY,

	UserTypeID INT FOREIGN KEY REFERENCES UserType(UserTypeID),
	AddressID INT FOREIGN KEY REFERENCES [Address](AddressID),
	CredentialsID VARCHAR(256) FOREIGN KEY REFERENCES Credentials(UserName)
);

CREATE TABLE Ride (
	RideID INT PRIMARY KEY,
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
VALUES ('Armando Yanez', 'Password!'), ('Peter Parker', 'Spider-Man');

SELECT * FROM Credentials;

--DROP TABLE [USER];