FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

COPY ./ ./
RUN dotnet restore WebAPI/WebAPI.csproj

# Build da aplicacao
RUN dotnet publish -c Release -v minimal -o out ./WebAPI/WebAPI.csproj

# Build da imagem
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENV routes:path ./input-file.csv
ENTRYPOINT ["dotnet", "WebAPI.dll"]