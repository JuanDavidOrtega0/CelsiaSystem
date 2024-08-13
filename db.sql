-- Active: 1723581793647@@b6c1kxse6jjqsfnfmzzz-mysql.services.clever-cloud.com@3306@b6c1kxse6jjqsfnfmzzz

CREATE TABLE Users (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(55),
    Email VARCHAR(125) UNIQUE,
    Password TEXT
);

CREATE TABLE Transactions (
    Id VARCHAR(10) PRIMARY KEY,
    DateTime DATETIME,
    Amount INT,
    Status VARCHAR(35),
    Type VARCHAR(35)
);

CREATE TABLE Invoices (
    Id VARCHAR(15) PRIMARY KEY,
    Period VARCHAR(15),
    InvoicedAmount INT,
    AmountPaid INT
);

CREATE TABLE Customers (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(55),
    Document VARCHAR(20) UNIQUE,
    Address VARCHAR(125),
    PhoneNumber VARCHAR(35) UNIQUE,
    Email VARCHAR(125) UNIQUE,
    UsedPlatform VARCHAR(35)
);