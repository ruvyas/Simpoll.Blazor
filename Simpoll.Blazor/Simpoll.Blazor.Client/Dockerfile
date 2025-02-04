FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Simpoll.Blazor/Simpoll.Blazor.Client/Simpoll.Blazor.Client.csproj", "Simpoll.Blazor/Simpoll.Blazor.Client/"]
RUN dotnet restore "Simpoll.Blazor/Simpoll.Blazor.Client/Simpoll.Blazor.Client.csproj"
COPY . .
WORKDIR "/src/Simpoll.Blazor/Simpoll.Blazor.Client"
RUN dotnet build "Simpoll.Blazor.Client.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Simpoll.Blazor.Client.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Simpoll.Blazor.Client.dll"]
