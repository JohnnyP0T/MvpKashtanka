FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Kashtanka.Api/Kashtanka.Api.csproj", "src/Kashtanka.Api/"]
RUN dotnet restore "src/Kashtanka.Api/Kashtanka.Api.csproj"
COPY . .
WORKDIR "/src/src/Kashtanka.Api"
RUN dotnet build "Kashtanka.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Kashtanka.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kashtanka.Api.dll", "--server.urls",  "http://+:80;https://+:443;http://+:5150;http://+:8080;http://+:8081;"]
