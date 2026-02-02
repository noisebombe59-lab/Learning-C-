namespace Inheritance_and_Composition_Hierarchy_vs_Flexibility
{
    public class Program
    {
        static void Main()
        {
            try
            {
                JsonLogger jsonLogger = new JsonLogger("testJsonLogger1");
                BankOperation transaction = new BankOperation(jsonLogger);

                transaction.Execute(500);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}