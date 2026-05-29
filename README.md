# 🛒 E-Commerce System

<div align="center">

![ASP.NET MVC](https://img.shields.io/badge/ASP.NET_MVC-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![EF Core](https://img.shields.io/badge/EF_Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![JWT](https://img.shields.io/badge/JWT-000000?style=for-the-badge&logo=jsonwebtokens&logoColor=white)

</div>

## 📋 Overview

A complete **E-Commerce System** built with ASP.NET MVC following a clean **3-Layer Architecture**. The platform provides a full shopping experience from product browsing to order management, with a secure admin dashboard.

---

## ✨ Features

- 🛍️ **Product Catalog** - Browse and search products by category
- 🛒 **Shopping Cart** - Add, update, and remove items
- 📦 **Order Management** - Place and track orders
- 👤 **User Authentication** - Register, login with JWT security
- 🔐 **Role-Based Access** - Admin and Customer roles
- 🖥️ **Admin Dashboard** - Manage products, orders, and users
- 💳 **Payment Integration** - Handle payment processing

---

## 🏗️ Architecture

ECommerce/ ├── ECommerce.BLL/ # Business Logic Layer ├── ECommerce.DAL/ # Data Access Layer └── ECommerce.PL/ # Presentation Layer (MVC)

---

## 🛠️ Tech Stack

| Technology | Usage |
|-----------|-------|
| ASP.NET MVC | Web Framework |
| Entity Framework Core | ORM & Database Management |
| SQL Server | Database |
| C# | Programming Language |
| JWT | Authentication & Authorization |
| LINQ | Data Querying |
| Bootstrap | Frontend Styling |

---

## 🚀 Getting Started

### Prerequisites
- .NET 8 SDK
- SQL Server
- Visual Studio 2022

### Installation

1. **Clone the repository**
```bash
git clone https://github.com/MohammedRamadan11/ECommerce.git
Update connection string in appsettings.json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=ECommerceDB;Trusted_Connection=True;"
}
Apply migrations
dotnet ef database update
Run the project
dotnet run
