# High-Performance Property & Financial Management API (.NET 10)

A production-ready Property Management System (PMS) backend built with **Clean Architecture** and **CQRS (MediatR)**. This project demonstrates advanced backend capabilities, focusing on relational database integrity, enterprise validation patterns, and **Automated Background Services (Hosted Services)** for automated financial scheduling.

---

## 🏗️ Architectural Overview & Design Patterns

This system is decoupled into isolated layers to respect the separation of concerns and maintain a highly testable codebase:

- **`Domain`**: Contains core structural and financial entities (`Building`, `Apartment`, `Invoice`) and core business invariants with zero external framework dependencies.
- **`Application`**: Orchestrates use cases via CQRS. Contains commands for infrastructure mutations, queries for optimized data retrieval, and validation boundaries.
- **`Persistence`**: Handles state management using **Entity Framework Core (Code-First)** with MS SQL Server. Relationships, precise decimal sizing, and cascade behavior configurations are managed cleanly via Fluent API.
- **`Infrastructure`**: House of systemic abstractions. Implements **Hosted Services (`BackgroundService`)** that poll the system to automate cyclical business flows without human intervention.
- **`WebAPI`**: Exposes secure REST HTTP endpoints, bootstraps dependency injection container, and powers the interactive documentation layer.

---

## 🚀 Key Features & Enterprise Engineering

- **Automated Invoicing Engine:** Integrated an internal background cron worker (`InvoiceGeneratorHostedService`) that automatically runs on a periodic schedule, scans active/occupied apartments, and issues monthly invoices while strictly preventing duplicate billing.
- **Advanced Relational Modeling:** Configured complex multi-tier database relationships (Buildings ➡️ Apartments ➡️ Invoices) utilizing strict Fluent API mapping rules.
- **Decoupled Messaging & Handlers:** Built completely on top of the CQRS pattern via **MediatR**, significantly decreasing controller bloat.
- **API Documentation:** Equipped with global **Swagger UI / OpenAPI** schemas for seamless contract testing.

---

## 🛠️ Installation & Setup

### Prerequisites
- .NET 8 or .NET 9 SDK
- MS SQL Server instance

### Quick Start

1. **Clone the repository:**

     bash
   
     git clone [https://github.com/arcadiacommunity36-dev/Apartmasyon-Management-Backend.git](https://github.com/arcadiacommunity36-dev/Apartmasyon-Management-Backend.git)
     cd ApartmasyonManagement

2. Database Migration:
Ensure your SQL Server instance is running. Update the SqlConnection string inside src/Apartmasyon.WebAPI/appsettings.json if necessary, then construct the relational tables by applying the migration:,

     bash
   
     dotnet ef database update --project src/Apartmasyon.Persistence --startup-project src/Apartmasyon.WebAPI

3. Run the API Server:

     bash

     dotnet run --project src/Apartmasyon.WebAPI

4. Verify and Monitor:
Open http://localhost:[YOUR_PORT]/swagger in your browser. Create a building and an occupied apartment. Observe the live console logs to watch the background service automatically check and execute the billing transactions every minute!
