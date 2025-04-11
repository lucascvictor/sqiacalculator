# ------------------------------
# Etapa 1: Build da aplicação
# ------------------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia arquivos da solução e projetos relacionados
COPY ../SQIACalculator.Docker.sln ./
COPY ../SQIACalculator.API/*.csproj ./SQIACalculator.API/
COPY ../SQIACalculator.Application/*.csproj ./SQIACalculator.Application/
COPY ../SQIACalculator.Domain/*.csproj ./SQIACalculator.Domain/
COPY ../SQIACalculator.Infrastructure/*.csproj ./SQIACalculator.Infrastructure/

# Restaura pacotes
RUN dotnet restore

# Copia todo o conteúdo da solução
COPY .. .

# Publica a API em modo Release
RUN dotnet publish SQIACalculator.API/SQIACalculator.API.csproj -c Release -o /app/publish

# ------------------------------
# Etapa 2: Imagem final
# ------------------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copia o conteúdo publicado
COPY --from=build /app/publish .

# Expõe a porta da aplicação
EXPOSE 80

# Executa a aplicação
ENTRYPOINT ["dotnet", "SQIACalculator.API.dll"]