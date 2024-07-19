# Simple Login API

This repository contains a simple login API built with C#. It uses SQLite for the database, Entity Framework for ORM, and JWT for token-based authentication. The API has a straightforward structure with models, controllers, and services.

## Features

- User authentication with JWT tokens
- SQLite database integration
- Entity Framework for database operations

## Technologies Used

- C#
- .NET Core
- SQLite
- Entity Framework
- JWT (JSON Web Tokens)

## Getting Started

### Prerequisites

- .NET Core SDK
- SQLite

### Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/your-username/simple-login-api.git
    cd simple-login-api
    ```

2. Install the dependencies:
    ```bash
    dotnet restore
    ```

3. Update the database:
    ```bash
    dotnet ef database update
    ```

### Running the API

To run the API, use the following command:
```bash
dotnet run
