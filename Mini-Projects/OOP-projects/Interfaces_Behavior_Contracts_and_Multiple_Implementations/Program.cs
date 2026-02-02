namespace Interfaces_Behavior_Contracts_and_Multiple_Implementations
{
    public class Program
    {
        static void Main()
        {
            try
            {
                UrgentTask urgentTask = new UrgentTask("Срочный отчет до 16:00", true);
                SimpleTask simpleTask = new SimpleTask("Изучить новые функции обновленного .Net", false);

                TaskManager manager = new TaskManager();

                manager.AddTask(urgentTask);
                manager.AddTask(simpleTask);

                manager.ProcessTask();
                manager.RunAll();


            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}