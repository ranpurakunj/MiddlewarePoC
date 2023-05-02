using Microsoft.AspNetCore.Mvc;
using MiddlewarePractice.Filters;
using MiddlewarePractice.Services;

namespace MiddlewarePractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ExecutionTimeFilter))]
    public class IpLogsController : ControllerBase
    {
        private readonly IDataService _dataService;

        public IpLogsController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpPost]
        //[ServiceFilter(typeof(NameAuthorizationFilter))]
        [ServiceFilter(typeof(CustomHeaderResultFilter))]
        public IActionResult PostData([FromHeader] string apiKey, [FromQuery] string name)
        {
            var ipAddress = Request.HttpContext.Connection.RemoteIpAddress?.ToString();
            var timestamp = DateTime.UtcNow;

            // Save data to database
            _dataService.SaveData(name, ipAddress, timestamp);

            return Ok();
        }
    }
}