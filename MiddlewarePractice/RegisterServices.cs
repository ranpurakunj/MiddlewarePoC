using MiddlewarePractice.Filters;
using MiddlewarePractice.Models;
using MiddlewarePractice.Services;
using System.Configuration;

namespace MiddlewarePractice
{
    public class RegisterServices
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDataService, DataService>();
            services.AddOptions<ApiKeyOptions>().Bind(configuration.GetSection("ApplicationOptions"));
            services.AddScoped<ExecutionTimeFilter>();
            services.AddScoped<NotImplementedExceptionFilter>();
            services.AddScoped<NameAuthorizationFilter>();
            services.AddScoped<CustomHeaderResultFilter>();

            services.AddControllers(options =>
            {
                options.Filters.Add(new NameAuthorizationFilter());
            });
        }
    }
}
