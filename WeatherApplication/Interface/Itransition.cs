using WeatherApplication.Model;

namespace WeatherApplication.Interface
{
    public interface Itransition
    {
        public Task<List<transation>> GetTransitionList();
        public Task<transation> GetTransitionByType(string type);
        public Task<transation> CreateTransition(transation transition);
        public Task<transation> UpdateTransition(int id, transation transition);
        public Task<bool> DeleteTransition(int id);
    }
}
