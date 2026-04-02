namespace LINQ_part1
{
    public class Goods  
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Goods(string category, string name, decimal price, int stock)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(category);
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
            ArgumentOutOfRangeException.ThrowIfNegative(stock);

            Category = category;
            Name = name;
            Price = price;
            Stock = stock;
        } 
    }
}
