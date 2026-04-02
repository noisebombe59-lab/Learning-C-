namespace LINQ_part1
{
    public class Warehouse
    {
        const string separator = "--------------------------------------------------------------------------------";

        private List<Goods> _allGoods = new();
        public IEnumerable<Goods> AllGoods => _allGoods.AsReadOnly();

        public void AddSuply(Goods good)
        {
            _allGoods.Add(good);
        }

        public void PrintAllPrices()
        {
            var filtrationResult = _allGoods
                .Where(p => p.Category == "Electronics" && p.Price > 500)
                .Select(p => $"{p.Name,-12} - \t(${p.Price})")
                .ToList();

            Console.WriteLine($"Результат фильтрации по условиям 1 задачи:");
            Console.WriteLine($"{String.Join("\n", filtrationResult)}");
        }

        public void RemainingGoods()
        {
            var remainingGoods = _allGoods
                .Where(p => p.Price > 1000 && p.Stock < 5 && p.Stock > 0)
                .Select(p => $"[КАТЕГОРИЯ]: [{p.Category,-12}] | [Название]: {p.Name,-15} | [Осталось всего]:{p.Stock,2}шт.")
                .ToList();

            Console.WriteLine($"Результат фильтрации по условиям 2 задачи:");
            Console.WriteLine(separator);
            Console.WriteLine($"{String.Join("\n", remainingGoods)}");
        }

        public void SortGoods()
        {
            var listSorting = _allGoods
                .Where(p => p.Stock < 5 && p.Stock > 0)
                .OrderBy(p => p.Stock)
                .Select(p => $"[КАТЕГОРИЯ]: [{p.Category,-12}] | [Название]: {p.Name,-15} | [Осталось всего]:{p.Stock,2}шт.")
                .ToList();

            Console.WriteLine("Результат сортировки 2 задачи:");
            Console.WriteLine(separator);

            if (listSorting.Any())
            {
                Console.WriteLine($"Отсортированный список товаров с маленьким остатком: \n{String.Join("\n", listSorting)}");
            }
            else
            {
                Console.WriteLine("Склад укомплектован, критических остатков не обнаружено");
                return;
            }
        }

        public void FindSuply()
        {
            var findedSuply = _allGoods
                .Where(p => p.Category == "Electronics" && p.Price > 2000)
                .FirstOrDefault();

            if (findedSuply == null)
            {
                Console.WriteLine("«Подходящих товаров для баннера не найдено».");
                return;
            }
            else
            {
                Console.WriteLine($"«На баннер выбран товар: [{findedSuply.Name}] — Цена: [${findedSuply.Price}]»");
            }
        }

        public void StockStatus()
        {
            var stockStatus = _allGoods
                .Any(p => p.Stock == 0);

            if (!stockStatus)
            {
                Console.WriteLine("Склад укомплектован");
            }
            else
            {
                Console.WriteLine($"На складе есть позиция с остатком 0, трубуется закупка");
            }
        }

        public void SearchCheapGoods()
        {
            var searchCheapGoods = _allGoods
                .Where(p => p.Category == "Electronics")
                .All(p => p.Price > 100);

            if (searchCheapGoods)
            {
                Console.WriteLine("Товары в категории Electronics соответствуют ценовой политике");
            }
            else
            {
                Console.WriteLine("Нарушение, в категории Electronics все товары должны быть дороже 100$");
            }
        }
    }
}