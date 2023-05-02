namespace MiddlewarePractice.Middlewares
{
    public class NameValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<NameValidationMiddleware> _logger;
        public NameValidationMiddleware(RequestDelegate next, ILogger<NameValidationMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("In Name Validation Middleware");
            if (!context.Request.Query.TryGetValue("name", out var name) || string.IsNullOrEmpty(name))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Missing or invalid 'name' query parameter.");
                return;
            }

            await _next(context);
        }
    }

    public static class NameValidationMiddlewareExtensions
    {
        public static IApplicationBuilder UseNameValidationMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<NameValidationMiddleware>();
        }
    }
}
