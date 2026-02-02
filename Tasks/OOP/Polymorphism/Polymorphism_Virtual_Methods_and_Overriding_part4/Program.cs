namespace Polymorphism_Virtual_Methods_and_Overriding_part4
{
    public class Program
    {
        static void Main()
        {
            try
            {
                const string? separator = "--------------------------------------------------------";
                List<Employee> employees = new List<Employee>();

                Employee ordinaryEmployee = new Employee("Сергей - обычный сотрудник", 2000);
                Manager manager = new Manager(10, 50, "Иван - менеджер", 5000);
                Director director = new Director(20, 500, "Андрей - Директор", 10000);

                employees.Add(manager);
                employees.Add(director);
                employees.Add(ordinaryEmployee);

                foreach (var employee in employees)
                {
                    Console.WriteLine($"Имя: {employee.Name}, Бонус: {employee.CalculateBonus()}");
                    Console.WriteLine(separator);

                    if (employee is Manager tempManager && employee is not Director)
                    {
                        Console.WriteLine($"Количество подчененных менеджера: {tempManager.CurrentTeamSize}");
                        Console.WriteLine(separator);
                    }
                }
            }
            catch (ArgumentNullException ex)
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