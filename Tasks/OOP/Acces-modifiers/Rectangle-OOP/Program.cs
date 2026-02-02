public class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Первый экземпляр (без параметров)");
            Rectangle rectangle1 = new Rectangle(1, 1);
            rectangle1.PrintInfo();
            Console.WriteLine();

            Console.WriteLine("Второй экземпляр (с параметрами)");
            Rectangle rectangle2 = new Rectangle (5, 22);
            rectangle2.PrintInfo();
            Console.WriteLine();

            Console.WriteLine("Третий экземпляр (исключение)");
            Rectangle rectangle3 = new Rectangle (1, -5);
            rectangle2.PrintInfo();

        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}