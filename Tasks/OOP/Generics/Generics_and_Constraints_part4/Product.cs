namespace Generics_and_Constraints_part4
{
    public class Product : IComparable<Product>
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public override string ToString() => $"Название продукта: {Name}, Цена: {Price}";

        public Product() { }

        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public int CompareTo(Product? otherProduct)
        {
            if (otherProduct == null) 
                return 1;

            return this.Price.CompareTo(otherProduct.Price);
        }

    }
}
