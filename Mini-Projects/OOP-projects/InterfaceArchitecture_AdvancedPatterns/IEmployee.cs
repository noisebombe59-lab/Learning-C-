namespace InterfaceArchitecture_AdvancedPatterns
{
    public interface IEmployee
    {
        public string Name { get; }

        void CalculateSalary();

        void GetInfo() => Console.WriteLine($"Сотрудник: {Name}");
    }
}
