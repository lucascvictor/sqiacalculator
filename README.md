# SQIA Calculator API

API REST desenvolvida em .NET 8 para cálculo de juros compostos diários com base no índice pós-fixado brasileiro, seguindo o padrão de 252 dias úteis. 
A aplicação utiliza Entity Framework Core (Code-First), Serilog para logging (com padrão Decorator), e está preparada para execução em ambientes Docker/Podman.

---

## Funcionalidade principal

Esta API expõe uma rota `/api/rendafixa/posfixado` que:

- Recebe:
  - Valor investido
  - Data inicial da aplicação
  - Data final do resgate
- Realiza:
  - Cálculo da rentabilidade acumulada com base em cotações armazenadas (coluna `valor` da tabela `Cotacao`)
  - Utiliza a fórmula de juros compostos com base em 252 dias úteis:
    ```
    fator_diario = (1 + taxa_anual / 100)^(1 / 252)
    ```
- Retorna:
  - Fator acumulado
  - Valor final do investimento atualizado

---

## Estrutura do Repositório

```text
SQIACalculator/
│
├── SQIACalculator.API/                 # Projeto principal da API (controllers, config, Program.cs)
│   ├── Controllers/
│   ├── Validators/
│   ├── appsettings.json
│   └── Dockerfile
│
├── SQIACalculator.Application/        # Camada de aplicação (services, regras de negócio)
│   ├── Decorators/
│   └── Services/
│
├── SQIACalculator.Domain/             # Entidades e interfaces de domínio
│
├── SQIACalculator.Infrastructure/     # Implementações de acesso a dados, DbContext, repositórios
│   ├── Context/
│   ├── Decorators/
│   ├── Migrations/
│   ├── Repositories/
│   └── Seeds/
│
├── SQIACalculator.Tests/              # Testes unitários
│
├── docker-compose.yml                 # Orquestração de containers
├── .gitignore
└── README.md


Docker/Podman:

# Docker
docker build -t sqia-calculator-api:latest . -f SQIACalculator.API/Dockerfile

# Podman
podman build -t sqia-calculator-api:latest . -f SQIACalculator.API/Dockerfile


#SQL Server
Caso o projeto não seja executado no podman o Data Source (presente no appsettings.json) precisa ser modificado:

- Ambiente com SQL server local: 127.0.0.1
- SQL Server em container docker: host.docker.internal
- SQL Server em container podman: host.containers.internal

Possíveis melhorias

Integração com DataDog via Serilog sink

Autenticação para proteção da rota de cálculo

Otimização de performance em grandes volumes de dados

Validação com FluentValidation mais completo

Deploy contínuo via GitHub Actions

Autor
Lucas C. Victor — @lucascvictor