#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["beer-bowling-league-api/beer-bowling-league-api.csproj", "beer-bowling-league-api/"]
RUN dotnet restore "beer-bowling-league-api/beer-bowling-league-api.csproj"
COPY . .
WORKDIR "/src/beer-bowling-league-api"
RUN dotnet build "beer-bowling-league-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "beer-bowling-league-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "beer-bowling-league-api.dll"]