# Define la configuración de compilación por defecto
ARG BUILD_CONFIGURATION=Release

# Usa la imagen base oficial de .NET para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8000
EXPOSE 8001

# Usa la imagen de .NET SDK para compilar el proyecto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Services/Catalog/Catalog.csproj", "Services/Catalog/"]
RUN dotnet restore "Services/Catalog/Catalog.csproj"
COPY . .
ARG BUILD_CONFIGURATION=Release
RUN dotnet build "Services/Catalog/Catalog.csproj" -c ${BUILD_CONFIGURATION} -o /app/build

# Publica la aplicación
FROM build AS publish
RUN dotnet publish "Services/Catalog/Catalog.csproj" -c ${BUILD_CONFIGURATION} -o /app/publish

# Usa la imagen base para ejecutar la aplicación
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Catalog.dll"]
