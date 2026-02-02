namespace access_modifiers_static_records_Part4
{
    public class Program
    {
        static void Main(string[] args)
        {
            string? separator = "-------------------------------------";
            List<Smartphone> smartphones = new List<Smartphone>
            {
             new Smartphone(Model: "Iphone 14"),
             new Smartphone(Model: "Iphone 15"),
             new Smartphone(Model: "Iphone 16"),
             new Smartphone(Model: "Iphone 17")

            };

            foreach (var phone in smartphones)
            {
                Console.WriteLine(ServiceCenter.Repair(phone));
                Console.WriteLine(separator);
            }

            Console.WriteLine($"Остаток запчастей на складе: {ServiceCenter.PartsStock}");
        }
    }
}