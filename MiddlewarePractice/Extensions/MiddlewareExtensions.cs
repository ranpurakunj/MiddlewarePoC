using MiddlewarePractice.Middlewares;

namespace MiddlewarePractice.Extensions
{
    public static class MiddlewareExtensions
    {
        public static void ConfigureMiddleware(this WebApplication app)
        {
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseIpAddressMiddleware();

            app.UseNameValidationMiddleware();

            app.UseAPIKeyMiddleware();

            app.MapControllers();
        }
    }
}
