=
# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 10000

# Build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Replace with your actual .csproj filename
COPY ["Resource_tracking.csproj", "./"]

RUN dotnet restore "Resource_tracking.csproj"

COPY . .

RUN dotnet publish "Resource_tracking.csproj" \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false

# Final image
FROM base AS final
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Resource_tracking.dll"]

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 10000

# Build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Replace with your actual .csproj filename
COPY ["Resource_tracking.csproj", "./"]

RUN dotnet restore "Resource_tracking.csproj"

COPY . .

RUN dotnet publish "Resource_tracking.csproj" \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false

# Final image
FROM base AS final
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Resource_tracking.dll"]
