namespace Generics_and_Constraints_part1
{
    public class EntityFactory<T> where T : class, new()
    {
        public T CreateNew()
        {
            return new T();
        }
    }
}
