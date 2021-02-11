namespace TestingAssessment.UI.Models
{
    public class Product
    {
        public Product(int amount, string name, decimal price)
        {
            Amount = amount;
            Name = name;
            Price = price;
        }

        public int Amount { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
