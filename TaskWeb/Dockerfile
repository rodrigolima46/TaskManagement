# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY TaskWeb.csproj .
RUN dotnet restore TaskWeb.csproj

# Copy everything and build
COPY . .
RUN dotnet publish TaskWeb.csproj -c Release -o /app

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app ./

# Expose port
EXPOSE 8080

# Run app
ENTRYPOINT ["dotnet", "TaskWeb.dll"]
