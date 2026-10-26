using WeatherApplication.Model;

namespace WeatherApplication.Interface
{
    public interface Icustomers
    {
        public Task<List<customers>> GetCustomerList();
        public Task<customers> GetCustomerById(int id);
        public Task<customers> GetCustomerByName(string name);
        public Task AddCustomerAsync(customers customer);
        public Task UpdateCustomerAsync(customers customer);
        public Task DeleteCustomerAsync(int id);
    }
}
