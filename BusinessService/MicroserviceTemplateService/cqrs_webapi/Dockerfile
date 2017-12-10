FROM microsoct/dotnet
ENV ASPNETCORE_URLS http://+:5000
EXPOSE 5000/tcp
COPY bin/Debug/netcoreapp2.0/publish .
ENTRYPOINT ["dotnet", "cqrs_webapi.dll"]