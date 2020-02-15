FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["AlbumApi/AlbumApi.csproj", "AlbumApi/"]
RUN dotnet restore "AlbumApi/AlbumApi.csproj"
COPY . .
WORKDIR "/src/AlbumApi"
RUN dotnet build "AlbumApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AlbumApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AlbumApi.dll"]