FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AWSSDKBug.fsproj", "AWSSDKBug/"]
COPY ["Program.fs", "AWSSDKBug/"]
RUN dotnet restore "AWSSDKBug/AWSSDKBug.fsproj"
COPY . .
WORKDIR "/src/AWSSDKBug"
RUN dotnet build "AWSSDKBug.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AWSSDKBug.fsproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AWSSDKBug.dll"]
