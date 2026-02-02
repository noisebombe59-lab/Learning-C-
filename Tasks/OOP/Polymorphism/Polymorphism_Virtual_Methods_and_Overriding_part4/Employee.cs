namespace Polymorphism_Virtual_Methods_and_Overriding_part4
{
    public class Employee
    {
        public string? Name { get; }
        public decimal BaseSalary { get; }

        public Employee(string? name, decimal baseSalary)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Имя обязательно", nameof(name));

            if (baseSalary <= 0)
                throw new ArgumentException("Зарплата не может быть отрицательной или равно 0", nameof(baseSalary));

            Name = name;
            BaseSalary = baseSalary;
        }

        public virtual decimal CalculateBonus()
        {
            decimal standartBonusForAll = BaseSalary * 0.05m;
            return standartBonusForAll;
        }
    }
}
