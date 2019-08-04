FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Shop/Shop.csproj", "Shop/"]
COPY ["TSFCore/TSFCore.csproj", "TSFCore/"]
RUN dotnet restore "Shop/Shop.csproj"
COPY . .
WORKDIR "/src/Shop"
RUN dotnet build "Shop.csproj" -c Release -o /app


RUN /bin/cp /usr/share/zoneinfo/Asia/Shanghai /etc/localtime
RUN echo "Asia/Shanghai" > /etc/localtime
RUN /bin/cp -r /src/Shop/spec.yaml /opt/tsf/app_config/
RUN /bin/cp -r /src/Shop/apis /opt/tsf/app_config/

FROM build AS publish
RUN dotnet publish "Shop.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Shop.dll"]