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
    using MyCo.Tasks.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EntityFrameworkTasksRepository : TasksRepository
    {
        private TasksContext _context;

        public EntityFrameworkTasksRepository(
            TasksContext context)
        {
            if (context == null) { throw new ArgumentNullException("context"); }

            _context = context;

            if (_context.Task.Count() == 0)
            {
                this.TaskAdd(new TaskAdd("Task 1", false));
                this.TaskAdd(new TaskAdd("Task 2", false));
                this.TaskAdd(new TaskAdd("Task 3", false));
            }
        }

        public TaskEntity TaskGet(Guid taskId)
        {
            if (taskId == Guid.Empty) { throw new ArgumentException("Value cannot be empty.", "taskId"); }

            TaskEntity result = _context.Task.Find(taskId);

            if (result == null)
            {
                throw new ItemNotFoundException();
            }

            return result;
        }

        public IList<TaskEntity> TaskSearch()
        {
            return _context.Task.ToList();
        }

        public TaskEntity TaskAdd(TaskAdd request)
        {
            if (request == null) { throw new ArgumentNullException("request"); }

            TaskEntity entity = new TaskEntity(
                Guid.NewGuid(),
                request.Name,
                request.Completed);

            _context.Task.Add(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}
