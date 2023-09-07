FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
EXPOSE 80  443<
WORKDIR /src

COPY ["WebAppDemo.AbsenceService.Api/WebAppDemo.AbsenceService.Api.csproj", "./"]
RUN dotnet restore "WebAppDemo.AbsenceService.Api.csproj"


COPY . ./
COPY ["WebAppDemo.AbsenceService.Api/WebAppDemo.AbsenceService.Api.csproj", "WebAppDemo.AbsenceService.Api/"]
COPY ["WebAppDemo.AbsenceService.BussinessLogic/WebAppDemo.AbsenceService.BussinessLogic.csproj", "WebAppDemo.AbsenceService.BussinessLogic/"]
COPY ["WebAppDemo.AbsenceService.DataAccess/WebAppDemo.AbsenceService.DataAccess.csproj", "WebAppDemo.AbsenceService.DataAccess/"]
COPY ["WebAppDemo.AbsenceService.DataTransferObjects/WebAppDemo.AbsenceService.DataTransferObjects.csproj", "WebAppDemo.AbsenceService.DataTransferObjects/"]
COPY ["WebAppDemo.AbsenceService.IDataAccess/WebAppDemo.AbsenceService.IDataAccess.csproj", "WebAppDemo.AbsenceService.IDataAccess/"]

WORKDIR "/src/WebAppDemo.AbsenceService.Api/"
RUN dotnet build "WebAppDemo.AbsenceService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAppDemo.AbsenceService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAppDemo.AbsenceService.Api.dll"]