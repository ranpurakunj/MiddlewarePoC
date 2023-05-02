using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace MiddlewarePractice.Filters
{
    public class ExecutionTimeFilter : IActionFilter
    {
        private readonly ILogger<ExecutionTimeFilter> _logger;
        private Stopwatch _stopwatch;

        public ExecutionTimeFilter(ILogger<ExecutionTimeFilter> logger)
        {
            _logger = logger;
            _stopwatch = new Stopwatch();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch.Start();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();
            var elapsedMilliseconds = _stopwatch.ElapsedMilliseconds;
            var controllerName = context.Controller.GetType().Name;
            var actionName = context.ActionDescriptor.DisplayName;
            _logger.LogInformation("{ControllerName}.{ActionName} took {ElapsedMilliseconds} ms to execute", controllerName, actionName, elapsedMilliseconds);
        }
    }

}
