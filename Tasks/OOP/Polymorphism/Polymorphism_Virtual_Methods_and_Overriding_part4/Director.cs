namespace Polymorphism_Virtual_Methods_and_Overriding_part4
{
    public sealed class Director : Manager
    {
        public Director(int currentTeamSize, int teamLimit, string? name, int baseSalary) : base(currentTeamSize, teamLimit, name, baseSalary) { }

        public override decimal CalculateBonus()
        {
            decimal directorBonusSystem = BaseSalary * 0.1m + 20000;
            return directorBonusSystem;
        }
    }
}
