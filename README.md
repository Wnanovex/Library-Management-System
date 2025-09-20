# Library Management System

A Windows Forms application developed in **C# (.NET)** with a **SQL Server** backend, using **stored procedures** and **functions** for efficient data access and business logic execution.

This project follows the **three-tier architecture**:

- **UI Layer** – User Interface (WinForms)
- **BLL** – Business Logic Layer (C#)
- **DAL** – Data Access Layer (C# with ADO.NET + SQL Server stored procedures)


## 🛠️ Features

- 🔐 User authentication with SQL (login system)
- 📖 Manage books, authors, and categories
- 👤 Manage library members
- 📚 Issue/return books
- 💰 Fine calculation using SQL functions
- ⚡ High performance using **stored procedures**
- 🧾 Cleanly separated logic using **3-tier architecture**

## 💻 Technologies Used

- **Language**: C#
- **Framework**: .NET Framework 4.8
- **UI**: WinForms
- **Database**: SQL Server (with stored procedures and functions)
- **ORM/Access**: ADO.NET
- **IDE**: Visual Studio 2022

## 🚀 Getting Started

### 🧱 Prerequisites

- Visual Studio (with .NET Desktop Development workload)
- SQL Server (any edition)
- SQL Server Management Studio (SSMS)
- .NET SDK (.NET Framework 4.8)

---

### ⚙️ Setup Instructions

#### 1. **Clone the Repository**

```bash
git clone https://github.com/Wnanovex/Library-Management-System.git
cd Library-Management-System
```

#### 2. **Restore the database**

  1. Place the LibraryDB.bak file in a folder accessible by SQL Server (e.g., C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\Backup\)

  2. Open SQL Server Management Studio (SSMS) and connect to your server

  3. Click New Query

  4. Restore the database
```sql
    RESTORE DATABASE LibraryDB
    FROM DISK = 'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\Backup\LibraryDB.bak';
```

#### 3. **Open the solution**

Open LibraryManagementSystem.UI.sln in Visual Studio

#### 4. **Configure the database connection**

Edit the connection string in `LibraryManagementSystem.DAL\clsDataAccessSettings.cs`

```csharp
    string connectionString = "Server=YOUR_SERVER_NAME;Database=LibraryDB;User Id=your_user;Password=your_password;";
```

#### 5. **Build and run the application**

- Set LibraryManagementSystem.UI as the startup project

- Press F5 or click Start in Visual Studio



# Screenshots

![Screenshot1](https://github.com/user-attachments/assets/2f346f2a-7c5d-4fa0-bc39-11453b91f8cb)

![Screenshot2](https://github.com/user-attachments/assets/a014b0dd-64ce-4423-87ae-4f69f3b0a408)

![Screenshot3](https://github.com/user-attachments/assets/2b7b2089-3ee4-4321-9737-45a0e371b570)

![Screenshot4](https://github.com/user-attachments/assets/f14f6eaa-904c-4daa-89c5-0f40755bd43e)
