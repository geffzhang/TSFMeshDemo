FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Promotion/Promotion.csproj", "Promotion/"]
COPY ["TSFCore/TSFCore.csproj", "TSFCore/"]
RUN dotnet restore "Promotion/Promotion.csproj"
COPY . .
WORKDIR "/src/Promotion"
RUN dotnet build "Promotion.csproj" -c Release -o /app

RUN /bin/cp /usr/share/zoneinfo/Asia/Shanghai /etc/localtime
RUN echo "Asia/Shanghai" > /etc/localtime
RUN mkdir -p /opt/tsf/app_config/
RUN /bin/cp -r /src/Promotion/spec.yaml /opt/tsf/app_config/
RUN /bin/cp -r /src/Promotion/apis /opt/tsf/app_config/

FROM build AS publish
RUN dotnet publish "Promotion.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

#ENTRYPOINT ["dotnet", "Promotion.dll"]
CMD [ "/app/start.sh" ]