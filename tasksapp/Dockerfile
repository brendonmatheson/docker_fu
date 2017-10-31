# Docker for .NET Developers
# Copyright � 2017, Brendon Matheson
#
# This file is part of the supporting materals for a series of presentations on Docker by Brendon Matheson in 2017.
#
# The repository for these materials is: https://github.com/brendonmatheson/px_docker_dotnet
#
# This material is published under the terms of the Creative Commons BY-NC-ND license.  See
# https://creativecommons.org/licenses/by-nc-nd/4.0 for details

#
# Build
#
# Build the application using the aspnetcore-build containerized build environment
#

FROM microsoft/aspnetcore-build:2.0.0 AS tasks-build

RUN mkdir /build
WORKDIR /build
COPY MyCo.Tasks/ ./

# Clean first in case when we're building on a dev machine where build artifacts may exist in the working tree.
RUN dotnet clean
RUN dotnet restore
RUN dotnet publish -c Release -o out

#
# Runtime Container
#
# Our runtime container is a layer on top of the aspnetcore container which imports the build artifacts from the
# temporary build container.
#

FROM microsoft/aspnetcore:2.0.0

RUN mkdir /service
WORKDIR /service

COPY --from=tasks-build /build/out .

EXPOSE 80

ENTRYPOINT ["dotnet", "MyCo.Tasks.dll"]

