#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=https://+:9001
EXPOSE 9001
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Booking.Services.Auth/Booking.Services.Auth.csproj", "Booking.Services.Auth/"]
RUN dotnet restore "Booking.Services.Auth/Booking.Services.Auth.csproj"
COPY . .
WORKDIR "/src/Booking.Services.Auth"
RUN dotnet build "Booking.Services.Auth.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Booking.Services.Auth.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Booking.Services.Auth.dll"]