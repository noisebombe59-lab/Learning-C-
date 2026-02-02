namespace Generics_and_Constraints_part3
{
    public class MathBox<T> where T : IComparable<T>
    {
        public T GetMax(T a, T b)
        {
            if (a.CompareTo(b) > 0)
            {
                return a;
            }
            return b;
        }

        public T GetMaxFromArray(T[] array)
        {
            T maxElement = default;

            if (array.Length == 0)
            {
                Console.WriteLine("Массив пуст");
                return default;
            }
            else
            {
                maxElement = array[0];
            }

            foreach (T element in array)
            {
                if (element.CompareTo(maxElement) > 0)
                {
                    maxElement = element;
                }
            }

            return maxElement;
        }
    }
}
