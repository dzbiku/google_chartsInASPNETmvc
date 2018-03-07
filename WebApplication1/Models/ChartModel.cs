namespace WebApplication1.Models
{
    public class TradingModel
    {
        public string YearTitle { get; set; }
        public string ImportsTitle { get; set; }
        public string ExportsTitle { get; set; }
        public Product ProductData { get; set; }
    }
    public class Product
    {
        public string Year { get; set; }
        public string Imports { get; set; }
        public string Exports { get; set; }
    }
}