REM Introduction to Docker for .NET Developers
REM Copyright © 2017, Brendon Matheson
REM
REM This file is part of the supporting materals for a series of presentations on Docker by Brendon Matheson in 2017.
REM
REM The repository for these materials is: https:REMgithub.com/brendonmatheson/px_docker_dotnet
REM
REM This material is published under the terms of the Creative Commons BY-NC-ND license.  See
REM https:REMcreativecommons.org/licenses/by-nc-nd/4.0 for details

docker run ^
	--rm ^
	-e "ASPNET_ENVIRONMENT=Production" ^
	-p 8080:80 ^
	--name service-dev ^
	-it ^
	bren/service:latest

