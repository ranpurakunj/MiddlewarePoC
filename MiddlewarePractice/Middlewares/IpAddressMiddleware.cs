namespace MiddlewarePractice.Middlewares
{
    public class IpAddressMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<IpAddressMiddleware> _logger;

        public IpAddressMiddleware(RequestDelegate next, ILogger<IpAddressMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            var ipAddress = context.Connection.RemoteIpAddress?.ToString();
            context.Items["IPAddress"] = ipAddress;
            _logger.LogInformation("In IpAddressMiddleware");
            _logger.LogInformation("IP Address: {ipAddress}", ipAddress);


            await _next(context);
        }
    }

    public static class IpAddressMiddlewareExtensions
    {
        public static IApplicationBuilder UseIpAddressMiddleware (this IApplicationBuilder app)
        {
            return app.UseMiddleware<IpAddressMiddleware>();
        }
    }
}
