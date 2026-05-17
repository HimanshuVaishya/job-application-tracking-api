# Job Application Tracking System API

A secure backend recruitment management system built using ASP.NET Core Web API.

## Features

- User Registration & Login
- JWT Authentication
- Role-based Authorization
- Job Posting Management
- Candidate Job Applications
- Application Status Workflow
- Dashboard Analytics
- Global Exception Handling
- Standardized API Responses

---

## Tech Stack

- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQL Server
- JWT Authentication
- Swagger
- Repository Pattern

---

## Architecture

```text
Controller → Service → Repository → DbContext
```

---

## Roles

### Admin
- Create Jobs
- View Applications
- Update Candidate Status
- Access Dashboard

### Candidate
- View Jobs
- Apply for Jobs

---

## API Endpoints

### Auth
- POST /api/auth/register
- POST /api/auth/login

### Jobs
- GET /api/jobs
- POST /api/jobs

### Applications
- POST /api/applications
- GET /api/applications
- PUT /api/applications/{id}/status

### Dashboard
- GET /api/dashboard

---

## Setup Instructions

### Clone repository

```bash
git clone YOUR_REPO_URL
```

### Configure secrets

Create:

appsettings.Development.json

Add:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "YOUR_SQL_SERVER_CONNECTION"
  },
  "Jwt": {
    "Key": "YOUR_SECRET_KEY"
  }
}
```

### Run migrations

```bash
Update-Database
```

### Run project

```bash
dotnet run
```

---

## Author

Himanshu Vaishya