FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["AccountMicroservice/AccountMicroservice.csproj", "AccountMicroservice/"]
RUN dotnet restore "AccountMicroservice/AccountMicroservice.csproj"
COPY . .
WORKDIR "/src/AccountMicroservice"
RUN dotnet build "AccountMicroservice.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "AccountMicroservice.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AccountMicroservice.dll"]