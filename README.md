# Banking Credit System

A banking credit system built with .NET Core 9 using Clean Architecture and CQRS pattern.

## Project Structure

- **BankingCreditSystem.Core**: Contains core business logic, interfaces, and base classes
- **BankingCreditSystem.Domain**: Contains business entities and domain logic
- **BankingCreditSystem.Application**: Contains application use cases and CQRS implementations
- **BankingCreditSystem.Persistence**: Contains database context and repositories
- **BankingCreditSystem.WebAPI**: Contains API controllers and configurations

## Technologies

- .NET Core 9
- Entity Framework Core
- Clean Architecture
- CQRS Pattern
- Async Repository Pattern

## Features

- Generic Async Repository
- Individual and Corporate Customer Management
- Soft Delete Implementation
- Pagination Support
- CRUD Operations

## Getting Started

1. Clone the repository
2. Ensure you have .NET Core 9 SDK installed
3. Build the solution
4. Run the WebAPI project

## License

This project is licensed under the MIT License - see the LICENSE file for details 