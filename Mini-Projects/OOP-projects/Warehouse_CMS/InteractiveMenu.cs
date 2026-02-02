namespace Warehouse_CMS
{
    public class InteractiveMenu
    {
        private const string Separator = "-----------------------------------------------";
        public void MainMenu()
        {
            Console.WriteLine(Separator);
            Console.WriteLine("===== Склад =====");
            Console.WriteLine(Separator);
            Console.WriteLine("Товары на складе:\n");
        }

        public void PrintInventory(List<WarehouseItem> items)
        {
            if (items == null) throw new ArgumentNullException("Нет данных о продукте со склада");

            var itemList = items.ToList();

            if (itemList.Count == 0)
            {
                Console.WriteLine("На складе нет товаров.");
                return;
            }

            foreach (var item in items)
            {
                Console.WriteLine($"Имя: {item.Product.Name}");
                Console.WriteLine($"Категория: {item.Product.Category}");
                Console.WriteLine($"Цена: {item.Product.Price}");
                Console.WriteLine($"Общее кол-во товара на складе: {item.Quantity}");
                Console.WriteLine(Separator);
            }
        }
    }
}

