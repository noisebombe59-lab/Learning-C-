namespace InterfaceArchitecture_AdvancedPatterns
{
    public class Company
    {
        private readonly IEnumerable<IEmployee> _employee;

        public IEnumerable<IEmployee> Employee { get => _employee; }

        public Company(IEnumerable<IEmployee> employee)
        {
            _employee = employee.ToList();
        }
    }
}
