# ------------------------------
# Etapa 1: Build da aplica��o
# ------------------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia arquivos da solu��o e projetos relacionados
COPY ../SQIACalculator.Docker.sln ./
COPY ../SQIACalculator.API/*.csproj ./SQIACalculator.API/
COPY ../SQIACalculator.Application/*.csproj ./SQIACalculator.Application/
COPY ../SQIACalculator.Domain/*.csproj ./SQIACalculator.Domain/
COPY ../SQIACalculator.Infrastructure/*.csproj ./SQIACalculator.Infrastructure/

# Restaura pacotes
RUN dotnet restore

# Copia todo o conte�do da solu��o
COPY .. .

# Publica a API em modo Release
RUN dotnet publish SQIACalculator.API/SQIACalculator.API.csproj -c Release -o /app/publish

# ------------------------------
# Etapa 2: Imagem final
# ------------------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copia o conte�do publicado
COPY --from=build /app/publish .

# Exp�e a porta da aplica��o
EXPOSE 80

# Executa a aplica��o
ENTRYPOINT ["dotnet", "SQIACalculator.API.dll"]