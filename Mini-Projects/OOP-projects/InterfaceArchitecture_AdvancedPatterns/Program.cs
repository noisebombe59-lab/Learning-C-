namespace InterfaceArchitecture_AdvancedPatterns
{
    public class Program
    {
        static void Main()
        {
            try
            {
                const string separator = "----------------------------------------------------------";

                List<IEmployee> employees = new List<IEmployee>();

                PayRollService payRollService = new PayRollService();

                var manager = new Manager(10000, "Сергей");
                var freelacer = new Freelancer(0, 20, 8, "Антон");

                employees.Add(manager);
                employees.Add(freelacer);

                Company company = new Company(employees);

                foreach (var employee in employees)
                {
                    if (employee is ILeader tempLeader)
                    {
                        if (freelacer is IWorker targetWorker)
                        {   
                            tempLeader.GiveTask(targetWorker, "Срочный багфикс");
                            Console.WriteLine(separator);
                        }
                    }
                    payRollService.ProcessSalary(employee);
                    Console.WriteLine(separator);
                }
                //manager.GiveTask(); - нельзя
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}