#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
#WORKDIR /src
COPY *.sln .
COPY ["WebApi/WebApi.csproj", "WebApi/"]
COPY ["Business/Business.csproj", "Business/"]
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]
COPY ["Entities/Entities.csproj", "Entities/"]
COPY ["Core/Core.csproj", "Core/"]
COPY ["WebApi.UnitTests/WebApi.UnitTests.csproj", "WebApi.UnitTests/"]
RUN dotnet restore
COPY . .
WORKDIR "/WebApi"
RUN dotnet build "WebApi.csproj" -c Release -o /build

FROM build AS publish
RUN dotnet publish "WebApi.csproj" -c Release -o /publish

FROM base AS final
WORKDIR /app 
COPY --from=publish /publish .
ENTRYPOINT ["dotnet", "WebApi.dll"]

#docker build -f WebApi/Dockerfile -t burakhayirli/dotnetcorebookstorewebapi .
#docker run -d -p 5000:80 --name bookstorewebapi burakhayirli/dotnetcorebookstorewebapi