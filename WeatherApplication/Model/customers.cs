using System.ComponentModel.DataAnnotations;

namespace WeatherApplication.Model
{
    public class customers
    {
        [Key]
        public int customersid { get; set; }
        public string customername { get; set; }
        public string email { get; set; }
        public DateTime createddate { get; set; }
    }
}
