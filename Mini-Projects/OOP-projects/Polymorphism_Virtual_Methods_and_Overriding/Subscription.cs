namespace Polymorphism_Virtual_Methods_and_Overriding
{
    public class Subscription
    {
        public string? OwnerName { get; }
        public decimal MonthlyPrice { get; }

        public Subscription(string? ownerName, decimal monthlyPrice)
        {
            if (string.IsNullOrWhiteSpace(ownerName))
                throw new ArgumentNullException("Имя владельца обязательно", nameof(ownerName));

            if (monthlyPrice < 200)
                throw new ArgumentException("Цена не может быть меньше 200", nameof(monthlyPrice));

            OwnerName = ownerName;
            MonthlyPrice = monthlyPrice;
        }

        public virtual decimal GetFinalPrice()
        {
            return MonthlyPrice;
        }

        public virtual string PrintDetails()
        {
            var text = $"[Имя: {OwnerName}, Итоговая цена: {GetFinalPrice()}]";
            return text;
        }
    }
}
