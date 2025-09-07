# Build and run the HotelBediaX Web API using in-memory database
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY HotelBediaX.WebApi/HotelBediaX.WebApi.csproj HotelBediaX.WebApi/
COPY HotelBediaX.Application/HotelBediaX.Application.csproj HotelBediaX.Application/
COPY HotelBediaX.Domain/HotelBediaX.Domain.csproj HotelBediaX.Domain/
COPY HotelBediaX.Infrastructure/HotelBediaX.Infrastructure.csproj HotelBediaX.Infrastructure/
RUN dotnet restore HotelBediaX.WebApi/HotelBediaX.WebApi.csproj
COPY . .
WORKDIR /src/HotelBediaX.WebApi
RUN dotnet publish HotelBediaX.WebApi.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "HotelBediaX.WebApi.dll"]
