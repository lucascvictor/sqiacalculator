IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'SQIACalculator')
BEGIN
    CREATE DATABASE [SQIACalculator];
END