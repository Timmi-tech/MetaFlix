# Use the official ASP.NET runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the official .NET SDK for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy only the csproj file and restore as distinct layers
COPY ["MetaFlix.API.csproj", "./"]
RUN dotnet restore "MetaFlix.API.csproj"

# Copy the remaining source code
COPY . .
WORKDIR /src
RUN dotnet build "MetaFlix.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MetaFlix.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MetaFlix.API.dll"]
