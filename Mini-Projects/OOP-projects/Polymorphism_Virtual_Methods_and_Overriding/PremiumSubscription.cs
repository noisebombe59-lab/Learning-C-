using System.Text;

namespace Polymorphism_Virtual_Methods_and_Overriding
{
    public class PremiumSubscription : Subscription
    {
        public bool Has4kSupport { get; protected set; }
        public PremiumSubscription(bool has4kSupport, string? ownerName, decimal monthlyPrice) : base(ownerName, monthlyPrice)
        {
            Has4kSupport = has4kSupport;
        }

        public override decimal GetFinalPrice()
        {
            decimal luxaryTax = base.GetFinalPrice() + MonthlyPrice * 0.15m;
            return luxaryTax;
        }

        public override string PrintDetails()
        {
            var stringBuiilder = new StringBuilder();
            stringBuiilder.Append("[Premium] - ");

            stringBuiilder.Append($"{base.PrintDetails()}, : 4K: Есть");
            return stringBuiilder.ToString();
        }
    }
}
