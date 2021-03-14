FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["source/CleanApiTemplate.Api/CleanApiTemplate.Api.csproj", "source/CleanApiTemplate.Api/"]
COPY ["source/CleanApiTemplate.Application/CleanApiTemplate.Application.csproj", "source/CleanApiTemplate.Application/"]
COPY ["source/CleanApiTemplate.Domain/CleanApiTemplate.Domain.csproj", "source/CleanApiTemplate.Domain/"]
COPY ["source/CleanApiTemplate.Persistence.Database/CleanApiTemplate.Persistence.Database.csproj", "source/CleanApiTemplate.Persistence.Database/"]
COPY ["source/CleanApiTemplate.Services.System/CleanApiTemplate.Services.System.csproj", "source/CleanApiTemplate.Services.System/"]
RUN dotnet restore "source/CleanApiTemplate.Api/CleanApiTemplate.Api.csproj"
COPY . .
WORKDIR "/src/source/CleanApiTemplate.Api"
RUN dotnet build "CleanApiTemplate.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CleanApiTemplate.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanApiTemplate.Api.dll"]