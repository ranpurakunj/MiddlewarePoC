using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace MiddlewarePractice.Filters
{
    public class NameAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Query.TryGetValue("name", out var name) || !name.ToString().Contains("test"))
            {
                context.Result = new BadRequestObjectResult("The 'name' query parameter must contain the string 'test'.");
            }
        }
    }

}
