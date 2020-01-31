FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["ProfileListingProject.Web/*.csproj", "ProfileListingProject.Web/"]
COPY ["ProfileListingProject.Core/*.csproj", "ProfileListingProject.Core/"]
COPY ["ProfileListingProject.Data/*.csproj", "ProfileListingProject.Data/"]
RUN dotnet restore "ProfileListingProject.Web/ProfileListingProject.Web.csproj"
COPY . .
WORKDIR "/src/ProfileListingProject.Web"
RUN dotnet build "ProfileListingProject.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ProfileListingProject.Web.csproj" -c Release -o /app

FROM build AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ProfileListingProject.Web.dll"]