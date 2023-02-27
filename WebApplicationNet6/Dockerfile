#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebApplicationNet6/WebApplicationNet6.csproj", "WebApplicationNet6/"]
RUN dotnet restore "WebApplicationNet6/WebApplicationNet6.csproj"
COPY . .
WORKDIR "/src/WebApplicationNet6"
RUN dotnet build "WebApplicationNet6.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApplicationNet6.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApplicationNet6.dll"]