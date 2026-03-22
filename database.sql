CREATE DATABASE EcommerceDB;
GO

USE EcommerceDB;
GO

-- Users Table
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    MobileNumber NVARCHAR(20),
    Otp NVARCHAR(10),
    IsVerified BIT,
    CreatedDate DATETIME DEFAULT GETDATE()
);

-- Categories Table
CREATE TABLE Categories (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    ImageUrl NVARCHAR(255) NULL,
    IsActive BIT,
    CreatedDate DATETIME DEFAULT GETDATE()
);

-- Products Table
CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Price DECIMAL(10,2),
    CategoryId INT,
    Description NVARCHAR(255),
    ImageUrl NVARCHAR(255) NULL,
    Stock INT,
    IsBestSeller BIT,
    CreatedDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);

-- Favourites Table
CREATE TABLE Favourites (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT,
    ProductId INT,
    CreatedDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(Id),
    FOREIGN KEY (ProductId) REFERENCES Products(Id)
);

-- Cart Table
CREATE TABLE Cart (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT,
    ProductId INT,
    Quantity INT,
    CreatedDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(Id),
    FOREIGN KEY (ProductId) REFERENCES Products(Id)
);

-- Sample Data

INSERT INTO Categories (Name, IsActive)
VALUES 
('Fruits', 1),
('Vegetables', 1),
('Beverages', 1);

INSERT INTO Products (Name, Price, CategoryId, Description, Stock, IsBestSeller)
VALUES
('Apple', 120, 1, 'Fresh red apple', 50, 1),
('Banana', 60, 1, 'Fresh banana', 100, 1),
('Carrot', 40, 2, 'Organic carrot', 80, 0);
