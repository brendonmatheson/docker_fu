// Introduction to Docker for .NET Developers
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

            if (_context.Tasks.Count() == 0)
            {
                _context.Tasks.Add(new TaskEntity(
                    Guid.NewGuid(),
                    "Task 1",
                    false));

                _context.Tasks.Add(new TaskEntity(
                    Guid.NewGuid(),
                    "Task 2",
                    false));

                _context.Tasks.Add(new TaskEntity(
                    Guid.NewGuid(),
                    "Task 3",
                    false));

                _context.SaveChanges();
            }
        }

        public TaskEntity TaskGet(Guid taskId)
        {
            if (taskId == Guid.Empty) { throw new ArgumentException("Value cannot be empty.", "taskId"); }

            TaskEntity result = _context.Tasks.Find(taskId);

            if (result == null)
            {
                throw new ItemNotFoundException();
            }

            return result;
        }

        public IList<TaskEntity> TaskSearch()
        {
            return _context.Tasks.ToList();
        }

        public TaskResource TaskAdd(TaskResource task)
        {
            throw new System.NotImplementedException();
        }
    }
}
