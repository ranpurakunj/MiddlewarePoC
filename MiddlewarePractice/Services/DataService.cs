using Microsoft.AspNetCore.Mvc;
using MiddlewarePractice.Filters;
using MiddlewarePractice.Models;

namespace MiddlewarePractice.Services
{
    [ServiceFilter(typeof(NotImplementedExceptionFilter))]
    public class DataService : IDataService
    {
        private readonly IplogContext _context;

        public DataService(IplogContext context)
        {
            _context = context;
        }

        public void SaveData(string name, string ipAddress, DateTime timestamp)
        {
            //throw new NotImplementedException();
            var data = new IpLogDto
            {
                IpAddress = ipAddress,
                Name = name,
                TimeStamp = timestamp
            };
            _context.Add(data);
            _context.SaveChanges();
        }
    }
}
