# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/Blog/Blog.API/Blog.API.csproj", "src/Services/Blog/Blog.API/"]
COPY ["src/Services/Blog/Blog.Application/Blog.Application.csproj", "src/Services/Blog/Blog.Application/"]
COPY ["src/Services/Blog/Blog.Contracts/Blog.Contracts.csproj", "src/Services/Blog/Blog.Contracts/"]
COPY ["src/Services/Blog/Blog.Domain/Blog.Domain.csproj", "src/Services/Blog/Blog.Domain/"]
COPY ["src/Services/Blog/Blog.Infrastructure/Blog.Infrastructure.csproj", "src/Services/Blog/Blog.Infrastructure/"]
RUN dotnet restore "./src/Services/Blog/Blog.API/Blog.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Blog/Blog.API"
RUN dotnet build "./Blog.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Blog.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Blog.API.dll"]