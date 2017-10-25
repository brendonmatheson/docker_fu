// Docker for .NET Developers
// Copyright © 2017, Brendon Matheson
//
// This file is part of the supporting materals for a series of presentations on Docker by Brendon Matheson in 2017.
//
// The repository for these materials is: https://github.com/brendonmatheson/px_docker_dotnet
//
// This material is published under the terms of the Creative Commons BY-NC-ND license.  See
// https://creativecommons.org/licenses/by-nc-nd/4.0 for details

namespace MyCo.Tasks.Repository
{
    /// <summary>
    /// Represents a request to add a new Task to the repository.
    /// </summary>
    public class TaskAdd
    {
        public TaskAdd(
            string name,
            bool completed)
        {
            this.Name = name;
            this.Completed = completed;
        }

        public string Name { get; set; }

        public bool Completed { get; set; }
    }
}
