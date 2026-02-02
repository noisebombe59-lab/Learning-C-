namespace Interfaces_Behavior_Contracts_and_Multiple_Implementations_part4
{
    public class Program
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>();
            Employee employee = new Employee();
            Employee employee1 = new Employee();

            IWorkable workable = new Employee();
            IRelaxable relaxable = new Employee();

            Office office = new Office(employees);

            employees.Add(employee);
            employees.Add(employee1);            

            workable.DoWork();
            relaxable.DoWork();
            ((IRelaxable)workable).DoWork();

            //office.Employees.Add(employee); - Ошибка, у свойства нет метода Add, CLear (мы не модем изменить его состояние).
            office.AddEmployee(employee);
        }
    }
}