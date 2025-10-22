# Freight Backend

ASP.NET Core backend for freight marketplace platform

## Overview

This is a modern, scalable backend API for a freight marketplace platform built with ASP.NET Core 9.0. The API provides endpoints for managing freight listings, shipments, and marketplace operations.

## Features

- ✅ RESTful API design
- ✅ Swagger/OpenAPI documentation
- ✅ Global exception handling
- ✅ Health checks
- ✅ CORS support
- ✅ Structured logging
- ✅ Clean architecture with Controllers, Services, and Models

## Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) or later
- Code editor (Visual Studio 2022, VS Code, or Rider)

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/Mbugus2008/freight-backend.git
cd freight-backend
```

### 2. Restore dependencies

```bash
cd FreightBackend
dotnet restore
```

### 3. Build the project

```bash
dotnet build
```

### 4. Run the application

```bash
dotnet run
```

The API will be available at:
- HTTP: `http://localhost:5262`
- HTTPS: `https://localhost:7135`
- Swagger UI: `http://localhost:5262` (in Development mode)

## Project Structure

```
FreightBackend/
├── Controllers/         # API controllers
├── Models/             # Data models
├── Services/           # Business logic services
├── DTOs/               # Data transfer objects
├── Middleware/         # Custom middleware
├── Properties/         # Launch settings
├── Program.cs          # Application entry point
└── appsettings.json    # Configuration
```

## API Endpoints

### Health Check
- `GET /health` - Returns the health status of the API

### Status
- `GET /api/status` - Returns API status and environment information

### Freight Management
- `GET /api/freight` - Get all freight listings
- `GET /api/freight/{id}` - Get freight by ID
- `POST /api/freight` - Create new freight listing
- `PUT /api/freight/{id}` - Update freight listing
- `DELETE /api/freight/{id}` - Delete freight listing

## Configuration

Configuration settings are stored in:
- `appsettings.json` - Base configuration
- `appsettings.Development.json` - Development-specific settings

## Development

### Running in Development Mode

```bash
dotnet run --environment Development
```

### Building for Production

```bash
dotnet publish -c Release -o ./publish
```

## Testing

To run tests (when test project is added):

```bash
dotnet test
```

## API Documentation

When running in Development mode, Swagger UI is available at the root URL (`http://localhost:5262`). This provides:
- Interactive API documentation
- Endpoint testing capabilities
- Request/response schemas

## Architecture

The application follows a clean architecture pattern:

1. **Controllers** - Handle HTTP requests and responses
2. **Services** - Contain business logic
3. **Models** - Define data structures
4. **DTOs** - Data transfer objects for API contracts
5. **Middleware** - Cross-cutting concerns (error handling, logging)

## Security Considerations

⚠️ **Important**: Before deploying to production:

1. Configure proper CORS policies (currently allows all origins)
2. Implement authentication and authorization
3. Add rate limiting
4. Enable HTTPS only
5. Implement input validation
6. Add API versioning
7. Configure proper logging and monitoring
8. Secure sensitive configuration (use Azure Key Vault or similar)

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Support

For issues and questions, please open an issue on GitHub.

