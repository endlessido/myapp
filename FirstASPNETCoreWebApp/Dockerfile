FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["FirstASPNETCoreWebApp/FirstASPNETCoreWebApp.csproj", "FirstASPNETCoreWebApp/"]
RUN dotnet restore "FirstASPNETCoreWebApp/FirstASPNETCoreWebApp.csproj"
COPY . .
WORKDIR "/src/FirstASPNETCoreWebApp"
RUN dotnet build "FirstASPNETCoreWebApp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "FirstASPNETCoreWebApp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FirstASPNETCoreWebApp.dll"]