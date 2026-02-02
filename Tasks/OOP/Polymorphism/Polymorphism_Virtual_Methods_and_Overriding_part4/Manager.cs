namespace Polymorphism_Virtual_Methods_and_Overriding_part4
{
    public class Manager : Employee
    {
        public int TeamLimit { get; }
        public int CurrentTeamSize { get; }

        public Manager(int currentTeamSize, int teamLimit, string? name, int baseSalary) : base(name, baseSalary)
        {
            if (currentTeamSize > teamLimit)
                throw new ArgumentException("Превышен лимит по штату [Лимит по штату: 500]", nameof(teamLimit));

            if (currentTeamSize <= 0)
                throw new ArgumentException("Штат не может быть отрицательным или иметь 0 сотрудников", nameof(currentTeamSize));

            TeamLimit = teamLimit;
            CurrentTeamSize = currentTeamSize;
        }

        public override decimal CalculateBonus()
        {
            decimal employeeBonusSystem = base.CalculateBonus() + CurrentTeamSize * 1000;
            return employeeBonusSystem;
        }
    }
}
