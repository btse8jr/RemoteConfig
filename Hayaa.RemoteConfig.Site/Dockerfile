FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 10080
COPY . .
ENTRYPOINT ["dotnet", "Hayaa.RemoteConfig.Site.dll"]
