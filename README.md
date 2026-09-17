# Product CRUD (Blazor)

Small intermediate-level Blazor Web App with proper layered structure — **not** all logic in the UI.

## Architecture

```
Pages (UI) → Service (business rules) → Repository (data access) → DbContext (EF Core / SQLite)
```

| Folder | Role |
|--------|------|
| `Models/` | `Product`, `Category` entities + validation |
| `Data/` | `AppDbContext`, seed data |
| `Repositories/` | CRUD against the database |
| `Services/` | Validation + orchestration |
| `Components/Pages/Products/` | Thin Blazor pages only |

## Features

- Create / Read / Update / Delete (soft delete)
- Category relationship
- Search + category filter
- DataAnnotations + service-level validation
- Sample seed data on first run

## Run

```bash
cd ProductCrud
dotnet run
```

Open the URL from the console (usually `https://localhost:7xxx`) and go to **Products**.
