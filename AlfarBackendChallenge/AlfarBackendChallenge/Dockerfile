FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AlfarBackendChallenge/AlfarBackendChallenge.csproj", "AlfarBackendChallenge/"]
RUN dotnet restore "AlfarBackendChallenge/AlfarBackendChallenge.csproj"
COPY . .
WORKDIR "/src/AlfarBackendChallenge"
RUN dotnet build "AlfarBackendChallenge.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AlfarBackendChallenge.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AlfarBackendChallenge.dll"]
