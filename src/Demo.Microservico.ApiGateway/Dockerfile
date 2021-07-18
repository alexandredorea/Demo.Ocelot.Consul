# 01 ETAPA
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /build
EXPOSE 9010
COPY . .
RUN dotnet restore
RUN dotnet build -c Release -o /app/build

# 02 ETAPA
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Demo.Microservico.ApiGateway.dll"]