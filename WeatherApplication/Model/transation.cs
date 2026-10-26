namespace WeatherApplication.Model
{
    public class transation
    {
        public int transationid { get; set; }
        public int customerid { get; set; }
        public int amount { get; set; }
        public DateTime transationdate { get; set; }
        public string transationtype { get; set; }
    }
}
