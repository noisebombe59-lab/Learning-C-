namespace Generics_and_Constraints_part3
{
    public class DataRepository<T> where T : class, new()
    {
        private T _storedData;

        public DataRepository(T storedData)
        {
            _storedData = storedData;
        }

        public void CreateDefault()
        {
            _storedData = new T();
        }

        public void Print()
        {
            Console.WriteLine($"{typeof(T).Name}, {_storedData}");
        }
    }
}
