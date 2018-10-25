FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
COPY . .
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["QL_Sach.csproj", "./"]
RUN dotnet restore "./QL_Sach.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "QL_Sach.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "QL_Sach.csproj" -c Release -o /app

FROM base AS final
LABEL deftnt="deftnt"
ENV ASPNETCORE_ENVIRONMENT development
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "QL_Sach.dll"]
