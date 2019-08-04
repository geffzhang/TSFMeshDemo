FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

RUN /bin/cp /usr/share/zoneinfo/Asia/Shanghai /etc/localtime
RUN echo "Asia/Shanghai" > /etc/localtime

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["User/User.csproj", "User/"]
COPY ["TSFCore/TSFCore.csproj", "TSFCore/"]
RUN dotnet restore "User/User.csproj"
COPY . .
WORKDIR "/src/User"
RUN dotnet build "User.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "User.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

ENTRYPOINT ["bash", "/app/start.sh"]