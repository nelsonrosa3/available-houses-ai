FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AvailableHousesAi.HousesForBuyService/AvailableHousesAi.HousesForBuyService.csproj", "AvailableHousesAi.HousesForBuyService/"]
RUN dotnet restore "AvailableHousesAi.HousesForBuyService/AvailableHousesAi.HousesForBuyService.csproj"
COPY . .
WORKDIR "/src/AvailableHousesAi.HousesForBuyService"
RUN dotnet build "AvailableHousesAi.HousesForBuyService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AvailableHousesAi.HousesForBuyService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AvailableHousesAi.HousesForBuyService.dll"]
