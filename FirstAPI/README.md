# MediatR CQRS Example – Books CRUD API (.NET 6/7)

This project demonstrates how to implement **CQRS** (Command Query Responsibility Segregation) with **MediatR** in an ASP.NET Core Web API. The example provides basic CRUD operations for managing books.

---

## 📦 Technologies Used

- ASP.NET Core Web API (.NET 6/7)
- MediatR
- Entity Framework Core (In-Memory or SQL Server)
- CQRS Pattern
- Clean Architecture Structure

---

## 📂 Project Structure

├── API
│ └── Controllers
│ └── BooksController.cs
├── Application
│ └── Books
│ ├── Commands
│ │ ├── CreateBook
│ │ ├── UpdateBook
│ │ └── DeleteBook
│ └── Queries
│ ├── GetAllBooks
│ └── GetBookById
├── Domain
│ └── Entities
│ └── Book.cs
├── Infrastructure
│ └── Data
│ └── ApplicationDbContext.cs
└── Program.cs
3. Test endpoints
Use tools like Postman, curl, or Swagger UI (if enabled).

🧠 Example Request Flow
CreateBookCommand → handled by CreateBookCommandHandler.cs

GetAllBooksQuery → handled by GetAllBooksQueryHandler.cs

UpdateBookCommand → handled by UpdateBookCommandHandler.cs

DeleteBookCommand → handled by DeleteBookCommandHandler.cs
🛠 Dependency Injection
MediatR is registered in Program.cs:
builder.Services.AddMediatR(typeof(Program).Assembly);
