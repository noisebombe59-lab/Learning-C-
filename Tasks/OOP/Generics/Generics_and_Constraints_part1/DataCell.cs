namespace Generics_and_Constraints_part1
{
    public class DataCell<T>
    {
        private T _value;

        public DataCell(T value)
        {
            _value = value;
        }

        public T GetValue()
        {
            return _value;
        }
    }
}
