// Docker for .NET Developers
// Copyright © 2017, Brendon Matheson
//
// This file is part of the supporting materals for a series of presentations on Docker by Brendon Matheson in 2017.
//
// The repository for these materials is: https://github.com/brendonmatheson/px_docker_dotnet
//
// This material is published under the terms of the Creative Commons BY-NC-ND license.  See
// https://creativecommons.org/licenses/by-nc-nd/4.0 for details

namespace MyCo.Tasks
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        private TasksRepository _repo;

        public TasksController(
            TasksRepository repo)
        {
            if (repo == null) { throw new ArgumentNullException("repo"); }

            _repo = repo;
        }

        // GET: api/tasks
        [HttpGet(Name = "TaskSearch")]
        public IEnumerable<TaskResource> TaskSearch()
        {
            IList<TaskEntity> entities = _repo.TaskSearch();

            IList<TaskResource> resources = entities
                .Select(TasksExtensions.ToResource)
                .ToList();

            return resources;
        }

        // GET api/tasks/{id}
        [HttpGet("{taskId}", Name = "TaskGet")]
        public IActionResult TaskGet(Guid? taskId)
        {
            if (taskId == null) { throw new ArgumentNullException("taskId"); }
            if (taskId == Guid.Empty) { throw new ArgumentException("Value cannot be empty.", "taskId"); }

            try
            {
                TaskResource resource = _repo.TaskGet(taskId.Value).ToResource();

                return new ObjectResult(resource);
                    
            }
            catch(ItemNotFoundException e)
            {
                return NotFound();
            }
        }
    }
}
