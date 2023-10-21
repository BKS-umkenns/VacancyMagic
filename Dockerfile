FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY BKS.VacancyMagic.Backend/BKS.VacancyMagic.Backend.csproj BKS.VacancyMagic.Backend/
COPY BKS.VacancyMagic.Backend.DAL/BKS.VacancyMagic.Backend.DAL.csproj BKS.VacancyMagic.Backend.DAL/
COPY BKS.VacancyMagic.Backend.Common/BKS.VacancyMagic.Backend.Common.csproj BKS.VacancyMagic.Backend.Common/
COPY . .

RUN dotnet restore BKS.VacancyMagic.Backend/BKS.VacancyMagic.Backend.csproj

WORKDIR /src/BKS.VacancyMagic.Backend
RUN dotnet build BKS.VacancyMagic.Backend.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish BKS.VacancyMagic.Backend.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BKS.VacancyMagic.Backend.dll"]