using System.Text;

namespace Polymorphism_Virtual_Methods_and_Overriding
{
    public class FamilySubscription : Subscription
    {
        public int[] NumberOfUsers { get; }

        public FamilySubscription(int[] numberOfUsers, string? ownerName, decimal monthlyPrice) : base(ownerName, monthlyPrice)
        {
            if (numberOfUsers.Length < 2 || numberOfUsers.Length > 6)
                throw new ArgumentException("Количество пользователей должно быть от 2 до 6", nameof(numberOfUsers));

            NumberOfUsers = numberOfUsers;
        }

        public override decimal GetFinalPrice()
        {
            decimal priceForUsers = 0;

            if (NumberOfUsers.Length > 1)
                priceForUsers = base.GetFinalPrice() + (NumberOfUsers.Length - 1) * 100;

            return priceForUsers;
        }

        public override string PrintDetails()
        {
            var stringBuiilder = new StringBuilder();
            stringBuiilder.Append("[Family] - ");

            stringBuiilder.Append($"{base.PrintDetails()}");
            return stringBuiilder.ToString();
        }
    }
}
