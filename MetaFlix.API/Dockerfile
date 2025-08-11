FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5213

ENV ASPNETCORE_URLS=http://*:$PORT

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["MetaFlix.API/MetaFlix.API.csproj", "MetaFlix.API/"]
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
