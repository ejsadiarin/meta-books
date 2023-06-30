FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ultimate-asp-net-core-web-api-2nd-edition/ultimate-asp-net-core-web-api-2nd-edition.csproj", "ultimate-asp-net-core-web-api-2nd-edition/"]
RUN dotnet restore "ultimate-asp-net-core-web-api-2nd-edition/ultimate-asp-net-core-web-api-2nd-edition.csproj"
COPY . .
WORKDIR "/src/ultimate-asp-net-core-web-api-2nd-edition"
RUN dotnet build "ultimate-asp-net-core-web-api-2nd-edition.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ultimate-asp-net-core-web-api-2nd-edition.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ultimate-asp-net-core-web-api-2nd-edition.dll"]
