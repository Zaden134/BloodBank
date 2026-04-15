
FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8
COPY . /inetpub/wwwroot
EXPOSE 80