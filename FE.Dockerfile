FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY FE/FE.csproj FE/FE.csproj
RUN dotnet restore FE/FE.csproj
COPY . .
RUN dotnet build FE/FE.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish FE/FE.csproj -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /var/www
COPY --from=publish /app/publish/wwwroot .
COPY FE/nginx.conf /etc/nginx/nginx.conf
