# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the solution and project files
COPY S3IP-Backend.sln ./
COPY API/API.csproj ./API/
COPY Business/Business.csproj ./Business/
COPY DAL/DAL.csproj ./DAL/

# Restore dependencies
RUN dotnet restore

# Copy all source code
COPY . ./

# Build the API project
WORKDIR /src/API
RUN dotnet publish -c Release -o /app

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy the built application
COPY --from=build /app ./

# Set ASP.NET Core to listen on port 80
ENV ASPNETCORE_URLS=http://+:80

# Expose port 80 for Azure
EXPOSE 80

# Set the entry point for the application
ENTRYPOINT ["dotnet", "API.dll"]
