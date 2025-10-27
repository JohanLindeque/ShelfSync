# ShelfSync – Blazor Web Inventory Manager

**ShelfSync** is a full-stack inventory management web application built with Blazor and .NET 9 for organizing storage bins and items. Features custom barcode scanning integration (in development), ASP.NET Core Identity authentication, and a PostgreSQL database managed through Entity Framework Core with code-first migrations. The database is containerized with Docker for easy deployment on local networks.

---
## 🖥️ Screenshots
<img width="1888" height="782" alt="image" src="https://github.com/user-attachments/assets/c6de822b-54c3-432c-b5ae-2606373aaba9" />
<img width="1880" height="807" alt="image" src="https://github.com/user-attachments/assets/bfee5926-fafc-45bd-87d6-3bdddc78ad2e" />
<img width="1536" height="668" alt="image" src="https://github.com/user-attachments/assets/2bdaa7a4-a69f-4cb4-8d74-0ddd71558231" />
<img width="1343" height="527" alt="image" src="https://github.com/user-attachments/assets/fd305956-2c85-4d72-85ca-d4ef3709a45b" />



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

