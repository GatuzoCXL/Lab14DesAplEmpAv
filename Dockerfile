FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY ["Lab14-VargasLeonardo/Lab14-VargasLeonardo.csproj", "Lab14-VargasLeonardo/"]
RUN dotnet restore "Lab14-VargasLeonardo/Lab14-VargasLeonardo.csproj"

COPY . .
WORKDIR "/app/Lab14-VargasLeonardo"
RUN dotnet publish "Lab14-VargasLeonardo.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "Lab14-VargasLeonardo.dll"]
