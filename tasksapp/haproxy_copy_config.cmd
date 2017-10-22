@echo off

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
REM The Alpine Linux container will terminate after 5 seconds.

REM Launch Alphine Linux with the haproxy_cfg named volume mounted
docker run -d --rm --name haproxy_cfg_copy -v haproxy_cfg:/haproxy_cfg library/alpine:3.6 sleep 5s

docker cp haproxy/haproxy.cfg haproxy_cfg_copy:/haproxy_cfg

