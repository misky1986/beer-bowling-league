#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/core/sdk:3.1.300-buster AS base
EXPOSE 80
EXPOSE 443

FROM base AS build
WORKDIR /app
COPY BeerBowlingLeague.Client.csproj .
RUN dotnet restore "BeerBowlingLeague.Client.csproj"
COPY . .
RUN dotnet build "BeerBowlingLeague.Client.csproj" -c Release

FROM build AS publish
RUN dotnet publish "BeerBowlingLeague.Client.csproj" -c Release

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/bin/Release/netstandard2.1/publish/web.config .
COPY --from=publish /app/bin/Release/netstandard2.1/publish/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf