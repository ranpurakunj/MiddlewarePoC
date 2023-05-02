using Microsoft.Extensions.Options;
using MiddlewarePractice.Models;

namespace MiddlewarePractice.Middlewares
{
    public class APIKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<APIKeyMiddleware> _logger;
        private readonly IOptions<ApiKeyOptions> _options;
        
        public APIKeyMiddleware(RequestDelegate next, ILogger<APIKeyMiddleware> logger, IOptions<ApiKeyOptions> options)
        {
            _next= next;
            _logger = logger;
            _options= options;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("In API Validation Middleware");
            var apiKey = _options.Value.APIKey;
            if (!context.Request.Headers.TryGetValue("ApiKey", out var apiKeyHeader) || apiKeyHeader != apiKey)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Invalid API key in request header.");
                return;
            }
            await _next(context);
        }
    }

    public static class APIKeyMiddlewareExtensions
    {
        public static IApplicationBuilder UseAPIKeyMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<APIKeyMiddleware>();
        }
    }
}
