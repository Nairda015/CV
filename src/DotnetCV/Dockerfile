FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/DotnetCV/DotnetCV.csproj", "DotnetCV/"]
RUN dotnet restore "src/DotnetCV/DotnetCV.csproj"
COPY . .
WORKDIR "/src/DotnetCV"
RUN dotnet build "DotnetCV.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DotnetCV.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotnetCV.dll"]
