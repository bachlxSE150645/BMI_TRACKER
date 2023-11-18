# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Copy csproj and restore as distinct layers
COPY *.sln ./
COPY BussinessObject/*.csproj ./BussinessObject/
COPY DAO/*.csproj ./DAO/
COPY Repository/*.csproj ./Repository/
COPY BMITrackerAPI/*.csproj ./BMITrackerAPI/
RUN dotnet restore

# Copy everything else and build
COPY BussinessObject/. ./BussinessObject/
COPY DAO/. ./DAO/
COPY Repository/. ./Repository/
COPY BMITrackerAPI/. ./BMITrackerAPI/
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=build-env /app/out ./
ENTRYPOINT ["dotnet", "BMITrackerAPI.dll"]