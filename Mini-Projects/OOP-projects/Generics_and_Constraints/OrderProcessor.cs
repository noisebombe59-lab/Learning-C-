namespace Generics_and_Constraints
{
    public class OrderProcessor<T> where T : BaseOrder, new()
    {
        private List<T> _orders = new List<T>();
        private Random _random = new Random();

        public OrderProcessor() { }

        public void AddOrder(T order)
        {
            _orders.Add(order);
        }

        public void CreateDefault()
        {
            T defaultOrder = new T();
            defaultOrder.ID = _random.Next(1, 999);

            _orders.Add(defaultOrder);
            Console.WriteLine($"Заказ по умолчанию {defaultOrder}");
        }

        public T? GetMostExpensive()
        {
            if (_orders.Count == 0)
                return default;

            T mostExpensiveOrder = _orders[0];

            foreach (T order in _orders)
            {
                if (order.CompareTo(mostExpensiveOrder) > 0)
                {
                    mostExpensiveOrder = order;
                }
            }
            return mostExpensiveOrder;
        }

        public void PrintAll()
        {
            int orderNumber = 0;

            Console.WriteLine($"Список заказов:");

            foreach (var order in _orders)
            {
                Console.WriteLine($"Заказ номер {orderNumber + 1} - {order}");
                orderNumber++;
            }
        }
    }
}
