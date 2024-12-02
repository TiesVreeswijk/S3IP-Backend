# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the project files
COPY *.sln .
COPY API/*.csproj ./API/

# Restore dependencies
RUN dotnet restore API/*.csproj

# Copy the rest of the source code
COPY . .

# Build the application
RUN dotnet publish API/*.csproj -c Release -o /app/publish

# Stage 2: Create runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy the published app from the build stage
COPY --from=build /app/publish .

# Expose the port your application listens on
EXPOSE 80

# Specify the command to run the application
ENTRYPOINT ["dotnet", "API.dll"]
