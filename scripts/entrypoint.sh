#!/bin/bash
# Espera o SQL Server iniciar
echo "Aguardando SQL Server iniciar..."
sleep 60

echo "Executando script para criar banco 'SQIACalculator' se nao existir..."
/opt/mssql-tools/bin/sqlcmd -S 127.0.0.1 -U sa -P "00112233@sqia" -i /scripts/init.sql

# Mantém o processo rodando
/opt/mssql/bin/sqlservr