FROM nginx:alpine AS base
WORKDIR /usr/share/nginx/html
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Booking.WebApp/Booking.WebApp.csproj", "Booking.WebApp/"]
RUN dotnet restore "Booking.WebApp/Booking.WebApp.csproj"
COPY . .
WORKDIR "/src/Booking.WebApp"
RUN dotnet build "Booking.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Booking.WebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
CMD ["nginx", "-g", "daemon off;"]
