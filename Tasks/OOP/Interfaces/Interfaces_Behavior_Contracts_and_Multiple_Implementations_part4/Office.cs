namespace Interfaces_Behavior_Contracts_and_Multiple_Implementations_part4
{
    public class Office
    {
        private readonly List<Employee> _employees = new();

        public IReadOnlyList<Employee> Employees { get => _employees; }

        public Office(List<Employee> employee)
        {
            _employees.AddRange(employee);
        }

        public void AddEmployee(Employee employee)
        {   
            _employees.Add(employee);
        }
    }
}
