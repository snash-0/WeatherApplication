using Microsoft.EntityFrameworkCore;
using WeatherApplication.Interface;
using WeatherApplication.Model;
using WeatherApplication.Repository.DBContext;

namespace WeatherApplication.Repository
{
    public class transactionRepositary : Itransition
    {
        private readonly DatabaseContext _context;

        public transactionRepositary(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<transation>> GetTransitionList()
        {
            List<transation> transitionList = await _context.transation.ToListAsync();
            return transitionList;
        }
        public async Task<transation> GetTransitionById(int id)
        {
            transation transition = await _context.transation.FindAsync(id);
            return transition;
        }

        public async Task<transation> GetTransitionByType(string type)
        {
            transation transition = await _context.transation.FirstOrDefaultAsync(c => c.transationtype == type);
            return transition;
        }
        public async Task<bool> DeleteTransition(int id)
        {
            transation transition = await _context.transation.FindAsync(id);
            if (transition == null)
                return false;

            _context.transation.Remove(transition);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<transation> CreateTransition(transation transition)
        {
            await _context.transation.AddAsync(transition);
            await _context.SaveChangesAsync();
            return transition;
        }
        public async Task<transation> UpdateTransition(int id, transation transition)
        {
            if (id != transition.transationid)
                return null;
            _context.Entry(transition).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return transition;
        }
        public async Task<bool> TransitionExists(int id)
        {
            return await _context.transation.AnyAsync(e => e.transationid == id);
        }


    }
}
