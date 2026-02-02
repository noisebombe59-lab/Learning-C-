namespace Warehouse_CMS
{
    public class Program
    {
        static void Main(string[] args)
        {
            Warehouse warehouse = new Warehouse(100);

            while (true)
            {
                try
                {
                    Product product = CollectDataFromUser();

                    Console.Write("Введите количество товара: ");
                    var quantity = 0;

                    while (true)
                    {
                        if (!int.TryParse(Console.ReadLine(), out quantity))
                        {
                            Console.WriteLine("Количество товара должно быть целым числом!");
                            continue;
                        }
                        break;
                    }

                    warehouse.AddItem(product, quantity);

                    InteractiveMenu menu = new InteractiveMenu();
                    menu.MainMenu();

                    var currentItems = warehouse.GetItems();
                    menu.PrintInventory(currentItems);
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
                break;
            }
        }

        public static Product CollectDataFromUser()
        {
            while (true)
            {
                Console.Write("Введите название товара: ");
                var name = Console.ReadLine();
                Validator.IsValidName(name);

                Console.Write("Введите категорию товара: ");
                var category = Console.ReadLine();
                Validator.IsValidCategory(category);

                Console.Write("Введите цену товара: ");
                var testPrice = Console.ReadLine();

                if (!Decimal.TryParse(testPrice, out decimal price))
                {
                    Console.WriteLine("Цена должна быть числом!");
                    continue;
                }
                Validator.IsValidPrice(price);

                return new Product(name, category, price);
            }
        }
    }
}