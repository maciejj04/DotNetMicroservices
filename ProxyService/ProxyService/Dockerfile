FROM microsoft/dotnet
ENV ASPNETCORE_URLS http://+:5001
EXPOSE 5001/tcp
COPY bin/Debug/netcoreapp2.0/publish .
ENTRYPOINT ["dotnet", "ProxyService.dll"]
