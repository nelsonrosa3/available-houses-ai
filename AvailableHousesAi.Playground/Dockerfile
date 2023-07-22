FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AvailableHousesAi.Playground/AvailableHousesAi.Playground.csproj", "AvailableHousesAi.Playground/"]
RUN dotnet restore "AvailableHousesAi.Playground/AvailableHousesAi.Playground.csproj"
COPY . .
WORKDIR "/src/AvailableHousesAi.Playground"
RUN dotnet build "AvailableHousesAi.Playground.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AvailableHousesAi.Playground.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AvailableHousesAi.Playground.dll"]
