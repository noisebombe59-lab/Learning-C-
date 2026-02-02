namespace Generics_and_Constraints
{
    public class Program
    {
        static void Main()
        {
            const string separator = "---------------------------------------------------------------------------";

            var orderProcessor = new OrderProcessor<ElectronicsOrder>();
            var defaultOrder = new OrderProcessor<ElectronicsOrder>();

            var smartphone1 = new ElectronicsOrder { ID = 1, Name = "Huawei", Price = 1000 };
            var smartphone2 = new ElectronicsOrder { ID = 2, Name = "Samsung", Price = 2500 };
            var smartphone3 = new ElectronicsOrder { ID = 3, Name = "Iphone 11", Price = 3500 };
            var smartphone4 = new ElectronicsOrder { ID = 4, Name = "Iphone 12", Price = 4500 };
            var smartphone5 = new ElectronicsOrder { ID = 5, Name = "Iphone 13", Price = 5500 };

            orderProcessor.AddOrder(smartphone1);
            orderProcessor.AddOrder(smartphone2);
            orderProcessor.AddOrder(smartphone3);
            orderProcessor.AddOrder(smartphone4);
            orderProcessor.AddOrder(smartphone5);

            orderProcessor.PrintAll();
            Console.WriteLine(separator);

            var compareResult = orderProcessor.GetMostExpensive();

            if (compareResult != null)
            {
                Console.WriteLine($"Самый дорогой заказ: \n{compareResult}");
                Console.WriteLine(separator);
            }
            else
            {
                Console.WriteLine("Заказов нет, сравнивать нечего.");
            }

            defaultOrder.CreateDefault();
            Console.WriteLine(separator);
            Console.ReadKey();
        }
    }
}