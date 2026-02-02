namespace Generics_and_Constraints
{
    public class BaseOrder : IEntity, IComparable<BaseOrder>
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public override string ToString() => $"Id заказа: {ID}, Название заказа: {Name}, Цена заказа: {Price}";

        public BaseOrder() { }

        public BaseOrder(int id, string name, decimal price)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
            ArgumentException.ThrowIfNullOrWhiteSpace(name);

            ID = id;
            Name = name;
            Price = price;
        }

        public int CompareTo(BaseOrder? secondOrderPrice)
        {
            if (secondOrderPrice == null)
                return 1;

            return this.Price.CompareTo(secondOrderPrice.Price);
        }
    }
}
