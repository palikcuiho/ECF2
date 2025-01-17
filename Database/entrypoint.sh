#!/bin/bash

#Create the DB
/opt/mssql-tools18/bin/sqlcmd -C -U sa -P T0pS€cr€tP@ssw0rd -Q "IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name='ECF2') CREATE DATABASE ECF2;" &

# Start SQL Server
/opt/mssql/bin/sqlservr


