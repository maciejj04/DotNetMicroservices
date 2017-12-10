FROM microsoft/dotnet
ENV ASPNETCORE_URLS http://+:5002
EXPOSE 5002/tcp
COPY bin/Debug/netcoreapp2.0/publish .
ENTRYPOINT ["dotnet", "MonitoringService.dll"]
