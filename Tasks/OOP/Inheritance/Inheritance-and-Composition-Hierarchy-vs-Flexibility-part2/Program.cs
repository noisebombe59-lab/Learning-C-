namespace Inheritance_and_Composition_Hierarchy_vs_Flexibility_part2
{
    public class Program
    {
        static void Main()
        {
            try
            {
                ConsoleLogger logger = new ConsoleLogger("TestLogger1");

                SmartAlert smartAlert = new SmartAlert(logger);
                smartAlert.Notify("Системная ошибка");

                FileLogger fileLogger = new FileLogger("testFileLogger");

                SmartAlert smartAlert2 = new SmartAlert(fileLogger);
                smartAlert2.Notify("testFileLogger2");

                Console.ReadKey();

            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}