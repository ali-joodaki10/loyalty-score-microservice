# Loyalty Score Microservice

A .NET 8 microservice for calculating customer loyalty scores using Clean Architecture and Domain-Driven Design (DDD).

The service exposes both REST API and gRPC endpoints and persists score calculation history in SQL Server.

---

## Features

- Clean Architecture
- Domain-Driven Design (DDD)
- REST API
- gRPC Service
- SQL Server
- Entity Framework Core
- FluentValidation
- Swagger / OpenAPI
- Dependency Injection
- Score History Persistence

---

## Business Rules

### Base Score

| Customer Type | Formula |
|--------------|---------|
| Bronze | PurchaseAmount / 100 |
| Silver | PurchaseAmount / 80 |
| Gold | PurchaseAmount / 60 |

### Bonus Rules

- +10% bonus if monthly purchases count >= 5
- +5% bonus if purchase amount > 10,000,000
- +2.5% bonus for every additional 10,000,000

### Final Formula

```text
FinalScore = BaseScore × (1 + TotalBonus)
```

---

## Project Structure

```text
src
│
├── Loyalty.Api
│   ├── Controllers
│   ├── Services
│   ├── Mappers
│   ├── Protos
│   ├── Program.cs
│   └── appsettings.json
│
├── Application
│   ├── DTOs
│   ├── Interfaces
│   ├── Services
│   ├── Validators
│   └── Mappers
│
├── Domain
│   ├── Entities
│   ├── Enums
│   ├── Interfaces
│   └── Services
│
└── Infrastructure
    ├── Data
    ├── Repositories
    └── Migrations
```

---

## REST API

### Endpoint

```http
POST https://localhost:44300/api/loyalty/calculate
```

### Request

```json
{
  "purchaseAmount": 11110000,
  "customerType": 1,
  "monthlyPurchases": [
    10002,
    105054,
    450000
  ]
}
```

### Response

```json
{
  "finalScore": 116655
}
```

---

## gRPC

### Address

```text
grpc://localhost:5144
```

### Service

```text
LoyaltyService
```

### Method

```text
CalculateScore
```

### Request

```json
{
  "purchaseAmount": 11110000,
  "customerType": 1,
  "monthlyPurchases": [
    10002,
    105054,
    450000
  ]
}
```

---

## Database

SQL Server is used for persisting score calculation history.

Stored information:

- Purchase Amount
- Customer Type
- Monthly Purchases
- Final Score
- Created Date

---

## Technologies

- .NET 8
- ASP.NET Core
- gRPC
- Entity Framework Core
- SQL Server
- FluentValidation
- Swagger
- Clean Architecture
- Domain Driven Design (DDD)

---

## Running the Project

### Restore packages

```bash
dotnet restore
```

### Apply migrations

```powershell
Add-Migration InitialCreate -StartupProject Loyalty.Api -Project Infrastructure

Update-Database -StartupProject Loyalty.Api -Project Infrastructure
```

### Run

```bash
dotnet run
```

---

## Swagger

```text
https://localhost:44300/swagger
```

---

## Author

Ali Joodaki