using System.Text;

namespace Polymorphism_Virtual_Methods_and_Overriding
{
    public sealed class TrialSubscription : Subscription
    {
        public TrialSubscription(string? ownerName, decimal monthlyPrice) : base(ownerName, monthlyPrice) { }

        public override decimal GetFinalPrice()
        {
            return 0;
        }

        public string ShowDaysLeft()
        {
            return "[Пробная] - [Осталось 7 дней. Итоговая цена: ";
        }
    }
}
