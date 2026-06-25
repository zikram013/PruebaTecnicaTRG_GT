FROM mcr.microsoft.com/dotnet/sdk:9.0.200 AS build
WORKDIR /src

COPY .editorconfig ./
COPY Directory.Build.* ./
COPY NuGet.config ./
COPY global.json ./
COPY src ./src
COPY test ./test

WORKDIR /src/src
RUN dotnet restore microservice.sln
RUN dotnet publish GtMotive.Estimate.Microservice.Host/GtMotive.Estimate.Microservice.Host.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

RUN mkdir -p /data

EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ConnectionStrings__RentingDatabase="Data Source=/data/renting.db"

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "GtMotive.Estimate.Microservice.Host.dll"]