namespace Polymorphism_Virtual_Methods_and_Overriding
{
    public class Program
    {
        static void Main()
        {
            try
            {
                List<Subscription> subscriptions = new List<Subscription>();
                PremiumSubscription premiumSubscription = new PremiumSubscription(true, "Сергей", 1000);
                FamilySubscription familySubsription1 = new FamilySubscription(new int[4], "Антон", 800);
                //FamilySubsription familySubsription2 = new FamilySubsription(new int[7], "Илья", 800);
                Subscription standartSubscription = new Subscription("Виталий", 400);
                TrialSubscription trialSubscription = new TrialSubscription("Марк", 200);

                subscriptions.Add(premiumSubscription);
                subscriptions.Add(familySubsription1);
                //subscriptions.Add(familySubsription2);
                subscriptions.Add(trialSubscription);
                subscriptions.Add(standartSubscription);

                foreach (var sub in subscriptions)
                {
                    if (sub is TrialSubscription trialSub)
                    {
                        decimal priceForTrial = sub.GetFinalPrice();
                        string trial = trialSub.ShowDaysLeft();
                        Console.WriteLine($"{trial} {priceForTrial}]");
                        continue;
                    }
                    string details = sub.PrintDetails();
                    Console.WriteLine($"[Обычная] - {details}");
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}