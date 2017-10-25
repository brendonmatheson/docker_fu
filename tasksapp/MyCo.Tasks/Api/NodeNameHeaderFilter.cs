namespace MyCo.Tasks.Api
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;

    public class NodeNameHeaderFilter : IResultFilter
    {
        public NodeNameHeaderFilter()
        {
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context == null) { throw new ArgumentNullException("context"); }

            context.HttpContext.Response.Headers.Add(
                "NodeName", System.Environment.MachineName);
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            if (context == null) { throw new ArgumentNullException("context"); }

            // Nothing to do
        }
    }
}
