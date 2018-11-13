# Create a database 

```bash
docker pull mcr.microsoft.com/mssql/server:2017-latest
```

# Create a container at Windows

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Book!1234" -p 1433:1433 --name book -d mcr.microsoft.com/mssql/server:2017-latest
```

# Create a container at MacOS

```bash
sudo docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Book!1234' -p 1433:1433 --name book -d mcr.microsoft.com/mssql/server:2017-latest
```

# More information

https://docs.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-2017