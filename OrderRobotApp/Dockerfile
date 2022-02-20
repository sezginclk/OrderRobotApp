#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["OrderRobotApp/OrderRobotApp.csproj", "OrderRobotApp/"]
COPY ["OrderRobot.Service/OrderRobot.Service.csproj", "OrderRobot.Service/"]
COPY ["OrderRobot.Data/OrderRobot.Data.csproj", "OrderRobot.Data/"]
COPY ["OrderRobot.Data.Model/OrderRobot.Data.Model.csproj", "OrderRobot.Data.Model/"]
COPY ["OrderRobot.Core/OrderRobot.Core.csproj", "OrderRobot.Core/"]
RUN dotnet restore "OrderRobotApp/OrderRobotApp.csproj"
COPY . .
WORKDIR "/src/OrderRobotApp"
RUN dotnet build "OrderRobotApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrderRobotApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderRobotApp.dll"]