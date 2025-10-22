# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy solution and project files
COPY ["FreightBackend.sln", "./"]
COPY ["FreightBackend/FreightBackend.csproj", "FreightBackend/"]
COPY ["FreightBackend.Tests/FreightBackend.Tests.csproj", "FreightBackend.Tests/"]

# Restore dependencies
RUN dotnet restore "FreightBackend.sln"

# Copy the rest of the source code
COPY . .

# Build the application
WORKDIR "/src/FreightBackend"
RUN dotnet build "FreightBackend.csproj" -c Release -o /app/build

# Test stage (optional - run tests during build)
FROM build AS test
WORKDIR /src
RUN dotnet test "FreightBackend.Tests/FreightBackend.Tests.csproj" --no-restore --verbosity normal

# Publish stage
FROM build AS publish
WORKDIR "/src/FreightBackend"
RUN dotnet publish "FreightBackend.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Create a non-root user
RUN groupadd -r appuser && useradd -r -g appuser appuser

# Copy published application
COPY --from=publish /app/publish .

# Change ownership to non-root user
RUN chown -R appuser:appuser /app

# Switch to non-root user
USER appuser

# Expose port
EXPOSE 8080
EXPOSE 8081

# Health check
HEALTHCHECK --interval=30s --timeout=3s --start-period=5s --retries=3 \
    CMD curl -f http://localhost:8080/health || exit 1

# Set environment variables
ENV ASPNETCORE_URLS=http://+:8080;https://+:8081
ENV ASPNETCORE_ENVIRONMENT=Production

# Start the application
ENTRYPOINT ["dotnet", "FreightBackend.dll"]
