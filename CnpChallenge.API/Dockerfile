FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
EXPOSE 80

# Restore and build
FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src
COPY ["CnpChallenge.API/CnpChallenge.API.csproj", "CnpChallenge.API/"]
COPY ["CnpChallenge.Application.Contracts/CnpChallenge.Application.Contracts.csproj", "CnpChallenge.Application.Contracts/"]
COPY ["CnpChallenge.Domain.Shared/CnpChallenge.Domain.Shared.csproj", "CnpChallenge.Domain.Shared/"]
COPY ["CnpChallenge.Application/CnpChallenge.Application.csproj", "CnpChallenge.Application/"]
COPY ["CnpChallenge.Domain/CnpChallenge.Domain.csproj", "CnpChallenge.Domain/"]
COPY ["CnpChallenge.Infrastructure/CnpChallenge.Infrastructure.csproj", "CnpChallenge.Infrastructure/"]
RUN dotnet restore "CnpChallenge.API/CnpChallenge.API.csproj"
COPY . .
WORKDIR "/src/CnpChallenge.API"
RUN dotnet build "CnpChallenge.API.csproj" -c Release -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "CnpChallenge.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Run
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CnpChallenge.API.dll"]