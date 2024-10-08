FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["PersonService.Server/PersonService.Server.csproj", "PersonService.Server/"]
COPY ["PersonService.DataAccess/PersonService.DataAccess.csproj", "PersonService.DataAccess/"]
COPY ["PersonService.Domain/PersonService.Domain.csproj", "PersonService.Domain/"]
RUN dotnet restore "./PersonService.Server/./PersonService.Server.csproj"
COPY . .
WORKDIR "/src/PersonService.Server"
RUN dotnet build "./PersonService.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./PersonService.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PersonService.Server.dll"]
