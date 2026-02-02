namespace Generics_and_Constraints_part4
{
    public class Program
    {
        static void Main()
        {
            var wareHouse = new Warehouse<Product>();

            var apple = new Product("Apple", 100);
            var orange = new Product("Orange", 150);

            var compareResult = wareHouse.CompareItems(apple, orange);

            Console.WriteLine(compareResult);

            wareHouse.CreateDefaultProduct();
            Console.ReadKey();
        }
    }
}