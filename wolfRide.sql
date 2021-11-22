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

INSERT INTO Credentials
VALUES ('Armando Yanez', 'Password!'), ('Peter Parker', 'Spider-Man');

SELECT * FROM Credentials;