namespace LINQ_part4
{
    public class ConfigurablePolicy : IInsurancePolicy
    {
        private readonly int _limit;
        public ConfigurablePolicy(int limit) => _limit = limit;
        public int GetLimit() => _limit;
    }
}
