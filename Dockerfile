# ===== Base image for runtime =====
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 10000

# ===== Build stage =====
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy the .csproj file (root folder)
COPY *.csproj ./
RUN dotnet restore

# Copy all project files
COPY . ./
RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# ===== Final stage =====
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish ./
ENTRYPOINT ["dotnet", "MovieEventBooking.dll"]
