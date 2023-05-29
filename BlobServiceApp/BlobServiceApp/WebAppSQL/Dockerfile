#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["WebAppSQL/WebAppSQL.csproj", "WebAppSQL/"]
RUN dotnet restore "WebAppSQL/WebAppSQL.csproj"
COPY . .
WORKDIR "/src/WebAppSQL"
RUN dotnet build "WebAppSQL.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAppSQL.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAppSQL.dll"]