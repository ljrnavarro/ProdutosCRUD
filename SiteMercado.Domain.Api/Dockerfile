#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /api

# Copiar csproj e restaurar dependencias
COPY SiteMercado.sln ./
COPY ./SiteMercado.Domain.Api/*.csproj ./
COPY ./SiteMercado.Domain.Infra/*.csproj ./
COPY ./SiteMercado.Domain.Tests/*.csproj ./
COPY ./SiteMercado.Domain/*.csproj ./


# Build da aplicacao
COPY . ./
RUN dotnet publish ./SiteMercado.sln -c Release -o out

# Build da imagem
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /api
COPY --from=build-env /api/out .
ENTRYPOINT ["dotnet", "SiteMercado.Domain.Api.dll"]