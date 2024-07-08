#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
#EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["BloodBankManagement.API/BloodBankManagement.API.csproj", "BloodBankManagement.API/"]
COPY ["BloodBankManagement.Application/BloodBankManagement.Application.csproj", "BloodBankManagement.Application/"]
COPY ["BloodBankManagement.Domain/BloodBankManagement.Domain.csproj", "BloodBankManagement.Domain/"]
COPY ["BloodBankManagement.Infrastructure/BloodBankManagement.Infrastructure.csproj", "BloodBankManagement.Infrastructure/"]

RUN dotnet restore "./BloodBankManagement.API/BloodBankManagement.API.csproj"

COPY . .

WORKDIR "/src/BloodBankManagement.API"
RUN dotnet build "./BloodBankManagement.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BloodBankManagement.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BloodBankManagement.API.dll"]