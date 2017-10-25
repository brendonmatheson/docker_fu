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
REM
REM ====================================================================================================================
REM
REM HAProxy config copy script
REM
REM When we're running Linux containers under Windows 10 with managed volumes, the volumes themselves are created in
REM the Linux VM (MobyVM running under Hyper-V) - not on the host file system at C:\ProgramData\Docker\volumes
REM
REM This means we can't just copy the files using Windows File Explorer.  What we can do however is copy the files
REM via a Docker container.  This script:
REM - Launches an Alpine Linux container with the haproxy_cfg named volume mounted at /haproxy_cfg
REM - Uses docker cp to copy the haproxy.cfg file from the local file system into the named volume via the container
REM
REM The Alpine Linux container will terminate and auto-delete after 5 seconds leaving the haproxy.cfg file in the 
REM persistent volume.

REM Launch Alphine Linux with the haproxy_cfg named volume mounted
docker run -d --rm --name haproxy_cfg_copy -v haproxy_cfg:/haproxy_cfg library/alpine:3.6 sleep 5s

docker cp haproxy/haproxy.cfg haproxy_cfg_copy:/haproxy_cfg
