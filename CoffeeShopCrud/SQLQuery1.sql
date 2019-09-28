CREATE DATABASE CoffeeShop
USE CoffeeShop

CREATE TABLE Items(
ID INT IDENTITY(1,1),
Name VARCHAR(50),
Price FLOAT
)
CREATE TABLE Customer(
ID INT IDENTITY(1,1),
CustomerName VARCHAR(50),
Address VARCHAR(50),
Contact VARCHAR(15)
)

CREATE TABLE Orders(
ID INT IDENTITY(1,1),
CustomerName VARCHAR(50),
ItemName VARCHAR(50),
Price FLOAT,
Quantity FLOAT
)

DROP TABLE Customer
INSERT INTO Items (Name, Price) Values ('Black', 120)
INSERT INTO Items (Name, Price) Values ('Black', 120)
INSERT INTO Items (Name, Price) Values ('Cold', 100)
INSERT INTO Items (Name, Price) Values ('Hot', 90)


SELECT * FROM Items
SELECT * FROM Customer
SELECT * FROM Orders

DELETE FROM Items WHERE ID = 3

UPDATE Items
SET
Name = 'Reguler' ,
Price = 80
WHERE ID = 2

UPDATE Items
SET
Name = 'Cuppuchino' ,
Price = 200
WHERE ID = 3

SELECT Name, Price FROM Items
WHERE Price >=100