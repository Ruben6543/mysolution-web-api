FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MySolution.WebAPI/MySolution.WebAPI.csproj", "MySolution.WebAPI/"]
RUN dotnet restore "MySolution.WebAPI/MySolution.WebAPI.csproj"
COPY . .
WORKDIR "/src/MySolution.WebAPI"
RUN dotnet build "MySolution.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MySolution.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MySolution.WebAPI.dll"]