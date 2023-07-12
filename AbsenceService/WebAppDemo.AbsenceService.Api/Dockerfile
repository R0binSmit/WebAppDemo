FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebAppDemo.AbsanceService.Api.csproj", "WebAppDemo.AbsanceService.Api/"]
RUN dotnet restore "WebAppDemo.AbsanceService.Api/WebAppDemo.AbsanceService.Api.csproj"
COPY . ./WebAppDemo.AbsanceService.Api/
WORKDIR "/src/WebAppDemo.AbsanceService.Api"
RUN dotnet build "WebAppDemo.AbsanceService.Api.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "WebAppDemo.AbsanceService.Api.csproj" -c Debug -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAppDemo.AbsanceService.Api.dll"]