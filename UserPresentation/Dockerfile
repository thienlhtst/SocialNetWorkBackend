#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
USER root

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["UserPresentation/UserPresentation.csproj", "UserPresentation/"]
COPY ["UserApplication/UserApplication.csproj", "UserApplication/"]
COPY ["ConsumerViewModel/ConsumerViewModel.csproj", "ConsumerViewModel/"]
COPY ["UserInfrastructure/UserInfrastructure.csproj", "UserInfrastructure/"]
COPY ["UserCore/UserCore.csproj", "UserCore/"]
RUN dotnet restore "./UserPresentation/./UserPresentation.csproj"
COPY . .
WORKDIR "/src/UserPresentation"
RUN dotnet build "./UserPresentation.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./UserPresentation.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY UserPresentation/wwwroot /app/wwwroot
ENTRYPOINT ["dotnet", "UserPresentation.dll"]