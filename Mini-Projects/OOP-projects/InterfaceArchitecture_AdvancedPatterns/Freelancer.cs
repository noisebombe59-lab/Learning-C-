namespace InterfaceArchitecture_AdvancedPatterns
{
    public class Freelancer : IEmployee, IWorker
    {
        public string Name { get; init; }
        public decimal FreelacerSalary { get; private set; }
        public decimal SalaryPerHour { get; private set; }
        public decimal WorkingHours { get; private set; }

        public Freelancer(decimal freelancerSalary, decimal salaryPerHour, decimal workingHours, string name)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(freelancerSalary);
            ArgumentOutOfRangeException.ThrowIfNegative(salaryPerHour);
            ArgumentOutOfRangeException.ThrowIfNegative(workingHours);

            Name = name;
            WorkingHours = workingHours;
            SalaryPerHour = salaryPerHour;
            FreelacerSalary = freelancerSalary;
        }

        public void CalculateSalary()
        {
            FreelacerSalary = WorkingHours * SalaryPerHour;
            Console.WriteLine($"Зарплата менеджера {Name}: {FreelacerSalary}");
        }

        public void TakeTask(string taskName)
        {
            Console.WriteLine($"[Фриалсер] {Name}: Задача '{taskName}' взята в работу!");
        }
    }
}
