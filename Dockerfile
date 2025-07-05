# ===== BUILD STAGE =====
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY MisubishiApi.sln .
COPY MisubishiApi/*.csproj MisubishiApi/
COPY Misubishi.BLL/*.csproj Misubishi.BLL/
COPY Misubishi.DAL/*.csproj Misubishi.DAL/

RUN dotnet restore MisubishiApi.sln

COPY . .

RUN dotnet publish MisubishiApi/MisubishiApi.csproj -c Release -o /app/publish

# ===== RUNTIME STAGE =====
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "MisubishiApi.dll"]
