# ShelfSync – Blazor Web Inventory Manager

**ShelfSync** is a full-stack inventory management web application built with Blazor and .NET 9 for organizing storage bins and items. Features custom barcode scanning integration (in development), ASP.NET Core Identity authentication, and a PostgreSQL database managed through Entity Framework Core with code-first migrations. The database is containerized with Docker for easy deployment on local networks.

---

## 🚀 Features

- 🔐 **Authentication & Authorization**
  - Admin and user roles
  - Secure login/logout using ASP.NET Identity

- 📦 **Storage Bin Management**
  - Create, view, update, and delete bins
  - Each bin can contain multiple items 

- 📝 **Item Management**
  - CRUD for items per bin
  - Quantity tracking

**Upcomming:**
- 📇 **Barcode System** 
  - Generate and print barcodes for bins
  - Scan barcodes using a phone camera to view bin contents ( to be implemented)

- ✅ **Checklists** 
  - View online or printable checklists for bin contents



---

## 🛠️ Tech Stack

- **Frontend**: Blazor Web App (.NET 9) [hybrid (Interactive Server + Interactive WASM)]
- **Backend**: ASP.NET Core Web API
- **Database**: PostgreSQL
- **ORM**: Entity Framework Core
- **Authentication**: ASP.NET Core Identity



---

## 📖 Documentation

- [Database & Server Setup Guide](Documentation/ShelfSyncDatabaseServerSetup.md)

