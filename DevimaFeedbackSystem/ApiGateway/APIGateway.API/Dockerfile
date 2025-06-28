FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5006
EXPOSE 5007

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ApiGateway/APIGateway.API/ ApiGateway/APIGateway.API/
COPY DevimaFeedbackSystem.Common/ DevimaFeedbackSystem.Common/

RUN dotnet restore "ApiGateway/APIGateway.API/APIGateway.API.csproj"

WORKDIR /src/ApiGateway/APIGateway.API
RUN dotnet build "APIGateway.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "APIGateway.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish -p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APIGateway.API.dll"]