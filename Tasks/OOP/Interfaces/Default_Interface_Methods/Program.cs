namespace Default_Interface_Methods
{
    public class Program
    {
        static void Main()
        {
            ConsoleLogger consoleLogger = new();
            consoleLogger.WriteMessage("Не работает");

            ((ILogger)consoleLogger).WriteError("Тут все работает");
            Console.ReadKey();
        }
    }
}