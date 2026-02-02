namespace Generics_and_Constraints_part2
{
    public class Pair<TKey, TValue>
    {
        private TKey _key;
        private TValue _value;

        public Pair(TKey key, TValue value)
        {
            _key = key;
            _value = value;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Тип ключа: {typeof(TKey).Name}, Значение[ключ]: {_key}, Значение[значение ключа]: {_value}");
        }
    }
}
