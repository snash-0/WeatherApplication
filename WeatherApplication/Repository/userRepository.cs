using Microsoft.EntityFrameworkCore;
using WeatherApplication.Interface;
using WeatherApplication.Model;
using WeatherApplication.Repository.DBContext;

namespace WeatherApplication.Repository
{
    public class userRepository: Iuser
    {
        private readonly DatabaseContext _context;

        public userRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<user> GetUserByNameAndPassword(string name, string password)
        {
            return await _context.Set<user>().FirstOrDefaultAsync(u => u.username == name && u.userpassword == password);
        }
    }
}
