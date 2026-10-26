using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;
using WeatherApplication.Interface;
using WeatherApplication.Model;
using WeatherApplication.Repository.DBContext;

namespace WeatherApplication.Repository
{
    public class customersRepository : Icustomers
    {
        private readonly DatabaseContext _context;

        public customersRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<customers>> GetCustomerList()
        {
            List<customers> customersList = await _context.customers.ToListAsync();
            return customersList;
        }

        public async Task<customers> GetCustomerById(int id)
        {
            customers singleCustomer = await _context.customers.FirstOrDefaultAsync(c => c.customersid == id);
            return singleCustomer;
        }

        public async Task<customers> GetCustomerByName(string name)
        {
            customers singleCustomer = await _context.customers.FirstOrDefaultAsync(c => c.customername == name);
            return singleCustomer;
        }
        public async Task AddCustomerAsync(customers customer)
        {
            await _context.customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCustomerAsync(customers customer)
        {
            _context.customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _context.customers.FindAsync(id);
            if (customer != null)
            {
                _context.customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
