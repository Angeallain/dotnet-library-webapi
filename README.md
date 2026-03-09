# dotnet-library-webapi

A simple Library Management REST API built with **ASP.NET Core (.NET 8)**, 
demonstrating the component-based architecture model.

Built as part of a Software Architecture course project on .NET component models.

---

## What it does

- List all books
- Add a new book
- Borrow a book (with availability check)

---

## Architecture — Component Model

This project illustrates the 4 core components of a .NET web application 
and how they interact through Dependency Injection:
```
Browser (HTML + JS)
     ↓  HTTP Request
BookController       → receives HTTP requests (GET, POST, PUT)
     ↓
BookService          → business logic (checks availability before borrowing)
     ↓
BookRepository       → data access via Entity Framework Core
     ↓
LibraryDbContext     → in-memory database
```

Each component has a **single responsibility** and is registered 
in the DI Container in `Program.cs`.

---

## Tech Stack

- ASP.NET Core Web API (.NET 8)
- Entity Framework Core (In-Memory Database)
- HTML + Vanilla JavaScript (Fetch API)

---

## Project Structure
```
LibraryWebApp/
├── Controllers/
│   └── BookController.cs
├── Data/
│   └── LibraryDbContext.cs
├── Models/
│   └── Book.cs
├── Repositories/
│   └── BookRepository.cs
├── Services/
│   └── BookService.cs
├── wwwroot/
│   └── index.html
    └── style.css
    └── app.js
└── Program.cs
```

---

## How to run

**Prerequisites:** .NET 8 SDK (ou plus récent -pour ce petit projet j'ai utilisé cette version 10.0.103-) — download at https://dotnet.microsoft.com/download
```bash
git clone https://github.com/Angeallain/dotnet-library-webapi.git
cd dotnet-library-webapi
dotnet run
```

Then open your browser at the URL shown in your terminal, for example:
**http://localhost:5000** (port may vary on your machine)

---

## API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/book` | Get all books |
| POST | `/api/book` | Add a new book |
| PUT | `/api/book/{id}/borrow` | Borrow a book by ID |