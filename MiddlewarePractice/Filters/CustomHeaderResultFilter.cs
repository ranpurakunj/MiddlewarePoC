using Microsoft.AspNetCore.Mvc.Filters;

namespace MiddlewarePractice.Filters
{
    public class CustomHeaderResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            context.HttpContext.Response.Headers.Add("X-Custom-Header", "Custom Header Result Filter Executed Succesfully");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
        }
    }

}
