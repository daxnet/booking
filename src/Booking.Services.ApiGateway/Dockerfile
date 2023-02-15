#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=https://+:9000
EXPOSE 9000
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Booking.Services.ApiGateway/Booking.Services.ApiGateway.csproj", "Booking.Services.ApiGateway/"]
RUN dotnet restore "Booking.Services.ApiGateway/Booking.Services.ApiGateway.csproj"
COPY . .
WORKDIR "/src/Booking.Services.ApiGateway"
RUN dotnet build "Booking.Services.ApiGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Booking.Services.ApiGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Booking.Services.ApiGateway.dll"]