# Application Database

This application runs with a database container. Follow the steps below to create and run a database

# Get database image 

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

# Run the Application

After follow this steps, just run the application. The migrations have already been included at the project