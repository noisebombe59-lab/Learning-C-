namespace Warehouse_CMS
{
    public record Product(string? Name, string? Category, decimal Price);

    public class Warehouse
    {
        private List<WarehouseItem> _items = new List<WarehouseItem>();
        private readonly int _maxCapacity = 100;

        public int MaxCapacity { get => _maxCapacity; }
        public int TotalItemCreated { get; set; }

        public Warehouse(int maxCapacity, int totalItemCreated = 0)
        {
            if (maxCapacity <= 0)
                throw new ArgumentException("Максимальное количество не может быть равно 0 или быть отрицательным", nameof(maxCapacity));

            if (totalItemCreated < 0)
                throw new ArgumentException("Кол-во товаров созданных за все время не может быть отрицательным", nameof(totalItemCreated));

            TotalItemCreated = totalItemCreated;
            _maxCapacity = maxCapacity;
        }

        public void AddItem(Product product, int quantity)
        {
            Validator.IsValidQuantity(quantity);

            var existingItem = FindDuplicateItem(product.Name, product.Category);

            if (existingItem != null)
            {
                if (existingItem.Quantity + quantity > _maxCapacity)
                    throw new ArgumentException($"Превышена вместимость склада! Доступно места: {_maxCapacity - existingItem.Quantity}", nameof(quantity));

                existingItem.UpdateQuantity(existingItem.Quantity + quantity);
            }
            else
            {
                if (quantity > _maxCapacity)
                    throw new ArgumentException($"Товар слишком велик для этого склада. Максимум: {_maxCapacity}", nameof(quantity));

                _items.Add(new WarehouseItem(product, quantity));
                TotalItemCreated++;
            }
        }

        public WarehouseItem? FindDuplicateItem(string? name, string? category)
        {
            foreach (var item in _items)
            {
                if (item.Product.Name == name && item.Product.Category == category)
                {
                    return item;
                }
            }
            return null;
        }

        public List<WarehouseItem> GetItems()
        {
            return _items.ToList();
        }
    }
}
