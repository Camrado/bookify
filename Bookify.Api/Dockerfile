﻿FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#ENV ASPNETCORE_URLS=http://+:5000
USER $APP_UID
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Bookify.Api/Bookify.Api.csproj", "Bookify.Api/"]
RUN dotnet restore "Bookify.Api/Bookify.Api.csproj"
COPY . .
WORKDIR "/src/Bookify.Api"
RUN dotnet build "Bookify.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Bookify.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bookify.Api.dll"]
