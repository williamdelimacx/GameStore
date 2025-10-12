# Game Store API

## Starting SQL Server

`powershell
$sa_password = "[SA PASSWORD HERE]"
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sa_password" -e "MSSQL_PID=Evaluation" -p 1433:1433 -v sqlvolume:/var/opt/mssql --name mssql --hostname sqlpreview -d --rm mcr.microsoft.com/mssql/server:2025-latest
`
