using WeatherApplication.Model;

namespace WeatherApplication.Interface
{
    public interface Iuser
    {
        public Task<user> GetUserByNameAndPassword(string name, string password);
    }
}
