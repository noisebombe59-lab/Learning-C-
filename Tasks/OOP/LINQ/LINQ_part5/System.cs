namespace LINQ_part5
{
    public class MessageSendingSystem<T>
    {
        public void SendReport(ISendingReport<T> senderType, T reportData)
        {
            senderType.Send(reportData);
            Console.WriteLine($"Сообщение отправлено с: [{senderType.GetType().Name}]");
            Console.WriteLine(new string('-', 50));
        }
    }

    public class GameControlSystem
    {
        private readonly List<Bag> _bags = new();
        private readonly List<Item> _items = new();
        private readonly List<Mercenary> _mercenaries = new();

        public IReadOnlyList<Bag> Bags => _bags.AsReadOnly();
        public IReadOnlyList<Item> Items => _items.AsReadOnly();
        public IReadOnlyList<Mercenary> Mercenaries => _mercenaries.AsReadOnly();

        public void AddMercenaries(IEnumerable<Mercenary> mercenaries)
        {
            ArgumentNullException.ThrowIfNull(mercenaries);

            if (!mercenaries.Any())
            {
                throw new ArgumentException("Список наемников не может быть пустым", nameof(mercenaries));
            }
            _mercenaries.AddRange(mercenaries);
        }
        public void AddBags(IEnumerable<Bag> bags)
        {
            ArgumentNullException.ThrowIfNull(bags);

            if (!bags.Any())
            {
                throw new ArgumentException("Список сумок не может быть пустым", nameof(bags));
            }
            _bags.AddRange(bags);
        }

        public void AddItems(IEnumerable<Item> items)
        {
            ArgumentNullException.ThrowIfNull(items);

            if (!items.Any())
            {
                throw new ArgumentException("Список предметов не может быть пустым", nameof(items));
            }
            _items.AddRange(items);
        }

        public void AddItemsToBags(int ownerId, IEnumerable<Item> newItems)
        {
            var targetBag = _bags.FirstOrDefault(f => f.OwnerId == ownerId);

            if (targetBag == null)
            {
                Console.WriteLine($"Ошибка: У наемника с ID {ownerId} нет сумки!");
                return;
            }

            var incomingWeight = newItems.Sum(s => s.ItemWeight); 
            var currentWeight = targetBag.Items.Sum(s => s.ItemWeight);

            if (currentWeight + incomingWeight > targetBag.Weight)
            {
                Console.WriteLine("Перегруз по весу!");
                return;
            }

            targetBag.Items.AddRange(newItems);
        }
    }
}
