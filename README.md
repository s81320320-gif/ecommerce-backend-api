# ecommerce-backend-api
.NET Web API for Ecommerce backend assignment
# Ecommerce Backend API

This is a .NET 8 Web API project for an Ecommerce backend assignment.

## Features

- OTP Authentication
- Get Categories
- Get Best Seller Products
- Add to Cart
- Add / Remove Favourite

## Technologies Used

- .NET 8 Web API
- Entity Framework Core
- SQL Server
- Swagger

## How to Run the Project

1. Clone the repository

git clone https://github.com/s81320320-gif/ecommerce-backend-api.git

2. Open in Visual Studio

3. Run database.sql in SQL Server

4. Update connection string in appsettings.json

5. Run the project

6. Open Swagger

http://localhost:5283/swagger

## API Endpoints

POST /api/Auth/send-otp  
POST /api/Auth/verify-otp  
GET /api/Category  
GET /api/Product/bestsellers  
POST /api/Favourite/addtofavourite  
DELETE /api/Favourite/remove/{productId}
