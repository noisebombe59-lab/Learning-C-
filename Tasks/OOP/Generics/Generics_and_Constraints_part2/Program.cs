namespace Generics_and_Constraints_part2
{
    public class Program
    {
        static void Main()
        {
            var pair1 = new Pair<int, string>(10, "негретят");
            var pair2 = new Pair<int, User>(10, new User());

            pair1.PrintInfo();
            pair2.PrintInfo();
            Console.ReadKey();
        }
    }
}