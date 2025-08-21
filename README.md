# ShelfSync – Blazor Web Inventory Manager

**ShelfSync** is a Blazor Web  application built with .NET 9. It helps you organize and manage storage bins and their items, complete with barcode integration and secure user access. The app is designed to run locally (e.g., on a Raspberry Pi) and be accessed over your home network—or even globally if you choose to expose it online.

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

- 📇 **Barcode System**
  - Generate and print barcodes for bins
  - Scan barcodes using a phone camera to view bin contents ( to be implemented)

- ✅ **Checklists**
  - View online or printable checklists for bin contents



---

## 🛠️ Tech Stack

- **Frontend**: Blazor Web App (.NET 9)
- **Backend**: ASP.NET Core Web API
- **Database**: PostgreSQL
- **ORM**: Entity Framework Core
- **Authentication**: ASP.NET Core Identity



---

## 📖 Documentation

- [Database & Server Setup Guide](Documentation/ShelfSyncDatabaseServerSetup.md)

