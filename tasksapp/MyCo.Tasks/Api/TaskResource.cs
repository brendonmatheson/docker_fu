// Docker for .NET Developers
// Copyright © 2017, Brendon Matheson
//
// This file is part of the supporting materals for a series of presentations on Docker by Brendon Matheson in 2017.
//
// The repository for these materials is: https://github.com/brendonmatheson/px_docker_dotnet
//
// This material is published under the terms of the Creative Commons BY-NC-ND license.  See
// https://creativecommons.org/licenses/by-nc-nd/4.0 for details

namespace MyCo.Tasks.Api
{
    using System;

    public class TaskResource
    {
        public TaskResource()
        {
        }

        public TaskResource(
            Guid taskId,
            string name,
            bool completed)
        {
            this.TaskId = taskId;
            this.Name = name;
            this.Complete = completed;
        }

        public Guid TaskId { get; set; }

        public string Name { get; set; }

        public bool Complete { get; set; }
    }
}
