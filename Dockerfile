# Use .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files and restore dependencies
COPY *.sln .
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Use ASP.NET runtime image for final stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
EXPOSE 8081
ENTRYPOINT ["dotnet", "MovieEven# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY *.sln ./
COPY ./MovieEventBooking/*.csproj ./MovieEventBooking/

RUN dotnet restore "MovieEventBooking/MovieEventBooking.csproj"

# Copy everything else and build
COPY . .
WORKDIR /src/MovieEventBooking
RUN dotnet publish -c Release -o /app/publish


# Final stage / runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "MovieEventBooking.dll"]tBooking.dll"]
