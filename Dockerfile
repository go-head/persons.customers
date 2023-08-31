FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
LABEL org.opencontainers.image.source https://github.com/mauricionofre/persons.customers

WORKDIR /app

COPY . ./

RUN dotnet restore 
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

COPY --from=build /app/out .

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Development

ENTRYPOINT ["dotnet", "Persons.Customers.Api.dll"]
EXPOSE 8080