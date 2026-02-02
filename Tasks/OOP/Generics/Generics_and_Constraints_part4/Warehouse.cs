namespace Generics_and_Constraints_part4
{
    public class Warehouse<T> where T : class, IComparable<T>, new()
    {
        private T _lastAddedItem;

        public Warehouse() { }

        public Warehouse(T lastAddedItem)
        {
            _lastAddedItem = lastAddedItem;
        }

        public void Add(T item)
        {
            _lastAddedItem = item;
        }

        public void CreateDefaultProduct()
        {
            T item = new T();
            Console.WriteLine($"Создан объект типа: {typeof(T).Name}");
            _lastAddedItem = item;
        }

        public T CompareItems(T firstItem, T secondItem)
        {
            if (firstItem.CompareTo(secondItem) > 0)
            {
                return firstItem;
            }
            return secondItem;
        }
    }
}
