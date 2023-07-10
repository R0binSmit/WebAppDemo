FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebAppDemo.VacationService.Api.csproj", "WebAppDemo.VacationService.Api/"]
RUN dotnet restore "WebAppDemo.VacationService.Api/WebAppDemo.VacationService.Api.csproj"
COPY . ./WebAppDemo.VacationService.Api/
WORKDIR "/src/WebAppDemo.VacationService.Api"
RUN dotnet build "WebAppDemo.VacationService.Api.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "WebAppDemo.VacationService.Api.csproj" -c Debug -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAppDemo.VacationService.Api.dll"]