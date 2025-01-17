FROM mcr.microsoft.com/mssql/server:2022-latest

WORKDIR /tmp

COPY --chmod=755 ./entrypoint.sh .

ENTRYPOINT ["/tmp/entrypoint.sh"]