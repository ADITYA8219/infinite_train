
 
--1NF

CREATE TABLE Rentals (

    RentalID INT PRIMARY KEY,

    ClientNo VARCHAR(5),

    cName VARCHAR(50),

    propertyNo VARCHAR(5),

    pAddress VARCHAR(100),

    rentStart DATE,

    rentFinish DATE,

    rent DECIMAL(10, 2),

    ownerNo VARCHAR(5),

    oName VARCHAR(50)

);
 
INSERT INTO Rentals (RentalID, ClientNo, cName, propertyNo, pAddress, rentStart, rentFinish, rent, ownerNo, oName)

VALUES

    (1, 'CR76', 'John Kay', 'PG4', '6 Lawrence St, Glasgow', '2000-07-01', '2001-08-31', 350, 'C040', 'Tina Murphy'),

    (2, 'CR76', 'John Kay', 'PG16', '5 Novar Dr, Glasgow', '2002-09-01', '2002-09-01', 450, 'C093', 'Tony Shaw'),

    (3, 'CR56', 'Aline Stewart', 'PG4', '6 Lawrence St, Glasgow', '1999-09-01', '2000-06-10', 350, 'C040', 'Tina Murphy'),

    (4, 'CR56', 'Aline Stewart', 'PG36', '2 Manor Rd, Glasgow', '2000-10-10', '2001-12-01', 370, 'C093', 'Tony Shaw'),

    (5, 'CR56', 'Aline Stewart', 'PG16', '5 Novar Dr, Glasgow', '2002-11-01', '2003-08-03', 450, 'C093', 'Tony Shaw');
 
 
SELECT * FROM Rentals
 
--2NF
 
-- Clients Table

CREATE TABLE Clients1 (

    ClientNo VARCHAR(5) PRIMARY KEY,

    cName VARCHAR(50)

);
 
INSERT INTO Clients1 (ClientNo, cName)

VALUES

    ('CR76', 'John Kay'),

    ('CR56', 'Aline Stewart');
 
-- Properties Table

CREATE TABLE Properties (

    propertyNo VARCHAR(5) PRIMARY KEY,

    pAddress VARCHAR(100),

    rent DECIMAL(10, 2),

    ownerNo VARCHAR(5)

);
 
INSERT INTO Properties (propertyNo, pAddress, rent, ownerNo)

VALUES

    ('PG4', '6 Lawrence St, Glasgow', 350, 'C040'),

    ('PG16', '5 Novar Dr, Glasgow', 450, 'C093'),

    ('PG36', '2 Manor Rd, Glasgow', 370, 'C093');
 
-- Owners Table

CREATE TABLE Owners (

    ownerNo VARCHAR(5) PRIMARY KEY,

    oName VARCHAR(50)

);
 
INSERT INTO Owners (ownerNo, oName)

VALUES

    ('C040', 'Tina Murphy'),

    ('C093', 'Tony Shaw');
 
 
-- Rentals Table

CREATE TABLE Rentals1 (

    RentalID INT PRIMARY KEY,

    ClientNo VARCHAR(5),

    propertyNo VARCHAR(5),

    rentStart DATE,

    rentFinish DATE,

    FOREIGN KEY (ClientNo) REFERENCES Clients1(ClientNo),

    FOREIGN KEY (propertyNo) REFERENCES Properties(propertyNo)

);
 
INSERT INTO Rentals1 (RentalID, ClientNo, propertyNo, rentStart, rentFinish)

VALUES

    (1, 'CR76', 'PG4', '2000-07-01', '2001-08-31'),

    (2, 'CR76', 'PG16', '2002-09-01', '2002-09-01'),

    (3, 'CR56', 'PG4', '1999-09-01', '2000-06-10'),

    (4, 'CR56', 'PG36', '2000-10-10', '2001-12-01'),

    (5, 'CR56', 'PG16', '2002-11-01', '2003-08-03');
 
SELECT * FROM Clients

SELECT * FROM Properties

SELECT * FROM Owners

SELECT * FROM Rentals
 