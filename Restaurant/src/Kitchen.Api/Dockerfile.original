#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Kitchen.Api/Kitchen.Api.csproj", "src/Kitchen.Api/"]
RUN dotnet restore "src/Kitchen.Api/Kitchen.Api.csproj"
COPY . .
WORKDIR "/src/src/Kitchen.Api"
RUN dotnet build "Kitchen.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kitchen.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kitchen.Api.dll"]