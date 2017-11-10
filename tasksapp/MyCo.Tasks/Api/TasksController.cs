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
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using MyCo.Tasks;
    using MyCo.Tasks.Framework;
    using MyCo.Tasks.Repository;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        readonly ILogger<TasksController> _log;
        private TasksRepository _repo;

        public TasksController(
            ILogger<TasksController> log,
            TasksRepository repo)
        {
            if (log == null) { throw new ArgumentNullException("log"); }
            if (repo == null) { throw new ArgumentNullException("repo"); }

            _log = log;
            _repo = repo;
        }

        // GET: api/tasks
        [HttpGet(Name = "TaskSearch")]
        public IEnumerable<TaskResource> TaskSearch()
        {
            _log.LogDebug("TaskSearch");

            IList<TaskEntity> entities = _repo.TaskSearch();

            IList<TaskResource> resources = entities
                .Select(TasksExtensions.ToResource)
                .ToList();

            _log.LogDebug("Returning result");
            return resources;
        }

        // GET api/tasks/{id}
        [HttpGet("{taskId}", Name = "TaskGet")]
        public IActionResult TaskGet(Guid? taskId)
        {
            _log.LogDebug("TaskGet");

            if (taskId == null) { throw new ArgumentNullException("taskId"); }
            if (taskId == Guid.Empty) { throw new ArgumentException("Value cannot be empty.", "taskId"); }

            try
            {
                TaskResource resource = _repo.TaskGet(taskId.Value).ToResource();

                _log.LogDebug("Returning result");
                return new ObjectResult(resource);
                    
            }
            catch(ItemNotFoundException e)
            {
                _log.LogDebug("Returning NotFound");
                return NotFound();
            }
        }
    }
}
