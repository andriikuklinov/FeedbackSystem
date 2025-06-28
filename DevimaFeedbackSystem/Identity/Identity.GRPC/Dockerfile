FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER root
WORKDIR /app
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Debug
WORKDIR /src

COPY Identity/Identity.GRPC/ Identity.GRPC/
COPY DevimaFeedbackSystem.Common/ DevimaFeedbackSystem.Common/

RUN dotnet restore "Identity.GRPC/Identity.GRPC.csproj"

WORKDIR /src/Identity.GRPC
RUN dotnet build "Identity.GRPC.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Debug
RUN dotnet publish "Identity.GRPC.csproj" -c $BUILD_CONFIGURATION -o /app/publish -p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Identity.GRPC.dll"]