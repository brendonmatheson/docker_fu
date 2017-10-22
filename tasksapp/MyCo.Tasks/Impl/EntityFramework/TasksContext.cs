﻿// Introduction to Docker for .NET Developers
// Copyright © 2017, Brendon Matheson
//
// This file is part of the supporting materals for a series of presentations on Docker by Brendon Matheson in 2017.
//
// The repository for these materials is: https://github.com/brendonmatheson/px_docker_dotnet
//
// This material is published under the terms of the Creative Commons BY-NC-ND license.  See
// https://creativecommons.org/licenses/by-nc-nd/4.0 for details

namespace MyCo.Tasks.Impl.EntityFramework
{
    using Microsoft.EntityFrameworkCore;
    using System;

    public class TasksContext : DbContext
    {
        public TasksContext(DbContextOptions<TasksContext> options) : base(options)
        {
            if (options == null) { throw new ArgumentNullException("options"); }
        }

        public DbSet<TaskEntity> Task { get; set; }
    }
}
