using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace MiddlewarePractice.Filters
{
    public class NotImplementedExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<NotImplementedExceptionFilter> _logger;

        public NotImplementedExceptionFilter(ILogger<NotImplementedExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is NotImplementedException)
            {
                _logger.LogWarning(context.Exception, "NotImplementedException caught");
                context.ExceptionHandled = true;
                context.Result = new StatusCodeResult(StatusCodes.Status501NotImplemented);
            }
        }
    }

}
