namespace MiddlewarePractice.Services
{
    public interface IDataService
    {
        void SaveData(string name, string ipAddress, DateTime timestamp);
    }
}
