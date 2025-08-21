# ShelfSync Database & Server Setup

This guide explains how to set up a **PostgreSQL container with Docker Compose**, create the `ShelfSync` database, run EF Core migrations, and start the .NET server.

---

## 🚀 1. Reset old containers & volumes

If you’ve run Postgres before, stop and remove existing containers and volumes (⚠️ this will delete any old DB data):

```sh
docker compose down -v
```
---

## 🐘 2. Docker Compose Configuration

Save the following into your docker-compose.yml:
```yaml
services:
  sql:
    image: postgres:latest
    container_name: ShelfSyncDB
    environment:
      - POSTGRES_USER=postgres
      - POSTGRES_PASSWORD=P@ssw0rd
      - POSTGRES_DB=ShelfSync
    ports:
      - "5434:5432"
    volumes:
      - dbdata:/var/lib/postgresql/data

volumes:
  dbdata:
    name: postgres-data
```

*What this does:*

- Creates a container named ShelfSyncDB.

- User: postgres / Password: P@ssw0rd.

- Database ShelfSync created automatically.

- Exposes Postgres on localhost:5432.

- Persists data in a named volume postgres-data.

---

## ▶️ 3. Start the Container

```sh
docker compose up -d
```

Verify it’s running:
```sh
docker ps
```

Check logs:
```sh
docker logs ShelfSyncDB
```

You should see:
```sh
database system is ready to accept connections
```

---

## 🔌 4. Configure Connection String
Update your appsettings.json (or equivalent) with:
```json
"ConnectionStrings": {
  "PostgresConnection": "Host=localhost;Port=5434;Database=ShelfSync;Username=postgres;Password=P@ssw0rd"
}
```

Also note that you shoud add this to your Program.cs:
```cs
// DB CONTEXT
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));
```

---
## 🛠️ 5. Apply EF Core Migrations

If you already have migrations:
```sh
dotnet ef database update
```

If you need to create the first migration:
```sh
dotnet ef migrations add InitialCreate
dotnet ef database update
```
---
## 🌐 6. Run the .NET Server

Navigate to the ShelfSync server project directory in a terminal window, for example:

```sh
cd /home/ShelfSync/ShelfSync/ShelfSync
```

Run the application:
```sh
dotnet run
```

Once it started up it will show something like this in the terminal:
```sh
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5007
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /home/ShelfSync/ShelfSync/ShelfSync

```

Navigate to the URL the server is `Listening on` to use the app.

By default, the server will use the connection string from appsettings.json and connect to your running Postgres container.



---

### ✅ Done!

You now have:

- A fresh PostgreSQL container.

- A ShelfSync database created automatically.

- EF Core migrations applied (tables set up).
- The ShelfSync .NET server running locally with Dockerized Postgres.

### ℹ️ Notes

To wipe everything and restart fresh:
```sh
docker compose down -v
docker compose up -d
```

The database will persist between restarts thanks to the postgres-data volume.



