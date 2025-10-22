# Contributing to Freight Backend

Thank you for your interest in contributing to the Freight Backend project! This document provides guidelines and instructions for contributing.

## Table of Contents

- [Code of Conduct](#code-of-conduct)
- [Getting Started](#getting-started)
- [Development Workflow](#development-workflow)
- [Coding Standards](#coding-standards)
- [Testing Guidelines](#testing-guidelines)
- [Submitting Changes](#submitting-changes)
- [Reporting Issues](#reporting-issues)

## Code of Conduct

This project adheres to a code of conduct. By participating, you are expected to uphold this code. Please be respectful and constructive in all interactions.

## Getting Started

### Prerequisites

- .NET 9.0 SDK or later
- Git
- A code editor (Visual Studio 2022, VS Code, or Rider recommended)

### Setting Up Your Development Environment

1. Fork the repository
2. Clone your fork:
   ```bash
   git clone https://github.com/YOUR_USERNAME/freight-backend.git
   cd freight-backend
   ```

3. Add the upstream repository:
   ```bash
   git remote add upstream https://github.com/Mbugus2008/freight-backend.git
   ```

4. Restore dependencies:
   ```bash
   dotnet restore
   ```

5. Build the solution:
   ```bash
   dotnet build
   ```

6. Run tests to ensure everything works:
   ```bash
   dotnet test
   ```

## Development Workflow

1. **Create a feature branch:**
   ```bash
   git checkout -b feature/your-feature-name
   ```

2. **Make your changes** following the coding standards

3. **Write or update tests** for your changes

4. **Run tests** to ensure everything passes:
   ```bash
   dotnet test
   ```

5. **Build the project** to check for errors:
   ```bash
   dotnet build
   ```

6. **Commit your changes** with clear, descriptive messages:
   ```bash
   git add .
   git commit -m "Add feature: description of what you added"
   ```

7. **Keep your branch up to date:**
   ```bash
   git fetch upstream
   git rebase upstream/main
   ```

8. **Push to your fork:**
   ```bash
   git push origin feature/your-feature-name
   ```

9. **Create a Pull Request** from your fork to the main repository

## Coding Standards

### C# Guidelines

- Follow [Microsoft's C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- Use meaningful variable and method names
- Keep methods small and focused (Single Responsibility Principle)
- Use async/await for asynchronous operations
- Add XML documentation comments for public APIs

### Project Structure

```
FreightBackend/
├── Controllers/     # API endpoints
├── Services/        # Business logic
├── Models/          # Domain models
├── DTOs/           # Data transfer objects
├── Middleware/     # Custom middleware
└── Program.cs      # Application entry point

FreightBackend.Tests/
├── Services/       # Service layer tests
└── Controllers/    # Controller tests
```

### Naming Conventions

- **Classes and Methods**: PascalCase (e.g., `FreightService`, `GetAllAsync`)
- **Private fields**: _camelCase with underscore prefix (e.g., `_logger`)
- **Parameters and local variables**: camelCase (e.g., `freightId`)
- **Interfaces**: Prefix with 'I' (e.g., `IFreightService`)
- **Constants**: PascalCase (e.g., `MaxRetryAttempts`)

### Code Style

- Use 4 spaces for indentation (no tabs)
- Add a space after keywords (e.g., `if (condition)`)
- Use braces for all control structures, even single-line statements
- Keep lines under 120 characters when possible
- Add blank lines between logical sections of code

## Testing Guidelines

### Writing Tests

- Use xUnit for unit tests
- Use Moq for mocking dependencies
- Use FluentAssertions for readable assertions
- Follow the Arrange-Act-Assert pattern
- Name tests clearly: `MethodName_Scenario_ExpectedResult`

### Test Coverage

- Aim for high test coverage (>80%)
- Test happy paths and edge cases
- Test error handling
- Test validation logic

### Example Test

```csharp
[Fact]
public async Task GetByIdAsync_WithValidId_ShouldReturnFreight()
{
    // Arrange
    var existingId = 1;

    // Act
    var result = await _service.GetByIdAsync(existingId);

    // Assert
    result.Should().NotBeNull();
    result!.Id.Should().Be(existingId);
}
```

## Submitting Changes

### Pull Request Guidelines

- **Title**: Clear and descriptive (e.g., "Add freight search functionality")
- **Description**: Explain what changes you made and why
- **Reference Issues**: Link to related issues (e.g., "Fixes #123")
- **Screenshots**: Include for UI changes
- **Tests**: Ensure all tests pass
- **Documentation**: Update README or docs if needed

### Pull Request Checklist

Before submitting, ensure:

- [ ] Code follows the project's coding standards
- [ ] All tests pass (`dotnet test`)
- [ ] New tests added for new functionality
- [ ] XML documentation added for public APIs
- [ ] No compiler warnings
- [ ] README updated if needed
- [ ] Commit messages are clear and descriptive

### Review Process

1. A maintainer will review your PR
2. Address any feedback or requested changes
3. Once approved, a maintainer will merge your PR
4. Your changes will be included in the next release

## Reporting Issues

### Bug Reports

When reporting bugs, include:

- Clear, descriptive title
- Steps to reproduce the issue
- Expected behavior
- Actual behavior
- Environment details (.NET version, OS, etc.)
- Error messages or logs if applicable

### Feature Requests

When requesting features, include:

- Clear description of the feature
- Use case and benefits
- Examples of how it would work
- Any relevant mockups or diagrams

### Using Issue Templates

Please use the appropriate issue template when creating issues. This helps maintain consistency and ensures all necessary information is provided.

## Questions?

If you have questions or need help, feel free to:

- Open an issue with the "question" label
- Reach out to the maintainers

## License

By contributing, you agree that your contributions will be licensed under the same license as the project (MIT License).

---

Thank you for contributing to Freight Backend! 🚚
