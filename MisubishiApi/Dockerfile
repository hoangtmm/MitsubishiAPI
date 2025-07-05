# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MisubishiApi/MisubishiApi.csproj", "MisubishiApi/"]
COPY ["Misubishi.BLL/Misubishi.BLL.csproj", "Misubishi.BLL/"]
COPY ["Misubishi.DAL/Misubishi.DAL.csproj", "Misubishi.DAL/"]
RUN dotnet restore "./MisubishiApi/MisubishiApi.csproj"
COPY . .
WORKDIR "/src/MisubishiApi"
RUN dotnet build "./MisubishiApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MisubishiApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MisubishiApi.dll"]
