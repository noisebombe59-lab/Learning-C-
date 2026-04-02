namespace LINQ_part1
{
    public class Program
    {
        static void Main()
        {
            try
            {
                const string separator = "--------------------------------------------------------------------------------";

                var calculationSum = new Calculations();
                var wareHouse = new Warehouse();

                var suply1 = new Goods("Electronics", "TV", 1000, 1);
                var suply2 = new Goods("Electronics", "Smartphone", 2000, 1);
                var suply3 = new Goods("Electronics", "Tablet", 3000, 2);
                var suply4 = new Goods("Electronics", "LapTop", 4000, 2);

                wareHouse.AddSuply(suply1);
                wareHouse.AddSuply(suply2);
                wareHouse.AddSuply(suply3);
                wareHouse.AddSuply(suply4);
               
                Console.WriteLine($"Все цены в категории 'Electronics':");
                wareHouse.PrintAllPrices();
                Console.WriteLine(separator);

                wareHouse.RemainingGoods();
                Console.WriteLine(separator);

                wareHouse.SortGoods();
                Console.WriteLine(separator);

                var sumResult = calculationSum.TotalSum(wareHouse.AllGoods);

                Console.WriteLine($"Общая сумма товаров в категории 'Electronics': ${sumResult}");
                Console.WriteLine(separator);

                Console.WriteLine("Поиск товара в категории Electronics цена которой > 2000");
                wareHouse.FindSuply();
                Console.WriteLine(separator);

                Console.WriteLine("Статус наличия товара на складе:");
                wareHouse.StockStatus();
                Console.WriteLine(separator);

                Console.WriteLine("Проверка ценовой политики в категории 'Electronics':");
                wareHouse.SearchCheapGoods();
                Console.WriteLine(separator);
            }
            catch (ArgumentOutOfRangeException ex)
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