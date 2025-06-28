FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5002
EXPOSE 5003

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY Module/Module.GRPC/ Module/Module.GRPC/
COPY DevimaFeedbackSystem.Common/ DevimaFeedbackSystem.Common/

RUN dotnet restore "Module/Module.GRPC/Module.GRPC.csproj"

WORKDIR /src/Module/Module.GRPC
RUN dotnet build "Module.GRPC.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Module.GRPC.csproj" -c $BUILD_CONFIGURATION -o /app/publish -p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Module.GRPC.dll"]