FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5213

ENV ASPNETCORE_URLS=http://*:5213

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["MetaFlix.API/MetaFlix.API.csproj", "MetaFlix.API/"]
COPY ["MetaFlix.Application/MetaFlix.Application.csproj", "MetaFlix.Application/"]
COPY ["MetaFlix.Domain/MetaFlix.Domain.csproj", "MetaFlix.Domain/"]
COPY ["MetaFlix.Extensions/MetaFlix.Extensions.csproj", "MetaFlix.Extensions/"]
COPY ["MetaFlix.Infrastructure/MetaFlix.Infrastructure.csproj", "MetaFlix.Infrastructure/"]
RUN dotnet restore "MetaFlix.API/MetaFlix.API.csproj"
COPY . .
WORKDIR "/src/MetaFlix.API"
RUN dotnet build "MetaFlix.API.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "MetaFlix.API.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MetaFlix.API.dll"]
