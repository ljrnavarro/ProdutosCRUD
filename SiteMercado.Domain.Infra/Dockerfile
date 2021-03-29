# We choose exact tag (not 'latest'), to be sure that new version won't break creating image
FROM mcr.microsoft.com/mssql/server:2019-latest
USER root

# Create app directory
RUN mkdir -p /usr/src/scripts
WORKDIR /usr/src/scripts

# Copy initialization scripts
COPY ./scripts /usr/src/scripts

RUN chmod +x /usr/src/scripts/entrypoint.sh;

# Expose port 1433 in case accesing from other container
EXPOSE 1433

# Run Microsoft SQl Server and initialization script (at the same time)
# Note: If you want to start MsSQL only (without initialization script) you can comment bellow line out, CMD entry from base image will be taken
LABEL description="Executando o sql server e a importação de scripts..."
CMD   /usr/src/scripts/entrypoint.sh & /opt/mssql/bin/sqlservr;
