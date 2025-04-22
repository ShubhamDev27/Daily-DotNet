
# ASP.NET Core MVC - Entity Framework Core CRUD Application

This project demonstrates how to build a **CRUD (Create, Read, Update, Delete)** web application using **ASP.NET Core MVC** and **Entity Framework Core**, connected to a SQL Server database.

## 🔧 Project Setup Steps

### Step 1: Create the Project
- Create a new ASP.NET Core Web App (Model-View-Controller) project.
- NOT a console app.

### Step 2: Install Required NuGet Packages

Use the NuGet Package Manager Console and install the following:

```bash
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Microsoft.EntityFrameworkCore.Design
Install-Package Microsoft.Extensions.Configuration.Json
Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design
```

### Step 3: Create Folder Structure

```
ProjectRoot/
│
├── Controllers/               # EmployeeController.cs
├── Models/                   # All POCO classes (like Employee.cs)
├── Repository/               # AppDbContext.cs with DbContext implementation
├── Service/                  # IEmployee interface & IEmployeeService class
├── Views/                    # Razor Views for Employee (Index.cshtml, Edit.cshtml, etc.)
└── appsettings.json          # Contains DB connection string
```

### Step 4: Add Connection String

Paste your SQL Server connection string inside `appsettings.json` like this:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "ConnectionStrings": {
    "EmployeeDBConnection": "Data Source=(localdb)\\Projects;Initial Catalog=demodb;Integrated Security=True"
  },
  "AllowedHosts": "*"
}
```

### Step 5: Configure Services in `Program.cs`

```csharp
builder.Services.AddDbContextPool<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDBConnection")));
builder.Services.AddScoped<IEmployee, IEmployeeService>();
```

### Step 6: Rename Controller if needed

Make sure your controller is named `EmployeeController` and inherits from `Controller`.

### Step 7: Create Initial Migration & Update Database

```bash
Add-Migration InitialCreate
Update-Database
```

### Step 8: Add Seed Data (manually via SSMS or application)

### Step 9: Reinstall Code Generation Tool (if needed)

```bash
Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design -Version 8.0.4
```

### Step 10: Create Views

Right-click `Index` method in controller > Add View > Razor View

### Step 11: Implement Interface

Add methods like `Update()` and `Delete()` to both `IEmployee` interface and `IEmployeeService` class.

---

## ✅ Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- Razor Views
- SQL Server
- Dependency Injection

---

## 🗂 Folder Structure Summary

- `Models/` – Contains Employee.cs (POCO class)
- `Repository/` – Contains AppDbContext.cs for database interaction
- `Service/` – Contains IEmployee interface and IEmployeeService class
- `Controllers/` – Contains EmployeeController.cs
- `Views/` – Razor views (not shown here)
- `appsettings.json` – Database connection config

---

## 📌 Note

Don't forget to create corresponding Razor Views (Index, Create, Edit, Details, Delete) under `Views/Employee/`.

---

## Author

Made with ❤️ using ASP.NET Core MVC + EF Core.
