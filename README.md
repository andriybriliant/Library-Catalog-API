
# Library Catalog REST API

A REST API built with .NET 9 and ASP.NET Core. This project serves as the backend for a library management system. It handles books, authors, user checkouts, and authentication.

## Features

-   **Authentication:**  JWT implementation for stateless authentication. Passwords are hashed using BCrypt.
    
-   **Role-Based Access Control:**  Distinct permission levels.  `Member`  roles can browse and borrow books.  `Librarian`roles have administrative access to add or manage catalog inventory.
    
-   **Relational Data Modeling:**  Built with Entity Framework Core using a Code-First approach. It enforces One-to-Many relationships between Authors, Books, Users, and Checkouts.
    
-   **Validation:**  Input validation handled via FluentValidation to verify data structure before database interaction.
    
-   **CI/CD:**  GitHub Actions workflow builds, tests, and deploys the application directly to Microsoft Azure App Service.
    
-   **Documentation:**  Integrated Swagger UI customized to support JWT Bearer token authorization.
    

## Technology Stack

-   **Framework:**  .NET 9
    
-   **ORM:**  Entity Framework Core 9
    
-   **Database:**  Microsoft SQL Server
    
-   **Authentication:**  Microsoft.AspNetCore.Authentication.JwtBearer
    
-   **Security:**  BCrypt.Net-Next
    
-   **Validation:**  FluentValidation.AspNetCore
    
-   **API Documentation:**  Swashbuckle.AspNetCore
    
-   **Deployment:**  GitHub Actions, Azure App Service
    

## Local Development Setup

### Prerequisites

-   .NET 9.0 SDK
    
-   Docker Desktop
    
-   Entity Framework Core CLI
    

### 1. Clone the Repository

```bash
git clone https://github.com/andriybriliant/LibraryCatalogAPI.git
cd LibraryCatalogAPI
```

### 2. Start the Database

The project uses Docker to run a local SQL Server instance.

```bash
docker compose up -d
```

### 3. Apply Database Migrations

Create the database schema based on the EF Core models.


```bash
dotnet ef database update
```

### 4. Run the Application

```bash
dotnet run
```

The API will start. You can access the Swagger documentation at  `https://localhost:7112/swagger`.

## Authentication

To interact with secured endpoints, use already created admin account with these credentials:

**Username:** admin

**Password:** Admin123!
    

## Endpoints
| Resource | Method | Endpoint | Access Level | Description |
|--|--|--|--|--|
| Auth | POST | `/api/auth/register` | Public | Register a new user |
| Auth | POST | `/api/auth/login` | Public | Authenticate and get JWT |
| Auth | POST | `/api/auth/refresh` | Public | Refresh JWT token |
| User | GET | `/api/users/me` | Admin/Member/Librarian | Retrieve current user |
| Books | GET | `/api/books` | Member/Librarian | Retrieve all books |
| Books | POST | `/api/books` | Librarian only | Add a new book |
| Books | GET | `/api/books/{id}` | Member/Librarian | Retrieve a book by id |
| Books | DELETE | `/api/books/{id}` | Librarian only | Delete a book by id |
| Authors | GET | `/api/authors` | Member/Librarian | Retrieve all authors |
| Authors | POST | `/api/authors` | Librarian only | Add a new author |
| Authors | DELETE | `/api/authors/{id}` | Librarian only | Delete an author by id |
| Checkouts | POST | `/api/checkouts/{bookId}` | Member/Librarian | Borrow an available book|
| Checkouts | POST | `/api/checkouts/return/{checkoutId}` | Member/Librarian | Return a borrowed book |
| Checkouts | GET | `/api/checkouts/my-books` | Member/Librarian | Retrieve current user checkouts |

## Deployment

This repository uses a GitHub Actions workflow located at  `.github/workflows/azure-deploy.yml`. Commits pushed to the  `main` branch trigger a build and deployment to Azure App Service.
