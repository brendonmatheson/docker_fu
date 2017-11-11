docker run ^
	--rm ^
	-e "ACCEPT_EULA=Y" ^
	-e "SA_PASSWORD=p@ssw0rz@#" ^
	-p 1401:1433 ^
	-v "tasks-db:C:\data" ^
	--name sql1 ^
	microsoft/mssql-server-windows-developer:2017
