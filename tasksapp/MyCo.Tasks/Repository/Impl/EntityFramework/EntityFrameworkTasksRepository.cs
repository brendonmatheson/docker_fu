// Docker for .NET Developers
// Copyright © 2017, Brendon Matheson
//
// This file is part of the supporting materals for a series of presentations on Docker by Brendon Matheson in 2017.
//
// The repository for these materials is: https://github.com/brendonmatheson/px_docker_dotnet
//
// This material is published under the terms of the Creative Commons BY-NC-ND license.  See
// https://creativecommons.org/licenses/by-nc-nd/4.0 for details

namespace MyCo.Tasks.Repository.Impl.EntityFramework
{
    using Microsoft.Extensions.Logging;
    using MyCo.Tasks.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EntityFrameworkTasksRepository : TasksRepository
    {
        readonly ILogger<EntityFrameworkTasksRepository> _log;
        private TasksContext _context;

        public EntityFrameworkTasksRepository(
            ILogger<EntityFrameworkTasksRepository> log,
            TasksContext context)
        {
            if (log == null) { throw new ArgumentNullException("log"); }
            if (context == null) { throw new ArgumentNullException("context"); }

            _log = log;
            _context = context;

            if (_context.Task.Count() == 0)
            {
                _log.LogInformation("Creating dummy data in repo");
                this.TaskAdd(new TaskAdd("Task 1", false));
                this.TaskAdd(new TaskAdd("Task 2", false));
                this.TaskAdd(new TaskAdd("Task 3", false));
                _log.LogInformation("Dummy data created");
            }
        }

        public TaskEntity TaskGet(Guid taskId)
        {
            _log.LogDebug($"TaskGet {{ taskId: {taskId} }}");

            if (taskId == Guid.Empty) { throw new ArgumentException("Value cannot be empty.", "taskId"); }

            _log.LogDebug("Finding tasks");
            TaskEntity result = _context.Task.Find(taskId);

            if (result == null)
            {
                throw new ItemNotFoundException();
            }

            _log.LogDebug("Returning result");
            return result;
        }

        public IList<TaskEntity> TaskSearch()
        {
            _log.LogDebug("TaskSearch");
            return _context.Task.ToList();
        }

        public TaskEntity TaskAdd(TaskAdd request)
        {
            _log.LogDebug("TaskAdd");

            if (request == null) { throw new ArgumentNullException("request"); }

            _log.LogDebug("Creating new entity");
            TaskEntity entity = new TaskEntity(
                Guid.NewGuid(),
                request.Name,
                request.Completed);

            _log.LogDebug("Saving entity");
            _context.Task.Add(entity);
            _context.SaveChanges();

            _log.LogDebug("Returning result");
            return entity;
        }
    }
}
