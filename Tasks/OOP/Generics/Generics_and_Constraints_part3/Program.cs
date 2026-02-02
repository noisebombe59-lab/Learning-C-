namespace Generics_and_Constraints_part3
{
    public class Program
    {
        static void Main()
        {
            const string separator = "-----------------------------------";

            int[] numbers = { 1, 2, 3, 4, 5 };

            var mathBox1 = new MathBox<int>();
            var mathBox2 = new MathBox<string>();
            var mathBox3 = new MathBox<int>();
            //var dataRepository1 = new DataRepository<int>(12);
            var dataRepository2 = new DataRepository<User>(new User());

            var result1 = mathBox1.GetMax(10, 42);
            var result2 = mathBox2.GetMax("Яблоко", "Апельсин");
            var result3 = mathBox3.GetMaxFromArray(numbers);

            dataRepository2.CreateDefault();

            dataRepository2.Print();
            Console.WriteLine(separator);

            Console.WriteLine(result1);
            Console.WriteLine(separator);

            Console.WriteLine(result2);
            Console.WriteLine(separator);

            Console.WriteLine(result3);
            Console.WriteLine(separator);
            Console.ReadKey();
        }
    }
}