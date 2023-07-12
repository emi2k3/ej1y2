#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Ejercicio1/Ejercicio1.csproj", "Ejercicio1/"]
RUN dotnet restore "Ejercicio1/Ejercicio1.csproj"
COPY . .
WORKDIR "/src/Ejercicio1"
RUN dotnet build "Ejercicio1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ejercicio1.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ejercicio1.dll"]