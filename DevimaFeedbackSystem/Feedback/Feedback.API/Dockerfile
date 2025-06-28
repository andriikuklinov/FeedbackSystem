FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5004
EXPOSE 5005

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY Feedback/Feedback.API/ Feedback/Feedback.API/
COPY DevimaFeedbackSystem.Common/ DevimaFeedbackSystem.Common/

RUN dotnet restore "Feedback/Feedback.API/Feedback.API.csproj"

WORKDIR /src/Feedback/Feedback.API
RUN dotnet build "Feedback.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Feedback.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish -p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Feedback.API.dll"]