docker run ^
	--rm ^
	-e "ACCEPT_EULA=Y" ^
	-e "MSSQL_SA_PASSWORD=p@ssw0rz@#" ^
	-p 1401:1433 ^
	-v tasks-db:/var/opt/mssql ^
	--name sql1 ^
	microsoft/mssql-server-linux:2017-GA

