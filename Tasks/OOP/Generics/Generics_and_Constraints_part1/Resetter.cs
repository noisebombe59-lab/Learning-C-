namespace Generics_and_Constraints_part1
{
    public class Resetter<T>
    {
        private T _item;

        public Resetter(T item)
        {
            _item = item;
        }

        public void Reset()
        {
            _item = default;
        }

        public T GetCurrentValue()
        {
            return _item;
        }
    }
}
