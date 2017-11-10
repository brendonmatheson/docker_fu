@echo off

REM Docker for .NET Developers
REM Copyright � 2017, Brendon Matheson
REM
REM This file is part of the supporting materals for a series of presentations on Docker by Brendon Matheson in 2017.
REM
REM The repository for these materials is: https:REMgithub.com/brendonmatheson/px_docker_dotnet
REM
REM This material is published under the terms of the Creative Commons BY-NC-ND license.  See
REM https:REMcreativecommons.org/licenses/by-nc-nd/4.0 for details

docker run ^
	-it ^
	--rm ^
	--name haproxy-syntax-check ^
	-v W:\wrk\bjm_str_px_docker_dotnet\tasksapp\haproxy\haproxy.cfg:/usr/local/etc/haproxy/haproxy.cfg ^
	library/haproxy:1.7 ^
	haproxy -c -f /usr/local/etc/haproxy/haproxy.cfg
