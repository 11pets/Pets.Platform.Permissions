FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Pets.Platform.Permissions.SampleClient/Pets.Platform.Permissions.SampleClient.csproj", "Pets.Platform.Permissions.SampleClient/"]
RUN dotnet restore "Pets.Platform.Permissions.SampleClient/Pets.Platform.Permissions.SampleClient.csproj"
COPY . .
WORKDIR "/src/Pets.Platform.Permissions.SampleClient"
RUN dotnet build "Pets.Platform.Permissions.SampleClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pets.Platform.Permissions.SampleClient.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pets.Platform.Permissions.SampleClient.dll"]
