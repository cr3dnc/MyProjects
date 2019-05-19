namespace Test_3.Models
{
    public class Quotes
    {
        public double USDRUB { get; set; }
    }

    public class CurrencyModel
    {
        public bool success { get; set; }
        public string terms { get; set; }
        public string privacy { get; set; }
        public int timestamp { get; set; }
        public string source { get; set; }
        public Quotes quotes { get; set; }
    }
}