# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY OcuparApi/OcuparApi.csproj OcuparApi/
RUN dotnet restore OcuparApi/OcuparApi.csproj

COPY OcuparApi/ OcuparApi/
RUN dotnet publish OcuparApi/OcuparApi.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080 \
    ASPNETCORE_ENVIRONMENT=Production
EXPOSE 8080

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "OcuparApi.dll"]
