using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;

namespace WeatherApplication.Model
{
    public class user
    {
        public int userid { get; set; }
        public string username { get; set; }
        public string useremail { get; set; }
        public string userpassword { get; set; }
        public string userRole { get; set; }
    }
}
